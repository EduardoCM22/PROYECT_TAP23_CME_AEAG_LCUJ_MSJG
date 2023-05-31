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
    public partial class FrmCompras : MetroFramework.Forms.MetroForm
    {
        public FrmCompras(List<Product> productos)
        {
            InitializeComponent();

            Conexion con = new Conexion();

            //Desactivar la adición, eliminación y edición el el gridview
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.DataSource = productos;

            dgvProductos.Columns["ProductName"].HeaderText = "Producto";
            dgvProductos.Columns["ReorderLevel"].HeaderText = "Cantidad Por Pedir";

            dgvProductos.Columns["ProductID"].Visible = false;
            dgvProductos.Columns["SupplierID"].Visible = false;
            dgvProductos.Columns["CompanyName"].Visible = false;
            dgvProductos.Columns["CategoryID"].Visible = false;
            dgvProductos.Columns["CategoryName"].Visible = false;
            dgvProductos.Columns["UnitPrice"].Visible = false;
            dgvProductos.Columns["UnitsInStock"].Visible = false;
            dgvProductos.Columns["Discontinued"].Visible = false;

            dgvProductos.AutoResizeColumns();
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvProductos.Rows.Clear();
        }
    }
}
