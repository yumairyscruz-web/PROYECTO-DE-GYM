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
            label10 = new Label();
            pbFotoEntrenador = new PictureBox();
            btnCargaFoto = new Button();
            label11 = new Label();
            label12 = new Label();
            dtpHoraEntrada = new DateTimePicker();
            dtpHoraSalida = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFotoEntrenador).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 192, 255);
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
            label2.Location = new Point(2, 50);
            label2.Name = "label2";
            label2.Size = new Size(67, 21);
            label2.TabIndex = 1;
            label2.Text = "Cédula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(2, 103);
            label3.Name = "label3";
            label3.Size = new Size(77, 21);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(232, 103);
            label4.Name = "label4";
            label4.Size = new Size(79, 21);
            label4.TabIndex = 3;
            label4.Text = "Apellido:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(2, 151);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 4;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(230, 153);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 5;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 234);
            label7.Name = "label7";
            label7.Size = new Size(110, 21);
            label7.TabIndex = 6;
            label7.Text = "Especialidad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(452, 252);
            label8.Name = "label8";
            label8.Size = new Size(65, 21);
            label8.TabIndex = 7;
            label8.Text = "Estado:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Location = new Point(363, 286);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(89, 43);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnditar
            // 
            btnditar.BackColor = Color.ForestGreen;
            btnditar.Location = new Point(458, 286);
            btnditar.Name = "btnditar";
            btnditar.Size = new Size(89, 43);
            btnditar.TabIndex = 9;
            btnditar.Text = "Editar";
            btnditar.UseVisualStyleBackColor = false;
            btnditar.Click += btnEditar_Click;
            // 
            // btnInactivar
            // 
            btnInactivar.BackColor = Color.Red;
            btnInactivar.Location = new Point(550, 286);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(89, 43);
            btnInactivar.TabIndex = 10;
            btnInactivar.Text = "Inactivar";
            btnInactivar.UseVisualStyleBackColor = false;
            btnInactivar.Click += btnInactivar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ActiveBorder;
            btnLimpiar.Location = new Point(648, 286);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(89, 43);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(83, 103);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(143, 33);
            txtNombre.TabIndex = 12;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(317, 103);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(181, 33);
            txtApellido.TabIndex = 13;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(301, 151);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(197, 33);
            txtCorreo.TabIndex = 14;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(90, 151);
            txtTelefono.Mask = "(999)000-0000";
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(139, 23);
            txtTelefono.TabIndex = 15;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(96, 50);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(160, 23);
            txtCedula.TabIndex = 16;
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.FormattingEnabled = true;
            cmbEspecialidad.Items.AddRange(new object[] { "Entrenamiento Funcional", "Pesas y Musculación", "Yoga / Pilates", "CrossFit", "Spinning / Ciclismo", "Boxeo / Artes Marciales", "Cardio / Aeróbicos" });
            cmbEspecialidad.Location = new Point(130, 236);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(232, 23);
            cmbEspecialidad.TabIndex = 17;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Checked = true;
            rbActivo.Location = new Point(550, 252);
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
            rbInactivo.Location = new Point(648, 252);
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
            label9.Location = new Point(33, 380);
            label9.Name = "label9";
            label9.Size = new Size(65, 21);
            label9.TabIndex = 21;
            label9.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(141, 367);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(227, 34);
            txtBuscar.TabIndex = 22;
            // 
            // dgvEntrenadores
            // 
            dgvEntrenadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntrenadores.Location = new Point(12, 414);
            dgvEntrenadores.Name = "dgvEntrenadores";
            dgvEntrenadores.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvEntrenadores.Size = new Size(781, 112);
            dgvEntrenadores.TabIndex = 23;
            dgvEntrenadores.CellClick += dgvEntrenadores_CellClick;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 191);
            label10.Name = "label10";
            label10.Size = new Size(207, 20);
            label10.TabIndex = 24;
            label10.Text = "ESPECIALIDAD Y HORARIOS";
            // 
            // pbFotoEntrenador
            // 
            pbFotoEntrenador.BackColor = SystemColors.ButtonFace;
            pbFotoEntrenador.BorderStyle = BorderStyle.FixedSingle;
            pbFotoEntrenador.Location = new Point(504, 9);
            pbFotoEntrenador.Name = "pbFotoEntrenador";
            pbFotoEntrenador.Size = new Size(252, 185);
            pbFotoEntrenador.SizeMode = PictureBoxSizeMode.Zoom;
            pbFotoEntrenador.TabIndex = 25;
            pbFotoEntrenador.TabStop = false;
            // 
            // btnCargaFoto
            // 
            btnCargaFoto.BackColor = Color.FromArgb(192, 192, 255);
            btnCargaFoto.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargaFoto.ForeColor = SystemColors.ButtonHighlight;
            btnCargaFoto.Location = new Point(577, 200);
            btnCargaFoto.Name = "btnCargaFoto";
            btnCargaFoto.Size = new Size(102, 34);
            btnCargaFoto.TabIndex = 26;
            btnCargaFoto.Text = "Carga Foto";
            btnCargaFoto.UseVisualStyleBackColor = false;
            btnCargaFoto.Click += btnCargarFoto_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(12, 271);
            label11.Name = "label11";
            label11.Size = new Size(114, 21);
            label11.TabIndex = 27;
            label11.Text = "Hora Entrada:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 320);
            label12.Name = "label12";
            label12.Size = new Size(102, 21);
            label12.TabIndex = 28;
            label12.Text = "Hora Salida:";
            // 
            // dtpHoraEntrada
            // 
            dtpHoraEntrada.Format = DateTimePickerFormat.Time;
            dtpHoraEntrada.Location = new Point(141, 271);
            dtpHoraEntrada.Name = "dtpHoraEntrada";
            dtpHoraEntrada.ShowUpDown = true;
            dtpHoraEntrada.Size = new Size(200, 23);
            dtpHoraEntrada.TabIndex = 29;
            // 
            // dtpHoraSalida
            // 
            dtpHoraSalida.Format = DateTimePickerFormat.Time;
            dtpHoraSalida.Location = new Point(141, 318);
            dtpHoraSalida.Name = "dtpHoraSalida";
            dtpHoraSalida.ShowUpDown = true;
            dtpHoraSalida.Size = new Size(200, 23);
            dtpHoraSalida.TabIndex = 30;
            // 
            // FormEntrenadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(821, 529);
            Controls.Add(dtpHoraSalida);
            Controls.Add(dtpHoraEntrada);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(btnCargaFoto);
            Controls.Add(pbFotoEntrenador);
            Controls.Add(label10);
            Controls.Add(dgvEntrenadores);
            Controls.Add(txtBuscar);
            Controls.Add(label9);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(cmbEspecialidad);
            Controls.Add(txtCedula);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(btnLimpiar);
            Controls.Add(btnInactivar);
            Controls.Add(btnditar);
            Controls.Add(btnGuardar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormEntrenadores";
            StartPosition = FormStartPosition.CenterParent;
            Load += FormEntrenadores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEntrenadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFotoEntrenador).EndInit();
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
        private Label label10;
        private PictureBox pbFotoEntrenador;
        private Button btnCargaFoto;
        private Label label11;
        private Label label12;
        private DateTimePicker dtpHoraEntrada;
        private DateTimePicker dtpHoraSalida;
    }
}