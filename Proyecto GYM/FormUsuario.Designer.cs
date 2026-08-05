namespace Proyecto_GYM
{
    partial class FormUsuario
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
        {// 1. Primero instancias el control
            dgvUsuarios = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCorreo = new TextBox();
            txtCedula = new MaskedTextBox();
            cmbRol = new ComboBox();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            pbFotoUsuario = new PictureBox();
            btnCargarFoto = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnInactivar = new Button();
            btnLimpiar = new Button();
            label9 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            cmbEntrenador = new ComboBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFotoUsuario).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(12, 380);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(721, 150);
            dgvUsuarios.TabIndex = 27;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 50);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(246, 50);
            label2.Name = "label2";
            label2.Size = new Size(100, 21);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 173);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 2;
            label3.Text = "Cédula:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 114);
            label4.Name = "label4";
            label4.Size = new Size(77, 21);
            label4.TabIndex = 3;
            label4.Text = "Nombre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(247, 116);
            label5.Name = "label5";
            label5.Size = new Size(79, 21);
            label5.TabIndex = 4;
            label5.Text = "Apellido:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 227);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 5;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(478, 294);
            label7.Name = "label7";
            label7.Size = new Size(39, 21);
            label7.TabIndex = 6;
            label7.Text = "Rol:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(452, 259);
            label8.Name = "label8";
            label8.Size = new Size(65, 21);
            label8.TabIndex = 7;
            label8.Text = "Estado:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(91, 43);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(150, 30);
            txtUsuario.TabIndex = 8;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(352, 43);
            txtClave.Multiline = true;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(143, 30);
            txtClave.TabIndex = 9;
            txtClave.UseSystemPasswordChar = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(95, 107);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(146, 30);
            txtNombre.TabIndex = 10;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(341, 114);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(143, 30);
            txtApellido.TabIndex = 11;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(95, 227);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(276, 30);
            txtCorreo.TabIndex = 12;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(91, 175);
            txtCedula.Mask = "000-000-0000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(210, 23);
            txtCedula.TabIndex = 14;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Recepcionista", "Entrenador" });
            cmbRol.Location = new Point(552, 296);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(152, 23);
            cmbRol.TabIndex = 15;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbActivo.Location = new Point(536, 259);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(65, 21);
            rbActivo.TabIndex = 16;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbInactivo.Location = new Point(630, 259);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(75, 21);
            rbInactivo.TabIndex = 17;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // pbFotoUsuario
            // 
            pbFotoUsuario.BorderStyle = BorderStyle.FixedSingle;
            pbFotoUsuario.Location = new Point(501, 12);
            pbFotoUsuario.Name = "pbFotoUsuario";
            pbFotoUsuario.Size = new Size(232, 196);
            pbFotoUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            pbFotoUsuario.TabIndex = 18;
            pbFotoUsuario.TabStop = false;
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.BackColor = SystemColors.ActiveCaption;
            btnCargarFoto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargarFoto.ForeColor = SystemColors.ButtonFace;
            btnCargarFoto.Location = new Point(565, 221);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new Size(96, 32);
            btnCargarFoto.TabIndex = 19;
            btnCargarFoto.Text = "Cargar Foto";
            btnCargarFoto.UseVisualStyleBackColor = false;
            btnCargarFoto.Click += btnCargarFoto_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(20, 276);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(129, 276);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(90, 32);
            btnEditar.TabIndex = 21;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnInactivar
            // 
            btnInactivar.Location = new Point(236, 276);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(90, 32);
            btnInactivar.TabIndex = 22;
            btnInactivar.Text = "Innactiva";
            btnInactivar.UseVisualStyleBackColor = true;
            btnInactivar.Click += btnInactivar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(353, 276);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(90, 32);
            btnLimpiar.TabIndex = 23;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(45, 325);
            label9.Name = "label9";
            label9.Size = new Size(65, 21);
            label9.TabIndex = 24;
            label9.Text = "buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(128, 325);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(129, 30);
            txtBuscar.TabIndex = 25;
            txtBuscar.Click += txtBuscar_TextChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(300, 323);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 32);
            btnBuscar.TabIndex = 26;
            btnBuscar.Text = "buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbEntrenador
            // 
            cmbEntrenador.FormattingEnabled = true;
            cmbEntrenador.Location = new Point(552, 341);
            cmbEntrenador.Name = "cmbEntrenador";
            cmbEntrenador.Size = new Size(152, 23);
            cmbEntrenador.TabIndex = 28;
            cmbEntrenador.SelectedIndexChanged += cmbEntrenador_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(425, 344);
            label10.Name = "label10";
            label10.Size = new Size(92, 20);
            label10.TabIndex = 29;
            label10.Text = "Entrenador:";
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 542);
            Controls.Add(label10);
            Controls.Add(cmbEntrenador);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label9);
            Controls.Add(btnLimpiar);
            Controls.Add(btnInactivar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(btnCargarFoto);
            Controls.Add(pbFotoUsuario);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(cmbRol);
            Controls.Add(txtCedula);
            Controls.Add(txtCorreo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormUsuario";
            Text = "FormUsuario";
            Load += FormUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFotoUsuario).EndInit();
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
        private TextBox txtUsuario;
        private TextBox txtClave;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCorreo;
        private MaskedTextBox txtCedula;
        private ComboBox cmbRol;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private PictureBox pbFotoUsuario;
        private Button btnCargarFoto;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnInactivar;
        private Button btnLimpiar;
        private Label label9;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvUsuarios;
        private ComboBox cmbEntrenador;
        private Label label10;
    }
}