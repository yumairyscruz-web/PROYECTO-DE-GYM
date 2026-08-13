namespace Proyecto_GYM
{
    partial class FormProveedores
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
            btnGuardar = new Button();
            btnEditar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            label9 = new Label();
            txtContacto = new TextBox();
            txtRNC = new TextBox();
            txtNombreEmpresa = new TextBox();
            txtEmail = new TextBox();
            txtDireccion = new TextBox();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            txtTelefono = new MaskedTextBox();
            dgvProveedores = new DataGridView();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 136);
            label2.Name = "label2";
            label2.Size = new Size(115, 21);
            label2.TabIndex = 1;
            label2.Text = "RNC / Cédula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 42);
            label3.Name = "label3";
            label3.Size = new Size(146, 21);
            label3.TabIndex = 2;
            label3.Text = "Nombre Empresa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(333, 91);
            label4.Name = "label4";
            label4.Size = new Size(150, 21);
            label4.TabIndex = 3;
            label4.Text = "Nombre Contacto:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 91);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 4;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 178);
            label6.Name = "label6";
            label6.Size = new Size(57, 21);
            label6.TabIndex = 5;
            label6.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(11, 227);
            label7.Name = "label7";
            label7.Size = new Size(87, 21);
            label7.TabIndex = 6;
            label7.Text = "Dirección:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(11, 284);
            label8.Name = "label8";
            label8.Size = new Size(61, 21);
            label8.TabIndex = 7;
            label8.Text = "Estado";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Gray;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(372, 275);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(84, 40);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Gray;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(462, 275);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(81, 40);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(549, 275);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(82, 40);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Gray;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(637, 275);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 40);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(192, 192, 255);
            btnBuscar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ButtonFace;
            btnBuscar.Location = new Point(290, 329);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(99, 40);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(17, 330);
            label9.Name = "label9";
            label9.Size = new Size(65, 21);
            label9.TabIndex = 13;
            label9.Text = "Buscar:";
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(485, 84);
            txtContacto.Multiline = true;
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(217, 32);
            txtContacto.TabIndex = 15;
            // 
            // txtRNC
            // 
            txtRNC.Location = new Point(141, 136);
            txtRNC.Multiline = true;
            txtRNC.Name = "txtRNC";
            txtRNC.Size = new Size(188, 27);
            txtRNC.TabIndex = 16;
            // 
            // txtNombreEmpresa
            // 
            txtNombreEmpresa.Location = new Point(159, 42);
            txtNombreEmpresa.Multiline = true;
            txtNombreEmpresa.Name = "txtNombreEmpresa";
            txtNombreEmpresa.Size = new Size(208, 32);
            txtNombreEmpresa.TabIndex = 17;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(106, 180);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(273, 30);
            txtEmail.TabIndex = 18;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(106, 227);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(305, 27);
            txtDireccion.TabIndex = 19;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbActivo.Location = new Point(95, 282);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(65, 21);
            rbActivo.TabIndex = 20;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbInactivo.Location = new Point(199, 282);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(75, 21);
            rbInactivo.TabIndex = 21;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(126, 93);
            txtTelefono.Mask = "(999)000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(163, 23);
            txtTelefono.TabIndex = 22;
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(29, 375);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(673, 140);
            dgvProveedores.TabIndex = 23;
            dgvProveedores.CellClick += dgvProveedores_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(106, 329);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(169, 32);
            txtBuscar.TabIndex = 24;
            // 
            // FormProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(743, 527);
            Controls.Add(txtBuscar);
            Controls.Add(dgvProveedores);
            Controls.Add(txtTelefono);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(txtDireccion);
            Controls.Add(txtEmail);
            Controls.Add(txtNombreEmpresa);
            Controls.Add(txtRNC);
            Controls.Add(txtContacto);
            Controls.Add(label9);
            Controls.Add(btnBuscar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FormProveedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormProveedores";
            TransparencyKey = Color.Cyan;
            Load += FormProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
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
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnBuscar;
        private Label label9;
        private TextBox txtContacto;
        private TextBox txtRNC;
        private TextBox txtNombreEmpresa;
        private TextBox txtEmail;
        private TextBox txtDireccion;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private MaskedTextBox txtTelefono;
        private DataGridView dgvProveedores;
        private TextBox txtBuscar;
    }
}