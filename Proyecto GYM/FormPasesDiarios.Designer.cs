namespace Proyecto_GYM
{
    partial class FormPasesDiarios
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
            txtPrecio = new TextBox();
            btnRegistrar = new Button();
            dgvVisitasHoy = new DataGridView();
            label4 = new Label();
            label1 = new Label();
            txtNombreCliente = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvVisitasHoy).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DodgerBlue;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(27, 9);
            label2.Name = "label2";
            label2.Size = new Size(302, 25);
            label2.TabIndex = 1;
            label2.Text = "\"Registro de Visita (Pase Diario)\"";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 173);
            label3.Name = "label3";
            label3.Size = new Size(62, 21);
            label3.TabIndex = 2;
            label3.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(80, 172);
            txtPrecio.Multiline = true;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(149, 31);
            txtPrecio.TabIndex = 4;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Blue;
            btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = SystemColors.Control;
            btnRegistrar.Location = new Point(300, 162);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(105, 42);
            btnRegistrar.TabIndex = 5;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.AutoSizeChanged += btnRegistrar_Click;
            // 
            // dgvVisitasHoy
            // 
            dgvVisitasHoy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisitasHoy.Location = new Point(39, 231);
            dgvVisitasHoy.Name = "dgvVisitasHoy";
            dgvVisitasHoy.Size = new Size(338, 150);
            dgvVisitasHoy.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Blue;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(39, 53);
            label4.Name = "label4";
            label4.Size = new Size(161, 21);
            label4.TabIndex = 7;
            label4.Text = "\"Registrar Entrada\":";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 108);
            label1.Name = "label1";
            label1.Size = new Size(158, 21);
            label1.TabIndex = 8;
            label1.Text = "Nombre de Cliente:";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(191, 108);
            txtNombreCliente.Multiline = true;
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(171, 31);
            txtNombreCliente.TabIndex = 9;
            // 
            // FormPasesDiarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(618, 450);
            Controls.Add(txtNombreCliente);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(dgvVisitasHoy);
            Controls.Add(btnRegistrar);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FormPasesDiarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPasesDiarios";
            Load += FormPasesDiarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVisitasHoy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox txtPrecio;
        private Button btnRegistrar;
        private DataGridView dgvVisitasHoy;
        private Label label4;
        private Label label1;
        private TextBox txtNombreCliente;
    }
}