namespace Proyecto_GYM
{
    partial class FormClientes
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCorreo = new TextBox();
            txtDireccion = new TextBox();
            txtCedula = new MaskedTextBox();
            txtTelefono = new MaskedTextBox();
            dtpFechaNacimiento = new DateTimePicker();
            cmbSexo = new ComboBox();
            pbFoto = new PictureBox();
            btnCargarFoto = new Button();
            label10 = new Label();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnInactivar = new Button();
            btnLimpia = new Button();
            label11 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 24);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
            label2.TabIndex = 1;
            label2.Text = "Cédula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 68);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 112);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 21);
            label4.TabIndex = 3;
            label4.Text = "Apellido:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 151);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 4;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 193);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 5;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 232);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(87, 21);
            label7.TabIndex = 6;
            label7.Text = "Dirección:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 279);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(119, 21);
            label8.TabIndex = 7;
            label8.Text = "F. Nacimiento:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 326);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(51, 21);
            label9.TabIndex = 8;
            label9.Text = "Sexo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(107, 56);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(225, 38);
            txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(109, 100);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(225, 41);
            txtApellido.TabIndex = 10;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(99, 195);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(246, 31);
            txtCorreo.TabIndex = 11;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(99, 232);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(256, 32);
            txtDireccion.TabIndex = 12;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(99, 21);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(143, 29);
            txtCedula.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(116, 148);
            txtTelefono.Mask = "(999)000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(128, 29);
            txtTelefono.TabIndex = 14;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(141, 273);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(231, 29);
            dtpFechaNacimiento.TabIndex = 15;
            // 
            // cmbSexo
            // 
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Items.AddRange(new object[] { "F", "M" });
            cmbSexo.Location = new Point(99, 326);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(121, 29);
            cmbSexo.TabIndex = 16;
            // 
            // pbFoto
            // 
            pbFoto.BackColor = SystemColors.ActiveCaption;
            pbFoto.BorderStyle = BorderStyle.Fixed3D;
            pbFoto.Location = new Point(403, 12);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(227, 214);
            pbFoto.SizeMode = PictureBoxSizeMode.AutoSize;
            pbFoto.TabIndex = 17;
            pbFoto.TabStop = false;
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.BackColor = Color.FromArgb(128, 128, 255);
            btnCargarFoto.ForeColor = SystemColors.ButtonHighlight;
            btnCargarFoto.Location = new Point(464, 232);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new Size(111, 43);
            btnCargarFoto.TabIndex = 18;
            btnCargarFoto.Text = "Cargar Foto";
            btnCargarFoto.UseVisualStyleBackColor = false;
            btnCargarFoto.Click += button1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(391, 281);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(65, 21);
            label10.TabIndex = 19;
            label10.Text = "Estado:";
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(476, 281);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(77, 25);
            rbActivo.TabIndex = 20;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(559, 281);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(100, 25);
            rbInactivo.TabIndex = 21;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Innactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Green;
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(299, 326);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(99, 41);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += button2_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.OrangeRed;
            btnEditar.ForeColor = SystemColors.ButtonFace;
            btnEditar.Location = new Point(403, 326);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(106, 41);
            btnEditar.TabIndex = 23;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnInactivar
            // 
            btnInactivar.BackColor = SystemColors.Highlight;
            btnInactivar.ForeColor = SystemColors.ButtonHighlight;
            btnInactivar.Location = new Point(515, 326);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(109, 41);
            btnInactivar.TabIndex = 24;
            btnInactivar.Text = "Inactivar";
            btnInactivar.UseVisualStyleBackColor = false;
            btnInactivar.Click += btnInactivar_Click;
            // 
            // btnLimpia
            // 
            btnLimpia.BackColor = SystemColors.ButtonShadow;
            btnLimpia.ForeColor = SystemColors.ButtonHighlight;
            btnLimpia.Location = new Point(630, 326);
            btnLimpia.Name = "btnLimpia";
            btnLimpia.Size = new Size(104, 41);
            btnLimpia.TabIndex = 25;
            btnLimpia.Text = "Limpiar";
            btnLimpia.UseVisualStyleBackColor = false;
            btnLimpia.Click += btnLimpiar_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 377);
            label11.Name = "label11";
            label11.Size = new Size(65, 21);
            label11.TabIndex = 26;
            label11.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(99, 377);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(137, 29);
            txtBuscar.TabIndex = 27;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(128, 128, 255);
            btnBuscar.ForeColor = SystemColors.ButtonHighlight;
            btnBuscar.Location = new Point(276, 377);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(96, 35);
            btnBuscar.TabIndex = 28;
            btnBuscar.Text = "buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.TextChanged += btnBuscar_Click;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = SystemColors.ActiveCaption;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 418);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(807, 146);
            dgvClientes.TabIndex = 29;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(838, 588);
            Controls.Add(pbFoto);
            Controls.Add(dgvClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label11);
            Controls.Add(btnLimpia);
            Controls.Add(btnInactivar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(label10);
            Controls.Add(btnCargarFoto);
            Controls.Add(cmbSexo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtTelefono);
            Controls.Add(txtCedula);
            Controls.Add(txtDireccion);
            Controls.Add(txtCorreo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormClientes";
            Load += FormClientes_Load_1;
            Click += FormClientes_Load_1;
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private MaskedTextBox txtCedula;
        private MaskedTextBox txtTelefono;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cmbSexo;
        private PictureBox pbFoto;
        private Button btnCargarFoto;
        private Label label10;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnInactivar;
        private Button btnLimpia;
        private Label label11;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvClientes;
    }
}