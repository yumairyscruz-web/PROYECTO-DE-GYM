using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FrmRenovarMembresia : Form
    {
        private bool cargandoCombo = false;
        private int idAsignacionSeleccionada = 0; // Controla el registro seleccionado para Editar/Eliminar

        public FrmRenovarMembresia()
        {
            InitializeComponent();
        }

        private void FrmRenovarMembresia_Load(object sender, EventArgs e)
        {
            cargandoCombo = true;

          
          

            // Cargar combos y DataGridView
            CargarClientesCombo();
            CargarTiposMembresiasCombo();
            CargarTablaRenovaciones("");

            cargandoCombo = false;
            rbActiva.Checked = true;
        }

        // BÚSQUEDA EN TIEMPO REAL
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

            if (cmbCliente.SelectedValue is int id)
            {
                idCliente = id;
            }
            else if (cmbCliente.SelectedValue is DataRowView drv)
            {
                idCliente = Convert.ToInt32(drv["id_cliente"]);
            }
            else if (int.TryParse(cmbCliente.SelectedValue.ToString(), out int parsedId))
            {
                idCliente = parsedId;
            }

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
                                dtpFechaInicio.Value = Convert.ToDateTime(dr["fecha_inicio"]);
                                dtpFechaVencimiento.Value = Convert.ToDateTime(dr["fecha_fin"]);
                                dateTimePicker1.Value = dtpFechaVencimiento.Value;
                            }
                            else
                            {
                                cmbMembresiaActual.SelectedIndex = -1;
                                dtpFechaInicio.Value = DateTime.Now;
                                dtpFechaVencimiento.Value = DateTime.Now;
                                dateTimePicker1.Value = DateTime.Now;
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

        // EDITAR REGISTRO SELECCIONADO
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

        // ELIMINAR REGISTRO SELECCIONADO
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

        // SELECCIONAR FILA DE LA TABLA
        private void dgvRenovaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvRenovaciones == null) return;

            cargandoCombo = true;
            try
            {
                DataGridViewRow fila = dgvRenovaciones.Rows[e.RowIndex];

                // Ajusta el nombre de la columna del ID según devuelva tu procedimiento almacenado
                if (dgvRenovaciones.Columns["id_cliente_membresia"] != null && fila.Cells["id_cliente_membresia"].Value != DBNull.Value)
                {
                    idAsignacionSeleccionada = Convert.ToInt32(fila.Cells["id_cliente_membresia"].Value);
                }

                if (fila.Cells["id_cliente"].Value != DBNull.Value)
                {
                    cmbCliente.SelectedValue = Convert.ToInt32(fila.Cells["id_cliente"].Value);
                }

                if (fila.Cells["id_membresia"].Value != DBNull.Value)
                {
                    cmbNuevaMembresia.SelectedValue = Convert.ToInt32(fila.Cells["id_membresia"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el registro: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cargandoCombo = false;
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

                        // Ocultar columnas de IDs internos si existen en el DataTable
                        if (dgvRenovaciones.Columns["id_cliente_membresia"] != null) dgvRenovaciones.Columns["id_cliente_membresia"].Visible = false;
                        if (dgvRenovaciones.Columns["id_cliente"] != null) dgvRenovaciones.Columns["id_cliente"].Visible = false;
                        if (dgvRenovaciones.Columns["id_membresia"] != null) dgvRenovaciones.Columns["id_membresia"].Visible = false;
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
            cmbCliente.SelectedIndex = -1;
            cmbMembresiaActual.SelectedIndex = -1;
            cmbNuevaMembresia.SelectedIndex = -1;
            txtPrecio.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            rbActiva.Checked = true;
            if (dgvRenovaciones != null) dgvRenovaciones.ClearSelection();
            cargandoCombo = false;
        }
    }
}