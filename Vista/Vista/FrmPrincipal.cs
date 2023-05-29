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
    public partial class FrmPrincipal : MetroFramework.Forms.MetroForm
    {
        private Employee emp;

        public FrmPrincipal(Employee empleado)
        {
            InitializeComponent();

            emp = empleado;

            if (empleado.Title.Equals("Vice President, Sales"))
            {
                //Acceso a todo
            }
            else if (empleado.Title.Equals("Sales Manager"))
            {
                //No menciona
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
    }
}
