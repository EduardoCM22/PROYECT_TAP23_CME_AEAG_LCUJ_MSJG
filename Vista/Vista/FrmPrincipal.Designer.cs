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
            this.btnEmpleados = new MetroFramework.Controls.MetroButton();
            this.btnVentas = new MetroFramework.Controls.MetroButton();
            this.btnCompras = new MetroFramework.Controls.MetroButton();
            this.btnAdquisicion = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(68, 155);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(200, 60);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Productos";
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(542, 155);
            this.btnCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(200, 60);
            this.btnCategorias.TabIndex = 1;
            this.btnCategorias.Text = "Categorías";
            this.btnCategorias.Click += new System.EventHandler(this.btnCatalogoCategorias_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Location = new System.Drawing.Point(68, 261);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(200, 60);
            this.btnEmpleados.TabIndex = 2;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(304, 261);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(200, 60);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(542, 261);
            this.btnCompras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(200, 60);
            this.btnCompras.TabIndex = 4;
            this.btnCompras.Text = "Compras";
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnAdquisicion
            // 
            this.btnAdquisicion.Location = new System.Drawing.Point(304, 155);
            this.btnAdquisicion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdquisicion.Name = "btnAdquisicion";
            this.btnAdquisicion.Size = new System.Drawing.Size(200, 60);
            this.btnAdquisicion.TabIndex = 5;
            this.btnAdquisicion.Text = "Adquisición Productos";
            this.btnAdquisicion.Click += new System.EventHandler(this.btnAdquisicion_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdquisicion);
            this.Controls.Add(this.btnCompras);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnProductos);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(20, 74, 20, 20);
            this.Text = "Menú";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnProductos;
        private MetroFramework.Controls.MetroButton btnCategorias;
        private MetroFramework.Controls.MetroButton btnEmpleados;
        private MetroFramework.Controls.MetroButton btnVentas;
        private MetroFramework.Controls.MetroButton btnCompras;
        private MetroFramework.Controls.MetroButton btnAdquisicion;
    }
}