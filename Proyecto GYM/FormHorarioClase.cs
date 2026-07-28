using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormHorarioClase : Form
    {
        public FormHorarioClase()
        {
            InitializeComponent();
        }

        private void FormHorarioClase_Load(object sender, EventArgs e)
        {
            CargarClasesComboBox();
            CargarHorarios();
        }

        // Carga las clases registradas en el ComboBox
        private void CargarClasesComboBox()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string query = "SELECT id_clase, nombre FROM clases WHERE estado = 1";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        da.Fill(tabla);

                        cmbClase.DataSource = tabla;
                        cmbClase.DisplayMember = "nombre";
                        cmbClase.ValueMember = "id_clase";
                        cmbClase.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las clases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga la lista de horarios registrados en el DataGridView
        private void CargarHorarios()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string query = @"SELECT h.id_horario, c.nombre AS [Clase], h.dia_semana AS [Día], 
                                    CONVERT(VARCHAR(5), h.hora_inicio, 108) AS [Hora Inicio], 
                                    CONVERT(VARCHAR(5), h.hora_fin, 108) AS [Hora Fin]
                                    FROM horarios_clases h
                                    INNER JOIN clases c ON h.id_clase = c.id_clase";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        da.Fill(tabla);

                        dgvHorariosClases.DataSource = tabla;
                        if (dgvHorariosClases.Columns.Contains("id_horario"))
                        {
                            dgvHorariosClases.Columns["id_horario"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los horarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbClase.SelectedValue == null || cmbDia.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione la clase y el día de la semana.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan inicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan fin = dtpHoraFin.Value.TimeOfDay;

            if (inicio >= fin)
            {
                MessageBox.Show("La hora de inicio debe ser menor a la hora de fin.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string query = "INSERT INTO horarios_clases (id_clase, dia_semana, hora_inicio, hora_fin) VALUES (@id_clase, @dia, @inicio, @fin)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_clase", Convert.ToInt32(cmbClase.SelectedValue));
                        cmd.Parameters.AddWithValue("@dia", cmbDia.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Horario asignado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHorarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvHorariosClases.SelectedRows.Count > 0)
            {
                int idHorario = Convert.ToInt32(dgvHorariosClases.CurrentRow.Cells["id_horario"].Value);

                if (MessageBox.Show("¿Desea eliminar este horario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = Conexion.ObtenerConexion())
                        {
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }

                            string query = "DELETE FROM horarios_clases WHERE id_horario = @id";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@id", idHorario);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        CargarHorarios();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbClase.SelectedIndex = -1;
            cmbDia.SelectedIndex = -1;
            dtpHoraInicio.Value = DateTime.Now;
            dtpHoraFin.Value = DateTime.Now;
        }
    }
}