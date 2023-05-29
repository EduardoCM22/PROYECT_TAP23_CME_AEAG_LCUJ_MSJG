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

            dgvProductos.Columns["ProductID"].Visible = false;
            dgvProductos.Columns["SupplierId"].Visible = false;
            dgvProductos.Columns["CategoryId"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProducto agregar = new FrmProducto();

            agregar.establecerValores(0, "", 0, 0, 0, 0, 0, false);
            agregar.ShowDialog();

            productos = new ProductDAO().obtenerProductos();
            dgvProductos.DataSource = productos;
            this.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmProducto editar = new FrmProducto();
            DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];

            int productId = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string productName = filaSeleccionada.Cells[1].Value.ToString();
            int supplierId = int.Parse(filaSeleccionada.Cells[2].Value.ToString());
            int categoryId = int.Parse(filaSeleccionada.Cells[4].Value.ToString());
            double unitPrice = Convert.ToDouble(filaSeleccionada.Cells[6].Value.ToString());
            int unitStock = int.Parse(filaSeleccionada.Cells[7].Value.ToString());
            int reorderLevel = int.Parse(filaSeleccionada.Cells[8].Value.ToString());
            bool discontinued = Convert.ToBoolean(filaSeleccionada.Cells[9].Value.ToString());

            editar.establecerValores(productId, productName, supplierId,
                categoryId, unitPrice, unitStock, reorderLevel, discontinued);
            editar.ShowDialog();

            productos = new ProductDAO().obtenerProductos();
            dgvProductos.DataSource = productos;
            this.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];

            int productId = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string productName = filaSeleccionada.Cells[1].Value.ToString();

            string message = "¿Está seguro que desea eliminar el producto " + productName + "?";
            string caption = "Eliminación Producto.";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int c = new ProductDAO().Eliminar(productId);
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
            productos = new ProductDAO().obtenerProductos();
            dgvProductos.DataSource = productos;
            this.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            FrmReorden reorden = new FrmReorden();
            reorden.ShowDialog();
        }
    }
}
