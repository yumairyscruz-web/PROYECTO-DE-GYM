using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuarioInput = txtusuario.Text.Trim();
            string claveInput = txtclave.Text.Trim();

            if (string.IsNullOrEmpty(usuarioInput) || string.IsNullOrEmpty(claveInput))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    // Usamos el Stored Procedure guardado en SQL Server
                    SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", usuarioInput);
                    cmd.Parameters.AddWithValue("@clave", claveInput);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Código para entrar al menú principal
                    if (reader.Read())
                    {
                        // Extraemos el nombre completo retornado por el Stored Procedure
                        string nombreCompleto = reader["nombre"].ToString() + " " + reader["apellido"].ToString();

                        MessageBox.Show($"Bienvenido {nombreCompleto}", "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir el Menú Principal (Form2) pasándole el nombre capturado de la BD
                        Form2 menuPrincipal = new Form2(nombreCompleto);
                        menuPrincipal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtclave.Clear();
                        txtusuario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}