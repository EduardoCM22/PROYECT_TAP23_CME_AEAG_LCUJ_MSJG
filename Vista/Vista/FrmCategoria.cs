using Datos;
using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmCategoria : MetroFramework.Forms.MetroForm
    {
        private int catId;

        public FrmCategoria()
        {
            InitializeComponent();
        }
        public void establecerValores(int categoryId, String nombre, String descripcion)
        {
            catId = categoryId;
            if (catId != 0)
            {
                txtNombre.Text = nombre;
                txtDescripcion.Text = descripcion;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int filasAfectadas;

            if (catId == 0)
            {
                Category caterory = new Category(0, txtNombre.Text, txtDescripcion.Text);
                filasAfectadas = new CategoryDAO().agregar(caterory);
            }
            else
            {
                Category caterory = new Category(catId, txtNombre.Text, txtDescripcion.Text);
                filasAfectadas = new CategoryDAO().editar(caterory);
            }
            if (filasAfectadas == 0)
            {
                MessageBox.Show("Error al realizar la operación.", "Agregar/Editar Categoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Operación realizada exitosamente.", "Agregar/Editar Categoria",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
