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
    public partial class FormTiposMembresias : Form
    {
        private int idMembresiaSeleccionada = 0;
        private bool cargandoDatos = false;

        public FormTiposMembresias()
        {
            InitializeComponent();
        }

        private void FormTiposMembresias_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarMembresias();
        }

        private void ConfigurarControles()
        {
            // Forzar que el radio button de activo esté seleccionado desde el inicio
            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            // Asegurar la asociación de los eventos KeyPress para bloquear números y símbolos
            txtNombre.KeyPress -= txtSoloLetras_KeyPress;
            txtNombre.KeyPress += txtSoloLetras_KeyPress;

            txtDescripcion.KeyPress -= txtSoloLetras_KeyPress;
            txtDescripcion.KeyPress += txtSoloLetras_KeyPress;

            nudDuracionmeses.Minimum = 1;
            nudDuracionmeses.Maximum = 120;
            nudDuracionmeses.Value = 1;

            nudPrecio.Minimum = 0;
            nudPrecio.Maximum = 100000;
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Value = 1000;
        }

        private void CargarMembresias(string criterio = "")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ListarTiposMembresias", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@criterio", criterio);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvMembresias.Columns.Clear();
                        dgvMembresias.DataSource = dt;
                        dgvMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de membresías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la membresía.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GuardarTipoMembresia", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@duracion_meses", Convert.ToInt32(nudDuracionmeses.Value));
                        cmd.Parameters.AddWithValue("@precio", nudPrecio.Value);
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Membresía registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMembresias();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la membresía: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idMembresiaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una membresía de la lista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la membresía.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_EditarTipoMembresia", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_tipo_membresia", idMembresiaSeleccionada);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@duracion_meses", Convert.ToInt32(nudDuracionmeses.Value));
                        cmd.Parameters.AddWithValue("@precio", nudPrecio.Value);
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? (object)DBNull.Value : txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Membresía actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMembresias();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la membresía: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idMembresiaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una membresía para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta membresía?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        string query = "DELETE FROM tipos_membresias WHERE id_tipo_membresia = @id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", idMembresiaSeleccionada);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Membresía eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMembresias();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la membresía: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMembresias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvMembresias == null) return;

            cargandoDatos = true;

            try
            {
                DataGridViewRow fila = dgvMembresias.Rows[e.RowIndex];

                if (dgvMembresias.Columns.Contains("Código") && fila.Cells["Código"].Value != DBNull.Value)
                {
                    idMembresiaSeleccionada = Convert.ToInt32(fila.Cells["Código"].Value);
                }

                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
                txtDescripcion.Text = fila.Cells["Descripción"].Value?.ToString() ?? "";

                if (fila.Cells["Duración (Meses)"].Value != DBNull.Value && int.TryParse(fila.Cells["Duración (Meses)"].Value?.ToString(), out int meses))
                {
                    nudDuracionmeses.Value = Math.Max(nudDuracionmeses.Minimum, Math.Min(nudDuracionmeses.Maximum, meses));
                }

                if (fila.Cells["Precio"].Value != DBNull.Value && decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                {
                    nudPrecio.Value = Math.Max(nudPrecio.Minimum, Math.Min(nudPrecio.Maximum, precio));
                }

                string estadoStr = fila.Cells["Estado"].Value?.ToString() ?? "";
                if (estadoStr.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estadoStr == "1")
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }
            }
            finally
            {
                cargandoDatos = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarMembresias(txtBuscar.Text.Trim());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cargandoDatos = true;

            idMembresiaSeleccionada = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            nudDuracionmeses.Value = 1;
            nudPrecio.Value = 1000;
            rbActivo.Checked = true; // Fuerza el estado Activo al limpiar

            cargandoDatos = false;
            txtNombre.Focus();
        }

        private void btnAsignarMembresia_Click(object sender, EventArgs e)
        {
            Form2 formPrincipal = Application.OpenForms["Form2"] as Form2;

            if (formPrincipal != null)
            {
                formPrincipal.AbrirFormularioHijo(new FrmAsignarMembresia(), "ASIGNACIÓN DE MEMBRESÍA");
            }
        }

        private void btnRenovarMembresia_Click(object sender, EventArgs e)
        {
            Form2 formPrincipal = Application.OpenForms["Form2"] as Form2;
            if (formPrincipal != null)
            {
                formPrincipal.AbrirFormularioHijo(new FrmRenovarMembresia(), "Renovacion / Membresia");
            }
        }

        // Restricción estricta: Solo permite letras (incluyendo tildes y eñes) y espacios. Bloquea números y símbolos.
        private void txtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsControl(c) && !char.IsLetter(c) && c != ' ' &&
                c != 'á' && c != 'é' && c != 'í' && c != 'ó' && c != 'ú' &&
                c != 'Á' && c != 'É' && c != 'Í' && c != 'Ó' && c != 'Ú' &&
                c != 'ñ' && c != 'Ñ')
            {
                e.Handled = true; // Bloquea cualquier número, asterisco o carácter especial
            }
        }

        private void FormTiposMembresias_Load_1(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}