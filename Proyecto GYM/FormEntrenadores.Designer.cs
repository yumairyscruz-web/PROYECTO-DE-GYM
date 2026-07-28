namespace Proyecto_GYM
{
    partial class FormEntrenadores
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
            btnGuardar = new Button();
            btnditar = new Button();
            btnInactivar = new Button();
            btnLimpiar = new Button();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new MaskedTextBox();
            txtCedula = new MaskedTextBox();
            cmbEspecialidad = new ComboBox();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            label9 = new Label();
            txtBuscar = new TextBox();
            dgvEntrenadores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 9);
            label1.Name = "label1";
            label1.Size = new Size(206, 21);
            label1.TabIndex = 0;
            label1.Text = "DATOS DEL ENTRENADOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 52);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
            label2.TabIndex = 1;
            label2.Text = "Cédula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 92);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 130);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 3;
            label4.Text = "Apelido:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 179);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 4;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(23, 216);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 5;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 269);
            label7.Name = "label7";
            label7.Size = new Size(110, 21);
            label7.TabIndex = 6;
            label7.Text = "Especialidad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(23, 307);
            label8.Name = "label8";
            label8.Size = new Size(65, 21);
            label8.TabIndex = 7;
            label8.Text = "Estado:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(15, 354);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(89, 43);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnditar
            // 
            btnditar.Location = new Point(121, 354);
            btnditar.Name = "btnditar";
            btnditar.Size = new Size(89, 43);
            btnditar.TabIndex = 9;
            btnditar.Text = "Editar";
            btnditar.UseVisualStyleBackColor = true;
            // 
            // btnInactivar
            // 
            btnInactivar.Location = new Point(229, 354);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(89, 43);
            btnInactivar.TabIndex = 10;
            btnInactivar.Text = "Inactivar";
            btnInactivar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(324, 354);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(89, 43);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(121, 80);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(164, 33);
            txtNombre.TabIndex = 12;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(121, 119);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(164, 33);
            txtApellido.TabIndex = 13;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(109, 217);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(197, 33);
            txtCorreo.TabIndex = 14;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(126, 178);
            txtTelefono.Mask = "(999)000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(159, 23);
            txtTelefono.TabIndex = 15;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(128, 55);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(157, 23);
            txtCedula.TabIndex = 16;
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.FormattingEnabled = true;
            cmbEspecialidad.Items.AddRange(new object[] { "Entrenamiento Funcional", "Pesas y Musculación", "Yoga / Pilates", "CrossFit", "Spinning / Ciclismo", "Boxeo / Artes Marciales", "Cardio / Aeróbicos" });
            cmbEspecialidad.Location = new Point(142, 267);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(121, 23);
            cmbEspecialidad.TabIndex = 17;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Checked = true;
            rbActivo.Location = new Point(94, 307);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(59, 19);
            rbActivo.TabIndex = 18;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(194, 307);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(67, 19);
            rbInactivo.TabIndex = 19;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(413, 22);
            label9.Name = "label9";
            label9.Size = new Size(65, 21);
            label9.TabIndex = 21;
            label9.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(484, 22);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(227, 34);
            txtBuscar.TabIndex = 22;
            // 
            // dgvEntrenadores
            // 
            dgvEntrenadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntrenadores.Location = new Point(324, 62);
            dgvEntrenadores.Name = "dgvEntrenadores";
            dgvEntrenadores.Size = new Size(514, 188);
            dgvEntrenadores.TabIndex = 23;
            // 
            // FormEntrenadores
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(850, 450);
            this.Controls.Add(dgvEntrenadores);
            this.Controls.Add(txtBuscar);
            this.Controls.Add(label9);
            this.Controls.Add(rbInactivo);
            this.Controls.Add(rbActivo);
            this.Controls.Add(cmbEspecialidad);
            this.Controls.Add(txtCedula);
            this.Controls.Add(txtTelefono);
            this.Controls.Add(txtCorreo);
            this.Controls.Add(txtApellido);
            this.Controls.Add(txtNombre);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(btnInactivar);
            this.Controls.Add(btnditar);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "FormEntrenadores";
            this.Load += FormEntrenadores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private Button btnGuardar;
        private Button btnditar;
        private Button btnInactivar;
        private Button btnLimpiar;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCorreo;
        private MaskedTextBox txtTelefono;
        private MaskedTextBox txtCedula;
        private ComboBox cmbEspecialidad;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private Label label9;
        private TextBox txtBuscar;
        private DataGridView dgvEntrenadores;
    }
}