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
    public partial class FrmCatalagoEmpleados : MetroFramework.Forms.MetroForm
    {
        private List<Employee> Empleados;
        public FrmCatalagoEmpleados()
        {
            InitializeComponent();
            Empleados = new EmployeeDAO().obtenerEmpleados();
            dgvEmpleados.DataSource = Empleados;
            //Desactivar la adición, eliminación y edición el el gridview
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Columns["EmployeeID"].Visible = false;
            dgvEmpleados.Columns["PostalCode"].Visible = false;
            dgvEmpleados.Columns["ReportsTo"].Visible = false;
            dgvEmpleados.Columns["FullName"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmEmpleado agregar = new FrmEmpleado();

            agregar.establecerValores(0, "", "", "", "", 0);
            agregar.ShowDialog();

            Empleados = new EmployeeDAO().obtenerEmpleados();
            dgvEmpleados.DataSource = Empleados;
            this.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEmpleado editar = new FrmEmpleado();
            DataGridViewRow filaSeleccionada = dgvEmpleados.SelectedRows[0];

            int employeeid = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string firstName = filaSeleccionada.Cells[1].Value.ToString();
            string lastName = filaSeleccionada.Cells[2].Value.ToString();
            string Puesto = filaSeleccionada.Cells[3].Value.ToString();
            string postal = filaSeleccionada.Cells[4].Value.ToString();
            int reporta = int.Parse(filaSeleccionada.Cells[5].Value.ToString());

            editar.establecerValores(employeeid, firstName, lastName, Puesto, postal, reporta);
            editar.ShowDialog();

            Empleados = new EmployeeDAO().obtenerEmpleados();
            dgvEmpleados.DataSource = Empleados;
            this.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvEmpleados.SelectedRows[0];
            int employeeId = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string fullName = filaSeleccionada.Cells[1].Value.ToString() + filaSeleccionada.Cells[2].Value.ToString();
            string message = "¿Está seguro que desea eliminar el producto " + fullName + " ?";
            string caption = "Eliminacion de producto";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int c = new EmployeeDAO().Eliminar(employeeId);
                if (c == 1451)
                {
                    MessageBox.Show("No se puede eliminar por que tiene relación con otros elementos.");
                }
                else if (c == 0)
                {
                    MessageBox.Show("No se pudo realizar la operación.");
                }
                else
                {
                    MessageBox.Show("Eliminado exitosamente.");
                }
            }
            Empleados = new EmployeeDAO().obtenerEmpleados();
            dgvEmpleados.DataSource = Empleados;
            this.Show();
        }
    }
}
