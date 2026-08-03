namespace Proyecto_GYM
{
    partial class Formproductos
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
            label7 = new Label();
            btnGuardar = new Button();
            tnEditar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            label8 = new Label();
            btnBuscar = new Button();
            cmbCategoria = new ComboBox();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtBuscar = new TextBox();
            rbActivo = new RadioButton();
            rbInactivo = new RadioButton();
            dgvProductos = new DataGridView();
            label9 = new Label();
            txtIdProducto = new TextBox();
            label10 = new Label();
            txtCodigoBarras = new TextBox();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 63);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 0;
            label1.Text = "Cod. Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 153);
            label2.Name = "label2";
            label2.Size = new Size(147, 21);
            label2.TabIndex = 1;
            label2.Text = "Nombre Producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(360, 17);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 2;
            label3.Text = "Categoria";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(34, 190);
            label4.Name = "label4";
            label4.Size = new Size(90, 21);
            label4.TabIndex = 3;
            label4.Text = "P. Compra:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(34, 225);
            label5.Name = "label5";
            label5.Size = new Size(52, 21);
            label5.TabIndex = 4;
            label5.Text = "Stock";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 271);
            label6.Name = "label6";
            label6.Size = new Size(100, 21);
            label6.TabIndex = 5;
            label6.Text = "Descripción";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(30, 311);
            label7.Name = "label7";
            label7.Size = new Size(61, 21);
            label7.TabIndex = 6;
            label7.Text = "Estado";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(313, 295);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(88, 37);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // tnEditar
            // 
            tnEditar.Location = new Point(407, 293);
            tnEditar.Name = "tnEditar";
            tnEditar.Size = new Size(88, 37);
            tnEditar.TabIndex = 8;
            tnEditar.Text = "Editar";
            tnEditar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(501, 293);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(88, 37);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(595, 295);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(88, 37);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(31, 358);
            label8.Name = "label8";
            label8.Size = new Size(60, 21);
            label8.TabIndex = 11;
            label8.Text = "Buscar";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(276, 352);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 37);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(450, 21);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(138, 23);
            cmbCategoria.TabIndex = 13;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(163, 65);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(150, 23);
            txtCodigo.TabIndex = 15;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(204, 145);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(233, 29);
            txtNombre.TabIndex = 16;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(136, 263);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(323, 29);
            txtDescripcion.TabIndex = 17;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(97, 360);
            txtBuscar.Multiline = true;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(155, 23);
            txtBuscar.TabIndex = 18;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(113, 311);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(59, 19);
            rbActivo.TabIndex = 19;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(195, 311);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(67, 19);
            rbInactivo.TabIndex = 20;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 396);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(680, 150);
            dgvProductos.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(34, 21);
            label9.Name = "label9";
            label9.Size = new Size(105, 21);
            label9.TabIndex = 22;
            label9.Text = "ID Producto:";
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(163, 19);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.Size = new Size(150, 23);
            txtIdProducto.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(35, 103);
            label10.Name = "label10";
            label10.Size = new Size(99, 21);
            label10.TabIndex = 24;
            label10.Text = "Cód. Barras:";
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(163, 105);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(150, 23);
            txtCodigoBarras.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(376, 103);
            label11.Name = "label11";
            label11.Size = new Size(61, 21);
            label11.TabIndex = 26;
            label11.Text = "Marca:";
            // 
            // cmbMarca
            // 
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(450, 103);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(138, 23);
            cmbMarca.TabIndex = 27;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(324, 225);
            label12.Name = "label12";
            label12.Size = new Size(120, 21);
            label12.TabIndex = 28;
            label12.Text = "Stock Mínimo:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(360, 185);
            label13.Name = "label13";
            label13.Size = new Size(77, 21);
            label13.TabIndex = 29;
            label13.Text = "P.Ventas:";
            // 
            // numPrecioVenta
            // 
            numPrecioVenta.Location = new Point(459, 183);
            numPrecioVenta.Name = "numPrecioVenta";
            numPrecioVenta.Size = new Size(120, 23);
            numPrecioVenta.TabIndex = 30;
            // 
            // numPrecioCompra
            // 
            numPrecioCompra.Location = new Point(163, 188);
            numPrecioCompra.Name = "numPrecioCompra";
            numPrecioCompra.Size = new Size(120, 23);
            numPrecioCompra.TabIndex = 31;
            // 
            // numStock
            // 
            numStock.Location = new Point(163, 228);
            numStock.Name = "numStock";
            numStock.Size = new Size(120, 23);
            numStock.TabIndex = 32;
            // 
            // numStockMinimo
            // 
            numStockMinimo.Location = new Point(459, 223);
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(120, 23);
            numStockMinimo.TabIndex = 33;
            // 
            // Formproductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 558);
            Controls.Add(numStockMinimo);
            Controls.Add(numStock);
            Controls.Add(numPrecioCompra);
            Controls.Add(numPrecioVenta);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(cmbMarca);
            Controls.Add(label11);
            Controls.Add(txtCodigoBarras);
            Controls.Add(label10);
            Controls.Add(txtIdProducto);
            Controls.Add(label9);
            Controls.Add(dgvProductos);
            Controls.Add(rbInactivo);
            Controls.Add(rbActivo);
            Controls.Add(txtBuscar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(cmbCategoria);
            Controls.Add(btnBuscar);
            Controls.Add(label8);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(tnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Formproductos";
            Text = "Formproductos";
            Load += Formproductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
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
        private Label label7;
        private Button btnGuardar;
        private Button tnEditar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Label label8;
        private Button btnBuscar;
        private ComboBox cmbCategoria;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtBuscar;
        private RadioButton rbActivo;
        private RadioButton rbInactivo;
        private DataGridView dgvProductos;
        private Label label9;
        private TextBox txtIdProducto;
        private Label label10;
        private TextBox txtCodigoBarras;
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