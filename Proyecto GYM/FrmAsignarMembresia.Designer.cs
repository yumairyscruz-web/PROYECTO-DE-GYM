namespace Proyecto_GYM
{
    partial class FrmAsignarMembresia
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
            label10 = new Label();
            btnAsignar = new Button();
            btnCancelar = new Button();
            btnEditar = new Button();
            btnLimpiar = new Button();
            cmbCliente = new ComboBox();
            txtTelefono = new TextBox();
            txtCedula = new MaskedTextBox();
            cmbMembresia = new ComboBox();
            nudDuracion = new NumericUpDown();
            txtPrecio = new TextBox();
            dtpInicio = new DateTimePicker();
            dtpVencimiento = new DateTimePicker();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            label11 = new Label();
            txtBuscar = new TextBox();
            dgvAsignaciones = new DataGridView();
            btnbuscar = new Button();
            btnInactivo = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsignaciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 192, 255);
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 0, 192);
            label1.Location = new Point(240, 13);
            label1.Name = "label1";
            label1.Size = new Size(272, 21);
            label1.TabIndex = 0;
            label1.Text = "          ASIGNACIÓN DE MEMBRESÍA\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 53);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 1;
            label2.Text = "Cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(355, 39);
            label3.Name = "label3";
            label3.Size = new Size(67, 42);
            label3.TabIndex = 2;
            label3.Text = "\nCédula:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(27, 109);
            label4.Name = "label4";
            label4.Size = new Size(81, 21);
            label4.TabIndex = 3;
            label4.Text = "Teléfono:\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(323, 107);
            label5.Name = "label5";
            label5.Size = new Size(156, 21);
            label5.TabIndex = 4;
            label5.Text = "Tipo de Membresía\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(27, 168);
            label6.Name = "label6";
            label6.Size = new Size(58, 21);
            label6.TabIndex = 5;
            label6.Text = "Precio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(359, 151);
            label7.Name = "label7";
            label7.Size = new Size(80, 21);
            label7.TabIndex = 6;
            label7.Text = "Duración";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(27, 227);
            label8.Name = "label8";
            label8.Size = new Size(101, 21);
            label8.TabIndex = 7;
            label8.Text = "Fecha Inicio\n";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(359, 227);
            label9.Name = "label9";
            label9.Size = new Size(155, 21);
            label9.TabIndex = 8;
            label9.Text = "Fecha Vencimiento\n";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(27, 283);
            label10.Name = "label10";
            label10.Size = new Size(61, 21);
            label10.TabIndex = 9;
            label10.Text = "Estado";
            // 
            // btnAsignar
            // 
            btnAsignar.BackColor = SystemColors.ActiveBorder;
            btnAsignar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAsignar.ForeColor = Color.White;
            btnAsignar.Location = new Point(304, 274);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(84, 40);
            btnAsignar.TabIndex = 10;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = false;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveBorder;
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(394, 274);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 40);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.ActiveBorder;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(485, 274);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(85, 40);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.AppWorkspace;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(576, 274);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(85, 40);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(124, 55);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(189, 23);
            cmbCliente.TabIndex = 14;
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(134, 109);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(157, 23);
            txtTelefono.TabIndex = 15;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(511, 58);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(145, 23);
            txtCedula.TabIndex = 16;
            // 
            // cmbMembresia
            // 
            cmbMembresia.FormattingEnabled = true;
            cmbMembresia.Location = new Point(485, 105);
            cmbMembresia.Name = "cmbMembresia";
            cmbMembresia.Size = new Size(267, 23);
            cmbMembresia.TabIndex = 17;
            cmbMembresia.SelectedIndexChanged += cmbMembresia_SelectedIndexChanged;
            // 
            // nudDuracion
            // 
            nudDuracion.Location = new Point(457, 154);
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(120, 23);
            nudDuracion.TabIndex = 18;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(113, 170);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 19;
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(134, 227);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(227, 23);
            dtpInicio.TabIndex = 20;
            dtpInicio.ValueChanged += dtpInicio_ValueChanged;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Location = new Point(521, 227);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(231, 23);
            dtpVencimiento.TabIndex = 21;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbActivo.Location = new Point(94, 280);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(72, 24);
            rbActivo.TabIndex = 22;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbInactivo.Location = new Point(172, 280);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(83, 24);
            rbInactivo.TabIndex = 23;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(35, 326);
            label11.Name = "label11";
            label11.Size = new Size(60, 21);
            label11.TabIndex = 24;
            label11.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(124, 328);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 25;
            // 
            // dgvAsignaciones
            // 
            dgvAsignaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsignaciones.Location = new Point(61, 366);
            dgvAsignaciones.Name = "dgvAsignaciones";
            dgvAsignaciones.Size = new Size(464, 150);
            dgvAsignaciones.TabIndex = 26;
            dgvAsignaciones.CellClick += dgvAsignaciones_CellClick;
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = Color.FromArgb(192, 192, 255);
            btnbuscar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnbuscar.ForeColor = Color.White;
            btnbuscar.Location = new Point(355, 320);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(84, 40);
            btnbuscar.TabIndex = 27;
            btnbuscar.Text = "Buscar";
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += txtBuscar_TextChanged;
            // 
            // btnInactivo
            // 
            btnInactivo.BackColor = SystemColors.AppWorkspace;
            btnInactivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInactivo.ForeColor = Color.White;
            btnInactivo.Location = new Point(667, 274);
            btnInactivo.Name = "btnInactivo";
            btnInactivo.Size = new Size(85, 40);
            btnInactivo.TabIndex = 28;
            btnInactivo.Text = "Inativar";
            btnInactivo.UseVisualStyleBackColor = false;
            btnInactivo.Click += btnInactivo_Click;
            // 
            // FrmAsignarMembresia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(781, 526);
            Controls.Add(btnInactivo);
            Controls.Add(btnbuscar);
            Controls.Add(dgvAsignaciones);
            Controls.Add(txtBuscar);
            Controls.Add(label11);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(dtpVencimiento);
            Controls.Add(dtpInicio);
            Controls.Add(txtPrecio);
            Controls.Add(nudDuracion);
            Controls.Add(cmbMembresia);
            Controls.Add(txtCedula);
            Controls.Add(txtTelefono);
            Controls.Add(cmbCliente);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEditar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAsignar);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmAsignarMembresia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAsignarMembresia";
            Load += FrmAsignarMembresia_Load;
            ((System.ComponentModel.ISupportInitialize)nudDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsignaciones).EndInit();
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
        private Label label10;
        private Button btnAsignar;
        private Button btnCancelar;
        private Button btnEditar;
        private Button btnLimpiar;
        private ComboBox cmbCliente;
        private TextBox txtTelefono;
        private MaskedTextBox txtCedula;
        private ComboBox cmbMembresia;
        private NumericUpDown nudDuracion;
        private TextBox txtPrecio;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpVencimiento;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private Label label11;
        private TextBox txtBuscar;
        private DataGridView dgvAsignaciones;
        private Button btnbuscar;
        private Button btnInactivo;
    }
}