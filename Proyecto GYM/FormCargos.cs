using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormCargos : Form
    {
        public FormCargos()
        {
            InitializeComponent();
        }

        private void FormCargos_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarListaCargos();

            // Bloquear campos de solo lectura
            txtNumeroCargo.ReadOnly = true;
            txtPlanAsignado.ReadOnly = true;
            txtMontoVencimiento.ReadOnly = true;
            txtCedula.ReadOnly = true;

            GenerarCodigoAutomatico();

            // Conectar evento para que al hacer clic en la tabla se llenen los campos
            dgvCargos.CellClick += new DataGridViewCellEventHandler(dgvCargos_CellClick);
        }

        private void GenerarCodigoAutomatico()
        {
            txtNumeroCargo.Text = "CARG-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    string query = "SELECT id_cliente, (nombre + ' ' + apellido) AS nombre_completo FROM Clientes WHERE estado = 1 ORDER BY nombre";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbClientes.DataSource = dt;
                        cmbClientes.DisplayMember = "nombre_completo";
                        cmbClientes.ValueMember = "id_cliente";
                        cmbClientes.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarListaCargos()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // Consulta mapeando 'concepto' como 'numero_cargo' para la interfaz y mostrando el estado
                    string query = @"SELECT c.id_cargo, c.id_cliente, (cli.nombre + ' ' + cli.apellido) AS cliente, 
                                     cli.cedula, c.concepto AS numero_cargo, c.monto, c.fecha_vencimiento, c.estado 
                                     FROM Cargos c
                                     INNER JOIN Clientes cli ON c.id_cliente = cli.id_cliente
                                     ORDER BY c.fecha_vencimiento DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvCargos.DataSource = dt;

                        if (dgvCargos.Columns["id_cargo"] != null) dgvCargos.Columns["id_cargo"].Visible = false;
                        if (dgvCargos.Columns["id_cliente"] != null) dgvCargos.Columns["id_cliente"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de cargos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue == null || cmbClientes.SelectedIndex == -1) return;

            if (int.TryParse(cmbClientes.SelectedValue.ToString(), out int idCliente))
            {
                CargarDatosMembresiaCliente(idCliente);
            }
        }

        private void CargarDatosMembresiaCliente(int idCliente)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT TOP 1 cl.cedula, m.nombre AS nombre_membresia, m.precio, cm.fecha_fin 
                                     FROM Clientes cl 
                                     LEFT JOIN cliente_membresia cm ON cl.id_cliente = cm.id_cliente 
                                     LEFT JOIN membresias m ON cm.id_membresia = m.id_membresia 
                                     WHERE cl.id_cliente = @id_cliente 
                                     ORDER BY cm.fecha_fin DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtCedula.Text = dr["cedula"]?.ToString() ?? "";
                                txtPlanAsignado.Text = dr["nombre_membresia"] != DBNull.Value ? dr["nombre_membresia"].ToString() : "Sin membresía activa";

                                decimal precio = dr["precio"] != DBNull.Value ? Convert.ToDecimal(dr["precio"]) : 0;
                                txtMontoVencimiento.Text = precio.ToString("N2", CultureInfo.InvariantCulture);

                                if (dr["fecha_fin"] != DBNull.Value && DateTime.TryParse(dr["fecha_fin"].ToString(), out DateTime fechaFin))
                                {
                                    dtpVencimiento.Value = fechaFin;
                                }
                                else
                                {
                                    dtpVencimiento.Value = DateTime.Now;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la información del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente antes de generar el cargo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMontoVencimiento.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto))
            {
                monto = 0;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    // Inserción usando 'concepto' para el código y registrando fecha_generacion y estado 'Pendiente'
                    string queryInsert = @"INSERT INTO Cargos (id_cliente, concepto, monto, fecha_generacion, fecha_vencimiento, estado) 
                                           VALUES (@id_cliente, @concepto, @monto, GETDATE(), @fecha_vencimiento, 'Pendiente')";

                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", Convert.ToInt32(cmbClientes.SelectedValue));
                        cmd.Parameters.AddWithValue("@concepto", txtNumeroCargo.Text);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@fecha_vencimiento", dtpVencimiento.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Cargo " + txtNumeroCargo.Text + " generado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarListaCargos();

                cmbClientes.SelectedIndex = -1;
                txtCedula.Text = "- -";
                txtPlanAsignado.Text = "";
                txtMontoVencimiento.Text = "";
                GenerarCodigoAutomatico();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cargo en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCargos.Rows[e.RowIndex];

                txtNumeroCargo.Text = row.Cells["numero_cargo"].Value?.ToString() ?? "";
                txtCedula.Text = row.Cells["cedula"].Value?.ToString() ?? "";

                if (row.Cells["monto"].Value != DBNull.Value && decimal.TryParse(row.Cells["monto"].Value?.ToString(), out decimal monto))
                {
                    txtMontoVencimiento.Text = monto.ToString("N2", CultureInfo.InvariantCulture);
                }

                if (row.Cells["fecha_vencimiento"].Value != DBNull.Value && DateTime.TryParse(row.Cells["fecha_vencimiento"].Value?.ToString(), out DateTime fecha))
                {
                    dtpVencimiento.Value = fecha;
                }

                if (row.Cells["id_cliente"].Value != DBNull.Value)
                {
                    cmbClientes.SelectedValue = Convert.ToInt32(row.Cells["id_cliente"].Value);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}