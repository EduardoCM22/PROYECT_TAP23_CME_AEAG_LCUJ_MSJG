﻿using System;
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

            //dgvCategorias.Columns["CategoryId"].Visible = false;
        }
    }
}
