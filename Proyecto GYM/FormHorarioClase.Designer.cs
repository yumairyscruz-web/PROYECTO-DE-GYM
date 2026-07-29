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
            ((System.ComponentModel.ISupportInitialize)dgvHorariosClases).BeginInit();
            SuspendLayout();
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClase.Location = new Point(25, 50);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(142, 21);
            lblClase.TabIndex = 0;
            lblClase.Text = "Clase / Actividad:";
            // 
            // cmbClase
            // 
            cmbClase.FormattingEnabled = true;
            cmbClase.Items.AddRange(new object[] { "Entrenamiento Funcional", "Pesas y Musculación", "Yoga / Pilates", "CrossFit", "Spinning / Ciclismo", "Boxeo / Artes Marciales", "Cardio / Aeróbicos" });
            cmbClase.Location = new Point(23, 86);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(144, 23);
            cmbClase.TabIndex = 1;
            // 
            // lblDia
            // 
            lblDia.AutoSize = true;
            lblDia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDia.Location = new Point(609, 50);
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
            cmbDia.Location = new Point(619, 86);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(134, 23);
            cmbDia.TabIndex = 3;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoraInicio.Location = new Point(272, 50);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(98, 21);
            lblHoraInicio.TabIndex = 4;
            lblHoraInicio.Text = "Hora Inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(238, 83);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(160, 23);
            dtpHoraInicio.TabIndex = 5;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoraFin.Location = new Point(462, 50);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(74, 21);
            lblHoraFin.TabIndex = 6;
            lblHoraFin.Text = "HoraFin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(439, 83);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(139, 23);
            dtpHoraFin.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(514, 183);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(113, 41);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Horario";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(514, 239);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 41);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Horario";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvHorariosClases
            // 
            dgvHorariosClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHorariosClases.Location = new Point(12, 173);
            dgvHorariosClases.Name = "dgvHorariosClases";
            dgvHorariosClases.ReadOnly = true;
            dgvHorariosClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHorariosClases.Size = new Size(435, 170);
            dgvHorariosClases.TabIndex = 10;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(514, 308);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(113, 35);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(364, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 21);
            label1.TabIndex = 12;
            label1.Text = " FORMULARIO";
            // 
            // FormHorarioClase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Text = "FormHorarioClase";
            Load += FormHorarioClase_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHorariosClases).EndInit();
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
    }
}