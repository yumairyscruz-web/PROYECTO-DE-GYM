using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
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
            // Configuramos las columnas del DataGridView para el detalle de la venta
            ConfigurarGrillaDetalle();

            // Bloqueamos los TextBox de totales para que solo muestren el cálculo automático
            txtSubtotal.ReadOnly = true;
            txtImpuesto.ReadOnly = true;
            txtTotal.ReadOnly = true;
        }

        private void ConfigurarGrillaDetalle()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Producto", "Producto / Concepto");
            dataGridView1.Columns.Add("Precio", "Precio Unitario");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns.Add("Subtotal", "Subtotal");
        }

        // 1. Botón para agregar producto al carrito (DataGridView)
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            // Validamos que se haya seleccionado un producto y escrito precio y cantidad
            if (cmbProductos.SelectedItem != null &&
                decimal.TryParse(textBox1.Text, out decimal precio) &&
                int.TryParse(textBox2.Text, out int cantidad))
            {
                string producto = cmbProductos.Text;
                decimal subtotalFila = precio * cantidad;

                // Agregamos la fila a la tabla
                dataGridView1.Rows.Add(producto, precio.ToString("N2"), cantidad, subtotalFila.ToString("N2"));

                // Recalculamos los totales generales
                CalcularTotalesGenerales();

                // Limpiamos los campos de producto para el siguiente ingreso
                textBox1.Clear();
                textBox2.Clear();
                cmbProductos.Focus();
            }
            else
            {
                MessageBox.Show("Por favor, verifique el producto, precio y cantidad ingresados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método auxiliar para calcular Subtotal, Impuesto (ITBIS) y Total General
        private void CalcularTotalesGenerales()
        {
            decimal sumaSubtotal = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    sumaSubtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            // Descuento manual ingresado en el TextBox
            decimal.TryParse(txtDescuento.Text, out decimal descuento);

            // Ejemplo de cálculo de Impuesto / ITBIS (18%)
            decimal impuesto = (sumaSubtotal - descuento) * 0.18m;
            decimal totalGeneral = (sumaSubtotal - descuento) + impuesto;

            // Mostramos los valores en los TextBox correspondientes
            txtSubtotal.Text = sumaSubtotal.ToString("N2");
            txtImpuesto.Text = impuesto.ToString("N2");
            txtTotal.Text = totalGeneral.ToString("N2");
        }

        // 2. Botón para completar/procesar la venta final
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

            try
            {
                // AQUÍ IRÍA TU LÓGICA DE BASE DE DATOS:
                // 1. Guardar la cabecera en la tabla 'ventas'[cite: 1] (usando cmbClientes, cmbTipoPago, dtpFecha, txtTotal, etc.) y obtener el ID generado.
                // 2. Recorrer con un foreach 'dataGridView1.Rows' para guardar cada línea en la tabla 'venta_detalle'[cite: 1] usando ese ID de venta.

                // Mensaje emergente de éxito requerido por el proyecto[cite: 1]
                MessageBox.Show("¡Venta completada y registrada exitosamente!", "Comprobante de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar formulario para una nueva venta
                dataGridView1.Rows.Clear();
                txtSubtotal.Clear();
                txtDescuento.Clear();
                txtImpuesto.Clear();
                txtTotal.Clear();
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}