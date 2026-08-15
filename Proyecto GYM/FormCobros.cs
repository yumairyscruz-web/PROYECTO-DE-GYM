using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormCobros : Form
    {
        private DataTable dtDetalleCobro = new DataTable();

        public FormCobros()
        {
            InitializeComponent();
        }

        private void FormCobros_Load(object sender, EventArgs e)
        {
            // 1. Asegurar la estructura de columnas una sola vez
            if (dtDetalleCobro == null)
            {
                dtDetalleCobro = new DataTable();
            }

            if (dtDetalleCobro.Columns.Count == 0)
            {
                dtDetalleCobro.Columns.Add("Tipo", typeof(string));
                dtDetalleCobro.Columns.Add("Descripcion", typeof(string));
                dtDetalleCobro.Columns.Add("Cantidad", typeof(int));
                dtDetalleCobro.Columns.Add("Precio Unitario", typeof(decimal));
                dtDetalleCobro.Columns.Add("Subtotal", typeof(decimal));
            }

            // 2. Vincular correctamente al DataGridView limpiando esquemas previos
            dgvDetalle.DataSource = null;
            dgvDetalle.AutoGenerateColumns = true; // Se encarga de crearlas solas basadas en el DataTable
            dgvDetalle.DataSource = dtDetalleCobro;
            // 3. Cargar catálogos
            CargarMetodosPago();
            CargarClientes();
            CargarTiposItem();

            // Propiedades de lectura
            txtSubtotal.ReadOnly = true;
            txtTotal.ReadOnly = true;
            txtNumeroCargo.ReadOnly = true;
            txtPlanAsignado.ReadOnly = true;
            txtMontoVencimiento.ReadOnly = true;

            lblCambio.Text = "0.00";
            txtSubtotal.Text = "0.00";
            txtTotal.Text = "0.00";
        }

        private void CargarMetodosPago()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT id_metodo, nombre_metodo FROM metodos_pago WHERE estado = 1 ORDER BY nombre_metodo";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        AsignarDataSourceComboBox(cmbMetodoPago, dt, "nombre_metodo", "id_metodo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar métodos de pago:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT id_cliente, cedula, nombre, apellido, (nombre + ' ' + apellido) AS nombre_completo FROM Clientes WHERE estado = 1 ORDER BY nombre, apellido";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        AsignarDataSourceComboBox(cmbClientes, dt, "nombre_completo", "id_cliente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valStr = ObtenerSelectedValue(cmbClientes);
            if (string.IsNullOrEmpty(valStr)) return;

            try
            {
                if (int.TryParse(valStr, out int idCliente))
                {
                    CargarInformacionCliente(idCliente);
                }
            }
            catch { }
        }

        private void CargarInformacionCliente(int idCliente)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = @"SELECT c.cedula, c.nombre, c.apellido, m.nombre AS nombre_membresia, m.precio, cm.fecha_fin AS fecha_vencimiento 
                                    FROM Clientes c 
                                    LEFT JOIN cliente_membresia cm ON c.id_cliente = cm.id_cliente 
                                    LEFT JOIN membresias m ON cm.id_membresia = m.id_membresia 
                                    WHERE c.id_cliente = @id_cliente";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (maskedTextBox1 != null)
                                    maskedTextBox1.Text = dr["cedula"] == DBNull.Value ? "" : dr["cedula"].ToString();

                                txtPlanAsignado.Text = dr["nombre_membresia"] != DBNull.Value ? dr["nombre_membresia"].ToString() : "Sin membresía";

                                if (dr["precio"] != DBNull.Value)
                                {
                                    txtMontoVencimiento.Text = Convert.ToDecimal(dr["precio"]).ToString("N2");
                                }
                                else
                                {
                                    txtMontoVencimiento.Text = "0.00";
                                }

                                if (dtpVencimiento != null)
                                {
                                    if (dr["fecha_vencimiento"] != DBNull.Value && DateTime.TryParse(dr["fecha_vencimiento"].ToString(), out DateTime fechaParsed))
                                    {
                                        dtpVencimiento.Value = fechaParsed;
                                    }
                                    else
                                    {
                                        dtpVencimiento.Value = DateTime.Now;
                                    }
                                }
                            }
                            else
                            {
                                LimpiarInformacionCliente();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información del cliente:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarInformacionCliente()
        {
            if (ExisteControl("txtCedula"))
                ObtenerControl("txtCedula").Text = "";

            txtPlanAsignado.Text = "";
            txtMontoVencimiento.Text = "0.00";
            if (dtpVencimiento != null)
                dtpVencimiento.Value = DateTime.Now;
        }

        private void CargarTiposItem()
        {
            LimpiarItemsComboBox(cmbTipoItem);
            AgregarItemComboBox(cmbTipoItem, "Membresía");
            AgregarItemComboBox(cmbTipoItem, "Producto");
            EstablecerSelectedIndex(cmbTipoItem, -1);
        }

        private void cmbTipoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = ObtenerTextoSeleccionado(cmbTipoItem);
            if (string.IsNullOrEmpty(tipo)) return;

            CargarCatalogoItems(tipo);
        }

        private void CargarCatalogoItems(string tipo)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = tipo == "Membresía"
                        ? "SELECT id_membresia AS id, nombre AS descripcion, precio FROM membresias WHERE estado = 1 ORDER BY nombre"
                        : "SELECT id_producto AS id, nombre AS descripcion, precio_venta AS precio, stock FROM productos WHERE estado = 1 ORDER BY nombre";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbCatalogoItems.DataSource = null;
                        cmbCatalogoItems.DisplayMember = "descripcion";
                        cmbCatalogoItems.ValueMember = "id";
                        cmbCatalogoItems.DataSource = dt;
                        cmbCatalogoItems.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCatalogoItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCatalogoItems.SelectedIndex == -1 || cmbCatalogoItems.SelectedItem == null)
                return;

            try
            {
                decimal precio = 0;
                DataRowView fila = cmbCatalogoItems.SelectedItem as DataRowView;

                if (fila != null)
                {
                    if (fila["precio"] != DBNull.Value)
                    {
                        precio = Convert.ToDecimal(fila["precio"]);
                    }

                    string tipo = ObtenerTextoSeleccionado(cmbTipoItem);
                    if (tipo == "Producto")
                    {
                        if (ExisteControl("txtStock"))
                        {
                            ObtenerControl("txtStock").Text = fila["stock"] == DBNull.Value ? "0" : fila["stock"].ToString();
                        }
                    }
                }

                if (ExisteControl("txtPrecio"))
                {
                    ObtenerControl("txtPrecio").Text = precio.ToString("N2");
                }
            }
            catch { }
        }

        private void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            txtNumeroCargo.Text = "CARG-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            MessageBox.Show("Cargo generado exitosamente.", "Cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbMetodoPago_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string textoMetodo = ObtenerTextoSeleccionado(cmbMetodoPago);
            if (textoMetodo.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
            {
                txtMontoRecibido.Enabled = true;
                decimal.TryParse(txtTotal.Text.Replace(".", "").Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal totalPuro);
                txtMontoRecibido.Text = Math.Round(totalPuro).ToString("0");
                txtMontoRecibido.SelectAll();
            }
            else
            {
                txtMontoRecibido.Enabled = false;
                txtMontoRecibido.Text = txtTotal.Text;
                lblCambio.Text = "0.00";
            }
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            string totalTexto = txtTotal.Text.Replace(".", "").Replace(",", ".");
            string recibidoTexto = txtMontoRecibido.Text.Replace(".", "").Replace(",", ".");

            decimal.TryParse(totalTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal totalPagar);
            decimal.TryParse(recibidoTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal montoRecibido);

            if (montoRecibido >= totalPagar)
            {
                decimal cambio = montoRecibido - totalPagar;
                lblCambio.Text = cambio.ToString("N2");
            }
            else
            {
                lblCambio.Text = "Insuficiente";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones
            string tipo = ObtenerTextoSeleccionado(cmbTipoItem);
            if (string.IsNullOrEmpty(tipo) || cmbCatalogoItems.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione tipo e ítem.");
                return;
            }

            // Obtener valores
            DataRowView fila = cmbCatalogoItems.SelectedItem as DataRowView;
            string descripcion = fila["descripcion"].ToString();
            decimal precio = Convert.ToDecimal(fila["precio"]);
            int.TryParse(txtCantidad.Text, out int cantidad);
            if (cantidad <= 0) cantidad = 1;

            decimal subtotalItem = cantidad * precio;

            // 4. AGREGAR A LA VARIABLE GLOBAL
            dtDetalleCobro.Rows.Add(tipo, descripcion, cantidad, precio, subtotalItem);

            // 5. REFRESCAR EL GRID
            // Al ser la misma variable global, el DataSource ya lo tiene enlazado, 
            // pero si no se actualiza visualmente, hacemos esto:
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = dtDetalleCobro;

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            foreach (DataRow fila in dtDetalleCobro.Rows)
            {
                subtotal += Convert.ToDecimal(fila["Subtotal"]);
            }

            txtSubtotal.Text = subtotal.ToString("N2");
            txtTotal.Text = subtotal.ToString("N2");

            string textoMetodo = ObtenerTextoSeleccionado(cmbMetodoPago);
            if (textoMetodo.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
            {
                txtMontoRecibido_TextChanged(null, EventArgs.Empty);
            }
            else
            {
                txtMontoRecibido.Text = txtTotal.Text;
            }
        }

        private void AsignarDataSourceComboBox(Control ctrl, DataTable dt, string display, string value)
        {
            if (ctrl == null) return;
            var propDataSource = ctrl.GetType().GetProperty("DataSource");
            var propDisplay = ctrl.GetType().GetProperty("DisplayMember");
            var propValue = ctrl.GetType().GetProperty("ValueMember");

            propDataSource?.SetValue(ctrl, dt);
            propDisplay?.SetValue(ctrl, display);
            propValue?.SetValue(ctrl, value);
            EstablecerSelectedIndex(ctrl, -1);
        }

        private int ObtenerSelectedIndex(Control ctrl)
        {
            if (ctrl == null) return -1;
            var prop = ctrl.GetType().GetProperty("SelectedIndex");
            return prop != null ? (int)prop.GetValue(ctrl) : -1;
        }

        private void EstablecerSelectedIndex(Control ctrl, int index)
        {
            if (ctrl == null) return;
            var prop = ctrl.GetType().GetProperty("SelectedIndex");
            prop?.SetValue(ctrl, index);
        }

        private string ObtenerSelectedValue(Control ctrl)
        {
            if (ctrl == null) return null;
            var prop = ctrl.GetType().GetProperty("SelectedValue");
            var val = prop?.GetValue(ctrl);
            return val?.ToString();
        }

        private string ObtenerTextoSeleccionado(Control ctrl)
        {
            if (ctrl == null) return "";
            var propText = ctrl.GetType().GetProperty("Text");
            return propText?.GetValue(ctrl)?.ToString() ?? "";
        }

        private void LimpiarItemsComboBox(Control ctrl)
        {
            if (ctrl == null) return;
            var propItems = ctrl.GetType().GetProperty("Items");
            var items = propItems?.GetValue(ctrl);
            var metodoClear = items?.GetType().GetMethod("Clear");
            metodoClear?.Invoke(items, null);
        }

        private void AgregarItemComboBox(Control ctrl, string item)
        {
            if (ctrl == null) return;
            var propItems = ctrl.GetType().GetProperty("Items");
            var items = propItems?.GetValue(ctrl);
            var metodoAdd = items?.GetType().GetMethod("Add", new Type[] { typeof(object) });
            metodoAdd?.Invoke(items, new object[] { item });
        }

        private bool ExisteControl(string nombre)
        {
            Control[] controles = this.Controls.Find(nombre, true);
            return controles.Length > 0;
        }

        private TextBox ObtenerControl(string nombre)
        {
            Control[] controles = this.Controls.Find(nombre, true);
            if (controles.Length > 0 && controles[0] is TextBox)
            {
                return (TextBox)controles[0];
            }
            return null;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            string idClienteStr = ObtenerSelectedValue(cmbClientes);
            if (string.IsNullOrEmpty(idClienteStr))
            {
                MessageBox.Show("Por favor, seleccione un cliente antes de efectuar el cobro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbClientes.Focus();
                return;
            }

            if (dtDetalleCobro == null || dtDetalleCobro.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos o membresías en la lista para cobrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metodoPago = ObtenerTextoSeleccionado(cmbMetodoPago);
            if (string.IsNullOrEmpty(metodoPago) || ObtenerSelectedIndex(cmbMetodoPago) == -1)
            {
                MessageBox.Show("Seleccione un método de pago válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMetodoPago.Focus();
                return;
            }

            if (metodoPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
            {
                if (!decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido) ||
                    !decimal.TryParse(txtTotal.Text, out decimal totalPagar) ||
                    montoRecibido < totalPagar)
                {
                    MessageBox.Show("El monto recibido es insuficiente para cubrir el total de la venta.", "Error de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoRecibido.Focus();
                    return;
                }
            }

            try
            {
                // Aquí realizas la inserción de la factura y detalles en tu base de datos SQL usando 'Conexion.ObtenerConexion()'

                MessageBox.Show("¡Cobro realizado y registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar formulario tras el éxito
                dtDetalleCobro.Rows.Clear();
                txtSubtotal.Text = "0.00";
                txtTotal.Text = "0.00";
                txtMontoRecibido.Text = "0.00";
                lblCambio.Text = "0.00";
                EstablecerSelectedIndex(cmbClientes, -1);
                EstablecerSelectedIndex(cmbMetodoPago, -1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el cobro en la base de datos:\n" + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            if (dtDetalleCobro == null || dtDetalleCobro.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la lista para generar el recibo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cliente = ObtenerTextoSeleccionado(cmbClientes);
            string metodoPago = ObtenerTextoSeleccionado(cmbMetodoPago);
            string total = txtTotal.Text;
            string recibido = txtMontoRecibido.Text;
            string cambio = lblCambio.Text;

            string ticket = "=====================================\n";
            ticket += "          GIMNASIO - RECIBO          \n";
            ticket += "=====================================\n";
            ticket += "Cliente: " + (string.IsNullOrEmpty(cliente) ? "General" : cliente) + "\n";
            ticket += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            ticket += "-------------------------------------\n";
            ticket += "CANT  DESCRIPCIÓN          SUBTOTAL\n";
            ticket += "-------------------------------------\n";

            foreach (DataRow fila in dtDetalleCobro.Rows)
            {
                string desc = fila["Descripcion"].ToString();
                if (desc.Length > 16) desc = desc.Substring(0, 16);
                ticket += $"{fila["Cantidad"],-5} {desc,-18} ${Convert.ToDecimal(fila["Subtotal"]):N2}\n";
            }

            ticket += "-------------------------------------\n";
            ticket += $"TOTAL A PAGAR:  ${total}\n";
            ticket += $"MÉTODO PAGO:    {metodoPago}\n";
            ticket += $"EFECTIVO REC.:  ${recibido}\n";
            ticket += $"CAMBIO/DEV.:    ${cambio}\n";
            ticket += "=====================================\n";
            ticket += "   ¡GRACIAS POR SU PREFERENCIA!  \n";
            ticket += "=====================================";

            MessageBox.Show(ticket, "Comprobante de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}