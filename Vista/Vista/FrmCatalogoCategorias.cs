using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

            //dgvCategorias.Columns["CategoryId"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCategoria cat = new FrmCategoria(0,"","");
            cat.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FrmCategoria cat;
            DataGridViewRow filaSeleccionada = dgvCategorias.SelectedRows[0];

            int id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string categorieName = filaSeleccionada.Cells[1].Value.ToString();
            string des = filaSeleccionada.Cells[2].Value.ToString();

            cat = new FrmCategoria(id, categorieName, des);
            cat.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmCategoria cat;
            DataGridViewRow filaSeleccionada = dgvCategorias.SelectedRows[0];
            int id = 0;
            id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());

            if (id > 0)
            {
                string categorieName = filaSeleccionada.Cells[1].Value.ToString();
                string des = filaSeleccionada.Cells[2].Value.ToString();
                new Datos.CategoryDAO().eliminar(new Category(id, categorieName, des));
            }
            else
            {
                MessageBox.Show("Selecciona una categoría a eliminar");
            }
            
        }
    }
}
