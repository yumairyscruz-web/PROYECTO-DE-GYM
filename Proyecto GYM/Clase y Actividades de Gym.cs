using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class Clase_y_Actividades_de_Gym : Form
    {
        private int idClaseSeleccionada = 0;
        private bool cargandoDatos = false;

        public Clase_y_Actividades_de_Gym()
        {
            InitializeComponent();
        }

        private void Clase_y_Actividades_de_Gym_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarEntrenadoresCombo();
            CargarClases();
        }

        private void ConfigurarControles()
        {
            cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.SelectedIndex = 0;

            nudCupoMaximo.Minimum = 1;
            nudCupoMaximo.Maximum = 500;
            nudCupoMaximo.Value = 20;
        }

        private void CargarEntrenadoresCombo()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerEntrenadoresCombo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

                        cargandoDatos = false;
                        cmbEntrenador.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                cargandoDatos = false;
                MessageBox.Show("Error al cargar lista de entrenadores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarClases(string criterio = "")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ListarClases", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@criterio", criterio);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvClases.DataSource = dt;

                        // Ocultar IDs que no son necesarios mostrar directamente al usuario en la vista
                        if (dgvClases.Columns.Contains("id_clase")) dgvClases.Columns["id_clase"].Visible = false;
                        if (dgvClases.Columns.Contains("id_entrenador")) dgvClases.Columns["id_entrenador"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de clases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la clase.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbEntrenador.SelectedValue == null || cmbEntrenador.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un entrenador.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEntrenador.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GuardarClase", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_entrenador", Convert.ToInt32(cmbEntrenador.SelectedValue));
                        cmd.Parameters.AddWithValue("@cupo_maximo", Convert.ToInt32(nudCupoMaximo.Value));
                        cmd.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem?.ToString() == "Activo" ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Clase o actividad registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClases();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la clase: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClaseSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una clase de la lista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la clase.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbEntrenador.SelectedValue == null || cmbEntrenador.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un entrenador.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEntrenador.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_EditarClase", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_clase", idClaseSeleccionada);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_entrenador", Convert.ToInt32(cmbEntrenador.SelectedValue));
                        cmd.Parameters.AddWithValue("@cupo_maximo", Convert.ToInt32(nudCupoMaximo.Value));
                        cmd.Parameters.AddWithValue("@estado", cmbEstado.SelectedItem?.ToString() == "Activo" ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Clase actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClases();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la clase: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idClaseSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una clase de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta clase?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        string query = "DELETE FROM clases WHERE id_clase = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", idClaseSeleccionada);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Clase eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClases();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la clase: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvClases == null) return;

            cargandoDatos = true;

            try
            {
                DataGridViewRow fila = dgvClases.Rows[e.RowIndex];

                // Cargar ID de la Clase
                if (dgvClases.Columns.Contains("id_clase"))
                {
                    object? valId = fila.Cells["id_clase"].Value;
                    if (valId != null && valId != DBNull.Value)
                    {
                        idClaseSeleccionada = Convert.ToInt32(valId);
                    }
                }

                // Cargar Nombre y Descripción (Validando nombres de columnas comunes)
                if (dgvClases.Columns.Contains("Nombre"))
                    txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
                else if (dgvClases.Columns.Contains("nombre"))
                    txtNombre.Text = fila.Cells["nombre"].Value?.ToString() ?? "";

                if (dgvClases.Columns.Contains("Descripción"))
                    txtDescripcion.Text = fila.Cells["Descripción"].Value?.ToString() ?? "";
                else if (dgvClases.Columns.Contains("descripcion"))
                    txtDescripcion.Text = fila.Cells["descripcion"].Value?.ToString() ?? "";

                // Seleccionar Entrenador en el ComboBox
                if (dgvClases.Columns.Contains("id_entrenador") && cmbEntrenador != null)
                {
                    object? idEntrenadorVal = fila.Cells["id_entrenador"].Value;

                    if (idEntrenadorVal != null && idEntrenadorVal != DBNull.Value && int.TryParse(idEntrenadorVal.ToString(), out int idEntrenadorParsed))
                    {
                        cmbEntrenador.SelectedValue = idEntrenadorParsed;
                    }
                    else
                    {
                        cmbEntrenador.SelectedIndex = -1;
                    }
                }

                // Cargar Cupo Máximo
                string? colCupo = null;
                if (dgvClases.Columns.Contains("Cupo Máximo")) colCupo = "Cupo Máximo";
                else if (dgvClases.Columns.Contains("cupo_maximo")) colCupo = "cupo_maximo";

                if (colCupo != null)
                {
                    object? valorCupo = fila.Cells[colCupo].Value;
                    if (valorCupo != null && valorCupo != DBNull.Value && int.TryParse(valorCupo.ToString(), out int cupo))
                    {
                        if (cupo >= nudCupoMaximo.Minimum && cupo <= nudCupoMaximo.Maximum)
                        {
                            nudCupoMaximo.Value = cupo;
                        }
                    }
                }

                // Cargar Estado
                string? colEstado = null;
                if (dgvClases.Columns.Contains("Estado")) colEstado = "Estado";
                else if (dgvClases.Columns.Contains("estado")) colEstado = "estado";

                if (colEstado != null)
                {
                    object? valorEstado = fila.Cells[colEstado].Value;
                    if (valorEstado != null && valorEstado != DBNull.Value)
                    {
                        string estadoStr = valorEstado.ToString() ?? "";
                        if (estadoStr == "1" || estadoStr.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                        {
                            cmbEstado.SelectedItem = "Activo";
                        }
                        else
                        {
                            cmbEstado.SelectedItem = "Inactivo";
                        }
                    }
                }
            }
            finally
            {
                cargandoDatos = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarClases(txtBuscar.Text.Trim());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cargandoDatos = true;

            idClaseSeleccionada = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();

            if (cmbEntrenador != null) cmbEntrenador.SelectedIndex = -1;
            if (cmbEstado != null) cmbEstado.SelectedIndex = 0;

            nudCupoMaximo.Value = 20;

            cargandoDatos = false;
            txtNombre.Focus();
        }
    }
}