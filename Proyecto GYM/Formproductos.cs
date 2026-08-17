using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FormProductos : Form
    {
        private int idProductoSeleccionado = 0;

        public FormProductos()
        {
            InitializeComponent();

            txtNombre.KeyPress += txtSoloLetras_KeyPress;
            txtDescripcion.KeyPress += txtSoloLetras_KeyPress;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            ConfigurarLimitesNumericos();
            CargarComboCategorias();
            CargarComboMarcas();
            CargarTablaProductos();
            LimpiarCampos();
        }

        private void txtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void ConfigurarLimitesNumericos()
        {
            numPrecioCompra.Minimum = 0m;
            numPrecioCompra.Maximum = 100000000m;
            numPrecioCompra.DecimalPlaces = 2;
            numPrecioCompra.ThousandsSeparator = true;

            numPrecioVenta.Minimum = 0m;
            numPrecioVenta.Maximum = 100000000m;
            numPrecioVenta.DecimalPlaces = 2;
            numPrecioVenta.ThousandsSeparator = true;

            numStock.Minimum = 0m;
            numStock.Maximum = 100000m;
            numStock.DecimalPlaces = 0;
            numStock.ThousandsSeparator = true;

            numStockMinimo.Minimum = 0m;
            numStockMinimo.Maximum = 100000m;
            numStockMinimo.DecimalPlaces = 0;
            numStockMinimo.ThousandsSeparator = true;
        }

        private void CargarComboCategorias()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = @"
                        SELECT id_categoria, nombre
                        FROM categorias
                        ORDER BY nombre ASC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbCategoria.DataSource = dt;
                        cmbCategoria.DisplayMember = "nombre";
                        cmbCategoria.ValueMember = "id_categoria";
                        cmbCategoria.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar categorías: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarComboMarcas()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = @"
                        SELECT id_marca, nombre
                        FROM marcas
                        ORDER BY nombre ASC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbMarca.DataSource = dt;
                        cmbMarca.DisplayMember = "nombre";
                        cmbMarca.ValueMember = "id_marca";
                        cmbMarca.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar marcas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarTablaProductos(string filtro = "")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = @"
                        SELECT
                            p.id_producto AS [ID],
                            p.nombre AS [Producto],
                            c.nombre AS [Categoría],
                            m.nombre AS [Marca],
                            p.precio_compra AS [P. Compra],
                            p.precio_venta AS [P. Venta],
                            p.stock AS [Stock],
                            p.stock_minimo AS [Stock Min.],
                            CASE
                                WHEN p.estado = 1 THEN 'Activo'
                                ELSE 'Inactivo'
                            END AS [Estado],
                            p.id_categoria,
                            p.id_marca,
                            p.descripcion
                        FROM productos p
                        INNER JOIN categorias c
                            ON p.id_categoria = c.id_categoria
                        INNER JOIN marcas m
                            ON p.id_marca = m.id_marca
                        WHERE p.nombre LIKE @filtro
                        ORDER BY p.id_producto DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvProductos.DataSource = null;
                        dgvProductos.DataSource = dt;

                        OcultarColumna("ID");
                        OcultarColumna("id_categoria");
                        OcultarColumna("id_marca");
                        OcultarColumna("descripcion");

                        FormatearTabla();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar productos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OcultarColumna(string nombreColumna)
        {
            DataGridViewColumn col = dgvProductos.Columns[nombreColumna];

            if (col != null)
                col.Visible = false;
        }

        private void FormatearTabla()
        {
            if (dgvProductos.Columns.Count == 0)
                return;

            dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.MultiSelect = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ReadOnly = true;

            DataGridViewColumn colCompra = dgvProductos.Columns["P. Compra"];
            if (colCompra != null)
                colCompra.DefaultCellStyle.Format = "N2";

            DataGridViewColumn colVenta = dgvProductos.Columns["P. Venta"];
            if (colVenta != null)
                colVenta.DefaultCellStyle.Format = "N2";

            DataGridViewColumn colStock = dgvProductos.Columns["Stock"];
            if (colStock != null)
                colStock.DefaultCellStyle.Format = "N0";

            DataGridViewColumn colStockMin = dgvProductos.Columns["Stock Min."];
            if (colStockMin != null)
                colStockMin.DefaultCellStyle.Format = "N0";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarTablaProductos(txtBuscar.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado != 0)
            {
                MessageBox.Show(
                    "Estás seleccionando un producto existente. Utiliza el botón 'Editar' para guardar los cambios.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del producto.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbCategoria.SelectedValue == null ||
                cmbMarca.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione una categoría y una marca válidas.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            byte estadoVal = (byte)(rbActivo.Checked ? 1 : 0);

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string queryInsert = @"
                        INSERT INTO productos
                        (
                            nombre,
                            descripcion,
                            id_categoria,
                            id_marca,
                            precio_compra,
                            precio_venta,
                            stock,
                            stock_minimo,
                            estado
                        )
                        VALUES
                        (
                            @nombre,
                            @descripcion,
                            @id_categoria,
                            @id_marca,
                            @precio_compra,
                            @precio_venta,
                            @stock,
                            @stock_minimo,
                            @estado
                        )";

                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue(
                            "@descripcion",
                            string.IsNullOrWhiteSpace(txtDescripcion.Text)
                                ? DBNull.Value
                                : (object)txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_categoria", Convert.ToInt32(cmbCategoria.SelectedValue));
                        cmd.Parameters.AddWithValue("@id_marca", Convert.ToInt32(cmbMarca.SelectedValue));
                        cmd.Parameters.AddWithValue("@precio_compra", numPrecioCompra.Value);
                        cmd.Parameters.AddWithValue("@precio_venta", numPrecioVenta.Value);
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(numStock.Value));
                        cmd.Parameters.AddWithValue("@stock_minimo", Convert.ToInt32(numStockMinimo.Value));
                        cmd.Parameters.AddWithValue("@estado", estadoVal);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Producto registrado con éxito.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtBuscar.Clear();
                CargarTablaProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar el producto: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto de la tabla para editar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del producto.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbCategoria.SelectedValue == null ||
                cmbMarca.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione una categoría y una marca válidas.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            byte estadoVal = (byte)(rbActivo.Checked ? 1 : 0);

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string queryUpdate = @"
                        UPDATE productos
                        SET
                            nombre = @nombre,
                            descripcion = @descripcion,
                            id_categoria = @id_categoria,
                            id_marca = @id_marca,
                            precio_compra = @precio_compra,
                            precio_venta = @precio_venta,
                            stock = @stock,
                            stock_minimo = @stock_minimo,
                            estado = @estado
                        WHERE id_producto = @id";

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idProductoSeleccionado);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue(
                            "@descripcion",
                            string.IsNullOrWhiteSpace(txtDescripcion.Text)
                                ? DBNull.Value
                                : (object)txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_categoria", Convert.ToInt32(cmbCategoria.SelectedValue));
                        cmd.Parameters.AddWithValue("@id_marca", Convert.ToInt32(cmbMarca.SelectedValue));
                        cmd.Parameters.AddWithValue("@precio_compra", numPrecioCompra.Value);
                        cmd.Parameters.AddWithValue("@precio_venta", numPrecioVenta.Value);
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(numStock.Value));
                        cmd.Parameters.AddWithValue("@stock_minimo", Convert.ToInt32(numStockMinimo.Value));
                        cmd.Parameters.AddWithValue("@estado", estadoVal);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Producto actualizado con éxito.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtBuscar.Clear();
                CargarTablaProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar el producto: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

            if (row.Cells["ID"].Value != null &&
                int.TryParse(row.Cells["ID"].Value.ToString(), out int id))
            {
                idProductoSeleccionado = id;
            }
            else
            {
                idProductoSeleccionado = 0;
            }

            txtNombre.Text = row.Cells["Producto"].Value?.ToString() ?? "";
            txtDescripcion.Text = row.Cells["descripcion"].Value?.ToString() ?? "";

            if (row.Cells["id_categoria"].Value != null &&
                row.Cells["id_categoria"].Value != DBNull.Value)
            {
                cmbCategoria.SelectedValue =
                    Convert.ToInt32(row.Cells["id_categoria"].Value);
            }
            else
            {
                cmbCategoria.SelectedIndex = -1;
            }

            if (row.Cells["id_marca"].Value != null &&
                row.Cells["id_marca"].Value != DBNull.Value)
            {
                cmbMarca.SelectedValue =
                    Convert.ToInt32(row.Cells["id_marca"].Value);
            }
            else
            {
                cmbMarca.SelectedIndex = -1;
            }

            decimal precioCompra = LeerDecimal(
                row.Cells["P. Compra"].Value,
                0m);

            decimal precioVenta = LeerDecimal(
                row.Cells["P. Venta"].Value,
                0m);

            numPrecioCompra.Value = LimitarValor(
                precioCompra,
                numPrecioCompra.Minimum,
                numPrecioCompra.Maximum);

            numPrecioVenta.Value = LimitarValor(
                precioVenta,
                numPrecioVenta.Minimum,
                numPrecioVenta.Maximum);

            decimal stock = LeerDecimal(
                row.Cells["Stock"].Value,
                0m);

            if (stock < 0m)
                stock = 0m;

            decimal stockMinimo = LeerDecimal(
                row.Cells["Stock Min."].Value,
                5m);

            if (stockMinimo < 0m)
                stockMinimo = 0m;

            numStock.Value = LimitarValor(
                stock,
                numStock.Minimum,
                numStock.Maximum);

            numStockMinimo.Value = LimitarValor(
                stockMinimo,
                numStockMinimo.Minimum,
                numStockMinimo.Maximum);

            string estado =
                row.Cells["Estado"].Value?.ToString() ?? "Activo";

            rbActivo.Checked = estado.Equals(
                "Activo",
                StringComparison.OrdinalIgnoreCase);

            rbInactivo.Checked = !rbActivo.Checked;
        }

        private decimal LeerDecimal(object valor, decimal valorPredeterminado)
        {
            if (valor == null || valor == DBNull.Value)
                return valorPredeterminado;

            if (valor is decimal decimalDirecto)
                return decimalDirecto;

            string texto = valor.ToString()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(texto))
                return valorPredeterminado;

            if (decimal.TryParse(
                texto,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal resultado))
            {
                return resultado;
            }

            if (decimal.TryParse(
                texto,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out resultado))
            {
                return resultado;
            }

            string normalizado = texto.Replace(" ", "");

            int ultimaComa = normalizado.LastIndexOf(',');
            int ultimoPunto = normalizado.LastIndexOf('.');

            if (ultimaComa >= 0 && ultimoPunto >= 0)
            {
                if (ultimaComa > ultimoPunto)
                {
                    normalizado = normalizado
                        .Replace(".", "")
                        .Replace(",", ".");
                }
                else
                {
                    normalizado = normalizado.Replace(",", "");
                }
            }
            else if (ultimaComa >= 0)
            {
                normalizado = normalizado.Replace(",", ".");
            }

            if (decimal.TryParse(
                normalizado,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out resultado))
            {
                return resultado;
            }

            return valorPredeterminado;
        }

        private decimal LimitarValor(
            decimal valor,
            decimal minimo,
            decimal maximo)
        {
            if (valor < minimo)
                return minimo;

            if (valor > maximo)
                return maximo;

            return valor;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idProductoSeleccionado = 0;

            txtNombre.Clear();
            txtDescripcion.Clear();

            cmbCategoria.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;

            numPrecioCompra.Value = 0m;
            numPrecioVenta.Value = 0m;
            numStock.Value = 0m;
            numStockMinimo.Value = 5m;

            rbActivo.Checked = true;

            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto para inactivar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de inactivar este producto?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = @"
                        UPDATE productos
                        SET estado = 0
                        WHERE id_producto = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            idProductoSeleccionado);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Producto inactivado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtBuscar.Clear();
                CargarTablaProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar el estado: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}