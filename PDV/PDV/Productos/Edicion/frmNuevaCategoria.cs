using PDV.Bussiness;
using PDV.Bussiness.Productos;
using PDV.Entities.Productos;
using System;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmNuevaCategoria : Form
    {
        #region Propiedades
        public int tipoFormulario;
        public int claveCategoria { get; set; }
        private string TNuevaCat => "Nueva Categoria";

        #endregion
        private Categoria categoria;
        public frmNuevaCategoria(int opcion)
        {
            InitializeComponent();

            tipoFormulario = opcion;
            categoria = new Categoria();

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
            this.Text = tipoFormulario == 1 ? "Nueva Categoría" : "Modificar Categoría";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = tipoFormulario == 2;
            this.txtCodigo.Visible = tipoFormulario == 2;
            if (tipoFormulario == 2)
            {
                categoria = new Categoria();
                txtCodigo.Text = claveCategoria.ToString();
                categoria.ClaveCategoria = claveCategoria;
                categoria.ConsultarCategorias();
                txtDescripcion.Text = categoria.Descripcion;
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
            bool Success = false;
            categoria = new Categoria
            {
                Descripcion = txtDescripcion.Text
            };
            var categorias = new Categorias(categoria);
            if (!categorias.Validar(out string Mensaje))
            {
                Mensajes.MostrarAdvertencia(TNuevaCat, Mensaje);
            }
            else
            {
                categorias.Guadar(out Mensaje, out Success);
                if (Success)
                {
                    Mensajes.MostrarNotificacion(TNuevaCat, categoria.Mensaje);
                }
                else
                {
                    Mensajes.MostrarAdvertencia(TNuevaCat, categoria.Mensaje);
                }
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
                categoria.Descripcion = txtDescripcion.Text;
                categoria.ActualizarCategoria();

                if (categoria.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Nueva Categoria", categoria.Mensaje);
                }
                if (categoria.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Nueva Categoria", categoria.Mensaje);
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
    }
}
