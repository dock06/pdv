using PDV.Compras;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PDV
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            tmrHoraSistema.Enabled = true;


        }
        #region Metodos
        public void AbrirFormulario<T>() where T : Form, new()
        {
            Form formulario = pnlContenedor.Controls.OfType<T>().FirstOrDefault();
            if (formulario != null)
            {
                //Si la instancia esta minimizada la dejamos en su estado normal
                if (formulario.WindowState == FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
                //Si la instancia existe la pongo en primer plano
                formulario.BringToFront();
                return;
            }
            //Se abre el form
            formulario = new T();
            formulario.TopLevel = false;
            pnlContenedor.Controls.Add(formulario);
            pnlContenedor.Tag = formulario;
            formulario.Show();
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tmrHoraSistema_Tick(object sender, EventArgs e)
        {
            this.tssTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            this.tssDate.Text = DateTime.Now.ToShortDateString();
        }






        private void btnVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Ventas.frmVentas>();
        }

        private void frmClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Clientes.frmClientes>();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Productos.frmProductos>();
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormulario<Ventas.frmVentas>();
            this.lblUsuario.Text = Program.NombreUsuario;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.AbrirFormulario<Proveedores.frmProveedores>();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCatalogoCompras>();
        }
    }
}
