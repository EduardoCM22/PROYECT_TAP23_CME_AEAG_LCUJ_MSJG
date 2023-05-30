using Datos;
using MetroFramework.Forms;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmVentas : MetroFramework.Forms.MetroForm
    {
        private List<Customer> customers = new CustomerDAO().obtenerCustomers();
        private List<Product> products = new ProductDAO().obtenerNoDescontinuados();

        private List<OrderDetails> ordersDetails = new List<OrderDetails>();
        private List<Product> productsAct = new List<Product>();

        private Employee emp;
        private Order ord;

        public FrmVentas(Employee employee)
        {
            InitializeComponent();

            lblClave.Visible = false;
            txtClave.Visible = false;

            //Desactivar la adición, eliminación y edición el el gridview
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvVentas.Columns.Add("CategoryID", "CategoryID");
            dgvVentas.Columns["CategoryID"].Visible = false;
            dgvVentas.Columns.Add("ProductID", "ProductID");
            dgvVentas.Columns["ProductID"].Visible = false;

            dgvVentas.Columns.Add("Product", "Producto");
            dgvVentas.Columns.Add("UnitPrice", "Precio");
            dgvVentas.Columns.Add("Units", "Unidades");
            dgvVentas.Columns.Add("SubTotal", "SubTotal");

            dgvVentas.AutoResizeColumns();
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.Text = "Ventas-" + employee.FullName;
            emp = employee;

            cmbClientes.DataSource = customers;
            cmbClientes.DisplayMember = "CompanyName";
            cmbClientes.ValueMember = "CustomerID";

            cmbProductos.DataSource = products;
            cmbProductos.DisplayMember = "ProductName";
            cmbProductos.ValueMember = "ProductID";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Product prod = null;
            int unidades;

            if (int.TryParse(txtUnidades.Text, out unidades))
            {
                if (unidades != 0)
                {
                   
                    foreach (Product product in products)
                    {
                        if (int.Parse(cmbProductos.SelectedValue.ToString()) == product.ProductID)
                        {
                            prod = product;
                            break;
                        }
                    }
                    if (unidades > prod.UnitsInStock)
                    {
                        MessageBox.Show("Unidades no validas. Las unidades son mayores a las que hay disponibles.", "Ingreso Datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //OrderDAO ordVerif = new OrderDAO();
                    //int verif = ordVerif.verificar(prod.ProductID, unidades);
                    //if (verif >= 0)
                    //{
                    //    Console.WriteLine(verif.ToString());
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Unidades venta mayores a las unidades stock", "Ingreso Datos",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}

                    if (dgvVentas.RowCount > 0)
                    {
                        
                        bool editado = false;
                        foreach (DataGridViewRow row in dgvVentas.Rows)
                        {
                            editado = false;
                            if (cmbClientes.SelectedValue.ToString().Equals(row.Cells[0].Value.ToString()) &&
                                int.Parse(cmbProductos.SelectedValue.ToString()) == int.Parse(row.Cells[1].Value.ToString()))
                            {
                                row.Cells[4].Value = int.Parse(row.Cells[4].Value.ToString()) + unidades;
                                row.Cells[5].Value = int.Parse(row.Cells[4].Value.ToString()) * prod.UnitPrice;
                                editado = true;
                                break;
                            }
                        }
                        if (editado == false)
                        {
                            dgvVentas.Rows.Add(cmbClientes.SelectedValue.ToString(), prod.ProductID, prod.ProductName,
                              prod.UnitPrice, txtUnidades.Text, (unidades * prod.UnitPrice));
                        }
                    }
                    else
                    {
                        dgvVentas.Rows.Add(cmbClientes.SelectedValue.ToString(), prod.ProductID, prod.ProductName,
                           prod.UnitPrice, txtUnidades.Text, (unidades * prod.UnitPrice));
                        ord = new Order(dgvVentas.SelectedRows[0].Cells[0].Value.ToString(), emp.EmployeeID);
                    }
                    double total = 0.00;
                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        total += double.Parse(row.Cells[5].Value.ToString());
                    }
                    lblCantidad.Text = total.ToString();
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

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            OrderDAO orderDAO = new OrderDAO();
            int ultimoID = orderDAO.insertar(ord);

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (ultimoID != 0)
                {
                    ordersDetails.Add(new OrderDetails(
                        ultimoID,
                        int.Parse(row.Cells[1].Value.ToString()),
                        double.Parse(row.Cells[3].Value.ToString()),
                        int.Parse(row.Cells[4].Value.ToString())
                        ));
                    productsAct.Add(new Product(
                        int.Parse(row.Cells[1].Value.ToString()),
                        row.Cells[2].Value.ToString(),
                        double.Parse(row.Cells[3].Value.ToString()),
                        int.Parse(row.Cells[4].Value.ToString()) //MySQL UnitsInStock-Units
                        ));
                }
                else
                {
                    MessageBox.Show("Error al agregar orden.", "Agregar Orden",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            OrderDetailsDAO orderDetailsDAO = new OrderDetailsDAO();
            int filasAfectadas = orderDetailsDAO.insertar(ordersDetails);

            if (filasAfectadas != 0)
            {
                MessageBox.Show("Operación realizada con exito", "Agregar Orden y Detalle Orden",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al insertar detalles orden.", "Agregar Detalle Orden",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProductDAO productDAO = new ProductDAO();
            int filasAfectProd = productDAO.actualizar(productsAct);

            if (filasAfectProd != 0)
            {
                MessageBox.Show("Operación realizada con exito", "Actualizar Productos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar productos.", "Actualizar Productos",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            double total = 0.00;
            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                total += double.Parse(row.Cells[5].Value.ToString());
            }
            lblCantidad.Text = total.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
