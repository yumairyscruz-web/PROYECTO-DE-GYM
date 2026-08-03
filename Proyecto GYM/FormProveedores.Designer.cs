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
            label1 = new Label();
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
            txtIdProveedor = new TextBox();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 30);
            label1.Name = "label1";
            label1.Size = new Size(110, 21);
            label1.TabIndex = 0;
            label1.Text = "ID Proveedor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(375, 30);
            label2.Name = "label2";
            label2.Size = new Size(111, 21);
            label2.TabIndex = 1;
            label2.Text = "RNC / Cédula";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 91);
            label3.Name = "label3";
            label3.Size = new Size(142, 21);
            label3.TabIndex = 2;
            label3.Text = "Nombre Empresa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(375, 91);
            label4.Name = "label4";
            label4.Size = new Size(146, 21);
            label4.TabIndex = 3;
            label4.Text = "Nombre Contacto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(39, 142);
            label5.Name = "label5";
            label5.Size = new Size(77, 21);
            label5.TabIndex = 4;
            label5.Text = "Teléfono";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(41, 189);
            label6.Name = "label6";
            label6.Size = new Size(53, 21);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(39, 237);
            label7.Name = "label7";
            label7.Size = new Size(83, 21);
            label7.TabIndex = 6;
            label7.Text = "Dirección";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(41, 279);
            label8.Name = "label8";
            label8.Size = new Size(61, 21);
            label8.TabIndex = 7;
            label8.Text = "Estado";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(367, 267);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(83, 40);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(456, 267);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(83, 40);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(546, 267);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(83, 40);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(635, 267);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 40);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(308, 321);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(83, 40);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(41, 338);
            label9.Name = "label9";
            label9.Size = new Size(65, 21);
            label9.TabIndex = 13;
            label9.Text = "Buscar:";
            // 
            // txtIdProveedor
            // 
            txtIdProveedor.Location = new Point(149, 32);
            txtIdProveedor.Multiline = true;
            txtIdProveedor.Name = "txtIdProveedor";
            txtIdProveedor.Size = new Size(122, 23);
            txtIdProveedor.TabIndex = 14;
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(527, 82);
            txtContacto.Multiline = true;
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(160, 32);
            txtContacto.TabIndex = 15;
            // 
            // txtRNC
            // 
            txtRNC.Location = new Point(492, 28);
            txtRNC.Multiline = true;
            txtRNC.Name = "txtRNC";
            txtRNC.Size = new Size(148, 27);
            txtRNC.TabIndex = 16;
            // 
            // txtNombreEmpresa
            // 
            txtNombreEmpresa.Location = new Point(181, 82);
            txtNombreEmpresa.Multiline = true;
            txtNombreEmpresa.Name = "txtNombreEmpresa";
            txtNombreEmpresa.Size = new Size(160, 32);
            txtNombreEmpresa.TabIndex = 17;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(119, 180);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(249, 30);
            txtEmail.TabIndex = 18;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(140, 237);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(274, 27);
            txtDireccion.TabIndex = 19;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(119, 282);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(59, 19);
            rbActivo.TabIndex = 20;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(247, 282);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(67, 19);
            rbInactivo.TabIndex = 21;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(149, 144);
            txtTelefono.Mask = "(999)000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(163, 23);
            txtTelefono.TabIndex = 22;
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(65, 375);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.Size = new Size(599, 150);
            dgvProveedores.TabIndex = 23;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(129, 329);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(160, 32);
            txtBuscar.TabIndex = 24;
            // 
            // FormProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
            Controls.Add(txtIdProveedor);
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
            Controls.Add(label1);
            Name = "FormProveedores";
            Text = "FormProveedores";
            Load += FormProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
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
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnBuscar;
        private Label label9;
        private TextBox txtIdProveedor;
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