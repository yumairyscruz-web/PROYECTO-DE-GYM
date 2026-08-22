namespace Proyecto_GYM
{
    partial class Formcuenta_por_cobrar
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
            label2 = new Label();
            txtCedula = new MaskedTextBox();
            label3 = new Label();
            txtMontoTotal = new TextBox();
            txtMontoAbono = new TextBox();
            label4 = new Label();
            label5 = new Label();
            dtpFechaPago = new DateTimePicker();
            dgvCuentasPorCobrar = new DataGridView();
            label6 = new Label();
            btnRegistrarPago = new Button();
            btnVerDetalle = new Button();
            btnLimpiar = new Button();
            txtEstadoCuenta = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCuentasPorCobrar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 26);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Clientes:";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(106, 23);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(228, 23);
            cmbClientes.TabIndex = 1;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 82);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 2;
            label2.Text = "Cedula:";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(106, 74);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.ReadOnly = true;
            txtCedula.Size = new Size(204, 23);
            txtCedula.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 130);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 4;
            label3.Text = "Monto Total / Deuda:";
            // 
            // txtMontoTotal
            // 
            txtMontoTotal.Location = new Point(184, 122);
            txtMontoTotal.Multiline = true;
            txtMontoTotal.Name = "txtMontoTotal";
            txtMontoTotal.ReadOnly = true;
            txtMontoTotal.Size = new Size(137, 31);
            txtMontoTotal.TabIndex = 5;
            // 
            // txtMontoAbono
            // 
            txtMontoAbono.Location = new Point(623, 28);
            txtMontoAbono.Name = "txtMontoAbono";
            txtMontoAbono.Size = new Size(137, 23);
            txtMontoAbono.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(370, 31);
            label4.Name = "label4";
            label4.Size = new Size(135, 15);
            label4.TabIndex = 7;
            label4.Text = "Monto a Pagar / Abono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(370, 82);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 8;
            label5.Text = "Fecha de Pago:";
            // 
            // dtpFechaPago
            // 
            dtpFechaPago.Location = new Point(517, 76);
            dtpFechaPago.Name = "dtpFechaPago";
            dtpFechaPago.Size = new Size(243, 23);
            dtpFechaPago.TabIndex = 9;
            // 
            // dgvCuentasPorCobrar
            // 
            dgvCuentasPorCobrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentasPorCobrar.Location = new Point(24, 242);
            dgvCuentasPorCobrar.Name = "dgvCuentasPorCobrar";
            dgvCuentasPorCobrar.Size = new Size(452, 150);
            dgvCuentasPorCobrar.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(370, 130);
            label6.Name = "label6";
            label6.Size = new Size(102, 15);
            label6.TabIndex = 11;
            label6.Text = "Estado de Cuenta:";
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(421, 177);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(113, 35);
            btnRegistrarPago.TabIndex = 13;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.Location = new Point(540, 175);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(130, 35);
            btnVerDetalle.TabIndex = 14;
            btnVerDetalle.Text = "Cuenta / Detalle";
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(676, 175);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(103, 35);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtEstadoCuenta
            // 
            txtEstadoCuenta.Location = new Point(549, 127);
            txtEstadoCuenta.Name = "txtEstadoCuenta";
            txtEstadoCuenta.ReadOnly = true;
            txtEstadoCuenta.Size = new Size(211, 23);
            txtEstadoCuenta.TabIndex = 16;
            // 
            // Formcuenta_por_cobrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(txtEstadoCuenta);
            Controls.Add(btnLimpiar);
            Controls.Add(btnVerDetalle);
            Controls.Add(btnRegistrarPago);
            Controls.Add(label6);
            Controls.Add(dgvCuentasPorCobrar);
            Controls.Add(dtpFechaPago);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtMontoAbono);
            Controls.Add(txtMontoTotal);
            Controls.Add(label3);
            Controls.Add(txtCedula);
            Controls.Add(label2);
            Controls.Add(cmbClientes);
            Controls.Add(label1);
            Name = "Formcuenta_por_cobrar";
            Text = "Formcuenta_por_cobrar";
            Load += Formcuenta_por_cobrar_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCuentasPorCobrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbClientes;
        private Label label2;
        private MaskedTextBox txtCedula;
        private Label label3;
        private TextBox txtMontoTotal;
        private TextBox txtMontoAbono;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpFechaPago;
        private DataGridView dgvCuentasPorCobrar;
        private Label label6;
        private Button btnRegistrarPago;
        private Button btnVerDetalle;
        private Button btnLimpiar;
        private TextBox txtEstadoCuenta;
    }
}