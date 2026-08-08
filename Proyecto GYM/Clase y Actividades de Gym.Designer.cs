namespace Proyecto_GYM
{
    partial class Clase_y_Actividades_de_Gym
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
            txtNombre = new TextBox();
            cmbEntrenador = new ComboBox();
            nudCupoMaximo = new NumericUpDown();
            cmbEstado = new ComboBox();
            txtDescripcion = new TextBox();
            txtBuscar = new TextBox();
            btnGuardar = new Button();
            BtnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvClases = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudCupoMaximo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClases).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la Clase:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(453, 43);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 1;
            label2.Text = "Entrenador:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 91);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 2;
            label3.Text = "Cupo Máximo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(453, 95);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 3;
            label4.Text = "Estado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 150);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 4;
            label5.Text = "Descripción:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 234);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 5;
            label6.Text = "Buscar:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(173, 39);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(259, 36);
            txtNombre.TabIndex = 6;
            // 
            // cmbEntrenador
            // 
            cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntrenador.FormattingEnabled = true;
            cmbEntrenador.Location = new Point(551, 43);
            cmbEntrenador.Name = "cmbEntrenador";
            cmbEntrenador.Size = new Size(153, 23);
            cmbEntrenador.TabIndex = 7;
            // 
            // nudCupoMaximo
            // 
            nudCupoMaximo.Location = new Point(128, 92);
            nudCupoMaximo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCupoMaximo.Name = "nudCupoMaximo";
            nudCupoMaximo.Size = new Size(120, 23);
            nudCupoMaximo.TabIndex = 8;
            nudCupoMaximo.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(527, 92);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(128, 23);
            cmbEstado.TabIndex = 9;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(112, 150);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(543, 54);
            txtDescripcion.TabIndex = 10;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(90, 234);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(169, 30);
            txtBuscar.TabIndex = 11;
            txtBuscar.Click += txtBuscar_TextChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveBorder;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Blue;
            btnGuardar.Location = new Point(279, 226);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(101, 40);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.BackColor = SystemColors.ActiveBorder;
            BtnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEditar.ForeColor = Color.Blue;
            BtnEditar.Location = new Point(386, 226);
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(101, 40);
            BtnEditar.TabIndex = 13;
            BtnEditar.Text = "Editar";
            BtnEditar.UseVisualStyleBackColor = false;
            BtnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.ActiveBorder;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.Blue;
            btnEliminar.Location = new Point(593, 226);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(98, 40);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ActiveBorder;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = Color.Blue;
            btnLimpiar.Location = new Point(493, 226);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 40);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvClases
            // 
            dgvClases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClases.Location = new Point(52, 288);
            dgvClases.Name = "dgvClases";
            dgvClases.Size = new Size(565, 138);
            dgvClases.TabIndex = 16;
            dgvClases.CellClick += dgvClases_CellClick;
            // 
            // Clase_y_Actividades_de_Gym
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(765, 450);
            Controls.Add(dgvClases);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(BtnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(txtBuscar);
            Controls.Add(txtDescripcion);
            Controls.Add(cmbEstado);
            Controls.Add(nudCupoMaximo);
            Controls.Add(cmbEntrenador);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Clase_y_Actividades_de_Gym";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clase_y_Actividades_de_Gym";
            Load += Clase_y_Actividades_de_Gym_Load;
            ((System.ComponentModel.ISupportInitialize)nudCupoMaximo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClases).EndInit();
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
        private TextBox txtNombre;
        private ComboBox cmbEntrenador;
        private NumericUpDown nudCupoMaximo;
        private ComboBox cmbEstado;
        private TextBox txtDescripcion;
        private TextBox txtBuscar;
        private Button btnGuardar;
        private Button BtnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvClases;
    }
}