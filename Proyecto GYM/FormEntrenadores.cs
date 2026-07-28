using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms; // <-- Faltaba el ';' aquí

namespace Proyecto_GYM
{
    public partial class FormEntrenadores : Form
    {
        public FormEntrenadores() // <-- Cambiar el nombre del constructor también
        {
            InitializeComponent();

            if (this.dgvEntrenadores != null)
            {
                this.dgvEntrenadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntrenadores_CellClick);
            }
        }

        // ... el resto de tus métodos siguen igual
        private void FormEntrenadores_Load(object sender, EventArgs e)
        {
            if (cmbEspecialidad != null)
            {
                cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            CargarEntrenadores();
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

                    string query = @"SELECT id_entrenador, cedula, nombre, apellido, telefono, correo, especialidad, estado 
                            FROM entrenadores";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dgvEntrenadores != null)
                        {
                            dgvEntrenadores.DataSource = dt;

                            // Ocultar la columna de manera segura
                            if (dgvEntrenadores.Columns.Count > 0)
                            {
                                dgvEntrenadores.Columns[0].Visible = false;
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

        // Guardar un nuevo entrenador
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

            if (cmbEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una especialidad de la lista.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecialidad.Focus();
                return;
            }

            string estadoEntrenador = rbActivo.Checked ? "Activo" : "Inactivo";

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string query = @"INSERT INTO entrenadores (cedula, nombre, apellido, telefono, correo, especialidad, estado) 
                                    VALUES (@cedula, @nombre, @apellido, @telefono, @correo, @especialidad, @estado)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@especialidad", cmbEspecialidad.Text.Trim());
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

        // Editar entrenador seleccionado
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEntrenadores.CurrentRow == null || string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione un entrenador de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una especialidad.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecialidad.Focus();
                return;
            }

            int idEntrenador = Convert.ToInt32(dgvEntrenadores.CurrentRow.Cells["id_entrenador"].Value);
            string estadoEntrenador = rbActivo.Checked ? "Activo" : "Inactivo";

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string query = @"UPDATE entrenadores 
                                    SET cedula = @cedula, nombre = @nombre, apellido = @apellido, 
                                        telefono = @telefono, correo = @correo, especialidad = @especialidad, estado = @estado 
                                    WHERE id_entrenador = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idEntrenador);
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@especialidad", cmbEspecialidad.Text.Trim());
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

        // Cambiar el estado a Inactivo
        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (dgvEntrenadores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un entrenador para inactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea inactivar este entrenador?",
                                                     "Confirmar Inactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    int idEntrenador = Convert.ToInt32(dgvEntrenadores.CurrentRow.Cells["id_entrenador"].Value);

                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        string query = "UPDATE entrenadores SET estado = 'Inactivo' WHERE id_entrenador = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", idEntrenador);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("El entrenador ha sido inactivado.", "Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEntrenadores();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cambiar estado del entrenador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Pasar datos de la fila seleccionada a los controles del formulario
        private void dgvEntrenadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvEntrenadores.Rows[e.RowIndex];

                txtCedula.Text = fila.Cells["cedula"]?.Value?.ToString() ?? "";
                txtNombre.Text = fila.Cells["nombre"]?.Value?.ToString() ?? "";
                txtApellido.Text = fila.Cells["apellido"]?.Value?.ToString() ?? "";
                txtTelefono.Text = fila.Cells["telefono"]?.Value?.ToString() ?? "";
                txtCorreo.Text = fila.Cells["correo"]?.Value?.ToString() ?? "";

                // Cargar la Especialidad en el ComboBox
                string? especialidadGuardada = fila.Cells["especialidad"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(especialidadGuardada))
                {
                    cmbEspecialidad.Text = especialidadGuardada;
                }

                // Cargar el Estado
                string? estado = fila.Cells["estado"]?.Value?.ToString();
                if (estado == "Activo")
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }
            }
        }

        // Filtrar en tiempo real
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvEntrenadores.DataSource is DataTable dt)
            {
                string filtro = txtBuscar.Text.Trim();
                dt.DefaultView.RowFilter = string.Format(
                    "cedula LIKE '%{0}%' OR nombre LIKE '%{0}%' OR apellido LIKE '%{0}%' OR especialidad LIKE '%{0}%'",
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
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtBuscar.Clear();

            cmbEspecialidad.SelectedIndex = -1;
            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            if (dgvEntrenadores.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = "";
            }

            txtCedula.Focus();
        }
    }
}