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
    public partial class FrmCatalogoProductos : MetroFramework.Forms.MetroForm
    {
        private List<Product> productos;
        public FrmCatalogoProductos()
        {
            InitializeComponent();
            Conexion con = new Conexion();

            /*MessageBox.Show(con.Conectar()+"");*/
            productos = new ProductDAO().obtenerProductos();

            dgvProductos.DataSource = productos;

            //Desactivar la adición, eliminación y edición el el gridview
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.EditMode = DataGridViewEditMode.EditProgrammatically;

            //Activar la selección por fila en lugar de columna
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.Columns["SupplierId"].Visible = false;
            dgvProductos.Columns["CategoryId"].Visible = false;
        }
    }
}
