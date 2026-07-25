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
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            pbFoto = new PictureBox();
            btnCargarFoto = new Button();
            label10 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
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
            label2.Location = new Point(25, 59);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
            label2.TabIndex = 1;
            label2.Text = "Cédula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 104);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 146);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 21);
            label4.TabIndex = 3;
            label4.Text = "Apellido:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 196);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 4;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 240);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 5;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 278);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(87, 21);
            label7.TabIndex = 6;
            label7.Text = "Dirección:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 313);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(119, 21);
            label8.TabIndex = 7;
            label8.Text = "F. Nacimiento:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(41, 356);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(51, 21);
            label9.TabIndex = 8;
            label9.Text = "Sexo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(116, 102);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(225, 23);
            txtNombre.TabIndex = 9;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(116, 146);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(225, 23);
            txtApellido.TabIndex = 10;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(116, 238);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(225, 23);
            txtCorreo.TabIndex = 11;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(123, 275);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(225, 23);
            txtDireccion.TabIndex = 12;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(116, 56);
            txtCedula.Mask = "000-000-0000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(143, 29);
            txtCedula.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(116, 193);
            txtTelefono.Mask = "(999)000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 29);
            txtTelefono.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(155, 313);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 29);
            dateTimePicker1.TabIndex = 15;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "F", "M" });
            comboBox1.Location = new Point(123, 353);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 29);
            comboBox1.TabIndex = 16;
            // 
            // pbFoto
            // 
            pbFoto.BackColor = SystemColors.InactiveCaption;
            pbFoto.BorderStyle = BorderStyle.Fixed3D;
            pbFoto.Location = new Point(405, 33);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(227, 214);
            pbFoto.TabIndex = 17;
            pbFoto.TabStop = false;
            // 
            // btnCargarFoto
            // 
            btnCargarFoto.BackColor = SystemColors.ActiveCaption;
            btnCargarFoto.ForeColor = SystemColors.ButtonHighlight;
            btnCargarFoto.Location = new Point(419, 268);
            btnCargarFoto.Name = "btnCargarFoto";
            btnCargarFoto.Size = new Size(111, 40);
            btnCargarFoto.TabIndex = 18;
            btnCargarFoto.Text = "Cargar Foto";
            btnCargarFoto.UseVisualStyleBackColor = false;
            btnCargarFoto.Click += button1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(393, 321);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(65, 21);
            label10.TabIndex = 19;
            label10.Text = "Estado:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(476, 317);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(77, 25);
            radioButton1.TabIndex = 20;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(559, 317);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(100, 25);
            radioButton2.TabIndex = 21;
            radioButton2.TabStop = true;
            radioButton2.Text = "Innactivo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(57, 403);
            button2.Name = "button2";
            button2.Size = new Size(75, 29);
            button2.TabIndex = 22;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(184, 403);
            button3.Name = "button3";
            button3.Size = new Size(75, 29);
            button3.TabIndex = 23;
            button3.Text = "Editar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(320, 403);
            button4.Name = "button4";
            button4.Size = new Size(82, 29);
            button4.TabIndex = 24;
            button4.Text = "Innativa";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(440, 403);
            button5.Name = "button5";
            button5.Size = new Size(75, 29);
            button5.TabIndex = 25;
            button5.Text = "Limpiar";
            button5.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(57, 457);
            label11.Name = "label11";
            label11.Size = new Size(65, 21);
            label11.TabIndex = 26;
            label11.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(136, 454);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 29);
            txtBuscar.TabIndex = 27;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(302, 454);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 32);
            btnBuscar.TabIndex = 28;
            btnBuscar.Text = "buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = SystemColors.ActiveCaption;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(51, 497);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(528, 125);
            dgvClientes.TabIndex = 29;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 685);
            Controls.Add(pbFoto);
            Controls.Add(dgvClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label11);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label10);
            Controls.Add(btnCargarFoto);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
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
            Text = "FormClientes";
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
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private PictureBox pbFoto;
        private Button btnCargarFoto;
        private Label label10;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label11;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvClientes;
    }
}