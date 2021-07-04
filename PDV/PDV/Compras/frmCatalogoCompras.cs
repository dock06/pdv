using System.Linq;
using System.Windows.Forms;

namespace PDV.Compras
{
    public partial class frmCatalogoCompras : Form
    {
        public frmCatalogoCompras()
        {
            InitializeComponent();

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

        private void btnCompras_Click(object sender, System.EventArgs e)
        {
            AbrirFormulario<Consultas.frmCompras>();
        }
    }
}
