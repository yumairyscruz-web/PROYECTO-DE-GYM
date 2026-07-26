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

            // Suscripción al evento adentro del constructor
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
        }
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_BuscarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@criterio", "");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dgvUsuarios != null)
                        {
                            dgvUsuarios.DataSource = dt;

                            // Ocultar la columna binaria de la foto sin lanzar excepciones
                            if (dgvUsuarios.Columns.Contains("foto"))
                            {
                                var columnaFoto = dgvUsuarios.Columns["foto"];
                                if (columnaFoto != null)
                                {
                                    columnaFoto.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrirImagen = new OpenFileDialog())
            {
                abrirImagen.Filter = "Archivos de Imagen (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                abrirImagen.Title = "Seleccionar Foto del Usuario";

                if (abrirImagen.ShowDialog() == DialogResult.OK)
                {
                    pbFotoUsuario.Image = Image.FromFile(abrirImagen.FileName);
                    pbFotoUsuario.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un Rol de la lista.", "Rol Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return;
            }

            string estadoUsuario = rbActivo.Checked ? "Activo" : "Inactivo";

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("sp_GuardarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@rol", cmbRol.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", estadoUsuario);

                    if (pbFotoUsuario.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbFotoUsuario.Image.Save(ms, pbFotoUsuario.Image.RawFormat);
                            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = ms.ToArray();
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = DBNull.Value;
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Usuario guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarUsuarios();
                    LimpiarFormulario();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("El nombre de usuario o la cédula ya existe en la base de datos.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error en SQL Server: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Seleccione o busque un usuario primero para poder editarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un Rol de la lista.", "Rol Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@rol", cmbRol.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? "Activo" : "Inactivo");

                    if (pbFotoUsuario.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbFotoUsuario.Image.Save(ms, pbFotoUsuario.Image.RawFormat);
                            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = ms.ToArray();
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = DBNull.Value;
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
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlCommand cmd = new SqlCommand("UPDATE usuarios SET estado = 0 WHERE usuario = @usuario", con);
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

        // Evento para transferir la información de la fila seleccionada a los controles
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el clic sea sobre una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                // 1. Cargar TextBoxes principales
                txtUsuario.Text = fila.Cells["usuario"]?.Value?.ToString() ?? "";
                txtCedula.Text = fila.Cells["cedula"]?.Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells["nombre"]?.Value?.ToString() ?? "";
                txtApellido.Text = fila.Cells["apellido"]?.Value?.ToString() ?? "";
                txtCorreo.Text = fila.Cells["correo"]?.Value?.ToString() ?? "";

                // 2. Cargar Contraseña (si viene en la consulta sp_BuscarUsuario)
                if (dgvUsuarios.Columns.Contains("clave"))
                {
                    txtClave.Text = fila.Cells["clave"]?.Value?.ToString() ?? "";
                }

                // 3. Cargar Rol en el ComboBox
                string? rolGuardado = fila.Cells["rol"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(rolGuardado))
                {
                    cmbRol.Text = rolGuardado;
                }

                // 4. Cargar Estado (RadioButtons)
                string? estadoGuardado = fila.Cells["estado"]?.Value?.ToString();
                if (estadoGuardado == "Activo")
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }

                // 5. Cargar Foto en el PictureBox
                if (dgvUsuarios.Columns.Contains("foto"))
                {
                    object? valorFoto = fila.Cells["foto"]?.Value;

                    if (valorFoto != null && valorFoto != DBNull.Value && valorFoto is byte[] bytesImagen && bytesImagen.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(bytesImagen))
                        {
                            pbFotoUsuario.Image = Image.FromStream(ms);
                            pbFotoUsuario.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        pbFotoUsuario.Image = null;
                    }
                }
                else
                {
                    pbFotoUsuario.Image = null;
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.DataSource is DataTable dt)
            {
                string filtro = txtBuscar.Text.Trim();
                dt.DefaultView.RowFilter = string.Format(
                    "usuario LIKE '%{0}%' OR cedula LIKE '%{0}%' OR nombre LIKE '%{0}%' OR apellido LIKE '%{0}%' OR rol LIKE '%{0}%'",
                    filtro
                );
            }
        }

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

            cmbRol.SelectedIndex = -1;
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