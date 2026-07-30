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
            cmbClase.Size = new Size(144, 23);
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
            btnGuardar.Location = new Point(517, 218);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(113, 41);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Horario";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(517, 318);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 41);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Horario";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvHorariosClases
            // 
            dgvHorariosClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHorariosClases.Location = new Point(25, 230);
            dgvHorariosClases.Name = "dgvHorariosClases";
            dgvHorariosClases.ReadOnly = true;
            dgvHorariosClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHorariosClases.Size = new Size(435, 170);
            dgvHorariosClases.TabIndex = 10;
            dgvHorariosClases.CellClick += dgvHorariosClases_CellClick;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(517, 365);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(113, 35);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.ClientSizeChanged += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(272, 9);
            label1.Name = "label1";
            label1.Size = new Size(224, 21);
            label1.TabIndex = 12;
            label1.Text = "HORARIOS DE ACTIVIDADES";
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(520, 274);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 38);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
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
            cmbEntrenador.Location = new Point(129, 180);
            cmbEntrenador.Name = "cmbEntrenador";
            cmbEntrenador.Size = new Size(121, 23);
            cmbEntrenador.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(272, 183);
            label3.Name = "label3";
            label3.Size = new Size(131, 20);
            label3.TabIndex = 16;
            label3.Text = "Cupo / Capacidad";
            // 
            // nudCapacidad
            // 
            nudCapacidad.Location = new Point(422, 181);
            nudCapacidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(120, 23);
            nudCapacidad.TabIndex = 17;
            nudCapacidad.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // FormHorarioClase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}