using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            ConfigurarLimitesNumericos();
            CargarComboCategorias();
            CargarComboMarcas(); // Carga dinámica de marcas desde la BD
            CargarTablaProductos();
            LimpiarCampos();
        }

        private void ConfigurarLimitesNumericos()
        {
            numPrecioCompra.Minimum = 0m;
            numPrecioCompra.Maximum = 1000000m;

            numPrecioVenta.Minimum = 0m;
            numPrecioVenta.Maximum = 1000000m;

            numStock.Minimum = 0m;
            numStock.Maximum = 100000m;

            numStockMinimo.Minimum = 0m;
            numStockMinimo.Maximum = 100000m;
        }

        private void CargarComboCategorias()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    string query = "SELECT id_categoria, nombre FROM categorias ORDER BY nombre ASC";
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
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboMarcas()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    string query = "SELECT id_marca, nombre FROM marcas ORDER BY nombre ASC";
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
                MessageBox.Show("Error al cargar marcas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTablaProductos(string filtro = "")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT p.id_producto AS [ID],
                                            p.codigo AS [Código],
                                            p.codigo_barras AS [Código Barras],
                                            p.nombre AS [Producto],
                                            c.nombre AS [Categoría],
                                            m.nombre AS [Marca],
                                            p.precio_compra AS [P. Compra],
                                            p.precio_venta AS [P. Venta],
                                            p.stock AS [Stock],
                                            p.stock_minimo AS [Stock Min.],
                                            CASE WHEN p.estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado],
                                            p.id_categoria,
                                            p.id_marca,
                                            p.descripcion
                                     FROM productos p
                                     INNER JOIN categorias c ON p.id_categoria = c.id_categoria
                                     INNER JOIN marcas m ON p.id_marca = m.id_marca
                                     WHERE p.nombre LIKE @filtro 
                                        OR p.codigo LIKE @filtro 
                                        OR p.codigo_barras LIKE @filtro
                                     ORDER BY p.id_producto DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvProductos.DataSource = dt;

                        // Ocultar IDs que solo sirven para la lógica interna
                        if (dgvProductos.Columns["id_categoria"] != null) dgvProductos.Columns["id_categoria"].Visible = false;
                        if (dgvProductos.Columns["id_marca"] != null) dgvProductos.Columns["id_marca"].Visible = false;
                        if (dgvProductos.Columns["descripcion"] != null) dgvProductos.Columns["descripcion"].Visible = false;

                        FormatearTabla();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearTabla()
        {
            if (dgvProductos.Columns.Count > 0)
            {
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProductos.MultiSelect = false;
                dgvProductos.AllowUserToAddRows = false;
                dgvProductos.ReadOnly = true;

                if (dgvProductos.Columns["P. Compra"] != null)
                    dgvProductos.Columns["P. Compra"].DefaultCellStyle.Format = "N2";
                if (dgvProductos.Columns["P. Venta"] != null)
                    dgvProductos.Columns["P. Venta"].DefaultCellStyle.Format = "N2";
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarTablaProductos(txtBuscar.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoría válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return;
            }

            if (cmbMarca.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una marca válida.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMarca.Focus();
                return;
            }

            byte estadoVal = (byte)(rbActivo.Checked ? 1 : 0);

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    if (string.IsNullOrEmpty(txtIdProducto.Text))
                    {
                        string queryInsert = @"INSERT INTO productos 
                                              (codigo, codigo_barras, nombre, descripcion, id_categoria, id_marca, precio_compra, precio_venta, stock, stock_minimo, estado) 
                                               VALUES 
                                              (@codigo, @codigo_barras, @nombre, @descripcion, @id_categoria, @id_marca, @precio_compra, @precio_venta, @stock, @stock_minimo, @estado)";

                        using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                        {
                            cmd.Parameters.AddWithValue("@codigo", string.IsNullOrWhiteSpace(txtCodigo.Text) ? DBNull.Value : (object)txtCodigo.Text.Trim());
                            cmd.Parameters.AddWithValue("@codigo_barras", string.IsNullOrWhiteSpace(txtCodigoBarras.Text) ? DBNull.Value : (object)txtCodigoBarras.Text.Trim());
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? DBNull.Value : (object)txtDescripcion.Text.Trim());
                            cmd.Parameters.AddWithValue("@id_categoria", Convert.ToInt32(cmbCategoria.SelectedValue));
                            cmd.Parameters.AddWithValue("@id_marca", Convert.ToInt32(cmbMarca.SelectedValue));
                            cmd.Parameters.AddWithValue("@precio_compra", numPrecioCompra.Value);
                            cmd.Parameters.AddWithValue("@precio_venta", numPrecioVenta.Value);
                            cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(numStock.Value));
                            cmd.Parameters.AddWithValue("@stock_minimo", Convert.ToInt32(numStockMinimo.Value));
                            cmd.Parameters.AddWithValue("@estado", estadoVal);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string queryUpdate = @"UPDATE productos SET 
                                                codigo = @codigo,
                                                codigo_barras = @codigo_barras,
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
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtIdProducto.Text));
                            cmd.Parameters.AddWithValue("@codigo", string.IsNullOrWhiteSpace(txtCodigo.Text) ? DBNull.Value : (object)txtCodigo.Text.Trim());
                            cmd.Parameters.AddWithValue("@codigo_barras", string.IsNullOrWhiteSpace(txtCodigoBarras.Text) ? DBNull.Value : (object)txtCodigoBarras.Text.Trim());
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? DBNull.Value : (object)txtDescripcion.Text.Trim());
                            cmd.Parameters.AddWithValue("@id_categoria", Convert.ToInt32(cmbCategoria.SelectedValue));
                            cmd.Parameters.AddWithValue("@id_marca", Convert.ToInt32(cmbMarca.SelectedValue));
                            cmd.Parameters.AddWithValue("@precio_compra", numPrecioCompra.Value);
                            cmd.Parameters.AddWithValue("@precio_venta", numPrecioVenta.Value);
                            cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(numStock.Value));
                            cmd.Parameters.AddWithValue("@stock_minimo", Convert.ToInt32(numStockMinimo.Value));
                            cmd.Parameters.AddWithValue("@estado", estadoVal);

                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                CargarTablaProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Seleccione un producto de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtNombre.Focus();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                txtIdProducto.Text = row.Cells["ID"].Value?.ToString() ?? "";
                txtCodigo.Text = row.Cells["Código"].Value?.ToString() ?? "";
                txtCodigoBarras.Text = row.Cells["Código Barras"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["Producto"].Value?.ToString() ?? "";
                txtDescripcion.Text = row.Cells["descripcion"].Value?.ToString() ?? "";

                if (row.Cells["id_categoria"].Value != DBNull.Value && row.Cells["id_categoria"].Value != null)
                    cmbCategoria.SelectedValue = Convert.ToInt32(row.Cells["id_categoria"].Value);
                else
                    cmbCategoria.SelectedIndex = -1;

                if (row.Cells["id_marca"].Value != DBNull.Value && row.Cells["id_marca"].Value != null)
                    cmbMarca.SelectedValue = Convert.ToInt32(row.Cells["id_marca"].Value);
                else
                    cmbMarca.SelectedIndex = -1;

                numPrecioCompra.Value = decimal.TryParse(row.Cells["P. Compra"].Value?.ToString(), out decimal pc) ? pc : 0m;
                numPrecioVenta.Value = decimal.TryParse(row.Cells["P. Venta"].Value?.ToString(), out decimal pv) ? pv : 0m;
                numStock.Value = decimal.TryParse(row.Cells["Stock"].Value?.ToString(), out decimal st) ? st : 0m;
                numStockMinimo.Value = decimal.TryParse(row.Cells["Stock Min."].Value?.ToString(), out decimal sm) ? sm : 5m;

                string estado = row.Cells["Estado"].Value?.ToString() ?? "Activo";
                if (estado == "Activo") rbActivo.Checked = true; else rbInactivo.Checked = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIdProducto.Clear();
            txtCodigo.Clear();
            txtCodigoBarras.Clear();
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
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Seleccione un producto para inactivar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de inactivar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        string query = "UPDATE productos SET estado = 0 WHERE id_producto = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtIdProducto.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Producto inactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaProductos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}