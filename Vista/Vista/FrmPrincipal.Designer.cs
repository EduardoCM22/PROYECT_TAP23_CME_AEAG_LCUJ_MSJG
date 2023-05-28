namespace Vista
{
    partial class FrmPrincipal
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
            this.btnProductos = new MetroFramework.Controls.MetroButton();
            this.btnCategorias = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(71, 88);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(112, 20);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Productos";
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(203, 88);
            this.btnCategorias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(112, 20);
            this.btnCategorias.TabIndex = 1;
            this.btnCategorias.Text = "Categorías";
            this.btnCategorias.Click += new System.EventHandler(this.btnCatalogoCategorias_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnProductos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.Text = "Menú";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnProductos;
        private MetroFramework.Controls.MetroButton btnCategorias;
    }
}