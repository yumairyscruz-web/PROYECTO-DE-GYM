namespace Proyecto_GYM
{
    partial class FomInventario
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
            cmbProducto = new ComboBox();
            btnGuardar = new Button();
            btnCerrar = new Button();
            btnLimpiar = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            cmbMovimiento = new ComboBox();
            label3 = new Label();
            txtStock = new TextBox();
            txtObsevacion = new TextBox();
            txtMover = new TextBox();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Producto:";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(109, 28);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(241, 23);
            cmbProducto.TabIndex = 1;
            cmbProducto.SelectedIndexChanged += cmbProducto_SelectedIndexChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Gray;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(437, 226);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(102, 41);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = SystemColors.ButtonHighlight;
            btnCerrar.Location = new Point(663, 226);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(102, 41);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = SystemColors.ButtonHighlight;
            btnLimpiar.Location = new Point(555, 226);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(102, 41);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 288);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(527, 150);
            dataGridView1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 6;
            label2.Text = "Tipo de Movimiento:";
            // 
            // cmbMovimiento
            // 
            cmbMovimiento.FormattingEnabled = true;
            cmbMovimiento.Location = new Point(171, 85);
            cmbMovimiento.Name = "cmbMovimiento";
            cmbMovimiento.Size = new Size(223, 23);
            cmbMovimiento.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(423, 28);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 8;
            label3.Text = "Stock Actual:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(594, 28);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(141, 23);
            txtStock.TabIndex = 9;
            // 
            // txtObsevacion
            // 
            txtObsevacion.Location = new Point(145, 163);
            txtObsevacion.Multiline = true;
            txtObsevacion.Name = "txtObsevacion";
            txtObsevacion.Size = new Size(437, 44);
            txtObsevacion.TabIndex = 10;
            // 
            // txtMover
            // 
            txtMover.Location = new Point(594, 93);
            txtMover.Name = "txtMover";
            txtMover.Size = new Size(164, 23);
            txtMover.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(423, 88);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 12;
            label4.Text = "Cantidad a mover:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 176);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 13;
            label5.Text = "Observación:";
            // 
            // FomInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtMover);
            Controls.Add(txtObsevacion);
            Controls.Add(txtStock);
            Controls.Add(label3);
            Controls.Add(cmbMovimiento);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCerrar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbProducto);
            Controls.Add(label1);
            Name = "FomInventario";
            Text = "FomInventario";
            Load += FomInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbProducto;
        private Button btnGuardar;
        private Button btnCerrar;
        private Button btnLimpiar;
        private DataGridView dataGridView1;
        private Label label2;
        private ComboBox cmbMovimiento;
        private Label label3;
        private TextBox txtStock;
        private TextBox txtObsevacion;
        private TextBox txtMover;
        private Label label4;
        private Label label5;
    }
}