using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarProductos();

            // Configuramos las columnas del DataGridView si no se hicieron desde el diseñador
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Producto", "Producto / Concepto");
                dataGridView1.Columns.Add("Precio", "Precio Compra");
                dataGridView1.Columns.Add("Cantidad", "Cantidad");
                dataGridView1.Columns.Add("Subtotal", "Subtotal");
            }

            // Protegemos los campos automáticos para que no se escriba en ellos manualmente
            txtPrecio.ReadOnly = true;
            txtTotalCompra.ReadOnly = true;

            // Generamos un Número de Factura automático para ahorrar tiempo
            GenerarNumeroFacturaAutomatico();
        }

        private void GenerarNumeroFacturaAutomatico()
        {
            txtNumeroFactura.Text = "FAC-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            txtNumeroFactura.ReadOnly = true;
        }

        private void CargarProveedores()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_proveedor, nombre_empresa FROM proveedores";
                using (var da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbProveedores.DataSource = dt;
                    cmbProveedores.DisplayMember = "nombre_empresa";
                    cmbProveedores.ValueMember = "id_proveedor";
                    cmbProveedores.SelectedIndex = -1;
                }
            }
        }

        private void CargarProductos()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_producto, nombre, precio_compra FROM productos";
                using (var da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbProductos.DataSource = dt;
                    cmbProductos.DisplayMember = "nombre";
                    cmbProductos.ValueMember = "id_producto";
                    cmbProductos.SelectedIndex = -1;
                }
            }
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem is DataRowView row)
            {
                txtPrecio.Text = row["precio_compra"].ToString();
            }
            else
            {
                txtPrecio.Clear();
            }
            CalcularVistaPreviaSubtotal();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularVistaPreviaSubtotal();
        }

        private void CalcularVistaPreviaSubtotal()
        {
            if (decimal.TryParse(txtPrecio.Text, out decimal precio) && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                if (dataGridView1.Rows.Count <= 1)
                {
                    decimal subtotalTemporal = precio * cantidad;
                    txtTotalCompra.Text = subtotalTemporal.ToString("N2");
                }
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio de compra válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreProducto = cmbProductos.Text;
            decimal subtotal = precio * cantidad;

            dataGridView1.Rows.Add(nombreProducto, precio.ToString("N2"), cantidad, subtotal.ToString("N2"));

            CalcularTotalCompra();

            cmbProductos.SelectedIndex = -1;
            txtPrecio.Clear();
            txtCantidad.Clear();
        }

        private void CalcularTotalCompra()
        {
            decimal totalGeneral = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["Subtotal"].Value != null && decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal sub))
                {
                    totalGeneral += sub;
                }
            }
            txtTotalCompra.Text = totalGeneral.ToString("N2");
        }

        private void btnCompletarCompra_Click(object sender, EventArgs e)
        {
            if (cmbProveedores.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.Rows.Count == 0 || (dataGridView1.Rows.Count == 1 && dataGridView1.Rows[0].IsNewRow))
            {
                MessageBox.Show("El carrito de compras está vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var con = Conexion.ObtenerConexion())
            {
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar la cabecera usando la tabla real 'compras' (campos: id_proveedor, id_usuario, fecha, total)
                        // Nota: Si aún no manejas sesiones de usuario, pasamos un id_usuario fijo por defecto (ej. 1)
                        string queryCompra = @"INSERT INTO compras (id_proveedor, id_usuario, fecha, total) 
                                               OUTPUT INSERTED.id_compra 
                                               VALUES (@id_proveedor, @id_usuario, @fecha, @total)";

                        int idCompraGenerada = 0;

                        using (var cmdCompra = new SqlCommand(queryCompra, con, transaction))
                        {
                            cmdCompra.Parameters.AddWithValue("@id_proveedor", cmbProveedores.SelectedValue);
                            cmdCompra.Parameters.AddWithValue("@id_usuario", 1); // Cambia esto si tienes un sistema de login activo
                            cmdCompra.Parameters.AddWithValue("@fecha", dtpFechaCompra.Value);
                            cmdCompra.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotalCompra.Text));

                            idCompraGenerada = (int)cmdCompra.ExecuteScalar();
                        }

                        // 2. Recorrer el grid para insertar los detalles y actualizar el stock
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string nombreProducto = row.Cells["Producto"].Value.ToString();
                            decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);

                            int idProducto = ObtenerIdProductoPorNombre(nombreProducto, con, transaction);

                            // Insertar detalle utilizando la tabla real 'compra_detalle'
                            // Insertar detalle utilizando la tabla real 'compra_detalle' (sin incluir 'subtotal')
                            string queryDetalle = @"INSERT INTO compra_detalle (id_compra, id_producto, cantidad, precio_compra) 
                        VALUES (@id_compra, @id_producto, @cantidad, @precio_compra)";

                            using (var cmdDetalle = new SqlCommand(queryDetalle, con, transaction))
                            {
                                cmdDetalle.Parameters.AddWithValue("@id_compra", idCompraGenerada);
                                cmdDetalle.Parameters.AddWithValue("@id_producto", idProducto);
                                cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdDetalle.Parameters.AddWithValue("@precio_compra", precio);
                                // Ya no enviamos @subtotal porque la base de datos lo calcula automáticamente

                                cmdDetalle.ExecuteNonQuery();
                            }

                            // Actualizar el stock del producto
                            string queryStock = "UPDATE productos SET stock = stock + @cantidad WHERE id_producto = @id_producto";
                            using (var cmdStock = new SqlCommand(queryStock, con, transaction))
                            {
                                cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdStock.Parameters.AddWithValue("@id_producto", idProducto);

                                cmdStock.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        MessageBox.Show("¡Compra registrada exitosamente y stock actualizado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView1.Rows.Clear();
                        txtTotalCompra.Clear();
                        txtPrecio.Clear();
                        cmbProveedores.SelectedIndex = -1;
                        GenerarNumeroFacturaAutomatico();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al registrar la compra: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

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