using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormClientes : Form
    {
        // Almacena la clave primaria id_cliente seleccionada de la tabla
        private int idClienteSeleccionado = 0;

        public FormClientes()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta al abrir el formulario
        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        // Carga los registros de la base de datos en el DataGridView
        private void CargarClientes()
        {
            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dgvClientes != null)
                    {
                        dgvClientes.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de clientes: " + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Deja todas las cajas en blanco y resetea los controles
        private void LimpiarFormulario()
        {
            idClienteSeleccionado = 0; // Reseteamos la ID seleccionada

            txtCedula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();

            dtpFechaNacimiento.Value = DateTime.Now;
            cmbSexo.SelectedIndex = -1;

            rbActivo.Checked = true;
            rbInactivo.Checked = false;

            pbFoto.Image = null;

            // Restablece el filtro de búsqueda del DataGridView si existía
            if (dgvClientes.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = "";
            }

            txtCedula.Focus();
        }

        // Método ajustado para aceptar valores nulos (Image?)
        private byte[]? ObtenerBytesDeImagen(Image? imagen)
        {
            if (imagen == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bmp = new Bitmap(imagen))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                return ms.ToArray();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    if (conexion.State == ConnectionState.Closed) conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_BuscarCliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@criterio", txtBuscar.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClientes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Seleccionar Imagen desde la PC
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrirImagen = new OpenFileDialog())
            {
                abrirImagen.Filter = "Archivos de Imagen (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                abrirImagen.Title = "Seleccionar Foto del Cliente";

                if (abrirImagen.ShowDialog() == DialogResult.OK)
                {
                    using (var imgTemp = Image.FromFile(abrirImagen.FileName))
                    {
                        pbFoto.Image = new Bitmap(imgTemp);
                    }
                    pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (dgvClientes.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format(
                    "cedula LIKE '%{0}%' OR nombre LIKE '%{0}%' OR apellido LIKE '%{0}%'",
                    busqueda
                );
            }
        }

        // GUARDAR CLIENTE
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (Cédula, Nombre, Apellido).", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    SqlCommand cmd = new SqlCommand("sp_GuardarCliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@sexo", cmbSexo.Text);
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                    byte[]? fotoBytes = ObtenerBytesDeImagen(pbFoto.Image);
                    if (fotoBytes != null && fotoBytes.Length > 0)
                    {
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = fotoBytes;
                    }
                    else
                    {
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientes();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // EDITAR CLIENTE (Busca por id_cliente y permite modificar la cédula libremente)
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un cliente de la tabla antes de hacer clic en Editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("El campo Cédula no puede quedar vacío.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_EditarCliente", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_cliente", idClienteSeleccionado);
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value);
                        cmd.Parameters.AddWithValue("@sexo", cmbSexo.Text);
                        cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                        byte[]? fotoBytes = ObtenerBytesDeImagen(pbFoto.Image);
                        if (fotoBytes != null && fotoBytes.Length > 0)
                        {
                            cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = fotoBytes;
                        }
                        else
                        {
                            cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                        }

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarFormulario();
                            CargarClientes();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el registro en la base de datos para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione un cliente para inactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cambiar el estado del cliente a Inactivo?",
                                                     "Confirmar Inactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = Conexion.ObtenerConexion())
                    {
                        if (con.State == ConnectionState.Closed) con.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE Clientes SET estado = 0 WHERE id_cliente = @id_cliente", con);
                        cmd.Parameters.AddWithValue("@id_cliente", idClienteSeleccionado);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El cliente ha sido inactivado correctamente.", "Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarClientes();
                        LimpiarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cambiar estado del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // Cargar datos en los controles y capturar el id_cliente
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                // 1. Guardar la clave primaria id_cliente
                if (fila.Cells["id_cliente"].Value != DBNull.Value)
                {
                    idClienteSeleccionado = Convert.ToInt32(fila.Cells["id_cliente"].Value);
                }

                // 2. Cargar datos de texto
                txtCedula.Text = fila.Cells["cedula"].Value?.ToString();
                txtNombre.Text = fila.Cells["nombre"].Value?.ToString();
                txtApellido.Text = fila.Cells["apellido"].Value?.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value?.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value?.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value?.ToString();

                // 3. Cargar Fecha de Nacimiento
                if (fila.Cells["fecha_nacimiento"].Value is object valFecha &&
                    DateTime.TryParse(valFecha.ToString(), out DateTime fechaNac))
                {
                    dtpFechaNacimiento.Value = fechaNac;
                }

                // 4. Cargar Sexo
                if (fila.Cells["sexo"].Value is object valSexo)
                {
                    cmbSexo.Text = valSexo.ToString();
                }

                // 5. Cargar Estado
                string estado = fila.Cells["estado"]?.Value?.ToString() ?? "";
                if (estado == "1" || estado.Equals("True", StringComparison.OrdinalIgnoreCase) || estado == "Activo")
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }

                // 6. Cargar la foto directamente de la base de datos usando el id_cliente
                CargarFotoClienteDesdeBD(idClienteSeleccionado);
            }
        }

        // Método para traer la foto directamente de SQL Server usando id_cliente
        private void CargarFotoClienteDesdeBD(int idCliente)
        {
            if (idCliente <= 0)
            {
                pbFoto.Image = null;
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    if (con.State == ConnectionState.Closed) con.Open();

                    string query = "SELECT foto FROM Clientes WHERE id_cliente = @id_cliente";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                        object? result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value && result is byte[] bytesFoto && bytesFoto.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(bytesFoto))
                            {
                                using (Image imgTemp = Image.FromStream(ms))
                                {
                                    pbFoto.Image = new Bitmap(imgTemp);
                                }
                            }
                            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
                            return;
                        }
                    }
                }

                pbFoto.Image = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar la foto desde SQL: " + ex.Message);
                pbFoto.Image = null;
            }
        }

        private void FormClientes_Load_1(object sender, EventArgs e)
        {

        }
    }
}