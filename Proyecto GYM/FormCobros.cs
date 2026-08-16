using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
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
                dtDetalleCobro.Columns.Add("IdItem", typeof(int)); // ID base (id_membresia o id_producto)
                dtDetalleCobro.Columns.Add("Descripción", typeof(string));
                dtDetalleCobro.Columns.Add("Cant", typeof(int));
                dtDetalleCobro.Columns.Add("Precio Unit.", typeof(decimal));
                dtDetalleCobro.Columns.Add("Subtotal", typeof(decimal));
            }

            // 2. Vincular correctamente al DataGridView
            dgvDetalle.DataSource = null;
            dgvDetalle.AutoGenerateColumns = true;
            dgvDetalle.DataSource = dtDetalleCobro;

            // Ocultar la columna interna de ID para una vista más limpia
            if (dgvDetalle.Columns["IdItem"] != null)
                dgvDetalle.Columns["IdItem"].Visible = false;

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
                                    txtMontoVencimiento.Text = Convert.ToDecimal(dr["precio"]).ToString("N2", CultureInfo.InvariantCulture);
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
                    ObtenerControl("txtPrecio").Text = precio.ToString("N2", CultureInfo.InvariantCulture);
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
                decimal.TryParse(txtTotal.Text.Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalPuro);
                txtMontoRecibido.Text = Math.Round(totalPuro).ToString("0", CultureInfo.InvariantCulture);
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
            string totalTexto = txtTotal.Text.Replace(",", "");
            string recibidoTexto = txtMontoRecibido.Text.Replace(",", "");

            decimal.TryParse(totalTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalPagar);
            decimal.TryParse(recibidoTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal montoRecibido);

            if (montoRecibido >= totalPagar)
            {
                decimal cambio = montoRecibido - totalPagar;
                lblCambio.Text = cambio.ToString("N2", CultureInfo.InvariantCulture);
            }
            else
            {
                lblCambio.Text = "Insuficiente";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = ObtenerTextoSeleccionado(cmbTipoItem);
            if (string.IsNullOrEmpty(tipo) || cmbCatalogoItems.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione tipo e ítem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView fila = cmbCatalogoItems.SelectedItem as DataRowView;
            if (fila == null) return;

            int idItem = Convert.ToInt32(cmbCatalogoItems.SelectedValue);
            string descripcion = fila["descripcion"].ToString();
            decimal precio = Convert.ToDecimal(fila["precio"]);

            int.TryParse(txtCantidad.Text, out int cantidad);
            if (cantidad <= 0) cantidad = 1;

            decimal subtotalItem = cantidad * precio;

            // Agregar la fila al DataTable en memoria
            dtDetalleCobro.Rows.Add(tipo, idItem, descripcion, cantidad, precio, subtotalItem);

            // Asegurar que la columna ID permanezca oculta
            if (dgvDetalle.Columns["IdItem"] != null)
            {
                dgvDetalle.Columns["IdItem"].Visible = false;
            }

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            foreach (DataRow fila in dtDetalleCobro.Rows)
            {
                subtotal += Convert.ToDecimal(fila["Subtotal"]);
            }

            txtSubtotal.Text = subtotal.ToString("N2", CultureInfo.InvariantCulture);
            txtTotal.Text = subtotal.ToString("N2", CultureInfo.InvariantCulture);

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

            string metodoPagoText = ObtenerTextoSeleccionado(cmbMetodoPago);
            if (string.IsNullOrEmpty(metodoPagoText) || ObtenerSelectedIndex(cmbMetodoPago) == -1)
            {
                MessageBox.Show("Seleccione un método de pago válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMetodoPago.Focus();
                return;
            }

            // Validación de efectivo si aplica
            if (metodoPagoText.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
            {
                if (!decimal.TryParse(txtMontoRecibido.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal montoRecibido) ||
                    !decimal.TryParse(txtTotal.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalPagar) ||
                    montoRecibido < totalPagar)
                {
                    MessageBox.Show("El monto recibido es insuficiente para cubrir el total del cobro.", "Error de Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoRecibido.Focus();
                    return;
                }
            }

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlTransaction transaccion = con.BeginTransaction();

                try
                {
                    int idCliente = Convert.ToInt32(idClienteStr);
                    decimal montoTotal = Convert.ToDecimal(txtTotal.Text, CultureInfo.InvariantCulture);
                    int idUsuarioSesion = 1; // ID del usuario logueado actualmente
                    int idMetodoPago = Convert.ToInt32(ObtenerSelectedValue(cmbMetodoPago));

                    // 1. Insertar la cabecera del pago usando las columnas reales de la base de datos (fecha_pago e id_metodo)
                    string queryPago = @"INSERT INTO pagos (id_cliente, id_usuario, fecha_pago, monto_total, id_metodo) 
                                       OUTPUT INSERTED.id_pago 
                                       VALUES (@id_cliente, @id_usuario, GETDATE(), @monto_total, @id_metodo)";

                    int idPago;
                    using (SqlCommand cmdPago = new SqlCommand(queryPago, con, transaccion))
                    {
                        cmdPago.Parameters.AddWithValue("@id_cliente", idCliente);
                        cmdPago.Parameters.AddWithValue("@id_usuario", idUsuarioSesion);
                        cmdPago.Parameters.AddWithValue("@monto_total", montoTotal);
                        cmdPago.Parameters.AddWithValue("@id_metodo", idMetodoPago);

                        idPago = (int)cmdPago.ExecuteScalar();
                    }

                    // 2. Insertar los detalles y manejar inventario / membresías
                    foreach (DataRow row in dtDetalleCobro.Rows)
                    {
                        string tipoItem = row["Tipo"].ToString();
                        int idItem = Convert.ToInt32(row["IdItem"]);
                        int cantidad = Convert.ToInt32(row["Cant"]);
                        decimal subtotalItem = Convert.ToDecimal(row["Subtotal"]);

                        if (tipoItem.Equals("Membresía", StringComparison.OrdinalIgnoreCase))
                        {
                            // A) Registrar o vincular la membresía al cliente en 'cliente_membresia' si es necesario
                            string queryVerificarMemb = "SELECT TOP 1 id_cliente_membresia FROM cliente_membresia WHERE id_cliente = @id_cliente AND id_membresia = @id_membresia ORDER BY id_cliente_membresia DESC";
                            int idClienteMembresia = 0;

                            using (SqlCommand cmdVerif = new SqlCommand(queryVerificarMemb, con, transaccion))
                            {
                                cmdVerif.Parameters.AddWithValue("@id_cliente", idCliente);
                                cmdVerif.Parameters.AddWithValue("@id_membresia", idItem);
                                var res = cmdVerif.ExecuteScalar();
                                if (res != null)
                                {
                                    idClienteMembresia = Convert.ToInt32(res);
                                }
                                else
                                {
                                    // Si no existe un registro previo activo, lo insertamos automáticamente (por ejemplo, 30 días de vigencia)
                                    string queryInsMemb = @"INSERT INTO cliente_membresia (id_cliente, id_membresia, fecha_inicio, fecha_fin, estado) 
                                                           OUTPUT INSERTED.id_cliente_membresia 
                                                           VALUES (@id_cliente, @id_membresia, GETDATE(), DATEADD(day, 30, GETDATE()), 1)";
                                    using (SqlCommand cmdInsMemb = new SqlCommand(queryInsMemb, con, transaccion))
                                    {
                                        cmdInsMemb.Parameters.AddWithValue("@id_cliente", idCliente);
                                        cmdInsMemb.Parameters.AddWithValue("@id_membresia", idItem);
                                        idClienteMembresia = (int)cmdInsMemb.ExecuteScalar();
                                    }
                                }
                            }

                            // Insertar en pagos_detalle vinculando el id_cliente_membresia
                            string queryDetalleMemb = @"INSERT INTO pagos_detalle (id_pago, id_cliente_membresia, monto) 
                                                     VALUES (@id_pago, @id_cliente_membresia, @monto)";
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalleMemb, con, transaccion))
                            {
                                cmdDetalle.Parameters.AddWithValue("@id_pago", idPago);
                                cmdDetalle.Parameters.AddWithValue("@id_cliente_membresia", idClienteMembresia);
                                cmdDetalle.Parameters.AddWithValue("@monto", subtotalItem);
                                cmdDetalle.ExecuteNonQuery();
                            }
                        }
                        else if (tipoItem.Equals("Producto", StringComparison.OrdinalIgnoreCase))
                        {
                            // B) Si es producto, actualizamos el stock directamente
                            string queryStock = "UPDATE productos SET stock = stock - @cantidad WHERE id_producto = @id_producto";
                            using (SqlCommand cmdStock = new SqlCommand(queryStock, con, transaccion))
                            {
                                cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdStock.Parameters.AddWithValue("@id_producto", idItem);
                                cmdStock.ExecuteNonQuery();
                            }
                        }
                    }

                    transaccion.Commit();

                    MessageBox.Show("¡Cobro registrado con éxito en la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. CONSULTAR EL HISTORIAL DEL CLIENTE PARA VERLO REFLEJADO EN LA TABLA dgvDetalle
                    CargarHistorialCobrosCliente(idCliente);

                    // Restablecer campos adicionales de pago (dejando el historial visible en la tabla)
                    txtSubtotal.Text = "0.00";
                    txtTotal.Text = "0.00";
                    txtMontoRecibido.Text = "0.00";
                    lblCambio.Text = "0.00";
                    EstablecerSelectedIndex(cmbClientes, -1);
                    EstablecerSelectedIndex(cmbMetodoPago, -1);
                    LimpiarInformacionCliente();
                }
                catch (Exception ex)
                {
                    try { transaccion.Rollback(); } catch { }
                    MessageBox.Show("Error al procesar el cobro en la base de datos:\n" + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarHistorialCobrosCliente(int idCliente)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    // Consulta que une el pago con sus detalles reales (Membresías o Productos)
                    string queryHistorial = @"SELECT 
                                        'Membresía' AS Tipo,
                                        m.id_membresia AS IdItem,
                                        m.nombre AS Descripción,
                                        1 AS Cant,
                                        pd.monto AS [Precio Unit.],
                                        pd.monto AS Subtotal
                                      FROM pagos p
                                      INNER JOIN pagos_detalle pd ON p.id_pago = pd.id_pago
                                      INNER JOIN cliente_membresia cm ON pd.id_cliente_membresia = cm.id_cliente_membresia
                                      INNER JOIN membresias m ON cm.id_membresia = m.id_membresia
                                      WHERE p.id_cliente = @id_cliente
                                      
                                      UNION ALL

                                      SELECT 
                                        'Pago' AS Tipo,
                                        p.id_pago AS IdItem,
                                        'Transacción ID: ' + CAST(p.id_pago AS VARCHAR) AS Descripción,
                                        1 AS Cant,
                                        p.monto_total AS [Precio Unit.],
                                        p.monto_total AS Subtotal
                                      FROM pagos p
                                      WHERE p.id_cliente = @id_cliente 
                                        AND NOT EXISTS (SELECT 1 FROM pagos_detalle pd WHERE pd.id_pago = p.id_pago)";

                    using (SqlCommand cmd = new SqlCommand(queryHistorial, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        dtDetalleCobro.Rows.Clear();
                        da.Fill(dtDetalleCobro);

                        dgvDetalle.DataSource = null;
                        dgvDetalle.DataSource = dtDetalleCobro;

                        if (dgvDetalle.Columns["IdItem"] != null)
                        {
                            dgvDetalle.Columns["IdItem"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la tabla de detalles:\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ticket += "         GIMNASIO - RECIBO           \n";
            ticket += "=====================================\n";
            ticket += "Cliente: " + (string.IsNullOrEmpty(cliente) ? "General" : cliente) + "\n";
            ticket += "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            ticket += "-------------------------------------\n";
            ticket += "CANT  DESCRIPCIÓN         SUBTOTAL\n";
            ticket += "-------------------------------------\n";

            foreach (DataRow fila in dtDetalleCobro.Rows)
            {
                string desc = fila["Descripción"].ToString();
                if (desc.Length > 16) desc = desc.Substring(0, 16);
                ticket += $"{fila["Cant"],-5} {desc,-18} ${Convert.ToDecimal(fila["Subtotal"]):N2}\n";
            }

            ticket += "-------------------------------------\n";
            ticket += $"TOTAL A PAGAR:  ${total}\n";
            ticket += $"MÉTODO PAGO:    {metodoPago}\n";
            ticket += $"EFECTIVO REC.:  ${recibido}\n";
            ticket += $"CAMBIO/DEV.:    ${cambio}\n";
            ticket += "=====================================\n";
            ticket += "   ¡GRACIAS POR SU PREFERENCIA!      \n";
            ticket += "=====================================";

            MessageBox.Show(ticket, "Comprobante de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}