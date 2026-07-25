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
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Dejar vacío por ahora
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

        // Variable para controlar qué formulario está activo en el panel
        private Form formularioActivo = null;

        // Método para abrir formularios dentro de panel7
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Si hay una pantalla abierta, la cerramos antes de abrir la nueva
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;

            // Preparamos el formulario para meterlo dentro del panel
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Usamos 'panel7' que es el nombre de tu panel blanco
            panel7.Controls.Add(formularioHijo);
            panel7.Tag = formularioHijo;

            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // Evento del botón clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormClientes());
        }
    }
}