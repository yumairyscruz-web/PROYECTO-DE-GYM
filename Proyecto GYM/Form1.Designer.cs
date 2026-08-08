using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_GYM
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnsalir = new Button();
            txtusuario = new TextBox();
            txtclave = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            btnIngresar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnsalir
            // 
            btnsalir.BackColor = SystemColors.ActiveBorder;
            btnsalir.Font = new Font("Script MT Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnsalir.Location = new Point(457, 228);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(113, 40);
            btnsalir.TabIndex = 1;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += btnsalir_Click;
            // 
            // txtusuario
            // 
            txtusuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtusuario.Location = new Point(377, 88);
            txtusuario.MaximumSize = new Size(0, 35);
            txtusuario.Multiline = true;
            txtusuario.Name = "txtusuario";
            txtusuario.Size = new Size(193, 25);
            txtusuario.TabIndex = 2;
            txtusuario.TextChanged += textusuario_TextChanged;
            // 
            // txtclave
            // 
            txtclave.Location = new Point(377, 158);
            txtclave.Name = "txtclave";
            txtclave.PasswordChar = '*';
            txtclave.Size = new Size(193, 23);
            txtclave.TabIndex = 3;
            txtclave.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Snap ITC", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(266, 88);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 4;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Snap ITC", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(246, 158);
            label2.Name = "label2";
            label2.Size = new Size(125, 25);
            label2.TabIndex = 5;
            label2.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(233, 312);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Ravie", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(377, 19);
            label3.Name = "label3";
            label3.Size = new Size(131, 39);
            label3.TabIndex = 7;
            label3.Text = "LOGIN";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = SystemColors.ActiveBorder;
            btnIngresar.Font = new Font("Script MT Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(284, 228);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(111, 45);
            btnIngresar.TabIndex = 8;
            btnIngresar.Text = "Ingresa";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(642, 311);
            Controls.Add(btnIngresar);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnsalir);
            Controls.Add(txtusuario);
            Controls.Add(txtclave);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btningresa;
        private Button btnsalir;
        private TextBox txtusuario;
        private TextBox txtclave;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        private Button btnIngresar;
    }
}