﻿namespace Vista
{
    partial class FrmProducto
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbxDescontinuado = new MetroFramework.Controls.MetroCheckBox();
            this.btnAceptar = new MetroFramework.Controls.MetroButton();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.cmbCompania = new MetroFramework.Controls.MetroComboBox();
            this.cmbCategoria = new MetroFramework.Controls.MetroComboBox();
            this.txtPrecio = new MetroFramework.Controls.MetroTextBox();
            this.txtStock = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(183, 83);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Nombre";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(174, 125);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(70, 20);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Campañia";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(176, 173);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 20);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Categoria";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(144, 227);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(100, 20);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Precio Unitario";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(140, 283);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(104, 20);
            this.metroLabel5.TabIndex = 4;
            this.metroLabel5.Text = "Unidades Stock";
            // 
            // cbxDescontinuado
            // 
            this.cbxDescontinuado.AutoSize = true;
            this.cbxDescontinuado.Location = new System.Drawing.Point(299, 337);
            this.cbxDescontinuado.Name = "cbxDescontinuado";
            this.cbxDescontinuado.Size = new System.Drawing.Size(111, 17);
            this.cbxDescontinuado.TabIndex = 5;
            this.cbxDescontinuado.Text = "Descontinuado";
            this.cbxDescontinuado.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(259, 381);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(366, 381);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(250, 83);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(232, 23);
            this.txtNombre.TabIndex = 8;
            // 
            // cmbCompania
            // 
            this.cmbCompania.FormattingEnabled = true;
            this.cmbCompania.ItemHeight = 24;
            this.cmbCompania.Location = new System.Drawing.Point(250, 125);
            this.cmbCompania.Name = "cmbCompania";
            this.cmbCompania.Size = new System.Drawing.Size(232, 30);
            this.cmbCompania.TabIndex = 9;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.ItemHeight = 24;
            this.cmbCategoria.Location = new System.Drawing.Point(250, 173);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(232, 30);
            this.cmbCategoria.TabIndex = 10;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(250, 227);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(232, 23);
            this.txtPrecio.TabIndex = 11;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(250, 283);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(232, 23);
            this.txtStock.TabIndex = 12;
            // 
            // FrmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbCompania);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbxDescontinuado);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FrmProducto";
            this.Text = "Producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroCheckBox cbxDescontinuado;
        private MetroFramework.Controls.MetroButton btnAceptar;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroComboBox cmbCompania;
        private MetroFramework.Controls.MetroComboBox cmbCategoria;
        private MetroFramework.Controls.MetroTextBox txtPrecio;
        private MetroFramework.Controls.MetroTextBox txtStock;
    }
}