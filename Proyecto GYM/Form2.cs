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
        private Form? formularioActivo = null;

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

            // Arrancan ocultos de forma limpia
            panel10.Visible = false;
            panelMovimientos.Visible = false;

            // Orden inicial de las etiquetas y paneles en el menú
            label2.Top = label1.Bottom + 10;
            panelMovimientos.Top = label2.Bottom + 5;
        }

        private void MostrarBienvenidaInicial()
        {
            panel7.Controls.Clear();

            Label lblBienvenida = new Label();
            lblBienvenida.Text = "¡Bienvenido/@, " + nombreUsuarioSesion + "!";
            lblBienvenida.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.BackColor = Color.Transparent;
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

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        // --- ACORDEÓN DE MANTENIMIENTO ---
        // --- ACORDEÓN DE MANTENIMIENTO ---
        // --- ACORDEÓN DE MANTENIMIENTO ---
        private void label1_Click(object sender, EventArgs e)
        {
            bool mostrarMantenimiento = !panel10.Visible;
            panel10.Visible = mostrarMantenimiento;

            if (mostrarMantenimiento)
            {
                panelMovimientos.Visible = false;
                label2.Top = panel10.Bottom + 12;
            }
            else
            {
                // Si ambos están cerrados, subimos Movimientos más arriba para que Consultas no quede tan abajo
                label2.Top = label1.Bottom + 40;
            }

            panelMovimientos.Top = label2.Bottom + 8;
        }

        // --- ACORDEÓN DE MOVIMIENTOS ---
        private void label2_Click(object sender, EventArgs e)
        {
            bool mostrarMovimientos = !panelMovimientos.Visible;
            panelMovimientos.Visible = mostrarMovimientos;

            if (mostrarMovimientos)
            {
                panel10.Visible = false;
                label2.Top = label1.Bottom + 40;
            }
            else
            {
                label2.Top = label1.Bottom + 40;
            }

            panelMovimientos.Top = label2.Bottom + 8;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRenovarMembresia(), "Renovacion / Membresia");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmAsignarMembresia(), "Asignaciones / Membresia");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCobros(), " Cobros");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormCargos(), " Generación de cargos");

        }

        private void button14_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVentas(), " Ventas");

        }

        private void button15_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Compras(), "Compras");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmReservasClases(), "Gestión de Reservas de Clases");

        }

        private void button16_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Formcuenta_por_cobrar(), "Gestión de Cuenta por Pagar");

        }

        private void button17_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Formabonos(), "Gestión de abonos");

        }

        private void button18_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FomInventario(), "Gestión de Entrada-salida de inventario");

        }
    }
}