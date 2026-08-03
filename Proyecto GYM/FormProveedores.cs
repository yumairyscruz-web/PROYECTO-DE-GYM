using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Proyecto_GYM
{
    public partial class FormProveedores : Form
    {
        // Bandera para evitar que eventos del formulario se disparen al poblar controles
        private bool cargandoDatos = false;

        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            cargandoDatos = true;

            CargarTablaProveedores();
            LimpiarCampos();

            cargandoDatos = false;
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
            if (string.IsNullOrWhiteSpace(txtIdProveedor.Text))
            {
                MessageBox.Show("Por favor seleccione un proveedor de la lista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                        // Solo agrega los parámetros QUE REALMENTE pida el Stored Procedure:
                        cmd.Parameters.AddWithValue("@rnc_cedula", txtRNC.Text.Trim()); cmd.Parameters.AddWithValue("@nombre_empresa", txtNombreEmpresa.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre_contacto", txtContacto.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        // Si tu SP también recibe el ID para saber si edita o inserta, agrégalo:
                        // cmd.Parameters.AddWithValue("@id_proveedor", string.IsNullOrEmpty(txtIdProveedor.Text) ? (object)DBNull.Value : Convert.ToInt32(txtIdProveedor.Text));

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

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cargandoDatos = true;

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

            txtIdProveedor.Clear();
            txtRNC.Clear();
            txtNombreEmpresa.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();
            rbActivo.Checked = true;

            cargandoDatos = false;
        }
    }
}