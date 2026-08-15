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
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracionmeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(12, 35);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(203, 21);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre de la membresía";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 171);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 1;
            label1.Text = "Precio ($):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 98);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 2;
            label2.Text = "Descripción:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(440, 37);
            label3.Name = "label3";
            label3.Size = new Size(147, 21);
            label3.TabIndex = 3;
            label3.Text = "Duración (Meses):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(426, 196);
            label4.Name = "label4";
            label4.Size = new Size(65, 21);
            label4.TabIndex = 4;
            label4.Text = "Estado:";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(115, 174);
            nudPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 5;
            nudPrecio.Value = new decimal(new int[] { 100000, 0, 0, 131072 });
            // 
            // nudDuracionmeses
            // 
            nudDuracionmeses.Location = new Point(595, 38);
            nudDuracionmeses.Maximum = new decimal(new int[] { 3650, 0, 0, 0 });
            nudDuracionmeses.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuracionmeses.Name = "nudDuracionmeses";
            nudDuracionmeses.Size = new Size(120, 23);
            nudDuracionmeses.TabIndex = 6;
            nudDuracionmeses.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(221, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(192, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(141, 98);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(375, 33);
            txtDescripcion.TabIndex = 9;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(98, 264);
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
            label5.Location = new Point(12, 262);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 11;
            label5.Text = "Buscar:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Gray;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(370, 251);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 36);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Gray;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = SystemColors.ButtonHighlight;
            btnEditar.Location = new Point(461, 251);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(87, 36);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Gray;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = SystemColors.ButtonHighlight;
            btnEliminar.Location = new Point(650, 251);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 36);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = SystemColors.ButtonHighlight;
            btnLimpiar.Location = new Point(554, 251);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 36);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvMembresias
            // 
            dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembresias.Location = new Point(12, 304);
            dgvMembresias.Name = "dgvMembresias";
            dgvMembresias.Size = new Size(451, 162);
            dgvMembresias.TabIndex = 16;
            dgvMembresias.CellClick += dgvMembresias_CellClick;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(533, 85);
            button1.Name = "button1";
            button1.Size = new Size(95, 48);
            button1.TabIndex = 17;
            button1.Text = "Asignar Membresía";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnAsignarMembresia_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Gray;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(634, 83);
            button2.Name = "button2";
            button2.Size = new Size(93, 48);
            button2.TabIndex = 18;
            button2.Text = "Renovar Membresía";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnRenovarMembresia_Click;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbActivo.Location = new Point(533, 196);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(65, 21);
            rbActivo.TabIndex = 21;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbInactivo.Location = new Point(640, 196);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(75, 21);
            rbInactivo.TabIndex = 22;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // FormTiposMembresias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(750, 478);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblNombre);
            Controls.Add(rbActivo);
            Controls.Add(rbInactivo);
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
            Load += FormTiposMembresias_Load;
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
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
    }
}