namespace Proyecto_GYM
{
    partial class FormCobros
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
            cmbClientes = new ComboBox();
            btnGenerarCargo = new Button();
            txtPlanAsignado = new TextBox();
            label2 = new Label();
            txtMontoVencimiento = new TextBox();
            label3 = new Label();
            cmbTipoItem = new ComboBox();
            label4 = new Label();
            cmbCatalogoItems = new ComboBox();
            label11 = new Label();
            nudCantidad = new NumericUpDown();
            btnQuitarDetalle = new Button();
            dgvDetalle = new DataGridView();
            cmbMetodoPago = new ComboBox();
            label5 = new Label();
            btnCobrar = new Button();
            label6 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            dtpVencimiento = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtSubtotal = new TextBox();
            txtTotal = new TextBox();
            lblCambio = new Label();
            label10 = new Label();
            txtMontoRecibido = new TextBox();
            btnImprimirRecibo = new Button();
            txtNumeroCargo = new TextBox();
            label12 = new Label();
            txtCantidad = new TextBox();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Clientes";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(86, 28);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(205, 23);
            cmbClientes.TabIndex = 1;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // btnGenerarCargo
            // 
            btnGenerarCargo.Location = new Point(179, 60);
            btnGenerarCargo.Name = "btnGenerarCargo";
            btnGenerarCargo.Size = new Size(82, 34);
            btnGenerarCargo.TabIndex = 2;
            btnGenerarCargo.Text = " Cargo ";
            btnGenerarCargo.UseVisualStyleBackColor = true;
            btnGenerarCargo.Click += btnGenerarCargo_Click;
            // 
            // txtPlanAsignado
            // 
            txtPlanAsignado.Location = new Point(116, 106);
            txtPlanAsignado.Name = "txtPlanAsignado";
            txtPlanAsignado.ReadOnly = true;
            txtPlanAsignado.Size = new Size(293, 23);
            txtPlanAsignado.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 114);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 4;
            label2.Text = "PlanAsignado";
            // 
            // txtMontoVencimiento
            // 
            txtMontoVencimiento.Location = new Point(214, 158);
            txtMontoVencimiento.Name = "txtMontoVencimiento";
            txtMontoVencimiento.ReadOnly = true;
            txtMontoVencimiento.Size = new Size(165, 23);
            txtMontoVencimiento.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 161);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 6;
            label3.Text = "Monto Vencimiento";
            // 
            // cmbTipoItem
            // 
            cmbTipoItem.FormattingEnabled = true;
            cmbTipoItem.Location = new Point(597, 144);
            cmbTipoItem.Name = "cmbTipoItem";
            cmbTipoItem.Size = new Size(200, 23);
            cmbTipoItem.TabIndex = 7;
            cmbTipoItem.SelectedIndexChanged += cmbTipoItem_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(501, 144);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 8;
            label4.Text = "TipoItem";
            // 
            // cmbCatalogoItems
            // 
            cmbCatalogoItems.FormattingEnabled = true;
            cmbCatalogoItems.Location = new Point(597, 183);
            cmbCatalogoItems.Name = "cmbCatalogoItems";
            cmbCatalogoItems.Size = new Size(200, 23);
            cmbCatalogoItems.TabIndex = 9;
            cmbCatalogoItems.SelectedIndexChanged += cmbCatalogoItems_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(501, 183);
            label11.Name = "label11";
            label11.Size = new Size(63, 17);
            label11.TabIndex = 30;
            label11.Text = "Catálogo";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(621, 270);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(102, 23);
            nudCantidad.TabIndex = 10;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnQuitarDetalle
            // 
            btnQuitarDetalle.Location = new Point(735, 333);
            btnQuitarDetalle.Name = "btnQuitarDetalle";
            btnQuitarDetalle.Size = new Size(83, 29);
            btnQuitarDetalle.TabIndex = 20;
            btnQuitarDetalle.Text = "Quitar";
            btnQuitarDetalle.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(17, 333);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new Size(712, 150);
            dgvDetalle.TabIndex = 12;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(125, 240);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(226, 23);
            cmbMetodoPago.TabIndex = 13;
            cmbMetodoPago.SelectedIndexChanged += cmbMetodoPago_SelectedIndexChanged_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 243);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 14;
            label5.Text = "Método de pago";
            // 
            // btnCobrar
            // 
            btnCobrar.BackColor = Color.Gray;
            btnCobrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.Location = new Point(309, 295);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(83, 33);
            btnCobrar.TabIndex = 15;
            btnCobrar.Text = "Cobrar";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(477, 31);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 16;
            label6.Text = "Cedula:";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(556, 28);
            maskedTextBox1.Mask = "000-0000000-0";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(144, 23);
            maskedTextBox1.TabIndex = 17;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Location = new Point(565, 73);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(232, 23);
            dtpVencimiento.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(417, 79);
            label7.Name = "label7";
            label7.Size = new Size(140, 20);
            label7.TabIndex = 19;
            label7.Text = "Fecha Vencimiento\r\n";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 201);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 21;
            label8.Text = "Subtotal";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(254, 201);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 22;
            label9.Text = "Total";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(86, 201);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(118, 23);
            txtSubtotal.TabIndex = 23;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(309, 198);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(118, 23);
            txtTotal.TabIndex = 24;
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Location = new Point(258, 304);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(28, 15);
            lblCambio.TabIndex = 25;
            lblCambio.Text = "0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 299);
            label10.Name = "label10";
            label10.Size = new Size(89, 15);
            label10.TabIndex = 26;
            label10.Text = "MontoRecibido";
            // 
            // txtMontoRecibido
            // 
            txtMontoRecibido.Location = new Point(125, 296);
            txtMontoRecibido.Name = "txtMontoRecibido";
            txtMontoRecibido.Size = new Size(127, 23);
            txtMontoRecibido.TabIndex = 27;
            txtMontoRecibido.TextChanged += txtMontoRecibido_TextChanged;
            // 
            // btnImprimirRecibo
            // 
            btnImprimirRecibo.BackColor = Color.Gray;
            btnImprimirRecibo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimirRecibo.ForeColor = SystemColors.ButtonHighlight;
            btnImprimirRecibo.Location = new Point(417, 295);
            btnImprimirRecibo.Name = "btnImprimirRecibo";
            btnImprimirRecibo.Size = new Size(82, 33);
            btnImprimirRecibo.TabIndex = 29;
            btnImprimirRecibo.Text = "Recibo";
            btnImprimirRecibo.UseVisualStyleBackColor = false;
            btnImprimirRecibo.Click += btnImprimirRecibo_Click;
            // 
            // txtNumeroCargo
            // 
            txtNumeroCargo.Location = new Point(17, 67);
            txtNumeroCargo.Name = "txtNumeroCargo";
            txtNumeroCargo.ReadOnly = true;
            txtNumeroCargo.Size = new Size(108, 23);
            txtNumeroCargo.TabIndex = 30;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(507, 224);
            label12.Name = "label12";
            label12.Size = new Size(58, 15);
            label12.TabIndex = 31;
            label12.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(597, 224);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(125, 23);
            txtCantidad.TabIndex = 32;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(612, 263);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(95, 30);
            btnAgregar.TabIndex = 33;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormCobros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(830, 486);
            Controls.Add(btnAgregar);
            Controls.Add(txtCantidad);
            Controls.Add(label12);
            Controls.Add(txtNumeroCargo);
            Controls.Add(btnImprimirRecibo);
            Controls.Add(txtMontoRecibido);
            Controls.Add(label10);
            Controls.Add(lblCambio);
            Controls.Add(txtTotal);
            Controls.Add(txtSubtotal);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dtpVencimiento);
            Controls.Add(maskedTextBox1);
            Controls.Add(label6);
            Controls.Add(btnCobrar);
            Controls.Add(label5);
            Controls.Add(cmbMetodoPago);
            Controls.Add(dgvDetalle);
            Controls.Add(cmbCatalogoItems);
            Controls.Add(label11);
            Controls.Add(cmbTipoItem);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMontoVencimiento);
            Controls.Add(label2);
            Controls.Add(txtPlanAsignado);
            Controls.Add(btnGenerarCargo);
            Controls.Add(cmbClientes);
            Controls.Add(label1);
            Name = "FormCobros";
            Load += FormCobros_Load;
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbClientes;
        private Button btnGenerarCargo;
        private TextBox txtPlanAsignado;
        private Label label2;
        private TextBox txtMontoVencimiento;
        private Label label3;
        private ComboBox cmbTipoItem;
        private Label label4;
        private ComboBox cmbCatalogoItems; // <--- Declarado como ComboBox aquí también
        private NumericUpDown nudCantidad;
        private DataGridView dgvDetalle;
        private ComboBox cmbMetodoPago;
        private Label label5;
        private Button btnCobrar;
        private Label label6;
        private MaskedTextBox maskedTextBox1;
        private DateTimePicker dtpVencimiento;
        private Label label7;
        private Button btnQuitarDetalle;
        private Label label8;
        private Label label9;
        private TextBox txtSubtotal;
        private TextBox txtTotal;
        private Label lblCambio;
        private Label label10;
        private TextBox txtMontoRecibido;
        private Button btnImprimirRecibo;
        private Label label11;
        private TextBox txtNumeroCargo;
        private Label label12;
        private TextBox txtCantidad;
        private Button btnAgregar;
    }
}