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
            ((System.ComponentModel.ISupportInitialize)dgvHorariosClases).BeginInit();
            SuspendLayout();
            // 
            // lblClase
            // 
            lblClase.AutoSize = true;
            lblClase.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClase.Location = new Point(288, 9);
            lblClase.Name = "lblClase";
            lblClase.Size = new Size(163, 25);
            lblClase.TabIndex = 0;
            lblClase.Text = "Clase / Actividad:";
            // 
            // cmbClase
            // 
            cmbClase.FormattingEnabled = true;
            cmbClase.Location = new Point(46, 89);
            cmbClase.Name = "cmbClase";
            cmbClase.Size = new Size(121, 23);
            cmbClase.TabIndex = 1;
            // 
            // lblDia
            // 
            lblDia.AutoSize = true;
            lblDia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDia.Location = new Point(46, 137);
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
            cmbDia.Location = new Point(46, 178);
            cmbDia.Name = "cmbDia";
            cmbDia.Size = new Size(134, 23);
            cmbDia.TabIndex = 3;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoraInicio.Location = new Point(333, 70);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(98, 21);
            lblHoraInicio.TabIndex = 4;
            lblHoraInicio.Text = "Hora Inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(299, 96);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(200, 23);
            dtpHoraInicio.TabIndex = 5;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoraFin.Location = new Point(333, 137);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(74, 21);
            lblHoraFin.TabIndex = 6;
            lblHoraFin.Text = "HoraFin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(299, 178);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(200, 23);
            dtpHoraFin.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(573, 50);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(113, 41);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Horario";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(573, 117);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 41);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Horario";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvHorariosClases
            // 
            dgvHorariosClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHorariosClases.Location = new Point(73, 248);
            dgvHorariosClases.Name = "dgvHorariosClases";
            dgvHorariosClases.ReadOnly = true;
            dgvHorariosClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHorariosClases.Size = new Size(630, 166);
            dgvHorariosClases.TabIndex = 10;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(573, 177);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(113, 35);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FormHorarioClase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}