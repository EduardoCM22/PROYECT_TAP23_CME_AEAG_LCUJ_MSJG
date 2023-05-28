namespace Vista
{
    partial class FrmEmpleado
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
            this.cmbPuesto = new MetroFramework.Controls.MetroComboBox();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.txtApellidos = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtPostal = new MetroFramework.Controls.MetroTextBox();
            this.C = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cmbReporta = new MetroFramework.Controls.MetroComboBox();
            this.btnAceptar = new MetroFramework.Controls.MetroButton();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.ItemHeight = 24;
            this.cmbPuesto.Items.AddRange(new object[] {
            "Vice President, Sales",
            "Sales Manager",
            "Sales Representative",
            "Inside Sales Coordinator"});
            this.cmbPuesto.Location = new System.Drawing.Point(222, 196);
            this.cmbPuesto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(219, 30);
            this.cmbPuesto.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(222, 107);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 28);
            this.txtNombre.TabIndex = 6;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(222, 153);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(220, 28);
            this.txtApellidos.TabIndex = 7;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(110, 112);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 20);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Nombre";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(110, 158);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 20);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Apellidos";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(110, 208);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(51, 20);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Puesto";
            // 
            // txtPostal
            // 
            this.txtPostal.Location = new System.Drawing.Point(222, 252);
            this.txtPostal.Margin = new System.Windows.Forms.Padding(4);
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(220, 28);
            this.txtPostal.TabIndex = 11;
            // 
            // C
            // 
            this.C.AutoSize = true;
            this.C.Location = new System.Drawing.Point(92, 257);
            this.C.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(92, 20);
            this.C.TabIndex = 12;
            this.C.Text = "Codigo Postal";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(103, 318);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(69, 20);
            this.metroLabel4.TabIndex = 13;
            this.metroLabel4.Text = "Reporta a";
            // 
            // cmbReporta
            // 
            this.cmbReporta.FormattingEnabled = true;
            this.cmbReporta.ItemHeight = 24;
            this.cmbReporta.Items.AddRange(new object[] {
            "-"});
            this.cmbReporta.Location = new System.Drawing.Point(222, 305);
            this.cmbReporta.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReporta.Name = "cmbReporta";
            this.cmbReporta.Size = new System.Drawing.Size(219, 30);
            this.cmbReporta.TabIndex = 14;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(206, 400);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(343, 400);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 495);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbReporta);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.C);
            this.Controls.Add(this.txtPostal);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbPuesto);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEmpleado";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "FrmEmpleado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox cmbPuesto;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroTextBox txtApellidos;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtPostal;
        private MetroFramework.Controls.MetroLabel C;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox cmbReporta;
        private MetroFramework.Controls.MetroButton btnAceptar;
        private MetroFramework.Controls.MetroButton btnCancelar;
    }
}