using System;
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
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.");
                return;
            }

            string query = @"SELECT id_usuario,nombre,apellido,id_rol
                             FROM usuarios
                             WHERE usuario=@usuario
                             AND clave_hash=@clave
                             AND estado=1";

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@usuario", usuarioInput);
                    cmd.Parameters.AddWithValue("@clave", claveInput);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Bienvenido " +
                            reader["nombre"] + " " + reader["apellido"]);
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}