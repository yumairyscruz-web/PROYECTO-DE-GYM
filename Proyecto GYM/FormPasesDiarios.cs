using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FormPasesDiarios : Form
    {
        public FormPasesDiarios()
        {
            InitializeComponent();
        }

        private void FormPasesDiarios_Load(object sender, EventArgs e)
        {
            // Precio predeterminado para agilizar el cobro
            txtPrecio.Text = "100.00";

            // Nombre predeterminado automático para que no lo dejes vacío
            txtNombreCliente.Text = "Visitante";

            // Permite que al presionar la tecla ENTER se active el botón de registrar de inmediato
            this.AcceptButton = btnRegistrar;

            // Cargar los registros de pases diarios al abrir el formulario
            CargarVisitasHoy();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, ingrese el monto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Aseguramos que el punto sea interpretado correctamente como separador decimal
                decimal monto;
                if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
                {
                    MessageBox.Show("Por favor, ingrese un monto válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // Si borran el texto por error, asigna "Visitante" por defecto
                    string nombreCliente = string.IsNullOrWhiteSpace(txtNombreCliente.Text) ? "Visitante" : txtNombreCliente.Text;

                    // Insertamos el nombre del cliente y el monto
                    string query = "INSERT INTO pases_diarios (nombre_cliente, monto) VALUES (@nombre, @monto)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreCliente);
                        cmd.Parameters.AddWithValue("@monto", monto);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Volver a colocar "Visitante" y enfocar el precio para el siguiente cobro rápido
                txtNombreCliente.Text = "Visitante";
                txtPrecio.Focus();
                txtPrecio.SelectAll();

                // Refrescar automáticamente la tabla inferior con el nuevo registro
                CargarVisitasHoy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pase diario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya una fila seleccionada en la tabla
            if (dgvVisitasHoy.SelectedRows.Count > 0)
            {
                // Pedir confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        // Obtenemos el ID oculto de la fila seleccionada a través de la primera columna (índice 0)
                        int idPase = Convert.ToInt32(dgvVisitasHoy.SelectedRows[0].Cells[0].Value);

                        using (SqlConnection con = Conexion.ObtenerConexion())
                        {
                            if (con.State == ConnectionState.Closed) con.Open();

                            string query = "DELETE FROM pases_diarios WHERE id_pase = @id";

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@id", idPase);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Recargar la tabla y notificar
                        CargarVisitasHoy();
                        MessageBox.Show("Registro eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione de la tabla el registro que desea eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarVisitasHoy()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // Consulta sin el filtro de la fecha de hoy para que mantenga el historial completo
                    string query = @"SELECT id_pase, 
                                            nombre_cliente AS [Cliente], 
                                            monto AS [Monto], 
                                            CONVERT(VARCHAR(8), fecha_pago, 108) AS [Hora] 
                                     FROM pases_diarios 
                                     ORDER BY fecha_pago DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvVisitasHoy.DataSource = dt;
                    dgvVisitasHoy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Ocultamos la columna del ID usando el índice 0 de forma totalmente segura
                    if (dgvVisitasHoy.Columns.Count > 0)
                    {
                        dgvVisitasHoy.Columns[0].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}