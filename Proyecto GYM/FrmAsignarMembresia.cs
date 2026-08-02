using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FrmAsignarMembresia : Form
    {
        public FrmAsignarMembresia()
        {
            InitializeComponent();
        }

        private void FrmAsignarMembresia_Load(object sender, EventArgs e)
        {
            // Suscripción de eventos principales
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            cmbMembresia.SelectedIndexChanged += cmbMembresia_SelectedIndexChanged;
            dtpInicio.ValueChanged += dtpInicio_ValueChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;

            btnAsignar.Click += btnAsignar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCancelar.Click += (s, ev) => this.Close();

            // Carga inicial
            CargarClientesCombo();
            CargarMembresiasCombo();
            CargarTablaAsignaciones();
            dtpInicio.Value = DateTime.Now;
            rbActivo.Checked = true;
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
            if (cmbCliente.SelectedItem is DataRowView drv)
            {
                txtCedula.Text = drv["cedula"].ToString();
                txtTelefono.Text = drv["telefono"].ToString();
            }
            else
            {
                txtCedula.Clear();
                txtTelefono.Clear();
            }
        }

        private void cmbMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMembresia.SelectedItem is DataRowView drv)
            {
                txtPrecio.Text = drv["precio"].ToString();

                // Asumimos que la propiedad duracion representa la cantidad de meses (ej: 1 = 1 mes, 3 = 3 meses)
                int meses = Convert.ToInt32(drv["duracion_dias"]);
                nudDuracion.Value = meses;

                // Suma los meses exactos respetando los días del calendario (2 de agosto -> 2 de septiembre)
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
            cmbCliente.SelectedIndex = -1;
            cmbMembresia.SelectedIndex = -1;
            txtCedula.Clear();
            txtTelefono.Clear();
            txtPrecio.Clear();
            nudDuracion.Value = 0;
            dtpInicio.Value = DateTime.Now;
            rbActivo.Checked = true;
        }
    }
}