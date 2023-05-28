using Datos;
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
    public partial class FrmCategoria : MetroFramework.Forms.MetroForm
    {
        private int tmpID = 0;
        private string c_name, c_description;
        public FrmCategoria()
        {
            InitializeComponent();
        }
        public FrmCategoria(int id, string name, string descrip)
        {
            InitializeComponent();
            tmpID = id;
            c_name = name;
            c_description = descrip;
            if (tmpID != 0)
            {
                txtCategoryId.Text = tmpID.ToString();
                txtCategoryName.Text = c_name;
                txtDescription.Text = c_description;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tmpID == 0)
            {
                CategoryDAO cat = new CategoryDAO();
                int filas = cat.agregar(new Modelos.Category(0, txtCategoryName.Text, txtDescription.Text)); 

            }
            else
            {
                CategoryDAO cat = new CategoryDAO();
                int filas=cat.editar(new Modelos.Category(Convert.ToInt32(txtCategoryId.Text), txtCategoryName.Text,
                    txtDescription.Text));

                if (filas == 0)
                {
                    MessageBox.Show("Error al realizar la operación.");
                }
                else
                {
                    MessageBox.Show("Operación realizada exitosamente.");
                    this.Dispose();
                }
            }
        }
    }
}
