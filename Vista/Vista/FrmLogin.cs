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
using MetroFramework.Forms;
using Modelos;

namespace Vista
{
    public partial class FrmLogin : MetroFramework.Forms.MetroForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee employee = employeeDAO.login(txtUsuario.Text, txtContrasenia.Text);

            if (employee != null)
            {
                MessageBox.Show("Bienvenido " + employee.FullName, "Inicio Sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmPrincipal principal = new FrmPrincipal(employee);
                this.Hide();
                principal.ShowDialog();
                this.Dispose();
            }
            else
            {
                if (!Conexion.Conectar())
                {
                    FrmConexion conexion = new FrmConexion();
                    conexion.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Inicio Sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCambio_Click(object sender, EventArgs e)
        {
            FrmConexion conexion = new FrmConexion();
            conexion.ShowDialog();
        }
    }
}
