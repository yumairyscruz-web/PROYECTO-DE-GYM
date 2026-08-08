namespace Proyecto_GYM
{
    partial class FormHorarioClase
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
            lblClase = new Label();
            cmbClase = new ComboBox();
            lblDia = new Label();
            cmbDia = new ComboBox();
            lblHoraInicio = new Label();
            dtpHoraInicio = new DateTimePicker();
            lblHoraFin = new Label();
            dtpHoraFin = new DateTimePicker();
            btnGuardar = new Button();
            btnEliminar = new Button();
            dgvHorariosClases = new DataGridView();
            btnLimpiar = new Button();
            label1 = new Label();
            btnEditar = new Button();
            label2 = new Label();
            cmbEntrenador = new ComboBox();
            label3 = new Label();
            nudCapacidad = new NumericUpDown();
            label4 = new Label();
            txtBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvHorariosClases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).BeginInit();
            SuspendLayout();
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClase.Location = new Point(27, 68);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(142, 21);
            lblClase.TabIndex = 0;
            lblClase.Text = "Clase / Actividad:";
            // 
            // cmbClase
            // 
            cmbClase.FormattingEnabled = true;
            cmbClase.Items.AddRange(new object[] { "Entrenamiento Funcional", "Pesas y Musculación", "Yoga / Pilates", "CrossFit", "Spinning / Ciclismo", "Boxeo / Artes Marciales", "Cardio / Aeróbicos" });
            cmbClase.Location = new Point(25, 109);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(184, 23);
            cmbClase.TabIndex = 1;
            cmbClase.SelectedIndexChanged += cmbClase_SelectedIndexChanged;
            // 
            // lblDia
            // 
            lblDia.AutoSize = true;
            lblDia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDia.Location = new Point(609, 68);
            lblDia.Name = "lblDia";
            lblDia.Size = new Size(144, 21);
            lblDia.TabIndex = 2;
            lblDia.Text = "Día de la semana:";
            // 
            // cmbDia
            // 
            cmbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDia.FormattingEnabled = true;
            cmbDia.Items.AddRange(new object[] { "Lunes", " Martes", "Miércoles", " Jueves", "Viernes", "Sábado", "Domingo" });
            cmbDia.Location = new Point(619, 109);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(134, 23);
            cmbDia.TabIndex = 3;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoraInicio.Location = new Point(262, 68);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(98, 21);
            lblHoraInicio.TabIndex = 4;
            lblHoraInicio.Text = "Hora Inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.CustomFormat = "";
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(241, 109);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(160, 23);
            dtpHoraInicio.TabIndex = 5;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoraFin.Location = new Point(464, 68);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(78, 21);
            lblHoraFin.TabIndex = 6;
            lblHoraFin.Text = "Hora Fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.CustomFormat = "";
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(444, 109);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(139, 23);
            dtpHoraFin.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DarkGreen;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonFace;
            btnGuardar.Location = new Point(96, 226);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(131, 38);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Horario";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = SystemColors.ButtonFace;
            btnEliminar.Location = new Point(411, 226);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(131, 38);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Horario";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvHorariosClases
            // 
            dgvHorariosClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHorariosClases.Location = new Point(47, 319);
            dgvHorariosClases.Name = "dgvHorariosClases";
            dgvHorariosClases.ReadOnly = true;
            dgvHorariosClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHorariosClases.Size = new Size(650, 157);
            dgvHorariosClases.TabIndex = 10;
            dgvHorariosClases.CellClick += dgvHorariosClases_CellClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.AppWorkspace;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = SystemColors.ButtonFace;
            btnLimpiar.Location = new Point(566, 226);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(131, 38);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.ClientSizeChanged += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(128, 128, 255);
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(272, 18);
            label1.Name = "label1";
            label1.Size = new Size(224, 21);
            label1.TabIndex = 12;
            label1.Text = "HORARIOS DE ACTIVIDADES";
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.OrangeRed;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = SystemColors.ButtonFace;
            btnEditar.Location = new Point(252, 226);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(128, 38);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 177);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 14;
            label2.Text = "Entrenador";
            // 
            // cmbEntrenador
            // 
            cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntrenador.FormattingEnabled = true;
            cmbEntrenador.Location = new Point(118, 174);
            cmbEntrenador.Name = "cmbEntrenador";
            cmbEntrenador.Size = new Size(137, 23);
            cmbEntrenador.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(272, 173);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 16;
            label3.Text = "Cupo / Capacidad";
            // 
            // nudCapacidad
            // 
            nudCapacidad.Location = new Point(422, 170);
            nudCapacidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(120, 23);
            nudCapacidad.TabIndex = 17;
            nudCapacidad.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(47, 283);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 18;
            label4.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(129, 284);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(173, 23);
            txtBuscar.TabIndex = 19;
            // 
            // FormHorarioClase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 501);
            Controls.Add(txtBuscar);
            Controls.Add(label4);
            Controls.Add(nudCapacidad);
            Controls.Add(label3);
            Controls.Add(cmbEntrenador);
            Controls.Add(label2);
            Controls.Add(btnEditar);
            Controls.Add(label1);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvHorariosClases);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(dtpHoraFin);
            Controls.Add(lblHoraFin);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblHoraInicio);
            Controls.Add(cmbDia);
            Controls.Add(lblDia);
            Controls.Add(cmbClase);
            Controls.Add(lblClase);
            Name = "FormHorarioClase";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormHorarioClase";
            Load += FormHorarioClase_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHorariosClases).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClase;
        private ComboBox cmbClase;
        private Label lblDia;
        private ComboBox cmbDia;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblHoraFin;
        private DateTimePicker dtpHoraFin;
        private Button btnGuardar;
        private Button btnEliminar;
        private DataGridView dgvHorariosClases;
        private Button btnLimpiar;
        private Label label1;
        private Button btnEditar;
        private Label label2;
        private ComboBox cmbEntrenador;
        private Label label3;
        private NumericUpDown nudCapacidad;
        private Label label4;
        private TextBox txtBuscar;
    }
}