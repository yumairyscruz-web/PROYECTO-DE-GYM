using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FormProveedores : Form
    {
        private string cadenaConexion = "Server=.;Database=GimnasioDB;Integrated Security=True;TrustServerCertificate=True;";

        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            CargarTablaProveedores();
            LimpiarCampos();
        }

        private void CargarTablaProveedores(string criterio = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarProveedores", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@criterio", criterio);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProveedores.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
            {
                MessageBox.Show("Por favor ingrese el Nombre de la Empresa.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_GuardarProveedor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text.Trim());
                    cmd.Parameters.AddWithValue("@rnc_cedula", txtRNC.Text.Trim());
                    cmd.Parameters.AddWithValue("@contacto_nombre", txtContacto.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Proveedor registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarTablaProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProveedor.Text))
            {
                MessageBox.Show("Por favor seleccione un proveedor de la lista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarProveedor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id_proveedor", Convert.ToInt32(txtIdProveedor.Text));
                    cmd.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text.Trim());
                    cmd.Parameters.AddWithValue("@rnc_cedula", txtRNC.Text.Trim());
                    cmd.Parameters.AddWithValue("@contacto_nombre", txtContacto.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarTablaProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];

                txtIdProveedor.Text = fila.Cells["Código"].Value?.ToString() ?? "";
                txtNombreEmpresa.Text = fila.Cells["Nombre Empresa"].Value?.ToString() ?? "";
                txtRNC.Text = fila.Cells["RNC / Cédula"].Value?.ToString() ?? "";
                txtContacto.Text = fila.Cells["Nombre Contacto"].Value?.ToString() ?? "";
                txtTelefono.Text = fila.Cells["Teléfono"].Value?.ToString() ?? "";
                txtEmail.Text = fila.Cells["Correo"].Value?.ToString() ?? "";
                txtDireccion.Text = fila.Cells["Dirección"].Value?.ToString() ?? "";

                string estadoStr = fila.Cells["Estado"].Value?.ToString() ?? "Activo";
                rbActivo.Checked = (estadoStr == "Activo");
                rbInactivo.Checked = (estadoStr == "Inactivo");
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
            txtIdProveedor.Clear();
            txtRNC.Clear();
            txtNombreEmpresa.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();
            rbActivo.Checked = true;
        }
    }
}