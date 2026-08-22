namespace Proyecto_GYM
{
    partial class Compras
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
            cmbProveedores = new ComboBox();
            dtpFechaCompra = new DateTimePicker();
            txtNumeroFactura = new TextBox();
            cmbProductos = new ComboBox();
            txtCantidad = new TextBox();
            btnAgregarItem = new Button();
            txtTotalCompra = new TextBox();
            btnCompletarCompra = new Button();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            txtPrecio = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 30);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Proveedores:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 225);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 1;
            label2.Text = "Fecha de Compra:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 169);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 2;
            label3.Text = "Numero de Factura:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(447, 95);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 3;
            label4.Text = "Cantidad:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(439, 27);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 4;
            label5.Text = "Productos:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(445, 164);
            label6.Name = "label6";
            label6.Size = new Size(97, 15);
            label6.TabIndex = 5;
            label6.Text = "Total de Compra:";
            // 
            // cmbProveedores
            // 
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(139, 27);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(273, 23);
            cmbProveedores.TabIndex = 8;
            // 
            // dtpFechaCompra
            // 
            dtpFechaCompra.Location = new Point(139, 219);
            dtpFechaCompra.Name = "dtpFechaCompra";
            dtpFechaCompra.Size = new Size(239, 23);
            dtpFechaCompra.TabIndex = 9;
            // 
            // txtNumeroFactura
            // 
            txtNumeroFactura.Location = new Point(163, 161);
            txtNumeroFactura.Multiline = true;
            txtNumeroFactura.Name = "txtNumeroFactura";
            txtNumeroFactura.Size = new Size(258, 32);
            txtNumeroFactura.TabIndex = 10;
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(562, 24);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(207, 23);
            cmbProductos.TabIndex = 11;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(561, 89);
            txtCantidad.Multiline = true;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(182, 30);
            txtCantidad.TabIndex = 12;
            txtCantidad.Click += txtCantidad_TextChanged;
            // 
            // btnAgregarItem
            // 
            btnAgregarItem.Location = new Point(439, 213);
            btnAgregarItem.Name = "btnAgregarItem";
            btnAgregarItem.Size = new Size(134, 39);
            btnAgregarItem.TabIndex = 13;
            btnAgregarItem.Text = "Agregar a Lista";
            btnAgregarItem.UseVisualStyleBackColor = true;
            btnAgregarItem.TextChanged += btnAgregarItem_Click;
            btnAgregarItem.Click += btnAgregarItem_Click;
            // 
            // txtTotalCompra
            // 
            txtTotalCompra.Location = new Point(592, 161);
            txtTotalCompra.Multiline = true;
            txtTotalCompra.Name = "txtTotalCompra";
            txtTotalCompra.ReadOnly = true;
            txtTotalCompra.Size = new Size(151, 32);
            txtTotalCompra.TabIndex = 14;
            // 
            // btnCompletarCompra
            // 
            btnCompletarCompra.Location = new Point(592, 213);
            btnCompletarCompra.Name = "btnCompletarCompra";
            btnCompletarCompra.Size = new Size(151, 39);
            btnCompletarCompra.TabIndex = 15;
            btnCompletarCompra.Text = "Registrar Compra";
            btnCompletarCompra.UseVisualStyleBackColor = true;
            btnCompletarCompra.TextChanged += btnCompletarCompra_Click;
            btnCompletarCompra.Click += btnCompletarCompra_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 272);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(493, 150);
            dataGridView1.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 97);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 17;
            label7.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(119, 92);
            txtPrecio.Multiline = true;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(141, 27);
            txtPrecio.TabIndex = 18;
            // 
            // Compras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPrecio);
            Controls.Add(label7);
            Controls.Add(dataGridView1);
            Controls.Add(btnCompletarCompra);
            Controls.Add(txtTotalCompra);
            Controls.Add(btnAgregarItem);
            Controls.Add(txtCantidad);
            Controls.Add(cmbProductos);
            Controls.Add(txtNumeroFactura);
            Controls.Add(dtpFechaCompra);
            Controls.Add(cmbProveedores);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Compras";
            Text = "Compras";
            Load += Compras_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private ComboBox cmbProveedores;
        private DateTimePicker dtpFechaCompra;
        private TextBox txtNumeroFactura;
        private ComboBox cmbProductos;
        private TextBox txtCantidad;
        private Button btnAgregarItem;
        private TextBox txtTotalCompra;
        private Button btnCompletarCompra;
        private DataGridView dataGridView1;
        private Label label7;
        private TextBox txtPrecio;
    }
}