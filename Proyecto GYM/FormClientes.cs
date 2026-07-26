using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta al abrir el formulario
        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        // Carga los registros de la base de datos en el DataGridView
        private void CargarClientes()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dgvClientes != null)
                    {
                        dgvClientes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de clientes: " + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Deja todas las cajas en blanco y resetea los controles
        private void LimpiarFormulario()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();

            dtpFechaNacimiento.Value = DateTime.Now;
            cmbSexo.SelectedIndex = -1;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            pbFoto.Image = null;

            // Restablece el filtro de búsqueda del DataGridView si existía
            if (dgvClientes.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = "";
            }

            txtCedula.Focus();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(@"Server=DESKTOP-AR0O5IR\SQLEXPRESS;Database=GimnasioDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarCliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@criterio", txtBuscar.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClientes.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar cliente: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Ventana emergente para seleccionar la imagen
            OpenFileDialog abrirImagen = new OpenFileDialog();

            // Filtro para mostrar únicamente archivos de imagen válidos
            abrirImagen.Filter = "Archivos de Imagen (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            abrirImagen.Title = "Seleccionar Foto del Cliente";

            if (abrirImagen.ShowDialog() == DialogResult.OK)
            {
                // Asigna la foto al PictureBox usando el nombre pbFoto
                pbFoto.Image = Image.FromFile(abrirImagen.FileName);

                // Ajusta la escala de la imagen para que no se deforme ni se corte
                pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (dgvClientes.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format(
                    "cedula LIKE '%{0}%' OR nombre LIKE '%{0}%' OR apellido LIKE '%{0}%'",
                    busqueda
                );
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios básicos
            if (string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (Cédula, Nombre, Apellido).", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_GuardarCliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@sexo", cmbSexo.Text);
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? "Activo" : "Inactivo");

                    if (pbFoto.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@foto", ms.ToArray());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientes();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione o busque un cliente primero para poder editarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@sexo", cmbSexo.Text);
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? "Activo" : "Inactivo");

                    if (pbFoto.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@foto", ms.ToArray());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos del cliente actualizados correctamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientes();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione un cliente para inactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cambiar el estado del cliente a Inactivo?",
                                                     "Confirmar Inactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Clientes SET estado = 'Inactivo' WHERE cedula = @cedula", con);
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El cliente ha sido inactivado correctamente.", "Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarClientes();
                        LimpiarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cambiar estado del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}



