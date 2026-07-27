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
        // Variable para guardar el nombre del usuario que inició sesión
        private string nombreUsuarioSesion;

        // Variable para controlar qué formulario hijo está activo en el panel
        private Form formularioActivo = null;

        // Constructor principal que recibe el nombre del usuario desde Form1 (Login)
        public Form2(string nombreUsuario)
        {
            InitializeComponent();
            this.nombreUsuarioSesion = nombreUsuario;
        }

        // Constructor por defecto (para compatibilidad con el Diseñador)
        public Form2()
        {
            InitializeComponent();
            this.nombreUsuarioSesion = "Usuario";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Mostrar la bienvenida inicial al usuario en la barra superior
            lblTituloHeader.Text = "Inicio";

            // Crear un Label de bienvenida dinámico en el panel central (panel7)
            MostrarBienvenidaInicial();
        }

        // Método para mostrar el mensaje de bienvenida dentro de panel7 al iniciar o volver a Inicio
        private void MostrarBienvenidaInicial()
        {
            // Limpiamos los controles del panel blanco por si hay otra vista abierta
            panel7.Controls.Clear();

            Label lblBienvenida = new Label();
            lblBienvenida.Text = "¡Bienvenid@, " + nombreUsuarioSesion + "!";
            lblBienvenida.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(28, 40, 51); // Color elegante
            lblBienvenida.AutoSize = true;

            // Centrar el mensaje dentro de panel7
            lblBienvenida.Location = new Point(
                (panel7.Width - lblBienvenida.PreferredWidth) / 2,
                (panel7.Height - lblBienvenida.PreferredHeight) / 2
            );
            lblBienvenida.Anchor = AnchorStyles.None;

            panel7.Controls.Add(lblBienvenida);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close(); // Cierra el menú y regresa al Login
        }

        // Botón Inicio (si tienes un botón para volver al panel principal de bienvenida)
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

        // Método para abrir formularios dentro de panel7
        private void AbrirFormularioHijo(Form formularioHijo, string titulo)
        {
            // Si hay una pantalla abierta, la cerramos antes de abrir la nueva
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            // Limpiamos cualquier control previo en panel7 (incluyendo la bienvenida)
            panel7.Controls.Clear();

            formularioActivo = formularioHijo;

            // Preparamos el formulario para meterlo dentro del panel
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Usamos 'panel7' que es el panel blanco
            panel7.Controls.Add(formularioHijo);
            panel7.Tag = formularioHijo;

            // Actualizamos el texto de la barra azul oscuro
            lblTituloHeader.Text = titulo;

            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // Evento del botón clientes
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
            AbrirFormularioHijo(new FormClientes(), "Gestión de Horarios de Clases / Actividades");

        }
    }
}