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
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsignaciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(224, 9);
            label1.Name = "label1";
            label1.Size = new Size(272, 21);
            label1.TabIndex = 0;
            label1.Text = "          ASIGNACIÓN DE MEMBRESÍA\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(45, 55);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 1;
            label2.Text = "Cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(401, 34);
            label3.Name = "label3";
            label3.Size = new Size(67, 42);
            label3.TabIndex = 2;
            label3.Text = "\nCédula:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(47, 111);
            label4.Name = "label4";
            label4.Size = new Size(81, 21);
            label4.TabIndex = 3;
            label4.Text = "Teléfono:\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(359, 99);
            label5.Name = "label5";
            label5.Size = new Size(156, 21);
            label5.TabIndex = 4;
            label5.Text = "Tipo de Membresía\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(55, 166);
            label6.Name = "label6";
            label6.Size = new Size(58, 21);
            label6.TabIndex = 5;
            label6.Text = "Precio";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(373, 152);
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
            label9.Location = new Point(341, 216);
            label9.Name = "label9";
            label9.Size = new Size(155, 21);
            label9.TabIndex = 8;
            label9.Text = "Fecha Vencimiento\n";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(45, 282);
            label10.Name = "label10";
            label10.Size = new Size(61, 21);
            label10.TabIndex = 9;
            label10.Text = "Estado";
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(359, 274);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(80, 40);
            btnAsignar.TabIndex = 10;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(457, 274);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 40);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(576, 274);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(80, 40);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(668, 274);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(80, 40);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(137, 60);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 14;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(158, 111);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
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
            cmbMembresia.Location = new Point(521, 97);
            cmbMembresia.Name = "cmbMembresia";
            cmbMembresia.Size = new Size(121, 23);
            cmbMembresia.TabIndex = 17;
            // 
            // nudDuracion
            // 
            nudDuracion.Location = new Point(493, 154);
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(120, 23);
            nudDuracion.TabIndex = 18;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(151, 170);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 19;
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(134, 227);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(200, 23);
            dtpInicio.TabIndex = 20;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Location = new Point(530, 216);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(200, 23);
            dtpVencimiento.TabIndex = 21;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(124, 285);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(59, 19);
            rbActivo.TabIndex = 22;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(240, 285);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(67, 19);
            rbInactivo.TabIndex = 23;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(62, 335);
            label11.Name = "label11";
            label11.Size = new Size(60, 21);
            label11.TabIndex = 24;
            label11.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(134, 337);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(173, 23);
            txtBuscar.TabIndex = 25;
            // 
            // dgvAsignaciones
            // 
            dgvAsignaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsignaciones.Location = new Point(134, 366);
            dgvAsignaciones.Name = "dgvAsignaciones";
            dgvAsignaciones.Size = new Size(443, 150);
            dgvAsignaciones.TabIndex = 26;
            // 
            // FrmAsignarMembresia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 518);
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
    }
}