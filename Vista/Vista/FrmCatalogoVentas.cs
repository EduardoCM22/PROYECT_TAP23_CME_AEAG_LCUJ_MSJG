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
    public partial class FrmCatalogoVentas : MetroFramework.Forms.MetroForm
    {
        private List<Order> ventas = new OrderDAO().obtenerVentas();
        private Employee emp;

        public FrmCatalogoVentas(Employee employee)
        {
            InitializeComponent();

            emp = employee;

            dgvVentas.DataSource = ventas;

            //Desactivar la adición, eliminación y edición el el gridview
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvVentas.Columns["EmployeeName"].HeaderText = "Nombre";
            dgvVentas.Columns["CustomerName"].HeaderText = "Cliente";
            dgvVentas.Columns["OrderDate"].HeaderText = "Fecha";
            dgvVentas.Columns["Freight"].HeaderText = "Total";

            dgvVentas.Columns["OrderID"].Visible = false;
            dgvVentas.Columns["EmployeeId"].Visible = false;
            dgvVentas.Columns["CustomerId"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmVentas agregar = new FrmVentas(emp);

            agregar.ShowDialog();

            ventas = new OrderDAO().obtenerVentas();
            dgvVentas.DataSource = ventas;
            this.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvVentas.SelectedRows[0];

            int orderId = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string employeeName = filaSeleccionada.Cells[2].Value.ToString();

            string message = "¿Está seguro que desea eliminar la venta de " + employeeName + "?";
            string caption = "Eliminación Venta.";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int c = new OrderDAO().Eliminar(orderId);
                if (c == 1451)
                {
                    MessageBox.Show("No se puede eliminar por que tiene relación con otros elementos.",
                        caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (c == 0)
                {
                    MessageBox.Show("No se pudo realizar la operación.", caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Eliminado exitosamente.", caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            ventas = new OrderDAO().obtenerVentas();
            dgvVentas.DataSource = ventas;
            this.Show();
        }
    }
}
