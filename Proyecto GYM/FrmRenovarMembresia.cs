using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FrmRenovarMembresia : Form
    {
        private bool cargandoCombo = false;

        public FrmRenovarMembresia()
        {
            InitializeComponent();
        }

        private void FrmRenovarMembresia_Load(object sender, EventArgs e)
        {
            cargandoCombo = true;

            // Registro de eventos
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            cmbNuevaMembresia.SelectedIndexChanged += cmbNuevaMembresia_SelectedIndexChanged;

            btnRenovar.Click += btnRenovar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            // Cargar combos y DataGridView
            CargarClientesCombo();
            CargarTiposMembresiasCombo();
            CargarTablaRenovaciones();

            cargandoCombo = false;
            rbActiva.Checked = true;
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

        // AL SELECCIONAR CLIENTE: Carga directo la membresía actual, fecha de inicio y fecha vence
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

                    // Busca la última asignación del cliente en cliente_membresia
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
                                // Llena los campos automáticamente
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

        // AL SELECCIONAR "RENOVAR POR": Carga el precio y calcula la nueva fecha
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

                // Suma la extensión desde la Fecha Vence actual
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
                CargarTablaRenovaciones();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la renovación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTablaRenovaciones()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarMembresiasAsignadas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@criterio", "");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvRenovaciones.DataSource = dt;
                        dgvRenovaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            cmbCliente.SelectedIndex = -1;
            cmbMembresiaActual.SelectedIndex = -1;
            cmbNuevaMembresia.SelectedIndex = -1;
            txtPrecio.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            rbActiva.Checked = true;
            cargandoCombo = false;
        }
    }
}