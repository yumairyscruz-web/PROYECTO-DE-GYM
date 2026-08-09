namespace Proyecto_GYM
{
    partial class FormTiposMembresias
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
            lblNombre = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            nudPrecio = new NumericUpDown();
            nudDuracionmeses = new NumericUpDown();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtBuscar = new TextBox();
            label5 = new Label();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvMembresias = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label6 = new Label();
            txtCodigo = new TextBox();
            cmbActivo = new RadioButton();
            cmbiInactivo = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracionmeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(23, 76);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(203, 21);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre de la membresía";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 190);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 1;
            label1.Text = "Precio ($):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 129);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 2;
            label2.Text = "Descripción:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(450, 25);
            label3.Name = "label3";
            label3.Size = new Size(147, 21);
            label3.TabIndex = 3;
            label3.Text = "Duración (Meses):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(451, 76);
            label4.Name = "label4";
            label4.Size = new Size(65, 21);
            label4.TabIndex = 4;
            label4.Text = "Estado:";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(116, 193);
            nudPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 5;
            nudPrecio.Value = new decimal(new int[] { 100000, 0, 0, 131072 });
            // 
            // nudDuracionmeses
            // 
            nudDuracionmeses.Location = new Point(627, 23);
            nudDuracionmeses.Maximum = new decimal(new int[] { 3650, 0, 0, 0 });
            nudDuracionmeses.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuracionmeses.Name = "nudDuracionmeses";
            nudDuracionmeses.Size = new Size(120, 23);
            nudDuracionmeses.TabIndex = 6;
            nudDuracionmeses.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(231, 78);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(192, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(133, 129);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(375, 33);
            txtDescripcion.TabIndex = 9;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(142, 260);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(213, 23);
            txtBuscar.TabIndex = 10;
            txtBuscar.Click += txtBuscar_TextChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(57, 260);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 11;
            label5.Text = "Buscar:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.ForestGreen;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(275, 193);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(104, 44);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.OrangeRed;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = SystemColors.ButtonHighlight;
            btnEditar.Location = new Point(400, 193);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(108, 44);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = SystemColors.ButtonHighlight;
            btnEliminar.Location = new Point(623, 193);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(104, 44);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Silver;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = SystemColors.ButtonHighlight;
            btnLimpiar.Location = new Point(520, 193);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(97, 44);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvMembresias
            // 
            dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembresias.Location = new Point(57, 304);
            dgvMembresias.Name = "dgvMembresias";
            dgvMembresias.Size = new Size(451, 162);
            dgvMembresias.TabIndex = 16;
            dgvMembresias.CellClick += dgvMembresias_CellClick;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(573, 304);
            button1.Name = "button1";
            button1.Size = new Size(95, 48);
            button1.TabIndex = 17;
            button1.Text = "Asignar Membresía";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnAsignarMembresia_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(575, 385);
            button2.Name = "button2";
            button2.Size = new Size(93, 48);
            button2.TabIndex = 18;
            button2.Text = "Renovar Membresía";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnRenovarMembresia_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 20);
            label6.Name = "label6";
            label6.Size = new Size(69, 21);
            label6.TabIndex = 19;
            label6.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(98, 23);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(109, 23);
            txtCodigo.TabIndex = 20;
            // 
            // cmbActivo
            // 
            cmbActivo.AutoSize = true;
            cmbActivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbActivo.Location = new Point(532, 77);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(65, 21);
            cmbActivo.TabIndex = 21;
            cmbActivo.TabStop = true;
            cmbActivo.Text = "Activo";
            cmbActivo.UseVisualStyleBackColor = true;
            // 
            // cmbiInactivo
            // 
            cmbiInactivo.AutoSize = true;
            cmbiInactivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbiInactivo.Location = new Point(623, 76);
            cmbiInactivo.Name = "cmbiInactivo";
            cmbiInactivo.Size = new Size(75, 21);
            cmbiInactivo.TabIndex = 22;
            cmbiInactivo.TabStop = true;
            cmbiInactivo.Text = "Inactivo";
            cmbiInactivo.UseVisualStyleBackColor = true;
            // 
            // FormTiposMembresias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(774, 478);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(txtCodigo);
            Controls.Add(lblNombre);
            Controls.Add(cmbActivo);
            Controls.Add(cmbiInactivo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEditar);
            Controls.Add(label5);
            Controls.Add(dgvMembresias);
            Controls.Add(btnLimpiar);
            Controls.Add(nudPrecio);
            Controls.Add(txtBuscar);
            Controls.Add(button1);
            Controls.Add(btnEliminar);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(nudDuracionmeses);
            Controls.Add(txtDescripcion);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Name = "FormTiposMembresias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTiposMembresias";
            Load += FormTiposMembresias_Load_1;
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracionmeses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown nudPrecio;
        private NumericUpDown nudDuracionmeses;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtBuscar;
        private Label label5;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvMembresias;
        private Button button1;
        private Button button2;
        private Label label6;
        private TextBox txtCodigo;
        private RadioButton cmbActivo;
        private RadioButton cmbiInactivo;
    }
}