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
    public partial class FrmVentas : MetroFramework.Forms.MetroForm
    {

        ProductDAO productDAO = new ProductDAO();
        List<Product> products = new List<Product>();
        CustomerDAO customersDAO = new CustomerDAO();
        List<Customer> customers = new List<Customer>();

        List<int> unitsID = new List<int>();
        List<int> productsID = new List<int>();
        
        
        Employee empleado;

        public FrmVentas(Employee value)
        {
            InitializeComponent();
            InitializeComponent();
            dgvVentas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            empleado = value;
            this.Text = "Ventas de " + empleado.FullName;
            products = productDAO.obtenerProductos();
            foreach (Product product in products)
            {
                cmbProductos.Items.Add(product.ProductName);
            }
            customers = customersDAO.GetAllCustomers();
            foreach (Customer customer in customers)
            {
                cmbClientes.Items.Add(customer.CompanyName);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            foreach (Product product in products)
            {
                if (product.ProductName.Equals(cmbProductos.Text))
                {
                    int units = Convert.ToInt32(txtUnidades.Text);
                    if (units <= 0)
                    {
                        //MetroMessageBox.Show(this, "Debe haber al menos una unidad", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        productsID.Add(product.ProductID);
                        unitsID.Add(units);
                        dgvVentas.Rows.Add(product.ProductName, product.UnitPrice, units, (units * product.UnitPrice));
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dgvVentas.SelectedRows[0];

                // Eliminar la fila del DataGridView
                dgvVentas.Rows.Remove(selectedRow);
            }
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            OrderDetailsDAO orderDetailsDAO = new OrderDetailsDAO();
            int edo = orderDetailsDAO.sale(empleado.EmployeeId, productsID, unitsID);
            if (edo == 1)
            {
                Console.WriteLine("Venta con varios productos agregada con éxito");
            }
            else if (edo == 0)
            {
                Console.WriteLine("Error al agregar la venta con varios productos");
            }
            else
            {
                Console.WriteLine("Error en la conexion");
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar != '\b')
                {
                    int index = Convert.ToInt32(txtClave.Text + e.KeyChar.ToString());
                    try
                    {
                        cmbProductos.SelectedIndex = index;
                    }
                    catch (Exception)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
