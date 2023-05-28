﻿using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmProducto : MetroFramework.Forms.MetroForm
    {

        private int proId;
        private List<Category> categorias = new CategoryDAO().obtenerCategorias();
        private List<Supplier> companias = new SupplierDAO().obtenerCompanias();

        public FrmProducto()
        {
            InitializeComponent();

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "CategoryName";
            cmbCategoria.ValueMember = "CategoryId";
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCompania.DataSource = companias;
            cmbCompania.DisplayMember = "CompanyName";
            cmbCompania.ValueMember = "SupplierId";
            cmbCompania.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        int reoLevel;
        public void establecerValores(int pId, string pName, int sId, int cId,
            double uPrice, int uStock, int rLevel, bool discont)
        {
            proId = pId;
            reoLevel = rLevel;
            if (pId != 0)
            {
                txtNombre.Text = pName;
                cmbCategoria.SelectedValue = cId;
                cmbCompania.SelectedValue = sId;
                txtPrecio.Text = uPrice + "";
                txtStock.Text = uStock + "";
                cbxDescontinuado.Checked = discont;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ProductDAO p = new ProductDAO();
            Product prdt;
            int contFilasModificadas = 0;
            int unidadesStock = 0;
            double precioUnidad = 0.0;
            if (!double.TryParse(txtPrecio.Text, out precioUnidad))
            {
                MessageBox.Show("Precio unitario no valido. Debe ser un número.", "Ingreso Datos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!int.TryParse(txtStock.Text, out unidadesStock))
            {
                MessageBox.Show("Unidades en stock no valido. Debe ser un número.", "Ingreso Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (proId == 0)
                {
                    prdt = new Product(0, txtNombre.Text, int.Parse(cmbCompania.SelectedValue.ToString()), 
                        cmbCategoria.SelectedText, int.Parse(cmbCategoria.SelectedValue.ToString()), 
                        cmbCategoria.SelectedText, Convert.ToDouble(txtPrecio.Text), 
                        int.Parse(txtStock.Text), reoLevel, cbxDescontinuado.Checked);
                    contFilasModificadas = p.agregar(prdt);
                }
                else
                {
                    prdt = new Product(proId, txtNombre.Text, int.Parse(cmbCompania.SelectedValue.ToString()), 
                        cmbCategoria.SelectedText, int.Parse(cmbCategoria.SelectedValue.ToString()), 
                        cmbCategoria.SelectedText, Convert.ToDouble(txtPrecio.Text), 
                        int.Parse(txtStock.Text), reoLevel, cbxDescontinuado.Checked);
                    contFilasModificadas = p.editar(prdt);
                }
                if (contFilasModificadas == 0)
                {
                    MessageBox.Show("Error al realizar la operación.", "Agregar/Editar Producto", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Operación realizada exitosamente.", "Agregar/Editar Producto", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
