using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            // Reemplaza dgvClientes por dataGridView1 si ese es el nombre de tu control
            if (dgvClientes.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = string.Format(
                    "cedula LIKE '%{0}%' OR nombre LIKE '%{0}%' OR apellido LIKE '%{0}%'",
                    busqueda
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

