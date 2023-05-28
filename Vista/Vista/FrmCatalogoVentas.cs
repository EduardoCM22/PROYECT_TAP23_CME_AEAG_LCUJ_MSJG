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
        private List<Order> ventas;
        public FrmCatalogoVentas()
        {
            InitializeComponent();
            Conexion con = new Conexion();

            /*MessageBox.Show(con.Conectar()+"");*/
            ventas = new OrderDAO().obtenerVentas();

            dgvVentas.DataSource = ventas;

            //Desactivar la adición, eliminación y edición el el gridview
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.EditMode = DataGridViewEditMode.EditProgrammatically;

            //Activar la selección por fila en lugar de columna
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvVentas.Columns["OrderID"].Visible = false;
            dgvVentas.Columns["EmployeeId"].Visible = false;
            dgvVentas.Columns["CustomerId"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            //pasar el empleado mamastrofico

            FrmVentas agregar = new FrmVentas();

            agregar.ShowDialog();

            ventas = new OrderDAO().obtenerVentas();
            dgvVentas.DataSource = ventas;
            this.Show();
        }
    }
}
