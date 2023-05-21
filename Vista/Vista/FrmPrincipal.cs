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
    public partial class FrmPrincipal : MetroFramework.Forms.MetroForm
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            
        }

        private void btnCatalogoCategorias_Click(object sender, EventArgs e)
        {
            FrmCatalogoCategorias categorias = new FrmCatalogoCategorias();
            categorias.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmCatalogoProductos productos = new FrmCatalogoProductos();
            productos.ShowDialog();
        }
    }
}
