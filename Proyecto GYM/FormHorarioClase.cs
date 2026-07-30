using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormHorarioClase : Form
    {
        // Bandera para evitar disparos accidentales en eventos intermedios
        private bool cargandoDatos = false;

        // Variable global para controlar la edición del registro
        private int idHorarioSeleccionado = 0;

        public FormHorarioClase()
        {
            InitializeComponent();
        }

        private void FormHorarioClase_Load(object sender, EventArgs e)
        {
            cargandoDatos = true;

            // Configuración inicial de estilos y controles
            cmbClase.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbDia != null) cmbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbEntrenador != null) cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;

            // Configuración adecuada de DateTimePicker con AM/PM y botones UpDown
            if (dtpHoraInicio != null)
            {
                dtpHoraInicio.Format = DateTimePickerFormat.Custom;
                dtpHoraInicio.CustomFormat = "hh:mm tt";
                dtpHoraInicio.ShowUpDown = true;
            }

            if (dtpHoraFin != null)
            {
                dtpHoraFin.Format = DateTimePickerFormat.Custom;
                dtpHoraFin.CustomFormat = "hh:mm tt";
                dtpHoraFin.ShowUpDown = true;
            }

            if (nudCapacidad != null)
            {
                nudCapacidad.Minimum = 1;
                nudCapacidad.Maximum = 100;
                nudCapacidad.Value = 20;
            }

            CargarClasesComboBox();
            CargarHorarios();

            cargandoDatos = false;
        }

        // Carga las clases registradas en el ComboBox
        private void CargarClasesComboBox()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

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

        // EVENTO: Al cambiar la clase seleccionada, se consulta únicamente su entrenador asignado
        private void cmbClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return;

            if (cmbClase.SelectedValue != null && int.TryParse(cmbClase.SelectedValue.ToString(), out int idClase))
            {
                CargarEntrenadorDeClase(idClase);
            }
            else
            {
                if (cmbEntrenador != null)
                {
                    cmbEntrenador.DataSource = null;
                }
            }
        }

        // Carga UNICAMENTE el entrenador correspondiente a la clase seleccionada mediante JOIN
        private void CargarEntrenadorDeClase(int idClase)
        {
            if (cmbEntrenador == null) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT e.id_entrenador, 
                                            ISNULL(e.nombre, '') + ' ' + ISNULL(e.apellido, '') AS nombre_completo
                                     FROM clases c
                                     INNER JOIN entrenadores e ON c.id_entrenador = e.id_entrenador
                                     WHERE c.id_clase = @idClase AND e.estado = 1";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idClase", idClase);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbEntrenador.DataSource = dt;
                        cmbEntrenador.DisplayMember = "nombre_completo";
                        cmbEntrenador.ValueMember = "id_entrenador";

                        if (dt.Rows.Count > 0)
                        {
                            cmbEntrenador.SelectedIndex = 0; // Selecciona automáticamente al entrenador responsable
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el entrenador de la clase: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga la lista de horarios registrados en el DataGridView
        private void CargarHorarios()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT h.id_horario, 
                                            c.nombre AS [Clase], 
                                            ISNULL(e.nombre, '') + ' ' + ISNULL(e.apellido, '') AS [Entrenador],
                                            h.dia_semana AS [Día], 
                                            CONVERT(VARCHAR(5), h.hora_inicio, 108) AS [Hora Inicio], 
                                            CONVERT(VARCHAR(5), h.hora_fin, 108) AS [Hora Fin],
                                            h.capacidad_maxima AS [Capacidad],
                                            h.id_clase,
                                            h.id_entrenador
                                     FROM horarios_clases h
                                     INNER JOIN clases c ON h.id_clase = c.id_clase
                                     LEFT JOIN entrenadores e ON h.id_entrenador = e.id_entrenador";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        da.Fill(tabla);

                        dgvHorariosClases.DataSource = tabla;

                        if (dgvHorariosClases.Columns["id_horario"] is { } colHorario) colHorario.Visible = false;
                        if (dgvHorariosClases.Columns["id_clase"] is { } colClase) colClase.Visible = false;
                        if (dgvHorariosClases.Columns["id_entrenador"] is { } colEntrenador) colEntrenador.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los horarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // METODO AUXILIAR DE VALIDACION DE REGLAS DE NEGOCIO
        private bool ValidarReglasDeNegocio(int idClase, int idEntrenador, string diaSemana, TimeSpan inicio, TimeSpan fin, int capacidad, int idHorarioExcluir = 0)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // 1. Validar Cupo Máximo según la Clase seleccionada
                    string queryClase = "SELECT cupo_maximo FROM clases WHERE id_clase = @idClase";
                    using (SqlCommand cmdClase = new SqlCommand(queryClase, con))
                    {
                        cmdClase.Parameters.AddWithValue("@idClase", idClase);
                        object resCupo = cmdClase.ExecuteScalar();

                        if (resCupo != null && int.TryParse(resCupo.ToString(), out int cupoMaximoClase))
                        {
                            if (capacidad > cupoMaximoClase)
                            {
                                MessageBox.Show($"La capacidad asignada ({capacidad}) supera el cupo máximo permitido para esta clase ({cupoMaximoClase}).",
                                                "Validación de Cupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }

                    // 2. Validar Disponibilidad del Entrenador según su Horario Laboral (Entrada/Salida)
                    string queryEntrenador = "SELECT hora_entrada, hora_salida FROM entrenadores WHERE id_entrenador = @idEntrenador";
                    using (SqlCommand cmdEnt = new SqlCommand(queryEntrenador, con))
                    {
                        cmdEnt.Parameters.AddWithValue("@idEntrenador", idEntrenador);
                        using (SqlDataReader dr = cmdEnt.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                TimeSpan horaEntradaEntrenador = (TimeSpan)dr["hora_entrada"];
                                TimeSpan horaSalidaEntrenador = (TimeSpan)dr["hora_salida"];

                                if (inicio < horaEntradaEntrenador || fin > horaSalidaEntrenador)
                                {
                                    string hEnt = DateTime.Today.Add(horaEntradaEntrenador).ToString("hh:mm tt");
                                    string hSal = DateTime.Today.Add(horaSalidaEntrenador).ToString("hh:mm tt");
                                    string hIni = DateTime.Today.Add(inicio).ToString("hh:mm tt");
                                    string hFin = DateTime.Today.Add(fin).ToString("hh:mm tt");

                                    MessageBox.Show($"El horario de la clase ({hIni} - {hFin}) se encuentra fuera de la jornada laboral del entrenador ({hEnt} - {hSal}).",
                                                    "Conflicto de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                    }

                    // 3. Validar Traslape / Empalme de Horarios del Entrenador en el mismo día
                    string queryCruces = @"SELECT COUNT(1) 
                                           FROM horarios_clases 
                                           WHERE id_entrenador = @idEntrenador 
                                             AND dia_semana = @dia 
                                             AND id_horario <> @idHorarioExcluir
                                             AND (hora_inicio < @fin AND hora_fin > @inicio)";

                    using (SqlCommand cmdCruce = new SqlCommand(queryCruces, con))
                    {
                        cmdCruce.Parameters.AddWithValue("@idEntrenador", idEntrenador);
                        cmdCruce.Parameters.AddWithValue("@dia", diaSemana);
                        cmdCruce.Parameters.AddWithValue("@idHorarioExcluir", idHorarioExcluir);
                        cmdCruce.Parameters.AddWithValue("@inicio", inicio);
                        cmdCruce.Parameters.AddWithValue("@fin", fin);

                        int existeEmpalme = Convert.ToInt32(cmdCruce.ExecuteScalar());
                        if (existeEmpalme > 0)
                        {
                            MessageBox.Show("El entrenador ya tiene asignada otra clase en ese mismo día y rango de horario.",
                                            "Conflicto de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar reglas de negocio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarCamposFormulario(out int idClase, out int idEntrenador, out string dia, out TimeSpan inicio, out TimeSpan fin, out int capacidad)
        {
            idClase = 0;
            idEntrenador = 0;
            dia = string.Empty;
            inicio = TimeSpan.Zero;
            fin = TimeSpan.Zero;
            capacidad = 20;

            if (cmbClase.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione la clase o actividad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbClase.Focus();
                return false;
            }

            if (cmbEntrenador != null && cmbEntrenador.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione el entrenador asignado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEntrenador.Focus();
                return false;
            }

            if (cmbDia == null || cmbDia.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione el día de la semana.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDia?.Focus();
                return false;
            }

            inicio = dtpHoraInicio.Value.TimeOfDay;
            fin = dtpHoraFin.Value.TimeOfDay;

            if (inicio >= fin)
            {
                MessageBox.Show("La hora de inicio debe ser menor a la hora de fin.\nVerifique los campos AM / PM.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpHoraInicio.Focus();
                return false;
            }

            capacidad = nudCapacidad != null ? Convert.ToInt32(nudCapacidad.Value) : 20;
            idClase = Convert.ToInt32(cmbClase.SelectedValue);
            idEntrenador = Convert.ToInt32(cmbEntrenador!.SelectedValue);
            dia = cmbDia.SelectedItem.ToString() ?? string.Empty;

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposFormulario(out int idClaseVal, out int idEntrenadorVal, out string diaVal, out TimeSpan inicio, out TimeSpan fin, out int capacidad))
                return;

            // Se ejecutan las reglas de validación
            if (!ValidarReglasDeNegocio(idClaseVal, idEntrenadorVal, diaVal, inicio, fin, capacidad))
            {
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"INSERT INTO horarios_clases (id_clase, id_entrenador, dia_semana, hora_inicio, hora_fin, capacidad_maxima) 
                                     VALUES (@id_clase, @id_entrenador, @dia, @inicio, @fin, @capacidad)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_clase", idClaseVal);
                        cmd.Parameters.AddWithValue("@id_entrenador", idEntrenadorVal);
                        cmd.Parameters.AddWithValue("@dia", diaVal);
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);
                        cmd.Parameters.AddWithValue("@capacidad", capacidad);

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idHorarioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un horario de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposFormulario(out int idClaseVal, out int idEntrenadorVal, out string diaVal, out TimeSpan inicio, out TimeSpan fin, out int capacidad))
                return;

            // Se ejecutan las reglas de validación excluyendo el id actual
            if (!ValidarReglasDeNegocio(idClaseVal, idEntrenadorVal, diaVal, inicio, fin, capacidad, idHorarioSeleccionado))
            {
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"UPDATE horarios_clases 
                                     SET id_clase = @id_clase, 
                                         id_entrenador = @id_entrenador, 
                                         dia_semana = @dia, 
                                         hora_inicio = @inicio, 
                                         hora_fin = @fin, 
                                         capacidad_maxima = @capacidad
                                     WHERE id_horario = @id_horario";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_clase", idClaseVal);
                        cmd.Parameters.AddWithValue("@id_entrenador", idEntrenadorVal);
                        cmd.Parameters.AddWithValue("@dia", diaVal);
                        cmd.Parameters.AddWithValue("@inicio", inicio);
                        cmd.Parameters.AddWithValue("@fin", fin);
                        cmd.Parameters.AddWithValue("@capacidad", capacidad);
                        cmd.Parameters.AddWithValue("@id_horario", idHorarioSeleccionado);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Horario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHorarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idHorarioSeleccionado > 0 || (dgvHorariosClases.CurrentRow != null && dgvHorariosClases.CurrentRow.Index >= 0))
            {
                int idAEliminar = idHorarioSeleccionado > 0
                    ? idHorarioSeleccionado
                    : Convert.ToInt32(dgvHorariosClases.CurrentRow!.Cells["id_horario"].Value);

                if (MessageBox.Show("¿Desea eliminar este horario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = Conexion.ObtenerConexion())
                        {
                            if (con.State == ConnectionState.Closed) con.Open();

                            string query = "DELETE FROM horarios_clases WHERE id_horario = @id";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@id", idAEliminar);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Horario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvHorariosClases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHorariosClases == null) return;

            cargandoDatos = true;

            try
            {
                DataGridViewRow fila = dgvHorariosClases.Rows[e.RowIndex];
                if (dgvHorariosClases.Columns["id_horario"] != null && fila.Cells["id_horario"].Value is object valHorario && valHorario != DBNull.Value)
                {
                    idHorarioSeleccionado = Convert.ToInt32(valHorario);
                }

                if (dgvHorariosClases.Columns["id_clase"] != null && fila.Cells["id_clase"].Value is object valClase && valClase != DBNull.Value)
                {
                    int idClaseVal = Convert.ToInt32(valClase);
                    cmbClase.SelectedValue = idClaseVal;
                    CargarEntrenadorDeClase(idClaseVal);
                }

                if (cmbEntrenador != null && dgvHorariosClases.Columns["id_entrenador"] != null && fila.Cells["id_entrenador"].Value is object valEntrenador && valEntrenador != DBNull.Value)
                {
                    cmbEntrenador.SelectedValue = valEntrenador!;
                }

                if (cmbDia != null && dgvHorariosClases.Columns["Día"] != null)
                {
                    cmbDia.Text = fila.Cells["Día"].Value?.ToString() ?? "";
                }

                if (dgvHorariosClases.Columns["Capacidad"] != null && nudCapacidad != null)
                {
                    if (int.TryParse(fila.Cells["Capacidad"].Value?.ToString(), out int cap))
                    {
                        nudCapacidad.Value = Math.Max(nudCapacidad.Minimum, Math.Min(nudCapacidad.Maximum, cap));
                    }
                }

                if (dgvHorariosClases.Columns["Hora Inicio"] != null && fila.Cells["Hora Inicio"].Value != DBNull.Value)
                {
                    string? horaInicioStr = fila.Cells["Hora Inicio"].Value?.ToString();
                    if (horaInicioStr != null && TimeSpan.TryParse(horaInicioStr, out TimeSpan tsInicio))
                    {
                        dtpHoraInicio.Value = DateTime.Today.Add(tsInicio);
                    }
                }

                if (dgvHorariosClases.Columns["Hora Fin"] != null && fila.Cells["Hora Fin"].Value != DBNull.Value)
                {
                    string? horaFinStr = fila.Cells["Hora Fin"].Value?.ToString();
                    if (horaFinStr != null && TimeSpan.TryParse(horaFinStr, out TimeSpan tsFin))
                    {
                        dtpHoraFin.Value = DateTime.Today.Add(tsFin);
                    }
                }
            }
            finally
            {
                cargandoDatos = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cargandoDatos = true;

            idHorarioSeleccionado = 0;

            cmbClase.SelectedIndex = -1;
            if (cmbDia != null) cmbDia.SelectedIndex = -1;

            if (cmbEntrenador != null) cmbEntrenador.DataSource = null;

            dtpHoraInicio.Value = DateTime.Now;
            dtpHoraFin.Value = DateTime.Now;

            if (nudCapacidad != null) nudCapacidad.Value = 20;

            if (dgvHorariosClases != null) dgvHorariosClases.ClearSelection();

            cargandoDatos = false;
        }
    }
}