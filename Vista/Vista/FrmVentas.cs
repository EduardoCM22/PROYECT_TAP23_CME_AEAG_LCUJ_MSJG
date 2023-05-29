using Datos;
using MetroFramework.Forms;
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
        private List<Customer> customers = new CustomerDAO().obtenerCustomers();
        private List<Product> products = new ProductDAO().obtenerProductos();
        private List<OrderDetails> orderDetails = new List<OrderDetails>();

        public FrmVentas(Employee employee)
        {
            InitializeComponent();

            //Desactivar la adición, eliminación y edición el el gridview
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Text = "Ventas-" + employee.FullName;

            cmbClientes.DataSource = customers;
            cmbClientes.DisplayMember = "CompanyName";
            cmbClientes.ValueMember = "CustomerID";

            cmbProductos.DataSource = products;
            cmbProductos.DisplayMember = "ProductName";
            cmbProductos.ValueMember = "ProductID";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int unidades;
            if (int.TryParse(txtUnidades.Text, out unidades))
            {
                if (unidades != 0)
                {

                }
                else
                {
                    MessageBox.Show("Unidades no validas. Debe ser un número mayor a cero.", "Ingreso Datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Unidades no validas. Debe ser un número mayor a cero.", "Ingreso Datos",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
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

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
