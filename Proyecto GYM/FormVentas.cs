using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaDetalle();

            txtSubtotal.ReadOnly = true;
            txtImpuesto.ReadOnly = true;
            txtTotal.ReadOnly = true;

            // Cargamos todos los combos al iniciar
            CargarClientesComboBox();
            CargarProductosComboBox();
            CargarTipoPagoComboBox();
        }

        private void ConfigurarGrillaDetalle()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Producto", "Producto / Concepto");
            dataGridView1.Columns.Add("Precio", "Precio Unitario");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Subtotal", "Subtotal");
        }

        private void CargarClientesComboBox()
        {
            string query = "SELECT id_cliente, CONCAT(nombre, ' ', apellido) AS NombreCompleto FROM Clientes WHERE estado = 1";

            using (var con = Conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        var da = new SqlDataAdapter(cmd);
                        var dt = new DataTable();
                        da.Fill(dt);

                        cmbClientes.DataSource = dt;
                        cmbClientes.DisplayMember = "NombreCompleto";
                        cmbClientes.ValueMember = "id_cliente";
                        cmbClientes.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CargarProductosComboBox()
        {
            string query = "SELECT id_producto, nombre, precio_venta FROM productos WHERE estado = 1";

            using (var con = Conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        var da = new SqlDataAdapter(cmd);
                        var dt = new DataTable();
                        da.Fill(dt);

                        cmbProductos.DataSource = dt;
                        cmbProductos.DisplayMember = "nombre";
                        cmbProductos.ValueMember = "id_producto";
                        cmbProductos.SelectedIndex = -1;

                        textBox1.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CargarTipoPagoComboBox()
        {
            string query = "SELECT id_metodo, nombre_metodo FROM metodos_pago WHERE estado = 1";

            using (var con = Conexion.ObtenerConexion())
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        var da = new SqlDataAdapter(cmd);
                        var dt = new DataTable();
                        da.Fill(dt);

                        cmbTipoPago.DataSource = dt;
                        cmbTipoPago.DisplayMember = "nombre_metodo";
                        cmbTipoPago.ValueMember = "id_metodo";
                        cmbTipoPago.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los tipos de pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================================
        // AUTOCOMPLETAR PRECIO AL SELECCIONAR UN PRODUCTO
        // ==========================================================
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem != null && cmbProductos.SelectedIndex != -1)
            {
                DataRowView row = cmbProductos.SelectedItem as DataRowView;
                if (row != null && row.Row.Table.Columns.Contains("precio_venta"))
                {
                    textBox1.Text = Convert.ToDecimal(row["precio_venta"]).ToString("N2");
                }
            }
        }

        // ==========================================================
        // CÁLCULO DE TOTALES EN TIEMPO REAL
        // ==========================================================
        private void CalcularTotalesEnTiempoReal()
        {
            decimal sumaSubtotalTabla = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    sumaSubtotalTabla += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            decimal precioActual = 0;
            decimal cantidadActual = 0;
            decimal subtotalActual = 0;

            if (decimal.TryParse(textBox1.Text, out precioActual) && decimal.TryParse(textBox2.Text, out cantidadActual))
            {
                subtotalActual = precioActual * cantidadActual;
            }

            decimal subtotalGeneral = sumaSubtotalTabla + subtotalActual;

            decimal.TryParse(txtDescuento.Text, out decimal descuento);

            decimal baseImponible = subtotalGeneral - descuento;
            if (baseImponible < 0) baseImponible = 0;

            decimal impuesto = baseImponible * 0.18m;
            decimal totalGeneral = baseImponible + impuesto;

            txtSubtotal.Text = subtotalGeneral.ToString("N2");
            txtImpuesto.Text = impuesto.ToString("N2");
            txtTotal.Text = totalGeneral.ToString("N2");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalesEnTiempoReal();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalesEnTiempoReal();
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalesEnTiempoReal();
        }

        // ==========================================================
        // BOTÓN AGREGAR (Con validación obligatoria de Tipo de Pago)
        // ==========================================================
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            // 1. Validar que el tipo de pago esté seleccionado obligatoriamente
            if (cmbTipoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un tipo de pago (Efectivo, Tarjeta, etc.) antes de agregar el producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoPago.Focus();
                return;
            }

            if (cmbProductos.SelectedItem != null &&
                decimal.TryParse(textBox1.Text, out decimal precio) &&
                int.TryParse(textBox2.Text, out int cantidad))
            {
                string producto = cmbProductos.Text;
                decimal subtotalFila = precio * cantidad;

                dataGridView1.Rows.Add(producto, precio.ToString("N2"), cantidad, subtotalFila.ToString("N2"));

                CalcularTotalesEnTiempoReal();

                textBox1.Clear();
                textBox2.Clear();
                cmbProductos.SelectedIndex = -1;
                cmbProductos.Focus();
            }
            else
            {
                MessageBox.Show("Por favor, verifique el producto, precio y cantidad ingresados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==========================================================
        // RECUPERAR DATOS AL HACER CLIC EN LA TABLA
        // ==========================================================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["Producto"].Value != null)
                    cmbProductos.Text = row.Cells["Producto"].Value.ToString();

                if (row.Cells["Precio"].Value != null)
                    textBox1.Text = row.Cells["Precio"].Value.ToString();

                if (row.Cells["Cantidad"].Value != null)
                    textBox2.Text = row.Cells["Cantidad"].Value.ToString();
            }
        }


        private void btnCompletarVenta_Click(object sender, EventArgs e)
        {
            // 1. Validaciones previas
            if (cmbClientes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para procesar la venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTipoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de pago válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Proceso de guardado en la Base de Datos con Transacción
            using (var con = Conexion.ObtenerConexion())
            {
                // Abrimos la conexión manualmente para manejar la transacción
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        // A. Insertar la Cabecera de la Venta adaptada a la tabla 'ventas'
                        string queryVenta = @"INSERT INTO ventas (id_cliente, id_usuario, tipo_pago, fecha, subtotal, descuento, impuesto, total, estado) 
                                      OUTPUT INSERTED.id_venta 
                                      VALUES (@id_cliente, @id_usuario, @tipo_pago, @fecha, @subtotal, @descuento, @impuesto, @total, 1)";

                        int idVentaGenerada = 0;

                        using (var cmdVenta = new SqlCommand(queryVenta, con, transaction))
                        {
                            cmdVenta.Parameters.AddWithValue("@id_cliente", cmbClientes.SelectedValue);
                            cmdVenta.Parameters.AddWithValue("@id_usuario", 1); // Ajusta aquí el ID del usuario actual si lo manejas por sesión
                            cmdVenta.Parameters.AddWithValue("@tipo_pago", cmbTipoPago.Text); // Guarda el texto del método (Ej. 'Efectivo')[cite: 1]
                            cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmdVenta.Parameters.AddWithValue("@subtotal", Convert.ToDecimal(txtSubtotal.Text));
                            cmdVenta.Parameters.AddWithValue("@descuento", string.IsNullOrEmpty(txtDescuento.Text) ? 0 : Convert.ToDecimal(txtDescuento.Text));
                            cmdVenta.Parameters.AddWithValue("@impuesto", Convert.ToDecimal(txtImpuesto.Text));
                            cmdVenta.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));

                            // Obtenemos el ID de la venta que se acaba de crear
                            idVentaGenerada = (int)cmdVenta.ExecuteScalar();
                        }

                        // B. Recorrer el DataGridView para insertar cada producto en 'venta_detalle'
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // Evitamos procesar la fila vacía de nueva creación del grid
                            if (row.IsNewRow) continue;

                            // Validar que la celda del producto no sea nula
                            if (row.Cells["Producto"].Value == null) continue;

                            string nombreProducto = row.Cells["Producto"].Value.ToString();

                            // Buscamos el ID del producto basado en su nombre
                            int idProducto = ObtenerIdProductoPorNombre(nombreProducto, con, transaction);

                            if (idProducto == 0)
                            {
                                throw new Exception("No se pudo encontrar el ID en la base de datos para el producto: " + nombreProducto);
                            }

                            decimal precioUnitario = Convert.ToDecimal(row.Cells["Precio"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                            // Omitimos 'subtotal' porque la base de datos lo calcula de forma automática[cite: 1]
                            string queryDetalle = @"INSERT INTO venta_detalle (id_venta, id_producto, cantidad, precio, descuento) 
                                          VALUES (@id_venta, @id_producto, @cantidad, @precio, @descuento)";

                            using (var cmdDetalle = new SqlCommand(queryDetalle, con, transaction))
                            {
                                cmdDetalle.Parameters.AddWithValue("@id_venta", idVentaGenerada);
                                cmdDetalle.Parameters.AddWithValue("@id_producto", idProducto);
                                cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precio", precioUnitario);
                                cmdDetalle.Parameters.AddWithValue("@descuento", 0); // Ajusta si manejas descuento por línea

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // Si todo salió bien, confirmamos los cambios permanentes en la base de datos
                        transaction.Commit();

                        MessageBox.Show("¡Venta completada y registrada exitosamente en la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiamos la pantalla para una nueva venta
                        dataGridView1.Rows.Clear();
                        txtSubtotal.Clear();
                        txtDescuento.Clear();
                        txtImpuesto.Clear();
                        txtTotal.Clear();
                        textBox1.Clear();
                        textBox2.Clear();
                        cmbClientes.SelectedIndex = -1;
                        cmbTipoPago.SelectedIndex = -1;
                        cmbProductos.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        // Si algo falla, revertimos cualquier cambio hecho
                        transaction.Rollback();
                        MessageBox.Show("Error al guardar la venta en la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Método auxiliar rápido para obtener el ID numérico del producto a partir de su nombre mostrado en la tabla
        private int ObtenerIdProductoPorNombre(string nombreProducto, SqlConnection con, SqlTransaction transaction)
        {
            string query = "SELECT id_producto FROM productos WHERE nombre = @nombre";
            using (var cmd = new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                object resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
        }
    }
}