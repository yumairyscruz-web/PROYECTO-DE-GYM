namespace Proyecto_GYM
{
    partial class FrmReservasClases
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbClientes = new ComboBox();
            txtCedula = new MaskedTextBox();
            label4 = new Label();
            cmbClases = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            dtpFechaReserva = new DateTimePicker();
            btnNuevaReserva = new Button();
            btnRegistrarReserva = new Button();
            btnCancelarReserva = new Button();
            dgvReservas = new DataGridView();
            cmbMembresia = new ComboBox();
            label7 = new Label();
            txtEstado = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 22);
            label1.Name = "label1";
            label1.Size = new Size(190, 21);
            label1.TabIndex = 0;
            label1.Text = "Información del Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 78);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Clientes:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 140);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 2;
            label3.Text = "Cedula:";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(109, 75);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(189, 23);
            cmbClientes.TabIndex = 3;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(109, 137);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(181, 23);
            txtCedula.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 198);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 6;
            label4.Text = "Membresia:";
            // 
            // cmbClases
            // 
            cmbClases.FormattingEnabled = true;
            cmbClases.Location = new Point(536, 70);
            cmbClases.Name = "cmbClases";
            cmbClases.Size = new Size(206, 23);
            cmbClases.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(382, 78);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 8;
            label5.Text = "Clases";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(382, 142);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 10;
            label6.Text = "Fecha de Reservas:";
            // 
            // dtpFechaReserva
            // 
            dtpFechaReserva.Location = new Point(536, 134);
            dtpFechaReserva.Name = "dtpFechaReserva";
            dtpFechaReserva.Size = new Size(236, 23);
            dtpFechaReserva.TabIndex = 11;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.Location = new Point(566, 236);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(97, 33);
            btnNuevaReserva.TabIndex = 12;
            btnNuevaReserva.Text = "Limpiar";
            btnNuevaReserva.UseVisualStyleBackColor = true;
            btnNuevaReserva.Click += btnNuevaReserva_Click;
            // 
            // btnRegistrarReserva
            // 
            btnRegistrarReserva.Location = new Point(437, 236);
            btnRegistrarReserva.Name = "btnRegistrarReserva";
            btnRegistrarReserva.Size = new Size(111, 33);
            btnRegistrarReserva.TabIndex = 13;
            btnRegistrarReserva.Text = "Registrar Reserva";
            btnRegistrarReserva.UseVisualStyleBackColor = true;
            btnRegistrarReserva.Click += btnRegistrarReserva_Click;
            // 
            // btnCancelarReserva
            // 
            btnCancelarReserva.Location = new Point(669, 236);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(119, 33);
            btnCancelarReserva.TabIndex = 14;
            btnCancelarReserva.Text = "Cancelar Reserva";
            btnCancelarReserva.UseVisualStyleBackColor = true;
            btnCancelarReserva.Click += btnCancelarReserva_Click;
            // 
            // dgvReservas
            // 
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(26, 288);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.Size = new Size(567, 150);
            dgvReservas.TabIndex = 15;
            // 
            // cmbMembresia
            // 
            cmbMembresia.FormattingEnabled = true;
            cmbMembresia.Location = new Point(115, 195);
            cmbMembresia.Name = "cmbMembresia";
            cmbMembresia.Size = new Size(175, 23);
            cmbMembresia.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(382, 203);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 17;
            label7.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(500, 198);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(200, 23);
            txtEstado.TabIndex = 18;
            // 
            // FrmReservasClases
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(txtEstado);
            Controls.Add(label7);
            Controls.Add(cmbMembresia);
            Controls.Add(dgvReservas);
            Controls.Add(btnCancelarReserva);
            Controls.Add(btnRegistrarReserva);
            Controls.Add(btnNuevaReserva);
            Controls.Add(dtpFechaReserva);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbClases);
            Controls.Add(label4);
            Controls.Add(txtCedula);
            Controls.Add(cmbClientes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmReservasClases";
            Text = "FrmReservasClases";
            Load += FrmReservasClases_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbClientes;
        private MaskedTextBox txtCedula;
        private Label label4;
        private ComboBox cmbClases;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpFechaReserva;
        private Button btnNuevaReserva;
        private Button btnRegistrarReserva;
        private Button btnCancelarReserva;
        private DataGridView dgvReservas;
        private ComboBox cmbMembresia;
        private Label label7;
        private TextBox txtEstado;
    }
}