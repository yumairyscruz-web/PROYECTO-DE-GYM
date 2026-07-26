using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        // Carga la lista en el DataGridView al abrir el formulario
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("SELECT id_usuario, usuario, cedula, nombre, apellido, correo, rol, estado FROM Usuarios", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Si tu DataGridView en el diseñador se llama dgvUsuarios o dgvClientes
                    if (dgvUsuarios != null)
                    {
                        dgvUsuarios.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------
        // Botón "Cargar" (Foto)
        // ----------------------------------------------------
        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirImagen = new OpenFileDialog();
            abrirImagen.Filter = "Archivos de Imagen (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            abrirImagen.Title = "Seleccionar Foto del Usuario";

            if (abrirImagen.ShowDialog() == DialogResult.OK)
            {
                pbFotoUsuario.Image = Image.FromFile(abrirImagen.FileName);
                pbFotoUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // ----------------------------------------------------
        // Botón "Guarda"
        // ----------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (Usuario y Contraseña).", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_GuardarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@rol", cmbRol.Text);
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? "Activo" : "Inactivo");

                    // Manejo de la foto
                    if (pbFotoUsuario.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pbFotoUsuario.Image.Save(ms, pbFotoUsuario.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@foto", ms.ToArray());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarUsuarios();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------
        // Botón "Editar"
        // ----------------------------------------------------
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Seleccione o busque un usuario primero para poder editarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@rol", cmbRol.Text);
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? "Activo" : "Inactivo");

                    if (pbFotoUsuario.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pbFotoUsuario.Image.Save(ms, pbFotoUsuario.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@foto", ms.ToArray());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@foto", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos del usuario actualizados correctamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarUsuarios();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------
        // Botón "Innacti" (Inactivar / Borrado lógico)
        // ----------------------------------------------------
        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario para inactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cambiar el estado del usuario a Inactivo?",
                                                     "Confirmar Inactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET estado = 'Inactivo' WHERE usuario = @usuario", con);
                        cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El usuario ha sido inactivado correctamente.", "Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarUsuarios();
                        LimpiarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cambiar estado del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ----------------------------------------------------
        // Botón "buscar"
        // ----------------------------------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@criterio", txtBuscar.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsuarios.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Búsqueda automática mientras escribes
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (dgvUsuarios.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format(
                    "usuario LIKE '%{0}%' OR cedula LIKE '%{0}%' OR nombre LIKE '%{0}%' OR apellido LIKE '%{0}%'",
                    busqueda
                );
            }
        }

        // ----------------------------------------------------
        // Botón "Elimina" / "Limpia"
        // ----------------------------------------------------
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtBuscar.Clear();

            if (cmbRol.Items.Count > 0)
            {
                cmbRol.SelectedIndex = -1;
            }

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            pbFotoUsuario.Image = null;

            if (dgvUsuarios.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = "";
            }

            txtUsuario.Focus();
        }
    }
}