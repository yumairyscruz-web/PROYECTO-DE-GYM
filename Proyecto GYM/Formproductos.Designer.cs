
namespace Proyecto_GYM
{
    partial class FormProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            label8 = new Label();
            btnBuscar = new Button();
            cmbCategoria = new ComboBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtBuscar = new TextBox();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            dgvProductos = new DataGridView();
            label11 = new Label();
            cmbMarca = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            numPrecioVenta = new NumericUpDown();
            numPrecioCompra = new NumericUpDown();
            numStock = new NumericUpDown();
            numStockMinimo = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 35);
            label2.Name = "label2";
            label2.Size = new Size(147, 21);
            label2.TabIndex = 1;
            label2.Text = "Nombre Producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(404, 31);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 2;
            label3.Text = "Categoria";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 101);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 3;
            label4.Text = "P. Compra:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 160);
            label5.Name = "label5";
            label5.Size = new Size(57, 21);
            label5.TabIndex = 4;
            label5.Text = "Stock:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 263);
            label6.Name = "label6";
            label6.Size = new Size(100, 21);
            label6.TabIndex = 5;
            label6.Text = "Descripción";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 312);
            label7.Name = "label7";
            label7.Size = new Size(61, 21);
            label7.TabIndex = 6;
            label7.Text = "Estado";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Gray;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonFace;
            btnGuardar.Location = new Point(291, 305);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(93, 37);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Gray;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = SystemColors.ControlLightLight;
            btnEditar.Location = new Point(390, 304);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(93, 37);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiar.ForeColor = SystemColors.ControlLightLight;
            btnLimpiar.Location = new Point(489, 304);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(99, 37);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Gray;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = SystemColors.ButtonFace;
            btnEliminar.Location = new Point(594, 304);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(98, 37);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(31, 368);
            label8.Name = "label8";
            label8.Size = new Size(60, 21);
            label8.TabIndex = 11;
            label8.Text = "Buscar";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(192, 192, 255);
            btnBuscar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ControlLightLight;
            btnBuscar.Location = new Point(291, 362);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 37);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(498, 33);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(194, 23);
            cmbCategoria.TabIndex = 13;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(165, 27);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(233, 29);
            txtNombre.TabIndex = 16;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(136, 255);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(323, 29);
            txtDescripcion.TabIndex = 17;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(113, 366);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(155, 29);
            txtBuscar.TabIndex = 18;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbActivo.Location = new Point(79, 313);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(65, 21);
            rbActivo.TabIndex = 19;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbInactivo.Location = new Point(176, 313);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(75, 21);
            rbInactivo.TabIndex = 20;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 407);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(680, 150);
            dgvProductos.TabIndex = 21;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(12, 208);
            label11.Name = "label11";
            label11.Size = new Size(61, 21);
            label11.TabIndex = 26;
            label11.Text = "Marca:";
            // 
            // cmbMarca
            // 
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Items.AddRange(new object[] { "Optimum Nutrition", "MuscleTech", "Cellucor", "Nike", "Gatorade" });
            cmbMarca.Location = new Point(113, 210);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(216, 23);
            cmbMarca.TabIndex = 27;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(325, 160);
            label12.Name = "label12";
            label12.Size = new Size(120, 21);
            label12.TabIndex = 28;
            label12.Text = "Stock Mínimo:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(350, 98);
            label13.Name = "label13";
            label13.Size = new Size(77, 21);
            label13.TabIndex = 29;
            label13.Text = "P.Ventas:";
            // 
            // numPrecioVenta
            // 
            numPrecioVenta.DecimalPlaces = 2;
            numPrecioVenta.Location = new Point(468, 101);
            numPrecioVenta.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrecioVenta.Name = "numPrecioVenta";
            numPrecioVenta.Size = new Size(143, 23);
            numPrecioVenta.TabIndex = 30;
            // 
            // numPrecioCompra
            // 
            numPrecioCompra.DecimalPlaces = 2;
            numPrecioCompra.Location = new Point(136, 101);
            numPrecioCompra.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrecioCompra.Name = "numPrecioCompra";
            numPrecioCompra.Size = new Size(134, 23);
            numPrecioCompra.TabIndex = 31;
            // 
            // numStock
            // 
            numStock.Location = new Point(118, 158);
            numStock.Name = "numStock";
            numStock.Size = new Size(120, 23);
            numStock.TabIndex = 32;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(468, 163);
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(120, 23);
            numStockMinimo.TabIndex = 33;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(724, 558);
            Controls.Add(numStockMinimo);
            Controls.Add(numStock);
            Controls.Add(numPrecioCompra);
            Controls.Add(numPrecioVenta);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(cmbMarca);
            Controls.Add(label11);
            Controls.Add(dgvProductos);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(txtBuscar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(cmbCategoria);
            Controls.Add(btnBuscar);
            Controls.Add(label8);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FormProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Productos";
            Load += FormProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Label label8;
        private Button btnBuscar;
        private ComboBox cmbCategoria;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtBuscar;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private DataGridView dgvProductos;
        private Label label11;
        private ComboBox cmbMarca;
        private Label label12;
        private Label label13;
        private NumericUpDown numPrecioVenta;
        private NumericUpDown numPrecioCompra;
        private NumericUpDown numStock;
        private NumericUpDown numStockMinimo;
    }
}
