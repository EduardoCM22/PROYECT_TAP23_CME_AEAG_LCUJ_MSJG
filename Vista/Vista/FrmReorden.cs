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
    public partial class FrmReorden : MetroFramework.Forms.MetroForm
    {
        private List<Product> productos;

        public FrmReorden()
        {
            InitializeComponent();
            Conexion con = new Conexion();

            /*MessageBox.Show(con.Conectar()+"");*/
            productos = new ProductDAO().reorder();

            dgvReorden.DataSource = productos;

            //Desactivar la adición, eliminación y edición el el gridview
            dgvReorden.AllowUserToAddRows = false;
            dgvReorden.AllowUserToDeleteRows = false;
            dgvReorden.EditMode = DataGridViewEditMode.EditProgrammatically;

            //Activar la selección por fila en lugar de columna
            dgvReorden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvReorden.Columns["ProductName"].HeaderText = "Producto";
            dgvReorden.Columns["CompanyName"].HeaderText = "Compañia";
            dgvReorden.Columns["ReorderLevel"].HeaderText = "Nivel Reorden";

            dgvReorden.Columns["SupplierId"].Visible = false;
            dgvReorden.Columns["CategoryId"].Visible = false;
            dgvReorden.Columns["ProductId"].Visible = false;
            dgvReorden.Columns["UnitsInStock"].Visible = false;
            dgvReorden.Columns["UnitPrice"].Visible = false;
            dgvReorden.Columns["Discontinued"].Visible = false;
            dgvReorden.Columns["CategoryName"].Visible = false;

            dgvReorden.AutoResizeColumns();
            dgvReorden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
