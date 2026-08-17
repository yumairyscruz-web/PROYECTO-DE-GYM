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
        private DataTable dtHistorialCliente = new DataTable();
        private bool cargandoClienteDesdeTabla = false;

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

            // La tabla de Cobros muestra todas las compras de todos los clientes.
            CargarTodosLosCobros();

            // Al hacer clic en una fila se carga ese cliente en los controles.
            dgvDetalle.CellClick -= dgvDetalle_CellClick;
            dgvDetalle.CellClick += dgvDetalle_CellClick;

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

            if (string.IsNullOrWhiteSpace(valStr) ||
                valStr == "System.Data.DataRowView")
            {
                // La tabla siempre muestra el historial general de TODOS los clientes.
                CargarTodosLosCobros();
                return;
            }

            try
            {
                if (int.TryParse(valStr, out int idCliente))
                {
                    // Cargar datos del cliente.
                    CargarInformacionCliente(idCliente);

                    // La tabla es general: no se filtra ni se vacía al cambiar de cliente.
                    // Solo se actualizan los datos del cliente arriba.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al seleccionar el cliente:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarInformacionCliente(int idCliente)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = @"
                SELECT TOP 1
                    c.cedula,
                    c.nombre,
                    c.apellido,
                    m.nombre AS nombre_membresia,
                    m.precio,
                    cm.fecha_fin AS fecha_vencimiento,

                    ca.id_cargo,
                    ca.concepto AS numero_cargo,
                    ca.monto AS monto_cargo,
                    ca.fecha_vencimiento AS vencimiento_cargo,
                    ca.estado AS estado_cargo

                FROM Clientes c

                LEFT JOIN cliente_membresia cm
                    ON c.id_cliente = cm.id_cliente
                    AND cm.estado = 1

                LEFT JOIN membresias m
                    ON cm.id_membresia = m.id_membresia

                OUTER APPLY
                (
                    SELECT TOP 1
                        id_cargo,
                        concepto,
                        monto,
                        fecha_vencimiento,
                        estado
                    FROM cargos
                    WHERE id_cliente = c.id_cliente
                      AND estado = 'Pendiente'
                    ORDER BY id_cargo DESC
                ) ca

                WHERE c.id_cliente = @id_cliente
            ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                // Cédula
                                if (maskedTextBox1 != null)
                                {
                                    maskedTextBox1.Text =
                                        dr["cedula"] == DBNull.Value
                                        ? ""
                                        : dr["cedula"].ToString();
                                }

                                // Membresía
                                txtPlanAsignado.Text =
                                    dr["nombre_membresia"] != DBNull.Value
                                    ? dr["nombre_membresia"].ToString()
                                    : "Sin membresía";

                                // Monto de la membresía
                                if (dr["precio"] != DBNull.Value)
                                {
                                    txtMontoVencimiento.Text =
                                        Convert.ToDecimal(dr["precio"])
                                        .ToString("N2", CultureInfo.InvariantCulture);
                                }
                                else
                                {
                                    txtMontoVencimiento.Text = "0.00";
                                }

                                // Fecha de vencimiento de membresía
                                if (dtpVencimiento != null)
                                {
                                    if (dr["fecha_vencimiento"] != DBNull.Value &&
                                        DateTime.TryParse(
                                            dr["fecha_vencimiento"].ToString(),
                                            out DateTime fechaParsed))
                                    {
                                        dtpVencimiento.Value = fechaParsed;
                                    }
                                }

                                // =====================================
                                // CARGO DEL CLIENTE
                                // =====================================

                                if (dr["id_cargo"] != DBNull.Value)
                                {
                                    int idCargo = Convert.ToInt32(dr["id_cargo"]);

                                    // En FormCargos el número visible se guarda en Cargos.concepto.
                                    txtNumeroCargo.Text =
                                        dr["numero_cargo"] == DBNull.Value
                                        ? idCargo.ToString()
                                        : dr["numero_cargo"].ToString();

                                    // Mostrar monto del cargo
                                    if (dr["monto_cargo"] != DBNull.Value)
                                    {
                                        txtMontoVencimiento.Text =
                                            Convert.ToDecimal(dr["monto_cargo"])
                                            .ToString("N2", CultureInfo.InvariantCulture);
                                    }

                                    // Mostrar fecha de vencimiento del cargo
                                    if (dr["vencimiento_cargo"] != DBNull.Value &&
                                        DateTime.TryParse(
                                            dr["vencimiento_cargo"].ToString(),
                                            out DateTime fechaCargo))
                                    {
                                        if (dtpVencimiento != null)
                                            dtpVencimiento.Value = fechaCargo;
                                    }
                                }
                                else
                                {
                                    txtNumeroCargo.Text = "";
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
                MessageBox.Show(
                    "Error al cargar la información del cliente:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string ObtenerNumeroCargo(int idCargo)
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    const string query = @"
                        SELECT TOP 1 concepto
                        FROM cargos
                        WHERE id_cargo = @id_cargo";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cargo", idCargo);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                            return resultado.ToString();
                    }
                }
            }
            catch
            {
                // Si numero_cargo no existe en la BD, no rompemos el formulario.
            }

            return idCargo.ToString();
        }

        private void LimpiarInformacionCliente()
        {
            if (ExisteControl("txtCedula"))
                ObtenerControl("txtCedula").Text = "";

            txtNumeroCargo.Text = "";
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
                        // SQL Server ya devuelve DECIMAL; conservar el valor
                        // numérico evita problemas de cultura decimal.
                        precio = Convert.ToDecimal(
                            fila["precio"],
                            CultureInfo.InvariantCulture);
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

            if (string.IsNullOrWhiteSpace(tipo) || cmbCatalogoItems.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione tipo e ítem.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DataRowView fila = cmbCatalogoItems.SelectedItem as DataRowView;
            if (fila == null)
                return;

            if (!int.TryParse(cmbCatalogoItems.SelectedValue?.ToString(), out int idItem))
            {
                MessageBox.Show(
                    "No se pudo obtener el ID del producto o membresía.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string descripcion = fila["descripcion"].ToString();

            // IMPORTANTE:
            // fila["precio"] viene de SQL Server como decimal.
            // No lo convertimos a texto para luego interpretarlo con
            // otra cultura, porque "4800,00" puede terminar convertido
            // incorrectamente en 480000.
            decimal precio;

            try
            {
                if (fila["precio"] == null || fila["precio"] == DBNull.Value)
                {
                    MessageBox.Show(
                        "El precio del artículo no es válido.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                precio = Convert.ToDecimal(
                    fila["precio"],
                    CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show(
                    "El precio del artículo no es válido.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (precio < 0)
            {
                MessageBox.Show(
                    "El precio del artículo no puede ser negativo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int cantidad = 1;

            if (!string.IsNullOrWhiteSpace(txtCantidad.Text))
                int.TryParse(txtCantidad.Text, out cantidad);

            if (cantidad <= 0)
                cantidad = 1;

            // Si el mismo producto/membresía ya está en la lista,
            // aumentamos la cantidad en lugar de crear otra fila.
            DataRow filaExistente = null;

            foreach (DataRow row in dtDetalleCobro.Rows)
            {
                if (row.RowState != DataRowState.Deleted &&
                    row["Tipo"].ToString().Equals(tipo, StringComparison.OrdinalIgnoreCase) &&
                    Convert.ToInt32(row["IdItem"]) == idItem)
                {
                    filaExistente = row;
                    break;
                }
            }

            if (filaExistente != null)
            {
                int nuevaCantidad = Convert.ToInt32(filaExistente["Cant"]) + cantidad;
                filaExistente["Cant"] = nuevaCantidad;
                filaExistente["Precio Unit."] = precio;
                filaExistente["Subtotal"] = nuevaCantidad * precio;
            }
            else
            {
                decimal subtotalItem = cantidad * precio;

                dtDetalleCobro.Rows.Add(
                    tipo,
                    idItem,
                    descripcion,
                    cantidad,
                    precio,
                    subtotalItem);
            }

            MostrarDetalleActual();

            if (dgvDetalle.Columns["IdItem"] != null)
                dgvDetalle.Columns["IdItem"].Visible = false;

            CalcularTotales();
        }

        private void MostrarDetalleActual()
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.AutoGenerateColumns = true;
            dgvDetalle.DataSource = dtDetalleCobro;

            if (dgvDetalle.Columns["IdItem"] != null)
                dgvDetalle.Columns["IdItem"].Visible = false;
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

        private void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            // Este botón puede utilizarse para preparar/generar el cargo del cliente.
            // Por ahora validamos que haya un cliente seleccionado para evitar errores.
            string idClienteStr = ObtenerSelectedValue(cmbClientes);

            if (string.IsNullOrEmpty(idClienteStr))
            {
                MessageBox.Show(
                    "Seleccione un cliente antes de generar el cargo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmbClientes.Focus();
                return;
            }

            MessageBox.Show(
                "El cliente está seleccionado y listo para generar el cargo.",
                "Cargo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

                    // 2. Insertar TODOS los detalles y manejar inventario / membresías
                    foreach (DataRow row in dtDetalleCobro.Rows)
                    {
                        string tipoItem = row["Tipo"].ToString();
                        int idItem = Convert.ToInt32(row["IdItem"]);
                        int cantidad = Convert.ToInt32(row["Cant"]);
                        decimal precioUnitario = Convert.ToDecimal(row["Precio Unit."]);
                        decimal subtotalItem = Convert.ToDecimal(row["Subtotal"]);
                        string descripcion = row["Descripción"].ToString();

                        // A) Si es membresía, registrar o vincular la membresía del cliente.
                        if (tipoItem.Equals("Membresía", StringComparison.OrdinalIgnoreCase))
                        {
                            string queryVerificarMemb = @"
                                SELECT TOP 1 id_cliente_membresia
                                FROM cliente_membresia
                                WHERE id_cliente = @id_cliente
                                  AND id_membresia = @id_membresia
                                ORDER BY id_cliente_membresia DESC";

                            using (SqlCommand cmdVerif = new SqlCommand(queryVerificarMemb, con, transaccion))
                            {
                                cmdVerif.Parameters.AddWithValue("@id_cliente", idCliente);
                                cmdVerif.Parameters.AddWithValue("@id_membresia", idItem);

                                object res = cmdVerif.ExecuteScalar();

                                if (res == null)
                                {
                                    string queryInsMemb = @"
                                        INSERT INTO cliente_membresia
                                        (id_cliente, id_membresia, fecha_inicio, fecha_fin, estado)
                                        VALUES
                                        (@id_cliente, @id_membresia, GETDATE(), DATEADD(day, 30, GETDATE()), 1)";

                                    using (SqlCommand cmdInsMemb = new SqlCommand(queryInsMemb, con, transaccion))
                                    {
                                        cmdInsMemb.Parameters.AddWithValue("@id_cliente", idCliente);
                                        cmdInsMemb.Parameters.AddWithValue("@id_membresia", idItem);
                                        cmdInsMemb.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        // B) Si es producto, descontar el inventario.
                        else if (tipoItem.Equals("Producto", StringComparison.OrdinalIgnoreCase))
                        {
                            string queryStock = @"
                                UPDATE productos
                                SET stock = stock - @cantidad
                                WHERE id_producto = @id_producto
                                  AND stock >= @cantidad";

                            using (SqlCommand cmdStock = new SqlCommand(queryStock, con, transaccion))
                            {
                                cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                                cmdStock.Parameters.AddWithValue("@id_producto", idItem);

                                int filasActualizadas = cmdStock.ExecuteNonQuery();

                                if (filasActualizadas == 0)
                                {
                                    throw new InvalidOperationException(
                                        "No hay suficiente stock para el producto: " + descripcion);
                                }
                            }
                        }

                        // C) MUY IMPORTANTE: guardar el detalle tanto para Producto como para Membresía.
                        string queryDetalle = @"
                            INSERT INTO detalle_cobro
                            (
                                id_pago,
                                tipo_item,
                                id_referencia,
                                descripcion,
                                cantidad,
                                precio_unitario,
                                subtotal
                            )
                            VALUES
                            (
                                @id_pago,
                                @tipo_item,
                                @id_referencia,
                                @descripcion,
                                @cantidad,
                                @precio_unitario,
                                @subtotal
                            )";

                        using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, con, transaccion))
                        {
                            cmdDetalle.Parameters.AddWithValue("@id_pago", idPago);
                            cmdDetalle.Parameters.AddWithValue("@tipo_item", tipoItem);
                            cmdDetalle.Parameters.AddWithValue("@id_referencia", idItem);
                            cmdDetalle.Parameters.AddWithValue("@descripcion", descripcion);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precio_unitario", precioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@subtotal", subtotalItem);

                            cmdDetalle.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();

                    MessageBox.Show("¡Cobro registrado con éxito en la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Limpiar la lista temporal para que el mismo detalle
                    // NO vuelva a insertarse en el próximo cobro.
                    dtDetalleCobro.Clear();

                    // 4. Volver a consultar la BD. La tabla muestra TODO el historial
                    // de compras de TODOS los clientes.
                    CargarTodosLosCobros();

                    // Restablecer los campos del cobro.
                    txtSubtotal.Text = "0.00";
                    txtTotal.Text = "0.00";
                    txtMontoRecibido.Text = "0.00";
                    lblCambio.Text = "0.00";

                    // Limpiar completamente los controles superiores.
                    EstablecerSelectedIndex(cmbClientes, -1);
                    EstablecerSelectedIndex(cmbMetodoPago, -1);

                    if (maskedTextBox1 != null)
                        maskedTextBox1.Text = "";

                    txtNumeroCargo.Text = "";
                    txtPlanAsignado.Text = "";
                    txtMontoVencimiento.Text = "0.00";

                    if (dtpVencimiento != null)
                        dtpVencimiento.Value = DateTime.Now;

                    // La tabla general permanece visible y se vuelve a consultar.
                    CargarTodosLosCobros();
                }
                catch (Exception ex)
                {
                    try { transaccion.Rollback(); } catch { }
                    MessageBox.Show("Error al procesar el cobro en la base de datos:\n" + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarTodosLosCobros()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    // No filtramos por cliente. Cada detalle se relaciona con su pago
                    // y cada pago con su cliente. El cargo se toma como el último cargo
                    // registrado para ese cliente, porque la tabla pagos no contiene
                    // una columna id_cargo en el código actual.
                    string query = @"
                        SELECT
                            p.id_pago AS IdPago,
                            p.id_cliente AS IdCliente,
                            (cli.nombre + ' ' + cli.apellido) AS Cliente,
                            cli.cedula AS Cédula,
                            ISNULL(ca.concepto, '') AS [Número de Cargo],
                            dc.tipo_item AS Tipo,
                            dc.id_referencia AS IdItem,
                            dc.descripcion AS Descripción,
                            dc.cantidad AS Cant,
                            dc.precio_unitario AS [Precio Unit.],
                            dc.subtotal AS Subtotal,
                            p.fecha_pago AS [Fecha Pago]
                        FROM pagos p
                        INNER JOIN Clientes cli
                            ON p.id_cliente = cli.id_cliente
                        INNER JOIN detalle_cobro dc
                            ON p.id_pago = dc.id_pago
                        OUTER APPLY
                        (
                            SELECT TOP 1 concepto
                            FROM cargos
                            WHERE id_cliente = p.id_cliente
                            ORDER BY id_cargo DESC
                        ) ca
                        ORDER BY p.id_pago DESC, dc.id_detalle_cobro DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dtHistorialCliente = dt;

                        dgvDetalle.DataSource = null;
                        dgvDetalle.AutoGenerateColumns = true;
                        dgvDetalle.DataSource = dtHistorialCliente;

                        if (dgvDetalle.Columns["IdItem"] != null)
                            dgvDetalle.Columns["IdItem"].Visible = false;
                        if (dgvDetalle.Columns["IdPago"] != null)
                            dgvDetalle.Columns["IdPago"].Visible = false;
                        if (dgvDetalle.Columns["IdCliente"] != null)
                            dgvDetalle.Columns["IdCliente"].Visible = false;

                        // Ajustar nombres/anchos para que la información sea legible.
                        if (dgvDetalle.Columns["Cliente"] != null)
                            dgvDetalle.Columns["Cliente"].HeaderText = "Cliente";
                        if (dgvDetalle.Columns["Número de Cargo"] != null)
                            dgvDetalle.Columns["Número de Cargo"].HeaderText = "Número de Cargo";
                        if (dgvDetalle.Columns["Descripción"] != null)
                            dgvDetalle.Columns["Descripción"].HeaderText = "Descripción";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar todas las compras desde la base de datos:\n" + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDetalle.Rows.Count)
                return;

            DataGridViewRow fila = dgvDetalle.Rows[e.RowIndex];
            if (fila.IsNewRow)
                return;

            try
            {
                object valorIdCliente = fila.Cells["IdCliente"]?.Value;
                if (valorIdCliente == null || valorIdCliente == DBNull.Value)
                    return;

                if (!int.TryParse(valorIdCliente.ToString(), out int idCliente))
                    return;

                cargandoClienteDesdeTabla = true;
                cmbClientes.SelectedValue = idCliente;
                cargandoClienteDesdeTabla = false;

                // Aseguramos que el cargo mostrado corresponda a la fila seleccionada.
                if (dgvDetalle.Columns["Número de Cargo"] != null)
                {
                    object cargo = fila.Cells["Número de Cargo"].Value;
                    txtNumeroCargo.Text = cargo == null || cargo == DBNull.Value
                        ? ""
                        : cargo.ToString();
                }
            }
            catch (Exception ex)
            {
                cargandoClienteDesdeTabla = false;
                MessageBox.Show(
                    "No se pudo cargar la información de la compra seleccionada:\n" + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            DataTable datosRecibo =
                (dtDetalleCobro != null && dtDetalleCobro.Rows.Count > 0)
                ? dtDetalleCobro
                : dtHistorialCliente;

            if (datosRecibo == null || datosRecibo.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos en la lista para generar el recibo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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

            foreach (DataRow fila in datosRecibo.Rows)
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