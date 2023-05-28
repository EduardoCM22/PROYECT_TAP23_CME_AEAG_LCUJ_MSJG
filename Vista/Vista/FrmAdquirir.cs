using Datos;
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
    public partial class FrmAdquirir : MetroFramework.Forms.MetroForm
    {

        private List<Product> productos = new ProductDAO().obtenerAdquirir();
        ProductDAO p = new ProductDAO();
        int contFilasModificadas;

        public FrmAdquirir()
        {
            InitializeComponent();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "ProductName";
            cmbProducto.ValueMember = "ProductId";
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Product product = (Product)cmbProducto.SelectedItem;
            int unidades;
            if (!int.TryParse(txtCantidad.Text, out unidades))
            {
                MessageBox.Show("Cantidad Adquirir no valido. Debe ser un número.", 
                    "Ingreso Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (product.UnitsInStock + Convert.ToInt32(txtCantidad.Text) <= product.ReorderLevel * 5)
                {
                    product.UnitsInStock = product.UnitsInStock + Convert.ToInt32(txtCantidad.Text);
                    contFilasModificadas = p.adquirir(product);
                    if (contFilasModificadas == 0)
                    {
                        MessageBox.Show("Error al realizar la operación.", "Adquirir Producto", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Operación realizada exitosamente.", "Adquirir Producto", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("UnitsInStock rebasa la cantidad máxima de inventario " +
                        "permitida para ese producto.", "Adquirir Producto", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
