using Datos;
using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmEmpleado : MetroFramework.Forms.MetroForm
    {
        private int empId;
        private List<Employee> empleados = new EmployeeDAO().obtenerEmpleados();
        public FrmEmpleado()
        {
            InitializeComponent();
            cmbPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReporta.DataSource = empleados;
            cmbReporta.DisplayMember = "FullName";
            cmbReporta.ValueMember = "EmployeeID";
            cmbReporta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void establecerValores(int eId, string FName, string LName, string cboPuesto,
           string cPostal, int cboReporta)
        {
            empId = eId;
            if (empId != 0)
            {
                txtNombre.Text = FName;
                txtApellidos.Text = LName;
                cmbPuesto.SelectedItem = cboPuesto;
                txtPostal.Text = cPostal;
                cmbReporta.SelectedValue = cboReporta;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            EmployeeDAO empDAO = new EmployeeDAO();
            Employee employee;
            int contFilasModificadas = 0;

            if (empId == 0)
            {
                employee = new Employee(0, txtNombre.Text, txtApellidos.Text, cmbPuesto.SelectedItem.ToString(),
                    txtPostal.Text, int.Parse(cmbReporta.SelectedValue.ToString()));
                contFilasModificadas = empDAO.agregar(employee);
            }
            else
            {
                employee = new Employee(empId, txtNombre.Text, txtApellidos.Text, cmbPuesto.SelectedItem.ToString(),
                    txtPostal.Text, int.Parse(cmbReporta.SelectedValue.ToString()));
                contFilasModificadas = empDAO.editar(employee);
            }
            if (contFilasModificadas == 0)
            {
                MessageBox.Show("Error al realizar la operación.");
            }
            else
            {
                MessageBox.Show("Operación realizada exitosamente.");
                this.Dispose();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
