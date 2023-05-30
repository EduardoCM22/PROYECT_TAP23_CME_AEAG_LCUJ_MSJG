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
    public partial class FrmConexion : MetroFramework.Forms.MetroForm
    {
        public FrmConexion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocalHost.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese correctamente los datos.", "Ingreso Datos", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Conexion.Conectar(txtLocalHost.Text, txtUsuario.Text, txtPassword.Text))
                {
                    MessageBox.Show("Operación realizada exitosamente","Conexión Realizada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Operación rechazada", "Conexión Fallida", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectar: {ex.Message}");
            }
        }
    }
}
