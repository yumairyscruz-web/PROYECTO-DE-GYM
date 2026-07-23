namespace Proyecto_GYM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btningresa = new Button();
            btnsalir = new Button();
            txtusuario = new TextBox();
            txtclave = new TextBox();
            SuspendLayout();
            // 
            // btningresa
            // 
            btningresa.Location = new Point(190, 331);
            btningresa.Name = "btningresa";
            btningresa.Size = new Size(113, 40);
            btningresa.TabIndex = 0;
            btningresa.Text = "Ingresar";
            btningresa.UseVisualStyleBackColor = true;
            // 
            // btnsalir
            // 
            btnsalir.Location = new Point(370, 331);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(113, 40);
            btnsalir.TabIndex = 1;
            btnsalir.Text = "Salir";
            btnsalir.UseVisualStyleBackColor = true;
            // 
            // txtusuario
            // 
            txtusuario.Location = new Point(323, 120);
            txtusuario.Name = "txtusuario";
            txtusuario.Size = new Size(183, 23);
            txtusuario.TabIndex = 2;
            txtusuario.TextChanged += textusuario_TextChanged;
            // 
            // txtclave
            // 
            txtclave.Location = new Point(323, 183);
            txtclave.Name = "txtclave";
            txtclave.Size = new Size(183, 23);
            txtclave.TabIndex = 3;
            txtclave.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(txtclave);
            Controls.Add(txtusuario);
            Controls.Add(btnsalir);
            Controls.Add(btningresa);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btningresa;
        private Button btnsalir;
        private TextBox txtusuario;
        private TextBox txtclave;
    }
}
