using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FormProveedores : Form
    {
        private bool cargandoDatos = false;

        public FormProveedores()
        {
            InitializeComponent();

            // Restricción: Solo permite letras y espacios en el nombre de la empresa y nombre de contacto
            txtNombreEmpresa.KeyPress += txtSoloLetras_KeyPress;
            txtContacto.KeyPress += txtSoloLetras_KeyPress;

            // Restricción: Solo permite números en RNC/Cédula y Teléfono
            txtRNC.KeyPress += txtSoloNumeros_KeyPress;
            txtTelefono.KeyPress += txtSoloNumeros_KeyPress;
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            cargandoDatos = true;

            CargarTablaProveedores("");
            LimpiarCampos();

            cargandoDatos = false;
        }

        // Método de restricción para aceptar únicamente letras y espacios (bloquea números, símbolos y asteriscos)
        private void txtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // Método de restricción para aceptar únicamente números
        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Validación de formato de correo electrónico exigiendo la presencia de '@' y un dominio válido (ej. .com)
        private bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return true;
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

        private void CargarTablaProveedores(string criterio = "")
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ListarProveedores", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@criterio", criterio);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cargandoDatos = true;
                        dgvProveedores.DataSource = dt;
                        cargandoDatos = false;
                    }
                }
            }
            catch (Exception ex)
            {
                cargandoDatos = false;
                MessageBox.Show("Error al cargar la lista de proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
            {
                MessageBox.Show("Por favor ingrese el Nombre de la Empresa.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEmpresa.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValidarCorreo(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido que contenga '@' y un dominio (ejemplo: correo@dominio.com).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GuardarProveedor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text.Trim());
                        cmd.Parameters.AddWithValue("@rnc_cedula", txtRNC.Text.Trim());
                        cmd.Parameters.AddWithValue("@contacto_nombre", txtContacto.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Proveedor registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                CargarTablaProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.CurrentRow.Cells["Código"].Value == null)
            {
                MessageBox.Show("Por favor seleccione un proveedor de la lista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValidarCorreo(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido que contenga '@' y un dominio (ejemplo: correo@dominio.com).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                int idProveedorSeleccionado = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["Código"].Value);

                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_EditarProveedor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_proveedor", idProveedorSeleccionado);
                        cmd.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text.Trim());
                        cmd.Parameters.AddWithValue("@rnc_cedula", txtRNC.Text.Trim());
                        cmd.Parameters.AddWithValue("@contacto_nombre", txtContacto.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                CargarTablaProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null || dgvProveedores.CurrentRow.Cells["Código"].Value == null)
            {
                MessageBox.Show("Por favor seleccione un proveedor de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int idProveedorSeleccionado = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["Código"].Value);

                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        using (SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_proveedor", idProveedorSeleccionado);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Proveedor eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    CargarTablaProveedores();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cargandoDatos = true;

                DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];

                txtNombreEmpresa.Text = fila.Cells["Nombre Empresa"].Value?.ToString() ?? "";
                txtRNC.Text = fila.Cells["RNC / Cédula"].Value?.ToString() ?? "";
                txtContacto.Text = fila.Cells["Nombre Contacto"].Value != DBNull.Value ? fila.Cells["Nombre Contacto"].Value?.ToString() ?? "" : "";
                txtTelefono.Text = fila.Cells["Teléfono"].Value?.ToString() ?? "";
                txtEmail.Text = fila.Cells["Correo"].Value?.ToString() ?? "";
                txtDireccion.Text = fila.Cells["Dirección"].Value?.ToString() ?? "";

                string estadoStr = fila.Cells["Estado"].Value?.ToString() ?? "Activo";
                rbActivo.Checked = (estadoStr == "Activo");
                rbInactivo.Checked = (estadoStr == "Inactivo");

                cargandoDatos = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarTablaProveedores(txtBuscar.Text.Trim());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cargandoDatos = true;

            txtRNC.Clear();
            txtNombreEmpresa.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();
            rbActivo.Checked = true; // Asegura que el radio button de activo esté seleccionado por defecto

            cargandoDatos = false;
        }
    }
}