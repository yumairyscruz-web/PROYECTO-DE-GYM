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

            // Cargar los registros de pases diarios de hoy al abrir el formulario
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
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // Si borran el texto por error, asigna "Visitante" por defecto
                    string nombreCliente = string.IsNullOrWhiteSpace(txtNombreCliente.Text) ? "Visitante" : txtNombreCliente.Text;

                    // Insertamos el nombre del cliente y el monto (la fecha se registra automáticamente con GETDATE en la BD)
                    string query = "INSERT INTO pases_diarios (nombre_cliente, monto) VALUES (@nombre, @monto)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreCliente);
                        cmd.Parameters.AddWithValue("@monto", Convert.ToDecimal(txtPrecio.Text));

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

        private void CargarVisitasHoy()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // Consulta adaptada para mostrar el cliente, monto y la hora del día actual
                    string query = @"SELECT nombre_cliente AS [Cliente], 
                                            monto AS [Monto], 
                                            CONVERT(VARCHAR(8), fecha_pago, 108) AS [Hora] 
                                     FROM pases_diarios 
                                     WHERE CONVERT(DATE, fecha_pago) = CONVERT(DATE, GETDATE()) 
                                     ORDER BY fecha_pago DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Utiliza tu DataGridView nombrado dgvVisitasHoy
                    dgvVisitasHoy.DataSource = dt;
                    dgvVisitasHoy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}