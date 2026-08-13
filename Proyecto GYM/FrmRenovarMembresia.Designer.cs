namespace Proyecto_GYM
{
    partial class FrmRenovarMembresia
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnRenovar = new Button();
            btnEditar = new Button();
            cmbCliente = new ComboBox();
            cmbMembresiaActual = new ComboBox();
            cmbNuevaMembresia = new ComboBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaVencimiento = new DateTimePicker();
            txtPrecio = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            rbActiva = new RadioButton();
            rbInactiva = new RadioButton();
            dgvRenovaciones = new DataGridView();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            label10 = new Label();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRenovaciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 192, 255);
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(235, 22);
            label1.Name = "label1";
            label1.Size = new Size(277, 21);
            label1.TabIndex = 0;
            label1.Text = "          RENOVACIÓN DE MEMBRESÍA\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 66);
            label2.Name = "label2";
            label2.Size = new Size(64, 21);
            label2.TabIndex = 1;
            label2.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(364, 66);
            label3.Name = "label3";
            label3.Size = new Size(148, 21);
            label3.TabIndex = 2;
            label3.Text = "Membresía Actual\n";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 119);
            label4.Name = "label4";
            label4.Size = new Size(101, 21);
            label4.TabIndex = 3;
            label4.Text = "Fecha Inicio\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(364, 115);
            label5.Name = "label5";
            label5.Size = new Size(104, 21);
            label5.TabIndex = 4;
            label5.Text = "Fecha Vence\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 175);
            label6.Name = "label6";
            label6.Size = new Size(103, 21);
            label6.TabIndex = 5;
            label6.Text = "Renovar por\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(280, 175);
            label7.Name = "label7";
            label7.Size = new Size(232, 21);
            label7.TabIndex = 6;
            label7.Text = "Nueva Fecha de Vencimiento";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(22, 227);
            label8.Name = "label8";
            label8.Size = new Size(87, 21);
            label8.TabIndex = 7;
            label8.Text = "Precio ($):";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(379, 218);
            label9.Name = "label9";
            label9.Size = new Size(61, 21);
            label9.TabIndex = 8;
            label9.Text = "Estado";
            // 
            // btnRenovar
            // 
            btnRenovar.BackColor = SystemColors.ActiveBorder;
            btnRenovar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRenovar.ForeColor = Color.White;
            btnRenovar.Location = new Point(379, 278);
            btnRenovar.Name = "btnRenovar";
            btnRenovar.Size = new Size(87, 37);
            btnRenovar.TabIndex = 9;
            btnRenovar.Text = "Renovar";
            btnRenovar.UseVisualStyleBackColor = false;
            btnRenovar.Click += btnRenovar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.ActiveBorder;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(482, 278);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(87, 37);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(131, 68);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(185, 23);
            cmbCliente.TabIndex = 11;
            // 
            // cmbMembresiaActual
            // 
            cmbMembresiaActual.FormattingEnabled = true;
            cmbMembresiaActual.Location = new Point(529, 68);
            cmbMembresiaActual.Name = "cmbMembresiaActual";
            cmbMembresiaActual.Size = new Size(246, 23);
            cmbMembresiaActual.TabIndex = 12;
            // 
            // cmbNuevaMembresia
            // 
            cmbNuevaMembresia.FormattingEnabled = true;
            cmbNuevaMembresia.Location = new Point(131, 178);
            cmbNuevaMembresia.Name = "cmbNuevaMembresia";
            cmbNuevaMembresia.Size = new Size(127, 23);
            cmbNuevaMembresia.TabIndex = 13;
            cmbNuevaMembresia.SelectedIndexChanged += cmbNuevaMembresia_SelectedIndexChanged;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(131, 119);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(214, 23);
            dtpFechaInicio.TabIndex = 14;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Location = new Point(499, 113);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(234, 23);
            dtpFechaVencimiento.TabIndex = 15;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(115, 231);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(518, 175);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(229, 23);
            dateTimePicker1.TabIndex = 17;
            // 
            // rbActiva
            // 
            rbActiva.AutoSize = true;
            rbActiva.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbActiva.Location = new Point(467, 218);
            rbActiva.Name = "rbActiva";
            rbActiva.Size = new Size(65, 21);
            rbActiva.TabIndex = 18;
            rbActiva.TabStop = true;
            rbActiva.Text = "Activo";
            rbActiva.UseVisualStyleBackColor = true;
            // 
            // rbInactiva
            // 
            rbInactiva.AutoSize = true;
            rbInactiva.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbInactiva.Location = new Point(550, 218);
            rbInactiva.Name = "rbInactiva";
            rbInactiva.Size = new Size(75, 21);
            rbInactiva.TabIndex = 19;
            rbInactiva.TabStop = true;
            rbInactiva.Text = "Inactivo";
            rbInactiva.UseVisualStyleBackColor = true;
            // 
            // dgvRenovaciones
            // 
            dgvRenovaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRenovaciones.Location = new Point(53, 332);
            dgvRenovaciones.Name = "dgvRenovaciones";
            dgvRenovaciones.Size = new Size(665, 141);
            dgvRenovaciones.TabIndex = 20;
            dgvRenovaciones.CellClick += dgvRenovaciones_CellClick;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.ActiveBorder;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(677, 278);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(87, 37);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ActiveBorder;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(575, 278);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(87, 37);
            btnLimpiar.TabIndex = 22;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(22, 294);
            label10.Name = "label10";
            label10.Size = new Size(65, 21);
            label10.TabIndex = 23;
            label10.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(93, 292);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(185, 23);
            txtBuscar.TabIndex = 24;
            txtBuscar.Click += txtBuscar_TextChanged;
            // 
            // FrmRenovarMembresia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 476);
            Controls.Add(txtBuscar);
            Controls.Add(label10);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvRenovaciones);
            Controls.Add(rbInactiva);
            Controls.Add(rbActiva);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtPrecio);
            Controls.Add(dtpFechaVencimiento);
            Controls.Add(dtpFechaInicio);
            Controls.Add(cmbNuevaMembresia);
            Controls.Add(cmbMembresiaActual);
            Controls.Add(cmbCliente);
            Controls.Add(btnEditar);
            Controls.Add(btnRenovar);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmRenovarMembresia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRenovarMembresia";
            Load += FrmRenovarMembresia_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRenovaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnRenovar;
        private Button btnEditar;
        private ComboBox cmbCliente;
        private ComboBox cmbMembresiaActual;
        private ComboBox cmbNuevaMembresia;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaVencimiento;
        private TextBox txtPrecio;
        private DateTimePicker dateTimePicker1;
        private RadioButton rbActiva;
        private RadioButton rbInactiva;
        private DataGridView dgvRenovaciones;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label label10;
        private TextBox txtBuscar;
    }
}