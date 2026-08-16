namespace Proyecto_GYM
{
    partial class FormCargos
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtCedula = new MaskedTextBox();
            txtPlanAsignado = new TextBox();
            txtMontoVencimiento = new TextBox();
            dtpVencimiento = new DateTimePicker();
            label7 = new Label();
            txtNumeroCargo = new TextBox();
            btnGenerarCargo = new Button();
            btnCancelar = new Button();
            dgvCargos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCargos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccionar Cliente:";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(12, 81);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(175, 23);
            cmbClientes.TabIndex = 1;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 22);
            label2.Name = "label2";
            label2.Size = new Size(173, 15);
            label2.TabIndex = 2;
            label2.Text = "Datos e Información del Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 67);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 3;
            label3.Text = "Cédula:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(334, 110);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 4;
            label4.Text = "Plan Asignado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(334, 196);
            label5.Name = "label5";
            label5.Size = new Size(126, 15);
            label5.TabIndex = 5;
            label5.Text = "Fecha de Vencimiento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(334, 150);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 6;
            label6.Text = "Monto a Pagar:";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(426, 67);
            txtCedula.Mask = "000-0000000-0";
            txtCedula.Name = "txtCedula";
            txtCedula.ReadOnly = true;
            txtCedula.Size = new Size(151, 23);
            txtCedula.TabIndex = 7;
            // 
            // txtPlanAsignado
            // 
            txtPlanAsignado.Location = new Point(466, 110);
            txtPlanAsignado.Name = "txtPlanAsignado";
            txtPlanAsignado.ReadOnly = true;
            txtPlanAsignado.Size = new Size(176, 23);
            txtPlanAsignado.TabIndex = 8;
            // 
            // txtMontoVencimiento
            // 
            txtMontoVencimiento.Location = new Point(475, 147);
            txtMontoVencimiento.Name = "txtMontoVencimiento";
            txtMontoVencimiento.ReadOnly = true;
            txtMontoVencimiento.Size = new Size(176, 23);
            txtMontoVencimiento.TabIndex = 9;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Enabled = false;
            dtpVencimiento.Location = new Point(504, 188);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(249, 23);
            dtpVencimiento.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 147);
            label7.Name = "label7";
            label7.Size = new Size(105, 15);
            label7.TabIndex = 11;
            label7.Text = "Número de Cargo:";
            // 
            // txtNumeroCargo
            // 
            txtNumeroCargo.Location = new Point(12, 188);
            txtNumeroCargo.Name = "txtNumeroCargo";
            txtNumeroCargo.ReadOnly = true;
            txtNumeroCargo.Size = new Size(298, 23);
            txtNumeroCargo.TabIndex = 12;
            // 
            // btnGenerarCargo
            // 
            btnGenerarCargo.Location = new Point(41, 227);
            btnGenerarCargo.Name = "btnGenerarCargo";
            btnGenerarCargo.Size = new Size(94, 37);
            btnGenerarCargo.TabIndex = 13;
            btnGenerarCargo.Text = "Generar Cargo";
            btnGenerarCargo.UseVisualStyleBackColor = true;
            btnGenerarCargo.Click += btnGenerarCargo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(165, 227);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 37);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvCargos
            // 
            dgvCargos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCargos.Location = new Point(30, 284);
            dgvCargos.Name = "dgvCargos";
            dgvCargos.Size = new Size(570, 154);
            dgvCargos.TabIndex = 15;
            // 
            // FormCargos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCargos);
            Controls.Add(btnCancelar);
            Controls.Add(btnGenerarCargo);
            Controls.Add(txtNumeroCargo);
            Controls.Add(label7);
            Controls.Add(dtpVencimiento);
            Controls.Add(txtMontoVencimiento);
            Controls.Add(txtPlanAsignado);
            Controls.Add(txtCedula);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbClientes);
            Controls.Add(label1);
            Name = "FormCargos";
            Text = "FormCargos";
            Load += FormCargos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCargos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbClientes;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private MaskedTextBox txtCedula;
        private TextBox txtPlanAsignado;
        private TextBox txtMontoVencimiento;
        private DateTimePicker dtpVencimiento;
        private Label label7;
        private TextBox txtNumeroCargo;
        private Button btnGenerarCargo;
        private Button btnCancelar;
        private DataGridView dgvCargos;
    }
}