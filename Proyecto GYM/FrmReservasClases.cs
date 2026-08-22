using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FrmReservasClases : Form
    {
        public FrmReservasClases()
        {
            InitializeComponent();
        }

        private void FrmReservasClases_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarClases();
            CargarGrillaReservas();

            // Estado inicial por defecto en el TextBox deshabilitado
            txtEstado.Text = "Confirmada";
            txtEstado.Enabled = false;
        }

        private void CargarClientes()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                // Usamos un INNER JOIN con cliente_membresia para traer SOLO a quienes tienen un plan activo
                string query = @"SELECT DISTINCT c.id_cliente, c.nombre, c.apellido, c.cedula 
                         FROM clientes c
                         INNER JOIN cliente_membresia cm ON c.id_cliente = cm.id_cliente
                         WHERE c.estado = 1 AND cm.estado = 1"; // Solo clientes activos CON membresía activa

                using (var da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("nombre_completo", typeof(string), "nombre + ' ' + apellido");

                    cmbClientes.DataSource = dt;
                    cmbClientes.DisplayMember = "nombre_completo";
                    cmbClientes.ValueMember = "id_cliente";
                    cmbClientes.SelectedIndex = -1;
                }
            }
        }

        private void CargarClases()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_clase, nombre FROM clases WHERE estado = 1";
                using (var da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbClases.DataSource = dt;
                    cmbClases.DisplayMember = "nombre";
                    cmbClases.ValueMember = "id_clase";
                    cmbClases.SelectedIndex = -1;
                }
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex != -1 && cmbClientes.SelectedItem is DataRowView row)
            {
                // Llena la cédula
                txtCedula.Text = row["cedula"].ToString();

                if (int.TryParse(row["id_cliente"].ToString(), out int idCliente))
                {
                    // Carga las membresías de este cliente específico
                    CargarMembresiasCliente(idCliente);
                }
            }
            else
            {
                // Si no hay cliente seleccionado, limpiamos todo
                txtCedula.Clear();
                cmbMembresia.DataSource = null;
                cmbMembresia.Items.Clear(); // Asegura que se borre cualquier texto residual
            }
        }

        private void CargarMembresiasCliente(int idCliente)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                string query = @"SELECT cm.id_cliente_membresia, m.nombre AS estado 
                         FROM cliente_membresia cm 
                         INNER JOIN membresias m ON cm.id_membresia = m.id_membresia 
                         WHERE cm.id_cliente = @id AND cm.estado = 1";

                using (var da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", idCliente);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbMembresia.DataSource = dt;
                        cmbMembresia.DisplayMember = "estado";
                        cmbMembresia.ValueMember = "id_cliente_membresia";
                        cmbMembresia.SelectedIndex = 0;
                    }
                    else
                    {
                        // Si el cliente no tiene membresías activas, limpiamos el ComboBox
                        cmbMembresia.DataSource = null;
                        cmbMembresia.Items.Clear();
                    }
                }
            }
        }

        private void btnRegistrarReserva_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbClases.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una clase.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var con = Conexion.ObtenerConexion())
            {
                // ELIMINAMOS O COMENTAMOS con.Open(); porque la conexión ya viene abierta
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        string queryReserva = @"INSERT INTO reservas (id_cliente, id_clase, fecha_reserva, estado) 
                                        VALUES (@id_cliente, @id_clase, @fecha_reserva, @estado)";

                        using (var cmd = new SqlCommand(queryReserva, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id_cliente", cmbClientes.SelectedValue);
                            cmd.Parameters.AddWithValue("@id_clase", cmbClases.SelectedValue);
                            cmd.Parameters.AddWithValue("@fecha_reserva", dtpFechaReserva.Value.Date);
                            cmd.Parameters.AddWithValue("@estado", txtEstado.Text);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("¡Reserva registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarFormulario();
                        CargarGrillaReservas();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al registrar la reserva: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CargarGrillaReservas()
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    string query = @"SELECT r.id_reserva, (c.nombre + ' ' + c.apellido) AS Cliente, cl.nombre AS Clase, r.fecha_reserva, r.estado 
                                     FROM reservas r
                                     INNER JOIN clientes c ON r.id_cliente = c.id_cliente
                                     INNER JOIN clases cl ON r.id_clase = cl.id_clase";
                    using (var da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvReservas.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla de reservas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbClientes.SelectedIndex = -1;
            cmbClases.SelectedIndex = -1;
            txtCedula.Clear();
            cmbMembresia.DataSource = null;
            dtpFechaReserva.Value = DateTime.Now;
            txtEstado.Text = "Confirmada";
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                int idReserva = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["id_reserva"].Value);

                using (var con = Conexion.ObtenerConexion())
                {
                    // ELIMINAMOS con.Open(); de aquí también, ya que viene abierta
                    string query = "UPDATE reservas SET estado = 'Cancelada' WHERE id_reserva = @id";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idReserva);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Reserva cancelada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrillaReservas();
            }
            else
            {
                MessageBox.Show("Seleccione una reserva de la tabla para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}