using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FrmAsignarMembresia : Form
    {
        private bool cargandoDatos = false;
        private int idAsignacionSeleccionada = 0;

        public FrmAsignarMembresia()
        {
            InitializeComponent();
        }

        private void FrmAsignarMembresia_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            cargandoDatos = true;
            CargarClientesCombo();
            CargarMembresiasCombo();
            CargarTablaAsignaciones();
            dtpInicio.Value = DateTime.Now;
            rbActivo.Checked = true;
            cargandoDatos = false;
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

        private void CargarMembresiasCombo()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerMembresiasCombo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbMembresia.DataSource = dt;
                        cmbMembresia.DisplayMember = "nombre";
                        cmbMembresia.ValueMember = "id_membresia";
                        cmbMembresia.SelectedIndex = -1;
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
            if (cargandoDatos) return;

            if (cmbCliente.SelectedItem is DataRowView drv)
            {
                txtCedula.Text = drv["cedula"]?.ToString() ?? "";
                txtTelefono.Text = drv["telefono"]?.ToString() ?? "";
            }
            else
            {
                txtCedula.Clear();
                txtTelefono.Clear();
            }
        }

        private void cmbMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return;

            if (cmbMembresia.SelectedItem is DataRowView drv)
            {
                txtPrecio.Text = drv["precio"]?.ToString() ?? "";

                int meses = Convert.ToInt32(drv["duracion_dias"]);
                nudDuracion.Value = meses > 0 ? meses : 1;

                dtpVencimiento.Value = dtpInicio.Value.AddMonths(meses);
            }
            else
            {
                txtPrecio.Clear();
                nudDuracion.Value = 0;
            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (cargandoDatos) return;

            if (cmbMembresia.SelectedItem is DataRowView drv)
            {
                int meses = Convert.ToInt32(drv["duracion_dias"]);
                dtpVencimiento.Value = dtpInicio.Value.AddMonths(meses);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null || cmbMembresia.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un cliente y un tipo de membresía.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AsignarMembresia", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_cliente", cmbCliente.SelectedValue);
                        cmd.Parameters.AddWithValue("@id_membresia", cmbMembresia.SelectedValue);
                        cmd.Parameters.AddWithValue("@fecha_inicio", dtpInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@fecha_fin", dtpVencimiento.Value.Date);
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Membresía asignada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTablaAsignaciones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la asignación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idAsignacionSeleccionada == 0)
            {
                MessageBox.Show("Por favor seleccione una asignación de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    string query = @"UPDATE cliente_membresia 
                                   SET id_cliente = @id_cliente, 
                                       id_membresia = @id_membresia, 
                                       fecha_inicio = @fecha_inicio, 
                                       fecha_fin = @fecha_fin, 
                                       estado = @estado 
                                   WHERE id_cliente_membresia = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idAsignacionSeleccionada);
                        cmd.Parameters.AddWithValue("@id_cliente", cmbCliente.SelectedValue);
                        cmd.Parameters.AddWithValue("@id_membresia", cmbMembresia.SelectedValue);
                        cmd.Parameters.AddWithValue("@fecha_inicio", dtpInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@fecha_fin", dtpVencimiento.Value.Date);
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Membresía actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTablaAsignaciones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la asignación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de cancelar la asignación de membresía?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }

        private void dgvAsignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            cargandoDatos = true;
            try
            {
                DataGridViewRow fila = dgvAsignaciones.Rows[e.RowIndex];

                // 1. Obtener ID de la asignación
                if (dgvAsignaciones.Columns["id_cliente_membresia"] != null && fila.Cells["id_cliente_membresia"].Value != DBNull.Value)
                {
                    idAsignacionSeleccionada = Convert.ToInt32(fila.Cells["id_cliente_membresia"].Value);
                }

                // 2. Seleccionar Cliente y extraer su teléfono de la fuente de datos
                if (dgvAsignaciones.Columns["id_cliente"] != null && fila.Cells["id_cliente"].Value != DBNull.Value)
                {
                    int idCliente = Convert.ToInt32(fila.Cells["id_cliente"].Value);
                    cmbCliente.SelectedValue = idCliente;

                    if (cmbCliente.SelectedItem is DataRowView drvClient)
                    {
                        txtCedula.Text = drvClient["cedula"]?.ToString() ?? "";
                        txtTelefono.Text = drvClient["telefono"]?.ToString() ?? "";
                    }
                }

                // 3. Seleccionar Membresía y extraer su precio y duración de la fuente de datos
                if (dgvAsignaciones.Columns["id_membresia"] != null && fila.Cells["id_membresia"].Value != DBNull.Value)
                {
                    int idMembresia = Convert.ToInt32(fila.Cells["id_membresia"].Value);
                    cmbMembresia.SelectedValue = idMembresia;

                    if (cmbMembresia.SelectedItem is DataRowView drvMemb)
                    {
                        txtPrecio.Text = drvMemb["precio"]?.ToString() ?? "";
                        int duracion = Convert.ToInt32(drvMemb["duracion_dias"]);
                        nudDuracion.Value = duracion > 0 ? duracion : 1;
                    }
                }

                // 4. Fechas
                if (dgvAsignaciones.Columns["Fecha Inicio"] != null && fila.Cells["Fecha Inicio"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["Fecha Inicio"].Value.ToString(), out DateTime fInicio))
                {
                    dtpInicio.Value = fInicio;
                }

                if (dgvAsignaciones.Columns["Fecha Vencimiento"] != null && fila.Cells["Fecha Vencimiento"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["Fecha Vencimiento"].Value.ToString(), out DateTime fFin))
                {
                    dtpVencimiento.Value = fFin;
                }

                // 5. Estado
                if (dgvAsignaciones.Columns["Estado"] != null)
                {
                    string estado = fila.Cells["Estado"].Value?.ToString() ?? "Activo";
                    if (estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estado == "1" || estado == "True")
                    {
                        rbActivo.Checked = true;
                    }
                    else
                    {
                        rbInactivo.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la fila: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cargandoDatos = false;
            }
        }

        private void CargarTablaAsignaciones(string criterio = "")
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

                        dgvAsignaciones.DataSource = dt;
                        dgvAsignaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvAsignaciones.Columns["id_cliente_membresia"] != null)
                            dgvAsignaciones.Columns["id_cliente_membresia"].Visible = false;

                        if (dgvAsignaciones.Columns["id_cliente"] != null)
                            dgvAsignaciones.Columns["id_cliente"].Visible = false;

                        if (dgvAsignaciones.Columns["id_membresia"] != null)
                            dgvAsignaciones.Columns["id_membresia"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarTablaAsignaciones(txtBuscar.Text.Trim());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cargandoDatos = true;
            idAsignacionSeleccionada = 0;
            cmbCliente.SelectedIndex = -1;
            cmbMembresia.SelectedIndex = -1;
            txtCedula.Clear();
            txtTelefono.Clear();
            txtPrecio.Clear();
            nudDuracion.Value = 0;
            dtpInicio.Value = DateTime.Now;
            rbActivo.Checked = true;
            txtBuscar.Clear();
            cargandoDatos = false;
        }

        private void btnInactivo_Click(object sender, EventArgs e)
        {
            if (idAsignacionSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccione una membresía de la tabla para inactivar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea inactivar esta membresía?",
                "Confirmar Inactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        string query = "UPDATE cliente_membresia SET estado = 0 WHERE id_cliente_membresia = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", idAsignacionSeleccionada);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Membresía inactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaAsignaciones();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al inactivar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}