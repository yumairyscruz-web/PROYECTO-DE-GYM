using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormUsuario : Form
    {
        // Bandera para evitar que los eventos del ComboBox se disparen mientras se llena la información
        private bool cargandoDatos = false;

        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            cargandoDatos = true;

            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cmbEntrenador != null)
            {
                cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbEntrenador.Enabled = false;
            }

            if (pbFotoUsuario != null)
            {
                pbFotoUsuario.BorderStyle = BorderStyle.FixedSingle;
                pbFotoUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            }

            CargarComboEntrenadores();
            CargarUsuarios();

            cargandoDatos = false;
        }

        private void CargarComboEntrenadores()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT 
                                        id_entrenador, 
                                        ISNULL(nombre, '') + ' ' + ISNULL(apellido, '') AS nombre_completo 
                                     FROM entrenadores";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cargandoDatos = true;

                        cmbEntrenador.DataSource = null;

                        if (dt.Rows.Count > 0)
                        {
                            cmbEntrenador.DisplayMember = "nombre_completo";
                            cmbEntrenador.ValueMember = "id_entrenador";
                            cmbEntrenador.DataSource = dt;
                            cmbEntrenador.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("La consulta no devolvió entrenadores.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        cargandoDatos = false;
                        cmbEntrenador.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                cargandoDatos = false;
                MessageBox.Show("Error al cargar la lista de entrenadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatos || cmbEntrenador == null) return;

            string rolSeleccionado = cmbRol.SelectedItem?.ToString()?.Trim() ?? string.Empty;
            bool esEntrenador = rolSeleccionado.Equals("Entrenador", StringComparison.OrdinalIgnoreCase);

            cmbEntrenador.Enabled = esEntrenador;

            if (esEntrenador)
            {
                // Bloquear campos heredados del entrenador
                txtCedula.ReadOnly = true;
                txtCedula.BackColor = Color.LightGray;
                txtNombre.ReadOnly = true;
                txtNombre.BackColor = Color.LightGray;
                txtApellido.ReadOnly = true;
                txtApellido.BackColor = Color.LightGray;
                txtCorreo.ReadOnly = true;
                txtCorreo.BackColor = Color.LightGray;
            }
            else
            {
                cargandoDatos = true;
                cmbEntrenador.SelectedIndex = -1;
                cargandoDatos = false;

                // Habilitar campos si no es entrenador
                txtCedula.ReadOnly = false;
                txtCedula.BackColor = SystemColors.Window;
                txtNombre.ReadOnly = false;
                txtNombre.BackColor = SystemColors.Window;
                txtApellido.ReadOnly = false;
                txtApellido.BackColor = SystemColors.Window;
                txtCorreo.ReadOnly = false;
                txtCorreo.BackColor = SystemColors.Window;
            }
        }

        private void cmbEntrenador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatos || cmbEntrenador == null || cmbEntrenador.SelectedIndex == -1 || cmbEntrenador.SelectedValue == null) return;

            if (int.TryParse(cmbEntrenador.SelectedValue.ToString(), out int idEntrenador))
            {
                CargarDatosEntrenadorPorId(idEntrenador);
            }
        }

        private void CargarDatosEntrenadorPorId(int idEntrenador)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT id_entrenador, cedula, nombre, apellido, correo, foto, estado 
                                     FROM entrenadores 
                                     WHERE id_entrenador = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idEntrenador);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string estadoStr = reader["estado"]?.ToString() ?? "0";
                                bool estaActivo = (estadoStr == "1" || estadoStr.Equals("True", StringComparison.OrdinalIgnoreCase) || estadoStr.Equals("Activo", StringComparison.OrdinalIgnoreCase));

                                if (!estaActivo)
                                {
                                    MessageBox.Show("El entrenador seleccionado está INACTIVO.\nNo se le puede crear ni asignar una cuenta de usuario.",
                                                    "Entrenador Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    LimpiarCamposEntrenador();
                                    btnGuardar.Enabled = false;
                                    return;
                                }

                                btnGuardar.Enabled = true;
                                txtCedula.Text = reader["cedula"]?.ToString() ?? "";
                                txtNombre.Text = reader["nombre"]?.ToString() ?? "";
                                txtApellido.Text = reader["apellido"]?.ToString() ?? "";
                                txtCorreo.Text = reader["correo"]?.ToString() ?? "";

                                // Mantener bloqueados los datos del entrenador seleccionado
                                txtCedula.ReadOnly = true;
                                txtCedula.BackColor = Color.LightGray;
                                txtNombre.ReadOnly = true;
                                txtNombre.BackColor = Color.LightGray;
                                txtApellido.ReadOnly = true;
                                txtApellido.BackColor = Color.LightGray;
                                txtCorreo.ReadOnly = true;
                                txtCorreo.BackColor = Color.LightGray;

                                DirectLimpiarImagenPerfil();

                                if (reader["foto"] != DBNull.Value && reader["foto"] is byte[] bytesFoto && bytesFoto.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(bytesFoto))
                                    {
                                        pbFotoUsuario.Image = new Bitmap(ms);
                                    }
                                }

                                txtUsuario.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información del entrenador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            string rolSeleccionado = cmbRol.SelectedItem?.ToString()?.Trim() ?? string.Empty;

            if (rolSeleccionado.Equals("Entrenador", StringComparison.OrdinalIgnoreCase))
            {
                string cedulaLimpia = txtCedula.Text.Replace("-", "").Trim();
                if (string.IsNullOrEmpty(cedulaLimpia)) return;

                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        string query = @"SELECT id_entrenador 
                                         FROM entrenadores 
                                         WHERE REPLACE(cedula, '-', '') = @cedula";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@cedula", cedulaLimpia);

                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                int id = Convert.ToInt32(result);

                                cargandoDatos = true;
                                cmbEntrenador.SelectedValue = id;
                                cargandoDatos = false;

                                CargarDatosEntrenadorPorId(id);
                            }
                            else
                            {
                                MessageBox.Show("No existe un entrenador registrado con la cédula ingresada.",
                                                "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarCamposEntrenador();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la cédula: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

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

                            if (dgvUsuarios.Columns.Contains("foto"))
                            {
                                var colFoto = dgvUsuarios.Columns["foto"];
                                if (colFoto != null) colFoto.Visible = false;
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
                    DirectLimpiarImagenPerfil();

                    byte[] bytesImagen = File.ReadAllBytes(abrirImagen.FileName);
                    using (MemoryStream ms = new MemoryStream(bytesImagen))
                    {
                        pbFotoUsuario.Image = new Bitmap(ms);
                    }
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

            string rolSeleccionado = cmbRol.Text.Trim();

            if (rolSeleccionado == "Entrenador" && (cmbEntrenador == null || cmbEntrenador.SelectedValue == null))
            {
                MessageBox.Show("Debe seleccionar un entrenador para vincularlo al usuario.", "Entrenador Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEntrenador?.Focus();
                return;
            }

            string estadoUsuario = rbActivo.Checked ? "Activo" : "Inactivo";

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GuardarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", rolSeleccionado);
                        cmd.Parameters.AddWithValue("@estado", estadoUsuario);

                        if (rolSeleccionado == "Entrenador" && cmbEntrenador?.SelectedValue != null)
                        {
                            cmd.Parameters.AddWithValue("@id_entrenador", cmbEntrenador.SelectedValue);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id_entrenador", DBNull.Value);
                        }

                        if (pbFotoUsuario.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (Bitmap bmp = new Bitmap(pbFotoUsuario.Image))
                                {
                                    bmp.Save(ms, ImageFormat.Png);
                                }
                                cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = ms.ToArray();
                            }
                        }
                        else
                        {
                            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        cmd.ExecuteNonQuery();
                    }

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

            string rolSeleccionado = cmbRol.Text.Trim();

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_EditarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", rolSeleccionado);
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? "Activo" : "Inactivo");

                        if (rolSeleccionado == "Entrenador" && cmbEntrenador?.SelectedValue != null)
                        {
                            cmd.Parameters.AddWithValue("@id_entrenador", cmbEntrenador.SelectedValue);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id_entrenador", DBNull.Value);
                        }

                        if (pbFotoUsuario.Image != null)
                        {
                            try
                            {
                                using (Bitmap bmp = new Bitmap(pbFotoUsuario.Image))
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        bmp.Save(ms, ImageFormat.Png);
                                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = ms.ToArray();
                                    }
                                }
                            }
                            catch
                            {
                                cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = DBNull.Value;
                            }
                        }
                        else
                        {
                            cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        cmd.ExecuteNonQuery();
                    }

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
                        if (con.State == ConnectionState.Closed) con.Open();

                        using (SqlCommand cmd = new SqlCommand("UPDATE usuarios SET estado = 0 WHERE usuario = @usuario", con))
                        {
                            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvUsuarios == null) return;

            cargandoDatos = true; // Bloquea disparos accidentales en combos

            try
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                txtUsuario.Text = dgvUsuarios.Columns.Contains("usuario") ? fila.Cells["usuario"].Value?.ToString() ?? "" : "";
                txtCedula.Text = dgvUsuarios.Columns.Contains("cedula") ? fila.Cells["cedula"].Value?.ToString() ?? "" : "";
                txtNombre.Text = dgvUsuarios.Columns.Contains("nombre") ? fila.Cells["nombre"].Value?.ToString() ?? "" : "";
                txtApellido.Text = dgvUsuarios.Columns.Contains("apellido") ? fila.Cells["apellido"].Value?.ToString() ?? "" : "";
                txtCorreo.Text = dgvUsuarios.Columns.Contains("correo") ? fila.Cells["correo"].Value?.ToString() ?? "" : "";

                // Bloquear los campos provenientes del entrenador al seleccionar de la tabla
                txtCedula.ReadOnly = true;
                txtCedula.BackColor = Color.LightGray;
                txtNombre.ReadOnly = true;
                txtNombre.BackColor = Color.LightGray;
                txtApellido.ReadOnly = true;
                txtApellido.BackColor = Color.LightGray;
                txtCorreo.ReadOnly = true;
                txtCorreo.BackColor = Color.LightGray;

                // Mapeo seguro de la clave si la columna existe en el grid
                if (dgvUsuarios.Columns.Contains("clave_hash"))
                {
                    txtClave.Text = fila.Cells["clave_hash"].Value?.ToString() ?? "";
                }
                else if (dgvUsuarios.Columns.Contains("clave"))
                {
                    txtClave.Text = fila.Cells["clave"].Value?.ToString() ?? "";
                }

                if (dgvUsuarios.Columns.Contains("rol"))
                {
                    string? rolGuardado = fila.Cells["rol"].Value?.ToString();
                    if (!string.IsNullOrEmpty(rolGuardado))
                    {
                        cmbRol.Text = rolGuardado;
                    }
                }

                if (dgvUsuarios.Columns.Contains("id_entrenador") && cmbEntrenador != null)
                {
                    object? idEntrenador = fila.Cells["id_entrenador"].Value;
                    if (idEntrenador != null && idEntrenador != DBNull.Value)
                    {
                        cmbEntrenador.SelectedValue = idEntrenador;
                        cmbEntrenador.Enabled = true;
                    }
                    else
                    {
                        cmbEntrenador.SelectedIndex = -1;
                        cmbEntrenador.Enabled = false;
                    }
                }

                if (dgvUsuarios.Columns.Contains("estado"))
                {
                    string? estadoGuardado = fila.Cells["estado"].Value?.ToString();
                    if (estadoGuardado == "Activo" || estadoGuardado == "True" || estadoGuardado == "1")
                    {
                        rbActivo.Checked = true;
                    }
                    else
                    {
                        rbInactivo.Checked = true;
                    }
                }

                DirectLimpiarImagenPerfil();

                if (dgvUsuarios.Columns.Contains("foto"))
                {
                    object? valorFoto = fila.Cells["foto"].Value;

                    if (valorFoto != null && valorFoto != DBNull.Value && valorFoto is byte[] bytesImagen && bytesImagen.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(bytesImagen))
                        {
                            pbFotoUsuario.Image = new Bitmap(ms);
                            pbFotoUsuario.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
            }
            finally
            {
                cargandoDatos = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_BuscarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@criterio", txtBuscar.Text.Trim());

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dgvUsuarios != null)
                        {
                            dgvUsuarios.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios?.DataSource is DataTable dt)
            {
                string filtro = txtBuscar.Text.Trim().Replace("'", "''");
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
            cargandoDatos = true;

            txtUsuario.Clear();
            txtClave.Clear();
            txtBuscar.Clear();

            LimpiarCamposEntrenador();

            cmbRol.SelectedIndex = -1;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            btnGuardar.Enabled = true;

            if (dgvUsuarios?.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = "";
            }

            cargandoDatos = false;
            txtUsuario.Focus();
        }

        private void LimpiarCamposEntrenador()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();

            if (cmbEntrenador != null)
            {
                cmbEntrenador.SelectedIndex = -1;
                cmbEntrenador.Enabled = false;
            }

            // Habilitar campos al limpiar para nuevos ingresos si se requiere
            txtCedula.ReadOnly = false;
            txtCedula.BackColor = SystemColors.Window;
            txtNombre.ReadOnly = false;
            txtNombre.BackColor = SystemColors.Window;
            txtApellido.ReadOnly = false;
            txtApellido.BackColor = SystemColors.Window;
            txtCorreo.ReadOnly = false;
            txtCorreo.BackColor = SystemColors.Window;

            DirectLimpiarImagenPerfil();
        }

        private void DirectLimpiarImagenPerfil()
        {
            if (pbFotoUsuario != null)
            {
                pbFotoUsuario.Image?.Dispose();
                pbFotoUsuario.Image = null;
            }
        }
    }
}