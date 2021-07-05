using System;
using System.Linq;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmProductos : Form
    {
        public frmProductos()
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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCatalogo>();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            AbrirFormulario<frmCatalogo>();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmTipoProducto>();
        }

        private void btnPresentaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmPresentaciones>();
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmPromociones>();
        }

        private void btnClasificacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCalidad>();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmImportar>();
        }
    }
}
