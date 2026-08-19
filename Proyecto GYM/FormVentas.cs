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

        // ==========================================================
        // BOTÓN COMPLETAR (Ya no borra la tabla automáticamente)
        // ==========================================================
        private void btnCompletarVenta_Click(object sender, EventArgs e)
        {
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

            try
            {
                // Aquí va tu código para guardar en la base de datos (INSERT a la tabla ventas y detalle_ventas)

                MessageBox.Show("¡Venta completada y registrada exitosamente!", "Comprobante de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ⚠️ IMPORTANTE: NO pongas dataGridView1.Rows.Clear(); aquí si quieres que los datos se queden en la tabla.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}