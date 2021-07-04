using System;
using System.Windows.Forms;

namespace PDV
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            string usuario = "";
            string password = "";
            string mensaje = "Ingrese los siguientes datos obligatorios.\n";
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                mensaje += "Usuario\n";
            }
            else
            {
                usuario = txtUsuario.Text;
            }

            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                mensaje += "Contraseña\n";
            }
            else
            {
                password = txtContrasena.Text;
            }

            if (mensaje != "Ingrese los siguientes datos obligatorios.\n")
            {
                MessageBox.Show(mensaje, "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PDV.Entities.Usuarios user = new Entities.Usuarios();
            user.usuario = txtUsuario.Text;
            user.password = txtContrasena.Text;
            user.Login();
            //string coneccion = ConfigurationManager.ConnectionStrings["DB_PDV"].ConnectionString;
            Program.NombreUsuario = user.nombreUsuario;

            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.Show();
            this.Hide();
        }
    }
}
