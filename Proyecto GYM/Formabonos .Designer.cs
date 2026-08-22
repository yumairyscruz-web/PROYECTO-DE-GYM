namespace Proyecto_GYM
{
    partial class Formabonos
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
            btnHistoria = new Button();
            btnCerrar = new Button();
            btnComprobante = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            cmbClientes = new ComboBox();
            label2 = new Label();
            txtCedula = new MaskedTextBox();
            label3 = new Label();
            txtTotal = new TextBox();
            txtPediente = new TextBox();
            label4 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnHistoria
            // 
            btnHistoria.BackColor = Color.Gray;
            btnHistoria.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistoria.ForeColor = SystemColors.ButtonFace;
            btnHistoria.Location = new Point(405, 217);
            btnHistoria.Name = "btnHistoria";
            btnHistoria.Size = new Size(103, 41);
            btnHistoria.TabIndex = 0;
            btnHistoria.Text = "Historia";
            btnHistoria.UseVisualStyleBackColor = false;
            btnHistoria.Click += btnHistoria_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Gray;
            btnCerrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = SystemColors.ButtonFace;
            btnCerrar.Location = new Point(627, 217);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(110, 41);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnComprobante
            // 
            btnComprobante.BackColor = Color.Gray;
            btnComprobante.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnComprobante.ForeColor = SystemColors.ButtonFace;
            btnComprobante.Location = new Point(514, 217);
            btnComprobante.Name = "btnComprobante";
            btnComprobante.Size = new Size(107, 41);
            btnComprobante.TabIndex = 2;
            btnComprobante.Text = "Comprobante";
            btnComprobante.UseVisualStyleBackColor = false;
            btnComprobante.Click += btnComprobante_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 273);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(457, 150);
            dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 61);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 4;
            label1.Text = "Clientes:";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(132, 61);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(202, 23);
            cmbClientes.TabIndex = 5;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(405, 64);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 6;
            label2.Text = "Cedula:";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(521, 61);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.ReadOnly = true;
            txtCedula.Size = new Size(216, 23);
            txtCedula.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 141);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 8;
            label3.Text = "Total Abonado:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(166, 138);
            txtTotal.Multiline = true;
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(135, 30);
            txtTotal.TabIndex = 9;
            txtTotal.Click += txtTotal_TextChanged;
            txtTotal.TextChanged += txtTotal_TextChanged;
            // 
            // txtPediente
            // 
            txtPediente.Location = new Point(573, 138);
            txtPediente.Multiline = true;
            txtPediente.Name = "txtPediente";
            txtPediente.Size = new Size(137, 30);
            txtPediente.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(405, 141);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 11;
            label4.Text = "Saldo Pendiente:";
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // Formabonos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(txtPediente);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(txtCedula);
            Controls.Add(label2);
            Controls.Add(cmbClientes);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnComprobante);
            Controls.Add(btnCerrar);
            Controls.Add(btnHistoria);
            Name = "Formabonos";
            Text = "Formabonos";
            Load += Formabonos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHistoria;
        private Button btnCerrar;
        private Button btnComprobante;
        private DataGridView dataGridView1;
        private Label label1;
        private ComboBox cmbClientes;
        private Label label2;
        private MaskedTextBox txtCedula;
        private Label label3;
        private TextBox txtTotal;
        private TextBox txtPediente;
        private Label label4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
    }
}