namespace Vista
{
    partial class FrmVentas
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
            this.txtUnidades = new MetroFramework.Controls.MetroTextBox();
            this.txtClave = new MetroFramework.Controls.MetroTextBox();
            this.cmbProductos = new MetroFramework.Controls.MetroComboBox();
            this.cmbClientes = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lblClave = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new MetroFramework.Controls.MetroButton();
            this.bntAceptar = new MetroFramework.Controls.MetroButton();
            this.btnEliminar = new MetroFramework.Controls.MetroButton();
            this.lblCantidad = new MetroFramework.Controls.MetroLabel();
            this.lblTotal = new MetroFramework.Controls.MetroLabel();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUnidades
            // 
            this.txtUnidades.Location = new System.Drawing.Point(370, 204);
            this.txtUnidades.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(150, 30);
            this.txtUnidades.TabIndex = 15;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(120, 157);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(150, 30);
            this.txtClave.TabIndex = 14;
            // 
            // cmbProductos
            // 
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.ItemHeight = 24;
            this.cmbProductos.Location = new System.Drawing.Point(370, 157);
            this.cmbProductos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(385, 30);
            this.cmbProductos.TabIndex = 13;
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.ItemHeight = 24;
            this.cmbClientes.Location = new System.Drawing.Point(120, 103);
            this.cmbClientes.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(634, 30);
            this.cmbClientes.TabIndex = 12;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(295, 204);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(67, 20);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Unidades";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(291, 157);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(71, 20);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Productos";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(69, 157);
            this.lblClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(43, 20);
            this.lblClave.TabIndex = 9;
            this.lblClave.Text = "Clave";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(54, 103);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(58, 20);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Clientes";
            // 
            // dgvVentas
            // 
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(54, 266);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.Size = new System.Drawing.Size(700, 300);
            this.dgvVentas.TabIndex = 16;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(546, 204);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.TabIndex = 17;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // bntAceptar
            // 
            this.bntAceptar.Location = new System.Drawing.Point(299, 597);
            this.bntAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.bntAceptar.Name = "bntAceptar";
            this.bntAceptar.Size = new System.Drawing.Size(100, 30);
            this.bntAceptar.TabIndex = 19;
            this.bntAceptar.Text = "Aceptar";
            this.bntAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(654, 204);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCantidad.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCantidad.Location = new System.Drawing.Point(681, 32);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(47, 25);
            this.lblCantidad.TabIndex = 21;
            this.lblCantidad.Text = "0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTotal.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotal.Location = new System.Drawing.Point(611, 32);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(64, 25);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "Total :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(420, 597);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmVentas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(810, 650);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.bntAceptar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.txtUnidades);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FrmVentas";
            this.Text = "Ventas-Nombre Empleado";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtUnidades;
        private MetroFramework.Controls.MetroTextBox txtClave;
        private MetroFramework.Controls.MetroComboBox cmbProductos;
        private MetroFramework.Controls.MetroComboBox cmbClientes;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblClave;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridView dgvVentas;
        private MetroFramework.Controls.MetroButton btnAgregar;
        private MetroFramework.Controls.MetroButton bntAceptar;
        private MetroFramework.Controls.MetroButton btnEliminar;
        private MetroFramework.Controls.MetroLabel lblCantidad;
        private MetroFramework.Controls.MetroLabel lblTotal;
        private MetroFramework.Controls.MetroButton btnCancelar;
    }
}