using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormEntrenadores : Form
    {
        public FormEntrenadores()
        {
            InitializeComponent();

            if (this.dgvEntrenadores != null)
            {
                this.dgvEntrenadores.CellClick += this.dgvEntrenadores_CellClick;
            }

            // Suscribir evento de la tecla Enter en la caja de búsqueda
            if (this.txtBuscar != null)
            {
                this.txtBuscar.KeyDown += this.txtBuscar_KeyDown;
            }

            // Restricción de solo letras para nombre y apellido
            this.txtNombre.KeyPress += ValidarSoloLetras_KeyPress;
            this.txtApellido.KeyPress += ValidarSoloLetras_KeyPress;
        }

        private void FormEntrenadores_Load(object sender, EventArgs e)
        {
            if (cmbEspecialidad != null)
            {
                cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            // Configuración de controles de hora
            dtpHoraEntrada.Format = DateTimePickerFormat.Time;
            dtpHoraEntrada.ShowUpDown = true;
            dtpHoraSalida.Format = DateTimePickerFormat.Time;
            dtpHoraSalida.ShowUpDown = true;

            CargarEntrenadores();
        }

        // Validación para permitir únicamente letras y espacios en nombres/apellidos
        private void ValidarSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea números, asteriscos y cualquier otro símbolo
            }
        }

        // Validador estricto de formato de correo con @ y dominio
        private bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;
            // Expresión regular para verificar formato estricto de correo (ej. texto@dominio.com)
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

        // Carga la lista de entrenadores en el DataGridView
        private void CargarEntrenadores()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string query = @"SELECT id_entrenador, cedula, nombre, apellido, telefono, correo, 
                                            especialidad, hora_entrada, hora_salida, foto, 
                                            CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado 
                                     FROM entrenadores";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dgvEntrenadores != null)
                        {
                            dgvEntrenadores.DataSource = dt;

                            if (dgvEntrenadores.Columns.Count > 0)
                            {
                                dgvEntrenadores.Columns[0].Visible = false; // id_entrenador
                            }

                            if (dgvEntrenadores.Columns.Contains("foto") && dgvEntrenadores.Columns["foto"] != null)
                            {
                                dgvEntrenadores.Columns["foto"]!.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de entrenadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var imgTemp = Image.FromFile(ofd.FileName))
                    {
                        pbFotoEntrenador.Image = new Bitmap(imgTemp);
                    }
                }
            }
        }

        private byte[]? ConvertirImagenABytes(Image? imagen)
        {
            if (imagen == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        // Guardar un nuevo entrenador con validaciones de campos y correo
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Debe ingresar la cédula del entrenador.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del entrenador.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            // Validación de correo con @ y dominio obligatorios
            if (!ValidarCorreo(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("El correo electrónico no es válido. Debe incluir '@' y un dominio correcto (ej. correo@dominio.com).", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (cmbEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una especialidad de la lista.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecialidad.Focus();
                return;
            }

            bool estadoEntrenador = rbActivo.Checked;
            byte[]? fotoBytes = ConvertirImagenABytes(pbFotoEntrenador?.Image);

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string query = @"INSERT INTO entrenadores (cedula, nombre, apellido, telefono, correo, especialidad, hora_entrada, hora_salida, foto, estado) 
                                    VALUES (@cedula, @nombre, @apellido, @telefono, @correo, @especialidad, @hora_entrada, @hora_salida, @foto, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@especialidad", cmbEspecialidad.Text.Trim());
                        cmd.Parameters.AddWithValue("@hora_entrada", dtpHoraEntrada.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@hora_salida", dtpHoraSalida.Value.TimeOfDay);

                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = (object?)fotoBytes ?? DBNull.Value;
                        cmd.Parameters.AddWithValue("@estado", estadoEntrenador);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Entrenador guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEntrenadores();
                LimpiarFormulario();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("La cédula ingresada ya está registrada.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error en SQL Server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Editar entrenador con validación de correo integrada
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEntrenadores.CurrentRow == null || string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione un entrenador de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCorreo(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("El correo electrónico no es válido. Debe incluir '@' y un dominio correcto.", "Correo Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (cmbEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una especialidad.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecialidad.Focus();
                return;
            }

            int idEntrenador = Convert.ToInt32(dgvEntrenadores.CurrentRow.Cells[0].Value);
            bool estadoEntrenador = rbActivo.Checked;
            byte[]? fotoBytes = ConvertirImagenABytes(pbFotoEntrenador?.Image);

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string query = @"UPDATE entrenadores 
                                    SET nombre = @nombre, 
                                        apellido = @apellido, 
                                        telefono = @telefono, 
                                        correo = @correo, 
                                        especialidad = @especialidad, 
                                        hora_entrada = @hora_entrada, 
                                        hora_salida = @hora_salida, 
                                        foto = @foto, 
                                        estado = @estado 
                                    WHERE id_entrenador = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idEntrenador);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@especialidad", cmbEspecialidad.Text.Trim());
                        cmd.Parameters.AddWithValue("@hora_entrada", dtpHoraEntrada.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@hora_salida", dtpHoraSalida.Value.TimeOfDay);
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary).Value = (object?)fotoBytes ?? DBNull.Value;
                        cmd.Parameters.AddWithValue("@estado", estadoEntrenador);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Datos del entrenador actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEntrenadores();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar entrenador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Eliminar en lugar de Inactivar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEntrenadores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un entrenador de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar permanentemente este entrenador?",
                                                     "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    int idEntrenador = Convert.ToInt32(dgvEntrenadores.CurrentRow.Cells[0].Value);

                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        string query = "DELETE FROM entrenadores WHERE id_entrenador = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", idEntrenador);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("El entrenador ha sido eliminado exitosamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEntrenadores();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el entrenador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvEntrenadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvEntrenadores.Rows[e.RowIndex];

                txtCedula.Text = fila.Cells["cedula"]?.Value?.ToString() ?? "";
                txtCedula.ReadOnly = true;
                txtCedula.BackColor = Color.LightGray;

                txtNombre.Text = fila.Cells["nombre"]?.Value?.ToString() ?? "";
                txtApellido.Text = fila.Cells["apellido"]?.Value?.ToString() ?? "";
                txtTelefono.Text = fila.Cells["telefono"]?.Value?.ToString() ?? "";
                txtCorreo.Text = fila.Cells["correo"]?.Value?.ToString() ?? "";

                string? especialidadGuardada = fila.Cells["especialidad"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(especialidadGuardada))
                {
                    cmbEspecialidad.Text = especialidadGuardada;
                }

                if (TimeSpan.TryParse(fila.Cells["hora_entrada"]?.Value?.ToString(), out TimeSpan hEntrada))
                {
                    dtpHoraEntrada.Value = DateTime.Today.Add(hEntrada);
                }
                if (TimeSpan.TryParse(fila.Cells["hora_salida"]?.Value?.ToString(), out TimeSpan hSalida))
                {
                    dtpHoraSalida.Value = DateTime.Today.Add(hSalida);
                }

                if (fila.Cells["foto"]?.Value != DBNull.Value && fila.Cells["foto"]?.Value is byte[] bytesFoto && bytesFoto.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(bytesFoto))
                    {
                        using (Image tempImage = Image.FromStream(ms))
                        {
                            pbFotoEntrenador.Image = new Bitmap(tempImage);
                        }
                    }
                }
                else
                {
                    pbFotoEntrenador.Image = null;
                }

                string? estado = fila.Cells["estado"]?.Value?.ToString();
                if (estado == "Activo" || estado == "True" || estado == "1")
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvEntrenadores.DataSource is DataTable dt)
                {
                    string filtro = txtBuscar.Text.Trim()
                        .Replace("'", "''")
                        .Replace("[", "[[]")
                        .Replace("%", "[%]")
                        .Replace("*", "[*]");

                    if (string.IsNullOrEmpty(filtro))
                    {
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = string.Format(
                            "cedula LIKE '%{0}%' OR nombre LIKE '%{0}%' OR apellido LIKE '%{0}%' OR especialidad LIKE '%{0}%'",
                            filtro
                        );
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCedula.Clear();
            txtCedula.ReadOnly = false;
            txtCedula.BackColor = SystemColors.Window;

            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtBuscar.Clear();

            cmbEspecialidad.SelectedIndex = -1;
            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            dtpHoraEntrada.Value = DateTime.Now;
            dtpHoraSalida.Value = DateTime.Now;

            if (pbFotoEntrenador.Image != null)
            {
                pbFotoEntrenador.Image.Dispose();
                pbFotoEntrenador.Image = null;
            }

            if (dgvEntrenadores.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = "";
            }

            txtCedula.Focus();
        }

        private void rbInactivo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}