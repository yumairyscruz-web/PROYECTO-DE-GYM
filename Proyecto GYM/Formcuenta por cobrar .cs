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
    public partial class Formcuenta_por_cobrar : Form
    {
        public Formcuenta_por_cobrar()
        {
            InitializeComponent();
        }

        private void Formcuenta_por_cobrar_Load(object sender, EventArgs e)
        {
            CargarClientesConMembresia();
            CargarGrillaCuentas();

            txtEstadoCuenta.Text = "Pendiente";
            txtEstadoCuenta.Enabled = false;
            txtCedula.Enabled = false;
            txtMontoTotal.Enabled = false;
        }

        private void CargarClientesConMembresia()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                // Solo traemos clientes que tengan una membresía activa asociada
                string query = @"SELECT DISTINCT c.id_cliente, c.nombre, c.apellido, c.cedula 
                                 FROM clientes c
                                 INNER JOIN cliente_membresia cm ON c.id_cliente = cm.id_cliente
                                 WHERE c.estado = 1 AND cm.estado = 1";

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
        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null && int.TryParse(cmbClientes.SelectedValue.ToString(), out int idCliente))
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    // Buscamos la cédula y el saldo pendiente real de la base de datos
                    string query = @"SELECT c.cedula, ISNULL(cc.saldo, m.precio) AS saldo_pendiente 
                             FROM clientes c
                             LEFT JOIN cliente_membresia cm ON c.id_cliente = cm.id_cliente AND cm.estado = 1
                             LEFT JOIN membresias m ON cm.id_membresia = m.id_membresia
                             LEFT JOIN cuentas_cobrar cc ON c.id_cliente = cc.id_cliente AND cc.estado = 'Pendiente'
                             WHERE c.id_cliente = @id";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idCliente);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCedula.Text = reader["cedula"].ToString();
                                txtMontoTotal.Text = Convert.ToDecimal(reader["saldo_pendiente"]).ToString("N2");
                            }
                        }
                    }
                }
            }
        }

        private void CargarDeudaCliente(int idCliente)
        {
            using (var con = Conexion.ObtenerConexion())
            {
                // Obtenemos el precio de la membresía asociada al cliente desde la tabla membresias
                string query = @"SELECT SUM(m.precio) AS total_deuda 
                                 FROM cliente_membresia cm 
                                 INNER JOIN membresias m ON cm.id_membresia = m.id_membresia 
                                 WHERE cm.id_cliente = @id AND cm.estado = 1";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        txtMontoTotal.Text = Convert.ToDecimal(result).ToString("N2");
                    }
                    else
                    {
                        txtMontoTotal.Text = "0.00";
                    }
                }
            }
        }

        private void CargarGrillaCuentas()
        {
            try
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    string query = @"SELECT cm.id_cliente_membresia, (c.nombre + ' ' + c.apellido) AS Cliente, m.nombre AS Membresia, m.precio AS Monto_Total, cm.estado 
                                     FROM cliente_membresia cm
                                     INNER JOIN clientes c ON cm.id_cliente = c.id_cliente
                                     INNER JOIN membresias m ON cm.id_membresia = m.id_membresia";
                    using (var da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvCuentasPorCobrar.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMontoAbono.Text) || !decimal.TryParse(txtMontoAbono.Text, out decimal montoAbono) || montoAbono <= 0)
            {
                MessageBox.Show("Debe ingresar un monto válido para el abono.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal montoTotal = decimal.Parse(txtMontoTotal.Text);
            int idCliente = (int)cmbClientes.SelectedValue;

            if (montoAbono > montoTotal)
            {
                MessageBox.Show("El monto a pagar no puede ser mayor al total de la deuda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var con = Conexion.ObtenerConexion())
            {
                int idCuenta = 0;
                decimal saldoActual = 0;

                // 1. Buscar si ya existe una cuenta por cobrar pendiente para el cliente
                string queryCuenta = "SELECT id_cuenta, saldo FROM cuentas_cobrar WHERE id_cliente = @idCliente AND estado = 'Pendiente'";
                using (var cmdCuenta = new SqlCommand(queryCuenta, con))
                {
                    cmdCuenta.Parameters.AddWithValue("@idCliente", idCliente);
                    using (var reader = cmdCuenta.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idCuenta = reader.GetInt32(0);
                            saldoActual = reader.GetDecimal(1);
                        }
                    }
                }

                // 2. Si no existe, la creamos automáticamente en la tabla cuentas_cobrar
                if (idCuenta == 0)
                {
                    // Nota: Asumimos un id_venta por defecto o 1 si tu flujo no usa ventas directas aquí[cite: 1]
                    string queryCrearCuenta = "INSERT INTO cuentas_cobrar (id_venta, id_cliente, saldo, fecha_vencimiento, estado) OUTPUT INSERTED.id_cuenta VALUES (1, @idCliente, @montoTotal, DATEADD(month, 1, GETDATE()), 'Pendiente')";
                    using (var cmdCrear = new SqlCommand(queryCrearCuenta, con))
                    {
                        cmdCrear.Parameters.AddWithValue("@idCliente", idCliente);
                        cmdCrear.Parameters.AddWithValue("@montoTotal", montoTotal);
                        idCuenta = (int)cmdCrear.ExecuteScalar();
                        saldoActual = montoTotal;
                    }
                }

                // 3. Insertar el abono en la tabla abonos[cite: 1]
                string queryInsertAbono = "INSERT INTO abonos (id_cuenta, fecha, monto) VALUES (@idCuenta, GETDATE(), @monto)";
                using (var cmdAbono = new SqlCommand(queryInsertAbono, con))
                {
                    cmdAbono.Parameters.AddWithValue("@idCuenta", idCuenta);
                    cmdAbono.Parameters.AddWithValue("@monto", montoAbono);
                    cmdAbono.ExecuteNonQuery();
                }

                // 4. Actualizar el saldo restante en cuentas_cobrar[cite: 1]
                decimal nuevoSaldo = saldoActual - montoAbono;
                string nuevoEstado = nuevoSaldo <= 0 ? "Pagado" : "Pendiente";

                string queryUpdateCuenta = "UPDATE cuentas_cobrar SET saldo = @nuevoSaldo, estado = @nuevoEstado WHERE id_cuenta = @idCuenta";
                using (var cmdUpdate = new SqlCommand(queryUpdateCuenta, con))
                {
                    cmdUpdate.Parameters.AddWithValue("@nuevoSaldo", nuevoSaldo);
                    cmdUpdate.Parameters.AddWithValue("@nuevoEstado", nuevoEstado);
                    cmdUpdate.Parameters.AddWithValue("@idCuenta", idCuenta);
                    cmdUpdate.ExecuteNonQuery();
                }
            }

            MessageBox.Show("¡Abono registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            CargarGrillaCuentas();
        }
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1 || cmbClientes.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para ver el detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = (int)cmbClientes.SelectedValue;

            using (var con = Conexion.ObtenerConexion())
            {
                string query = @"SELECT a.id_abono AS [ID Abono], a.fecha AS [Fecha], a.monto AS [Monto Abonado]
                         FROM abonos a
                         INNER JOIN cuentas_cobrar c ON a.id_cuenta = c.id_cuenta
                         WHERE c.id_cliente = @idCliente";

                using (var da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idCliente", idCliente);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Puedes mostrarlo temporalmente en la misma grilla principal para ver el historial
                        dgvCuentasPorCobrar.DataSource = dt;
                        MessageBox.Show("Historial de abonos cargado en la tabla.", "Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Este cliente aún no registra abonos o pagos parciales.", "Sin registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbClientes.SelectedIndex = -1;
            txtCedula.Text = "";
            txtMontoTotal.Text = "";
            txtMontoAbono.Text = "";
            txtEstadoCuenta.Text = "Pendiente";

            // AQUÍ ESTÁ LA CLAVE: Esto devuelve la tabla a su estado original de cuentas por cobrar
            CargarGrillaCuentas();
        }

        private void LimpiarFormulario()
        {
            cmbClientes.SelectedIndex = -1;
            txtCedula.Clear();
            txtMontoTotal.Clear();
            txtMontoAbono.Clear();
            txtEstadoCuenta.Text = "Pendiente";
            dtpFechaPago.Value = DateTime.Now;
        }
    }
}