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
    public partial class Formabonos : Form
    {
        public Formabonos()
        {
            InitializeComponent();
        }

        private void Formabonos_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            using (var con = Conexion.ObtenerConexion())
            {
                string query = "SELECT id_cliente, CONCAT(nombre, ' ', apellido) AS nombre_completo FROM clientes";
                using (var cmd = new SqlCommand(query, con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbClientes.DataSource = dt;
                        cmbClientes.DisplayMember = "nombre_completo";
                        cmbClientes.ValueMember = "id_cliente";
                        cmbClientes.SelectedIndex = -1; // Arranca vacío
                    }
                }
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedValue != null && int.TryParse(cmbClientes.SelectedValue.ToString(), out int idCliente))
            {
                using (var con = Conexion.ObtenerConexion())
                {
                    // Buscar Cédula y Saldo Pendiente de la cuenta del cliente
                    string query = @"SELECT c.cedula, ISNULL(cc.saldo, 0) AS saldo_pendiente 
                                     FROM clientes c
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
                                txtPediente.Text = Convert.ToDecimal(reader["saldo_pendiente"]).ToString("N2");
                            }
                        }
                    }

                    // Calcular el Total Abonado histórico de este cliente
                    string queryAbonosTotal = @"SELECT ISNULL(SUM(a.monto), 0) AS total_abonado 
                                                FROM abonos a
                                                INNER JOIN cuentas_cobrar cc ON a.id_cuenta = cc.id_cuenta
                                                WHERE cc.id_cliente = @id";

                    using (var cmdTotal = new SqlCommand(queryAbonosTotal, con))
                    {
                        cmdTotal.Parameters.AddWithValue("@id", idCliente);
                        decimal totalAbonado = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                        txtTotal.Text = totalAbonado.ToString("N2");
                    }
                }
            }
        }

        private void btnHistoria_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente para ver su historial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = (int)cmbClientes.SelectedValue;

            using (var con = Conexion.ObtenerConexion())
            {
                // Cargar la grilla con todos los abonos realizados por el cliente
                string query = @"SELECT a.id_abono AS [ID Abono], a.fecha AS [Fecha], a.monto AS [Monto Abonado]
                                 FROM abonos a
                                 INNER JOIN cuentas_cobrar cc ON a.id_cuenta = cc.id_cuenta
                                 WHERE cc.id_cliente = @id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }



        private void btnComprobante_Click(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente para generar el comprobante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clienteSeleccionado = cmbClientes.Text;
            string cedula = txtCedula.Text;
            string totalAbonado = txtTotal.Text;
            string saldoPendiente = txtPediente.Text;

            // Estructura limpia del recibo
            string recibo = "====================================\r\n" +
                            "       COMPROBANTE DE ABONOS        \r\n" +
                            "====================================\r\n" +
                            $"Cliente: {clienteSeleccionado}\r\n" +
                            $"Cédula: {cedula}\r\n" +
                            $"Total Abonado: RD$ {totalAbonado}\r\n" +
                            $"Saldo Pendiente: RD$ {saldoPendiente}\r\n" +
                            "------------------------------------\r\n" +
                            $"Fecha: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}\r\n" +
                            "====================================\r\n" +
                            "¡Gracias por su pago en el Gimnasio!";

            // 1. Guardar automáticamente el recibo como un archivo de texto que se puede abrir e imprimir
            try
            {
                string rutaArchivo = "Comprobante_" + clienteSeleccionado.Replace(" ", "_") + ".txt";
                System.IO.File.WriteAllText(rutaArchivo, recibo);

                // 2. Abrir el cuadro de diálogo estándar de impresión de Windows
                using (PrintDialog printDialog = new PrintDialog())
                {
                    System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                    printDoc.PrintPage += (s, ev) => {
                        ev.Graphics.DrawString(recibo, new Font("Consolas", 12), Brushes.Black, 100, 100);
                    };

                    printDialog.Document = printDoc;

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDoc.Print();
                    }
                }

                MessageBox.Show($"Comprobante generado y guardado exitosamente como:\n{rutaArchivo}", "Comprobante Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el documento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}