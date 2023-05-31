using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{

    public partial class FrmPrincipal : MetroFramework.Forms.MetroForm
    {
        private Employee emp;
        public List<Product> prod;
        private CancellationTokenSource cancellationTokenSource;

        
        public FrmPrincipal(Employee empleado)
        {
            InitializeComponent();

            emp = empleado;
            prod = null;
            cancellationTokenSource = new CancellationTokenSource();

            if (empleado.Title.Equals("Vice President, Sales"))
            {
                //Acceso a todo
            }
            else if (empleado.Title.Equals("Sales Manager"))
            {
                //Todo excepto Empleados, Notificacion para productos agotados
                btnEmpleados.Visible = false;
            }
            else if (empleado.Title.Equals("Sales Representative"))
            {
                //Ventas
                btnProductos.Visible = false;
                btnAdquisicion.Visible = false;
                btnCategorias.Visible = false;
                btnEmpleados.Visible = false;
                btnCompras.Visible = false;
            }
            else
            {
                //Inside Sales Coordinator - Todo excepto Empleados, Notificacion para productos agotados
                btnEmpleados.Visible = false;
                Task.Run(() => SatartTask(cancellationTokenSource.Token));
            }
        }

        public async Task SatartTask(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Verificar las unidades en stock de los productos que se están quedando sin stock de forma asíncrona
                ProductDAO productsDAO = new ProductDAO();
                List<Product> productsLowStock = await productsDAO.consultarProductosPorPedir();

                foreach (Product product in productsLowStock)
                {
                    product.ReorderLevel = (product.ReorderLevel - product.UnitsInStock) + (product.ReorderLevel / 2);
                }

                if (productsLowStock.Count > 0)
                {
                    await Task.Delay(5000); //para que no salga de inmediato
                    FrmTask wishList = new FrmTask(productsLowStock);
                    wishList.ShowDialog();
                }

                // Esperar 1 minuto
                await Task.Delay(10000, cancellationToken);
            }
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

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FrmCatalagoEmpleados empleados = new FrmCatalagoEmpleados();
            empleados.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmCatalogoVentas ventas = new FrmCatalogoVentas(emp);
            ventas.ShowDialog();
        }

        private void btnAdquisicion_Click(object sender, EventArgs e)
        {
            FrmAdquirir adquisicion = new FrmAdquirir();
            adquisicion.ShowDialog();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FrmCompras compras = new FrmCompras(prod);
            compras.ShowDialog();
        }
    }
}
