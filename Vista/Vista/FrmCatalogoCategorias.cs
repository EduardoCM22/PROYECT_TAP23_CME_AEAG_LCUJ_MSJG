using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Modelos;

namespace Vista
{
    public partial class FrmCatalogoCategorias : MetroFramework.Forms.MetroForm
    {
        private List<Category> categorias;
        public FrmCatalogoCategorias()
        {
            InitializeComponent();

            /*MessageBox.Show(con.Conectar()+"");*/
            categorias = new CategoryDAO().obtenerCategorias();

            dgvCategorias.DataSource = categorias;

            //Desactivar la adición, eliminación y edición el el gridview
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCategorias.Columns["CategoryId"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCategoria agregar = new FrmCategoria();

            agregar.establecerValores(0, "", "");
            agregar.ShowDialog();

            categorias = new CategoryDAO().obtenerCategorias();
            dgvCategorias.DataSource = categorias;
            this.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmCategoria editar = new FrmCategoria();
            DataGridViewRow filaSeleccionada = dgvCategorias.SelectedRows[0];

            int categoryId = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            String categorieName = filaSeleccionada.Cells[1].Value.ToString();
            String description = filaSeleccionada.Cells[2].Value.ToString();

            editar.establecerValores(categoryId, categorieName, description);
            editar.ShowDialog();

            categorias = new CategoryDAO().obtenerCategorias();
            dgvCategorias.DataSource = categorias;
            this.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvCategorias.SelectedRows[0];

            int categoryId = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            String categoryName= filaSeleccionada.Cells[1].Value.ToString();

            string message = "¿Está seguro que desea eliminar la categoría " + categoryName+ "?";
            string caption = "Eliminación Categoría.";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int c = new CategoryDAO().Eliminar(categoryId);
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
            categorias = new CategoryDAO().obtenerCategorias();
            dgvCategorias.DataSource = categorias;
            this.Show();
        }
    }
}
