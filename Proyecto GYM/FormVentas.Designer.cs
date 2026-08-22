namespace Proyecto_GYM
{
    partial class FormVentas
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
            cmbTipoPago = new ComboBox();
            label3 = new Label();
            dtpFecha = new DateTimePicker();
            label4 = new Label();
            cmbProductos = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnAgregarDetalle = new Button();
            dataGridView1 = new DataGridView();
            cmbClientes = new ComboBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtDescuento = new TextBox();
            txtSubtotal = new TextBox();
            txtImpuesto = new TextBox();
            txtTotal = new TextBox();
            btnCompletarVenta = new Button();
            printDocumentVenta = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 27);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 81);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Tipo Pago";
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Location = new Point(100, 73);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(168, 23);
            cmbTipoPago.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 139);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(100, 133);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 23);
            dtpFecha.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(449, 30);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 6;
            label4.Text = "Productos";
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(560, 24);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(228, 23);
            cmbProductos.TabIndex = 7;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(449, 81);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 8;
            label5.Text = "Precio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(449, 139);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 9;
            label6.Text = "Cantidad";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(560, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(560, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(141, 23);
            textBox2.TabIndex = 12;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(479, 237);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(97, 31);
            btnAgregarDetalle.TabIndex = 13;
            btnAgregarDetalle.Text = "Agregar Detalle";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(88, 309);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(581, 150);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(100, 24);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(205, 23);
            cmbClientes.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 183);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 16;
            label7.Text = "Subtotal:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(449, 183);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 17;
            label8.Text = "Descuento:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 221);
            label9.Name = "label9";
            label9.Size = new Size(96, 15);
            label9.TabIndex = 18;
            label9.Text = "Impuesto (ITBIS):";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(22, 269);
            label10.Name = "label10";
            label10.Size = new Size(78, 15);
            label10.TabIndex = 19;
            label10.Text = "Total General:";
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(560, 183);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(154, 23);
            txtDescuento.TabIndex = 20;
            txtDescuento.Click += txtDescuento_TextChanged;
            txtDescuento.TextChanged += txtDescuento_TextChanged;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(111, 180);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(100, 23);
            txtSubtotal.TabIndex = 21;
            // 
            // txtImpuesto
            // 
            txtImpuesto.Location = new Point(144, 218);
            txtImpuesto.Name = "txtImpuesto";
            txtImpuesto.ReadOnly = true;
            txtImpuesto.Size = new Size(136, 23);
            txtImpuesto.TabIndex = 22;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(132, 266);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(136, 23);
            txtTotal.TabIndex = 23;
            // 
            // btnCompletarVenta
            // 
            btnCompletarVenta.Location = new Point(602, 237);
            btnCompletarVenta.Name = "btnCompletarVenta";
            btnCompletarVenta.Size = new Size(112, 31);
            btnCompletarVenta.TabIndex = 24;
            btnCompletarVenta.Text = "Completar Venta";
            btnCompletarVenta.UseVisualStyleBackColor = true;
            btnCompletarVenta.Click += btnCompletarVenta_Click;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 471);
            Controls.Add(btnCompletarVenta);
            Controls.Add(txtTotal);
            Controls.Add(txtImpuesto);
            Controls.Add(txtSubtotal);
            Controls.Add(txtDescuento);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(cmbClientes);
            Controls.Add(dataGridView1);
            Controls.Add(btnAgregarDetalle);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cmbProductos);
            Controls.Add(label4);
            Controls.Add(dtpFecha);
            Controls.Add(label3);
            Controls.Add(cmbTipoPago);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormVentas";
            Text = "FormVentas";
            Load += FormVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbTipoPago;
        private Label label3;
        private DateTimePicker dtpFecha;
        private Label label4;
        private ComboBox cmbProductos;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnAgregarDetalle;
        private DataGridView dataGridView1;
        private ComboBox cmbClientes;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtDescuento;
        private TextBox txtSubtotal;
        private TextBox txtImpuesto;
        private TextBox txtTotal;
        private Button btnCompletarVenta;
        private System.Drawing.Printing.PrintDocument printDocumentVenta;
    }
}