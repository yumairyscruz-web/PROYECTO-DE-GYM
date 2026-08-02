using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            CargarTablaCategorias();
            LimpiarCampos();
        }

        // Carga la tabla aplicando filtro por Nombre o Descripción desde la tabla Categorias
        private void CargarTablaCategorias(string filtro = "")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = @"SELECT id_categoria AS [Código], 
                                            nombre AS [Nombre], 
                                            descripcion AS [Descripción], 
                                            estado AS [Estado] 
                                     FROM Categorias 
                                     WHERE nombre LIKE @filtro OR descripcion LIKE @filtro";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro.Trim() + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCategorias.DataSource = dt;
                        FormatearTabla();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearTabla()
        {
            if (dgvCategorias.Columns.Count > 0)
            {
                dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCategorias.MultiSelect = false;
                dgvCategorias.AllowUserToAddRows = false;
                dgvCategorias.ReadOnly = true;

                dgvCategorias.Columns["Código"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCategorias.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvCategorias.Columns["Código"].FillWeight = 50;
                dgvCategorias.Columns["Nombre"].FillWeight = 100;
                dgvCategorias.Columns["Descripción"].FillWeight = 150;
                dgvCategorias.Columns["Estado"].FillWeight = 60;
            }
        }

        // Consulta sobre la tabla Categorias para verificar duplicados
        private bool ExisteNombreCategoria(string nombre, string idActual = "")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = "SELECT COUNT(*) FROM Categorias WHERE LOWER(nombre) = LOWER(@nombre)";

                    if (!string.IsNullOrEmpty(idActual))
                    {
                        query += " AND id_categoria <> @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                        if (!string.IsNullOrEmpty(idActual))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idActual));
                        }

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarTablaCategorias(txtBuscar.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la categoría.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (ExisteNombreCategoria(txtNombre.Text, txtIdCategoria.Text))
            {
                MessageBox.Show("Ya existe una categoría registrada con este nombre.", "Nombre Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            string estadoSeleccionado = rbActivo.Checked ? "Activo" : "Inactivo";

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    if (string.IsNullOrEmpty(txtIdCategoria.Text))
                    {
                        string queryInsert = "INSERT INTO Categorias (nombre, descripcion, estado) VALUES (@nombre, @descripcion, @estado)";
                        using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
                            cmd.Parameters.AddWithValue("@estado", estadoSeleccionado);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Categoría guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string queryUpdate = "UPDATE Categorias SET nombre = @nombre, descripcion = @descripcion, estado = @estado WHERE id_categoria = @id";
                        using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtIdCategoria.Text));
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
                            cmd.Parameters.AddWithValue("@estado", estadoSeleccionado);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Categoría actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                CargarTablaCategorias();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null && dgvCategorias.CurrentRow.Index >= 0)
            {
                CargarDatosFilaSeleccionada(dgvCategorias.CurrentRow);
            }
            else
            {
                MessageBox.Show("Seleccione una categoría de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarDatosFilaSeleccionada(dgvCategorias.Rows[e.RowIndex]);
            }
        }

        private void CargarDatosFilaSeleccionada(DataGridViewRow row)
        {
            txtIdCategoria.Text = row.Cells["Código"].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
            txtDescripcion.Text = row.Cells["Descripción"].Value?.ToString() ?? "";

            string estado = row.Cells["Estado"].Value?.ToString() ?? "";

            if (estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                rbActivo.Checked = true;
            else
                rbInactivo.Checked = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtIdCategoria.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            rbActivo.Checked = true;

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                txtBuscar.Clear();
            }
            else
            {
                CargarTablaCategorias();
            }

            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                MessageBox.Show("Seleccione una categoría de la tabla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        string query = "DELETE FROM Categorias WHERE id_categoria = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtIdCategoria.Text));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Categoría eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTablaCategorias();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}