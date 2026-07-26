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
        {
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
            btnEliminar = new Button();
            label9 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvUsuarios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pbFotoUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 50);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(247, 41);
            label2.Name = "label2";
            label2.Size = new Size(100, 21);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 171);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 2;
            label3.Text = "Cédula:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 114);
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
            label6.Location = new Point(33, 232);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 5;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(478, 298);
            label7.Name = "label7";
            label7.Size = new Size(39, 21);
            label7.TabIndex = 6;
            label7.Text = "Rol:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(466, 272);
            label8.Name = "label8";
            label8.Size = new Size(65, 21);
            label8.TabIndex = 7;
            label8.Text = "Estado:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(112, 41);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(129, 30);
            txtUsuario.TabIndex = 8;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(353, 41);
            txtClave.Multiline = true;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(129, 30);
            txtClave.TabIndex = 9;
            txtClave.UseSystemPasswordChar = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(112, 116);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(129, 30);
            txtNombre.TabIndex = 10;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(353, 116);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(129, 30);
            txtApellido.TabIndex = 11;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(114, 229);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(276, 30);
            txtCorreo.TabIndex = 12;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(114, 171);
            txtCedula.Mask = "000-000-0000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(143, 23);
            txtCedula.TabIndex = 14;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Recepcionista", "Entrenador" });
            cmbRol.Location = new Point(565, 296);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(121, 23);
            cmbRol.TabIndex = 15;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(537, 271);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(59, 19);
            rbActivo.TabIndex = 16;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(602, 271);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(74, 19);
            rbInactivo.TabIndex = 17;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Innactivo";
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
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(20, 276);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(129, 276);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(90, 32);
            btnEditar.TabIndex = 21;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnInactivar
            // 
            btnInactivar.Location = new Point(236, 276);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(90, 32);
            btnInactivar.TabIndex = 22;
            btnInactivar.Text = "Innactiva";
            btnInactivar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(353, 276);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 32);
            btnEliminar.TabIndex = 23;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
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
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(300, 323);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 32);
            btnBuscar.TabIndex = 26;
            btnBuscar.Text = "buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(0, 361);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(676, 150);
            dgvUsuarios.TabIndex = 27;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 513);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label9);
            Controls.Add(btnEliminar);
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
            ((System.ComponentModel.ISupportInitialize)pbFotoUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
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
        private Button btnEliminar;
        private Label label9;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvUsuarios;
    }
}