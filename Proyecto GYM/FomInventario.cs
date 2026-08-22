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
    public partial class FomInventario : Form
    {
        public FomInventario()
        {
            InitializeComponent();
        }

        private void FomInventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarTiposMovimiento();
            CargarHistorialInventario();
            txtStock.ReadOnly = true; // Para que el stock no se pueda editar manualmente
        }

        private void CargarProductos()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                // Asumimos que tu tabla se llama 'productos' con 'id_producto' y 'nombre'
                string query = "SELECT id_producto, nombre FROM productos";
                using (var cmd = new SqlCommand(query, con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbProducto.DataSource = dt;
                        cmbProducto.DisplayMember = "nombre";
                        cmbProducto.ValueMember = "id_producto";
                        cmbProducto.SelectedIndex = -1;
                    }
                }
            }
        }

        private void CargarTiposMovimiento()
        {
            cmbMovimiento.Items.Clear();
            cmbMovimiento.Items.Add("Entrada");
            cmbMovimiento.Items.Add("Salida");
            cmbMovimiento.SelectedIndex = -1;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue != null && int.TryParse(cmbProducto.SelectedValue.ToString(), out int idProducto))
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    string query = "SELECT stock FROM productos WHERE id_producto = @id";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idProducto);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtStock.Text = result.ToString();
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMovimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de movimiento (Entrada o Salida).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMover.Text) || !int.TryParse(txtMover.Text, out int cantidadMover) || cantidadMover <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = (int)cmbProducto.SelectedValue;
            string tipoMovimiento = cmbMovimiento.SelectedItem.ToString();
            int stockActual = int.Parse(txtStock.Text);
            string observacion = txtObsevacion.Text.Trim();

            // Validar que si es salida, no intentemos sacar más de lo que hay
            if (tipoMovimiento == "Salida" && cantidadMover > stockActual)
            {
                MessageBox.Show("No hay suficiente stock disponible para realizar esta salida.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcular el nuevo stock
            int nuevoStock = tipoMovimiento == "Entrada" ? stockActual + cantidadMover : stockActual - cantidadMover;

            using (var con = Conexion.ObtenerConexion())
            {
                // 1. Actualizar el stock en la tabla productos
                string queryUpdate = "UPDATE productos SET stock = @nuevoStock WHERE id_producto = @idProducto";
                using (var cmdUpdate = new SqlCommand(queryUpdate, con))
                {
                    cmdUpdate.Parameters.AddWithValue("@nuevoStock", nuevoStock);
                    cmdUpdate.Parameters.AddWithValue("@idProducto", idProducto);
                    cmdUpdate.ExecuteNonQuery();
                }

                // 2. Registrar el movimiento en una tabla de historial (opcional si la tienes creada)
                // Asegúrate de tener o ajustar la tabla de movimientos si la usas
                /*
                string queryMov = "INSERT INTO inventario_movimientos (id_producto, tipo, cantidad, fecha, observacion) VALUES (@idProducto, @tipo, @cantidad, GETDATE(), @obs)";
                using (var cmdMov = new SqlCommand(queryMov, con))
                {
                    cmdMov.Parameters.AddWithValue("@idProducto", idProducto);
                    cmdMov.Parameters.AddWithValue("@tipo", tipoMovimiento);
                    cmdMov.Parameters.AddWithValue("@cantidad", cantidadMover);
                    cmdMov.Parameters.AddWithValue("@obs", observacion);
                    cmdMov.ExecuteNonQuery();
                }
                */
            }

            MessageBox.Show("¡Movimiento de inventario registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarHistorialInventario();
        }

        private void CargarHistorialInventario()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                // Muestra la lista de productos actualizados en la grilla
                string query = "SELECT id_producto AS [ID], nombre AS [Producto], precio_venta AS [Precio], stock AS [Stock Actual] FROM productos";
                using (var da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void LimpiarFormulario()
        {
            cmbProducto.SelectedIndex = -1;
            cmbMovimiento.SelectedIndex = -1;
            txtStock.Text = "";
            txtMover.Text = "";
            txtObsevacion.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}