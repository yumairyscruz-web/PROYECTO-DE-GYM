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
        public FormClientes()
        {
            InitializeComponent();
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
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

        private byte[] ObtenerBytesDeImagen(Image imagen)
        {
            if (imagen == null) return null;

            using (MemoryStream ms = new MemoryStream())
            {
                // Guardar explícitamente en PNG para evitar errores de RawFormat en GDI+
                using (Bitmap bmp = new Bitmap(imagen))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                return ms.ToArray();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(@"Server=DESKTOP-AR0O5IR\SQLEXPRESS;Database=GimnasioDB;Integrated Security=True;TrustServerCertificate=True;"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BuscarCliente", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@criterio", txtBuscar.Text.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClientes.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar cliente: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrirImagen = new OpenFileDialog())
            {
                abrirImagen.Filter = "Archivos de Imagen (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                abrirImagen.Title = "Seleccionar Foto del Cliente";

                if (abrirImagen.ShowDialog() == DialogResult.OK)
                {
                    // Cargar imagen en memoria para evitar bloqueos de archivo
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

                    // Se envía 1 si está marcado Activo, 0 si está Inactivo para ser compatible con BIT
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                    byte[] fotoBytes = ObtenerBytesDeImagen(pbFoto.Image);
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

        // EDITAR CLIENTE
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione o busque un cliente primero para poder editarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCliente", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@sexo", cmbSexo.Text);

                    // Enviamos 1 o 0 en lugar del texto "Activo"/"Inactivo"
                    cmd.Parameters.AddWithValue("@estado", rbActivo.Checked ? 1 : 0);

                    // Pasamos la foto asignando el tipo de dato SQL explícito
                    byte[] fotoBytes = ObtenerBytesDeImagen(pbFoto.Image);
                    if (fotoBytes != null && fotoBytes.Length > 0)
                    {
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = fotoBytes;
                    }
                    else
                    {
                        cmd.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Datos del cliente actualizados correctamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Forzar recarga limpia
                    LimpiarFormulario();
                    CargarClientes();
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
                        // Se actualiza a 0 si la columna estado en la BD es BIT
                        SqlCommand cmd = new SqlCommand("UPDATE Clientes SET estado = 0 WHERE cedula = @cedula", con);
                        cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());

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

        // Evento para llenar los controles al hacer clic en el DataGridView
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                // 1. Cargar datos de texto
                txtNombre.Text = fila.Cells["nombre"].Value?.ToString();
                txtApellido.Text = fila.Cells["apellido"].Value?.ToString();
                txtCedula.Text = fila.Cells["cedula"].Value?.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value?.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value?.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value?.ToString();

                // 2. Cargar Fecha de Nacimiento
                if (fila.Cells["fecha_nacimiento"].Value is object valFecha &&
                    DateTime.TryParse(valFecha.ToString(), out DateTime fechaNac))
                {
                    dtpFechaNacimiento.Value = fechaNac;
                }

                // 3. Cargar Sexo
                if (fila.Cells["sexo"].Value is object valSexo)
                {
                    cmbSexo.Text = valSexo.ToString();
                }

                // 4. Cargar Estado (Especialmente ajustado para leer 1, True o Activo)
                string estado = fila.Cells["estado"]?.Value?.ToString() ?? "";
                if (estado == "1" || estado.Equals("True", StringComparison.OrdinalIgnoreCase) || estado == "Activo")
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }

                // 5. Cargar Fotografía desde arreglo de bytes (byte[])
                if (dgvClientes.Columns.Contains("foto") &&
                    fila.Cells["foto"].Value is byte[] bytesFoto &&
                    bytesFoto.Length > 0)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(bytesFoto))
                        {
                            using (Image imgOriginal = Image.FromStream(ms))
                            {
                                pbFoto.Image = new Bitmap(imgOriginal);
                            }
                        }
                        pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error al convertir la foto: " + ex.Message);
                        pbFoto.Image = null;
                    }
                }
                else
                {
                    pbFoto.Image = null;
                }
            }
        }
    }
}