using System;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmNuevoTipoProducto : Form
    {
        #region Propiedades
        public int tipoFormulario;
        public int claveTipoProducto { get; set; }
        private string TNuevaCat => "Nuevo Tipo Producto";

        #endregion
        private Entities.Productos.TipoProducto tipoProducto;
        private Bussiness.Productos.TipoProducto bTipoProducto;
        public frmNuevoTipoProducto(int opcion)
        {
            InitializeComponent();
            tipoFormulario = opcion;
            tipoProducto = new Entities.Productos.TipoProducto();

        }
        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tipoFormulario == 1)//Nueva Categoría
            {
                GuardarCategoria();
            }
            if (tipoFormulario == 2)//Editar Categoría
            {
                ActualizarCategoria();
            }
        }
        private void frmNuevaCategoria_Load(object sender, EventArgs e)
        {
            InicializarControles();
            txtDescripcion.Select();
            txtDescripcion.Select();
            txtDescripcion.Select();
            txtDescripcion.Select();
            txtDescripcion.Focus();
        }
        #endregion
        #region Metodos
        public void InicializarControles()
        {
            this.Text = tipoFormulario == 1 ? "Nuevo Tipo Producto" : "Modificar Tipo Producto";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = tipoFormulario == 2;
            this.txtCodigo.Visible = tipoFormulario == 2;
            if (tipoFormulario == 2)
            {
                tipoProducto = new Entities.Productos.TipoProducto();
                tipoProducto.ClaveTipoProducto = claveTipoProducto;
                tipoProducto.NombreTipoProducto = "";
                tipoProducto.Status = -1;
                tipoProducto.Consultar();
                txtCodigo.Text = claveTipoProducto.ToString();
                txtDescripcion.Text = tipoProducto.NombreTipoProducto;
                this.txtCodigo.ReadOnly = true;

            }

        }
        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
        }
        public void GuardarCategoria()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Tipo Producto", "Ingrese el tipo de producto.");
                return;
            }
            tipoProducto = new Entities.Productos.TipoProducto();
            tipoProducto.NombreTipoProducto = txtDescripcion.Text;
            bTipoProducto = new Bussiness.Productos.TipoProducto(tipoProducto);
            bTipoProducto.Guadar();
            if (tipoProducto.StatusOP == 1)
            {
                Mensajes.MostrarNotificacion("Nuevo Tipo Producto", tipoProducto.Mensaje);
            }
            if (tipoProducto.StatusOP == 0)
            {
                Mensajes.MostrarAdvertencia("Nuevo Tipo Producto", tipoProducto.Mensaje);
            }
            if (tipoProducto.StatusOP == -1)
            {
                Mensajes.MostrarError("Nuevo Tipo Producto", tipoProducto.MensajeException);
            }

        }
        public void ActualizarCategoria()
        {

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Mensajes.MostrarNotificacion("Modificar Categoría", "Ingrese el nombre de la categoría.");
                return;
            }
            if (Mensajes.MostrarConfirmacion("Modificar Categoría", "Desea modificar la categoría."))
            {
                tipoProducto.NombreTipoProducto = txtDescripcion.Text;
                tipoProducto.Actualizar();

                if (tipoProducto.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Nueva Categoria", tipoProducto.Mensaje);
                }
                if (tipoProducto.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Nueva Categoria", tipoProducto.Mensaje);
                }
            }
        }

        #endregion

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Focus();
        }
    }
}
