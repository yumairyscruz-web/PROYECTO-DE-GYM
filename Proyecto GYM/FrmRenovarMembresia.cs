using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FrmRenovarMembresia : Form
    {
        private bool cargandoCombo = false;
        private int idAsignacionSeleccionada = 0;

        public FrmRenovarMembresia()
        {
            InitializeComponent();
        }

        private void FrmRenovarMembresia_Load(object sender, EventArgs e)
        {
            cargandoCombo = true;

            CargarClientesCombo();
            CargarTiposMembresiasCombo();
            CargarTablaRenovaciones("");

            cargandoCombo = false;
            if (rbActiva != null) rbActiva.Checked = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarTablaRenovaciones(txtBuscar.Text.Trim());
        }

        private void CargarClientesCombo()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerClientesCombo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbCliente.DataSource = dt;
                        cmbCliente.DisplayMember = "nombre_completo";
                        cmbCliente.ValueMember = "id_cliente";
                        cmbCliente.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiposMembresiasCombo()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerMembresiasCombo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter daActual = new SqlDataAdapter(cmd);
                        DataTable dtActual = new DataTable();
                        daActual.Fill(dtActual);
                        cmbMembresiaActual.DataSource = dtActual;
                        cmbMembresiaActual.DisplayMember = "nombre";
                        cmbMembresiaActual.ValueMember = "id_membresia";
                        cmbMembresiaActual.SelectedIndex = -1;

                        SqlDataAdapter daNueva = new SqlDataAdapter(cmd);
                        DataTable dtNueva = new DataTable();
                        daNueva.Fill(dtNueva);
                        cmbNuevaMembresia.DataSource = dtNueva;
                        cmbNuevaMembresia.DisplayMember = "nombre";
                        cmbNuevaMembresia.ValueMember = "id_membresia";
                        cmbNuevaMembresia.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar membresías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoCombo || cmbCliente.SelectedIndex == -1 || cmbCliente.SelectedValue == null)
                return;

            int idCliente = 0;
            if (cmbCliente.SelectedValue is int id) idCliente = id;
            else if (cmbCliente.SelectedValue is DataRowView drv) idCliente = Convert.ToInt32(drv["id_cliente"]);
            else int.TryParse(cmbCliente.SelectedValue.ToString(), out idCliente);

            if (idCliente <= 0) return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT TOP 1 id_membresia, fecha_inicio, fecha_fin 
                                     FROM cliente_membresia 
                                     WHERE id_cliente = @id_cliente 
                                     ORDER BY id_cliente_membresia DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                cmbMembresiaActual.SelectedValue = Convert.ToInt32(dr["id_membresia"]);

                                DateTime fechaInicioAnt = Convert.ToDateTime(dr["fecha_inicio"]);
                                DateTime fechaFinAnt = Convert.ToDateTime(dr["fecha_fin"]);

                                dtpFechaInicio.Value = fechaInicioAnt;
                                dtpFechaVencimiento.Value = fechaFinAnt;
                                dateTimePicker1.Value = fechaFinAnt;
                            }
                        }
                    }
                }

                CalcularRenovacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNuevaMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularRenovacion();
        }

        private void CalcularRenovacion()
        {
            if (cargandoCombo) return;

            if (cmbNuevaMembresia.SelectedItem is DataRowView drv)
            {
                txtPrecio.Text = drv["precio"].ToString();
                int meses = Convert.ToInt32(drv["duracion_dias"]);
                dateTimePicker1.Value = dtpFechaVencimiento.Value.AddMonths(meses);
            }
            else
            {
                txtPrecio.Clear();
            }
        }

        private void btnRenovar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null || cmbNuevaMembresia.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un cliente y la nueva membresía.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = 0;
            if (cmbCliente.SelectedValue is int id) idCliente = id;
            else if (cmbCliente.SelectedValue is DataRowView drv) idCliente = Convert.ToInt32(drv["id_cliente"]);
            else int.TryParse(cmbCliente.SelectedValue.ToString(), out idCliente);

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_RenovarMembresia", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                        cmd.Parameters.AddWithValue("@id_membresia", cmbNuevaMembresia.SelectedValue);
                        cmd.Parameters.AddWithValue("@fecha_inicio", dtpFechaVencimiento.Value.Date);
                        cmd.Parameters.AddWithValue("@fecha_fin", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@estado", rbActiva.Checked ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Membresía renovada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTablaRenovaciones("");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la renovación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idAsignacionSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccione un registro de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"UPDATE cliente_membresia 
                                   SET fecha_inicio = @inicio, 
                                       fecha_fin = @fin, 
                                       estado = @estado 
                                   WHERE id_cliente_membresia = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@inicio", dtpFechaVencimiento.Value.Date);
                        cmd.Parameters.AddWithValue("@fin", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@estado", rbActiva.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@id", idAsignacionSeleccionada);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Renovación actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTablaRenovaciones("");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAsignacionSeleccionada == 0 && (dgvRenovaciones.CurrentRow == null || dgvRenovaciones.CurrentRow.Index < 0))
            {
                MessageBox.Show("Por favor, seleccione un registro para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAEliminar = idAsignacionSeleccionada > 0
                ? idAsignacionSeleccionada
                : Convert.ToInt32(dgvRenovaciones.CurrentRow.Cells["id_cliente_membresia"].Value);

            if (MessageBox.Show("¿Está seguro de eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        string query = "DELETE FROM cliente_membresia WHERE id_cliente_membresia = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", idAEliminar);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaRenovaciones("");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRenovaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvRenovaciones == null) return;

            cargandoCombo = true;
            try
            {
                DataGridViewRow fila = dgvRenovaciones.Rows[e.RowIndex];

                if (dgvRenovaciones.Columns["id_cliente_membresia"] != null && fila.Cells["id_cliente_membresia"].Value != DBNull.Value)
                {
                    idAsignacionSeleccionada = Convert.ToInt32(fila.Cells["id_cliente_membresia"].Value);
                }

                if (dgvRenovaciones.Columns["id_cliente"] != null && fila.Cells["id_cliente"].Value != DBNull.Value)
                {
                    cmbCliente.SelectedValue = Convert.ToInt32(fila.Cells["id_cliente"].Value);
                }

                if (dgvRenovaciones.Columns["id_membresia"] != null && fila.Cells["id_membresia"].Value != DBNull.Value)
                {
                    int idMembresia = Convert.ToInt32(fila.Cells["id_membresia"].Value);
                    cmbMembresiaActual.SelectedValue = idMembresia;
                    cmbNuevaMembresia.SelectedValue = idMembresia;
                }

                if (dgvRenovaciones.Columns["Fecha Inicio"] != null && fila.Cells["Fecha Inicio"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["Fecha Inicio"].Value.ToString(), out DateTime fInicio))
                {
                    dtpFechaInicio.Value = fInicio;
                }

                if (dgvRenovaciones.Columns["Fecha Vencimiento"] != null && fila.Cells["Fecha Vencimiento"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["Fecha Vencimiento"].Value.ToString(), out DateTime fFin))
                {
                    dtpFechaVencimiento.Value = fFin;
                    dateTimePicker1.Value = fFin.AddMonths(1);
                }

                if (dgvRenovaciones.Columns["Estado"] != null)
                {
                    string estado = fila.Cells["Estado"].Value?.ToString() ?? "Activo";
                    if (estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estado == "1" || estado == "True")
                    {
                        if (rbActiva != null) rbActiva.Checked = true;
                    }
                    else
                    {
                        if (rbInactiva != null) rbInactiva.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el registro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cargandoCombo = false;
                CalcularRenovacion();
            }
        }

        private void CargarTablaRenovaciones(string criterio)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarMembresiasAsignadas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@criterio", criterio);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvRenovaciones.DataSource = dt;
                        dgvRenovaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        foreach (DataGridViewColumn col in dgvRenovaciones.Columns)
                        {
                            if (col.Name == "id_cliente_membresia" || col.Name == "id_cliente" || col.Name == "id_membresia")
                            {
                                col.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cargandoCombo = true;
            idAsignacionSeleccionada = 0;
            if (txtBuscar != null) txtBuscar.Clear();
            if (cmbCliente != null) cmbCliente.SelectedIndex = -1;
            if (cmbMembresiaActual != null) cmbMembresiaActual.SelectedIndex = -1;
            if (cmbNuevaMembresia != null) cmbNuevaMembresia.SelectedIndex = -1;
            if (txtPrecio != null) txtPrecio.Clear();
            if (dtpFechaInicio != null) dtpFechaInicio.Value = DateTime.Now;
            if (dtpFechaVencimiento != null) dtpFechaVencimiento.Value = DateTime.Now;
            if (dateTimePicker1 != null) dateTimePicker1.Value = DateTime.Now;
            if (rbActiva != null) rbActiva.Checked = true;
            if (dgvRenovaciones != null) dgvRenovaciones.ClearSelection();
            cargandoCombo = false;
        }
    }
}