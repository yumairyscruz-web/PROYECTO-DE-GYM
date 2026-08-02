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
            panel1 = new Panel();
            cmbiInactivo = new RadioButton();
            cmbActivo = new RadioButton();
            txtCodigo = new TextBox();
            label6 = new Label();
            button2 = new Button();
            button1 = new Button();
            dgvMembresias = new DataGridView();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            label5 = new Label();
            txtBuscar = new TextBox();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            nudDuracionmeses = new NumericUpDown();
            nudPrecio = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblNombre = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracionmeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(cmbiInactivo);
            panel1.Controls.Add(cmbActivo);
            panel1.Controls.Add(txtCodigo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dgvMembresias);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(nudDuracionmeses);
            panel1.Controls.Add(nudPrecio);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblNombre);
            panel1.Location = new Point(3, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 481);
            panel1.TabIndex = 0;
            // 
            // cmbiInactivo
            // 
            cmbiInactivo.AutoSize = true;
            cmbiInactivo.Location = new Point(657, 75);
            cmbiInactivo.Name = "cmbiInactivo";
            cmbiInactivo.Size = new Size(67, 19);
            cmbiInactivo.TabIndex = 22;
            cmbiInactivo.TabStop = true;
            cmbiInactivo.Text = "Inactivo";
            cmbiInactivo.UseVisualStyleBackColor = true;
            // 
            // cmbActivo
            // 
            cmbActivo.AutoSize = true;
            cmbActivo.Location = new Point(575, 75);
            cmbActivo.Name = "cmbActivo";
            cmbActivo.Size = new Size(59, 19);
            cmbActivo.TabIndex = 21;
            cmbActivo.TabStop = true;
            cmbActivo.Text = "Activo";
            cmbActivo.UseVisualStyleBackColor = true;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(162, 28);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(58, 28);
            label6.Name = "label6";
            label6.Size = new Size(69, 21);
            label6.TabIndex = 19;
            label6.Text = "Código:";
            // 
            // button2
            // 
            button2.Location = new Point(657, 189);
            button2.Name = "button2";
            button2.Size = new Size(89, 44);
            button2.TabIndex = 18;
            button2.Text = "Renovar Membresía";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(545, 189);
            button1.Name = "button1";
            button1.Size = new Size(89, 44);
            button1.TabIndex = 17;
            button1.Text = "Asignar Membresía";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvMembresias
            // 
            dgvMembresias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembresias.Location = new Point(58, 285);
            dgvMembresias.Name = "dgvMembresias";
            dgvMembresias.Size = new Size(645, 162);
            dgvMembresias.TabIndex = 16;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(435, 189);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(84, 44);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(328, 189);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(84, 44);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(238, 189);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(84, 44);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(119, 189);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(84, 44);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(58, 256);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 11;
            label5.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(130, 256);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(173, 23);
            txtBuscar.TabIndex = 10;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(144, 145);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(300, 33);
            txtDescripcion.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(238, 61);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(192, 23);
            txtNombre.TabIndex = 8;
            // 
            // nudDuracionmeses
            // 
            nudDuracionmeses.Location = new Point(605, 26);
            nudDuracionmeses.Maximum = new decimal(new int[] { 3650, 0, 0, 0 });
            nudDuracionmeses.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuracionmeses.Name = "nudDuracionmeses";
            nudDuracionmeses.Size = new Size(120, 23);
            nudDuracionmeses.TabIndex = 6;
            nudDuracionmeses.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Location = new Point(144, 103);
            nudPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 5;
            nudPrecio.Value = new decimal(new int[] { 100000, 0, 0, 131072 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(482, 72);
            label4.Name = "label4";
            label4.Size = new Size(65, 21);
            label4.TabIndex = 4;
            label4.Text = "Estado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(454, 28);
            label3.Name = "label3";
            label3.Size = new Size(147, 21);
            label3.TabIndex = 3;
            label3.Text = "Duración (Meses):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(19, 145);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 2;
            label2.Text = "Descripción:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(19, 103);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 1;
            label1.Text = "Precio ($):";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(9, 61);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(203, 21);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre de la membresía";
            // 
            // FormTiposMembresias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 459);
            Controls.Add(panel1);
            Name = "FormTiposMembresias";
            Text = "FormTiposMembresias";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuracionmeses).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblNombre;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown nudDuracionmeses;
        private NumericUpDown nudPrecio;
        private TextBox txtNombre;
        private DataGridView dgvMembresias;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Label label5;
        private TextBox txtBuscar;
        private TextBox txtDescripcion;
        private Button button2;
        private Button button1;
        private TextBox txtCodigo;
        private Label label6;
        private RadioButton cmbiInactivo;
        private RadioButton cmbActivo;
    }
}