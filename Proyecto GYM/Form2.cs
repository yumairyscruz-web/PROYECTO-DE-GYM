using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class Form2 : Form
    {
        private string nombreUsuarioSesion;
        private Form formularioActivo = null;

        public Form2(string nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsuarioSesion = nombreUsuario;
        }

        public Form2()
        {
            InitializeComponent();
            this.nombreUsuarioSesion = "Usuario";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblTituloHeader.Text = "Inicio";
            MostrarBienvenidaInicial();
        }

        private void MostrarBienvenidaInicial()
        {
            panel7.Controls.Clear();

            Label lblBienvenida = new Label();
            lblBienvenida.Text = "¡Bienvenido/@, " + nombreUsuarioSesion + "!";
            lblBienvenida.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(28, 40, 51);
            lblBienvenida.AutoSize = true;

            lblBienvenida.Location = new Point(
                (panel7.Width - lblBienvenida.PreferredWidth) / 2,
                (panel7.Height - lblBienvenida.PreferredHeight) / 2
            );
            lblBienvenida.Anchor = AnchorStyles.None;

            panel7.Controls.Add(lblBienvenida);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo = null;
            }

            lblTituloHeader.Text = "Inicio";
            MostrarBienvenidaInicial();
        }

        // Método público para incrustar cualquier formulario dentro del panel7 contenedor
        public void AbrirFormularioHijo(Form formularioHijo, string titulo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            panel7.Controls.Clear();
            formularioActivo = formularioHijo;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panel7.Controls.Add(formularioHijo);
            panel7.Tag = formularioHijo;

            lblTituloHeader.Text = titulo;

            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormClientes(), "Mantenimiento de Clientes");
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormUsuario(), "Mantenimiento de Usuarios");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Clase_y_Actividades_de_Gym(), "Clases-actividades del gym");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormEntrenadores(), "Gestión de Entrenadores");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormHorarioClase(), "Gestión de Horarios de Clases / Actividades");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormTiposMembresias(), "  GESTIÓN DE TIPOS DE MEMBRESÍAS");
        }

        // Evento para abrir el formulario de renovación directamente dentro de panel7
        public void AbrirRenovacionMembresia()
        {
            AbrirFormularioHijo(new FrmRenovarMembresia(), "RENOVACIÓN DE MEMBRESÍA");
        }

        // Asigna este método al evento Click del botón de Renovar Membresía de tu menú
        private void btnRenovarMembresia_Click(object sender, EventArgs e)
        {
            AbrirRenovacionMembresia();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCategorias(), "Mantenimiento de Categorías de Productos");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProductos(), "GESTIÓN DE PRODUCTOS");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProveedores(), "Mantenimiento de Proveedores");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormPasesDiarios(), "Pases del Día / Visitas");
        }
    }
}