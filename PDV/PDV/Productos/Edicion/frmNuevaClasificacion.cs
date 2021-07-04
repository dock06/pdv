using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmNuevaClasificacion : Form
    {
        #region Propiedades
        public int tipoFormulario;
        public int ClaveClasifiacion { get; set; }
        #endregion
        public Categoria categoria = new Categoria();
        private Clasificacion clasificacion;
        public frmNuevaClasificacion(int opcion)
        {
            InitializeComponent();

            tipoFormulario = opcion;
            categoria = new Categoria();
            clasificacion = new Clasificacion();

        }
        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tipoFormulario == 1)
            {
                Guardar();
            }
            if (tipoFormulario == 2)
            {
                ActualizarClase();
            }
        }
        private void frmNuevaCategoria_Load(object sender, EventArgs e)
        {
            InicializarControles();
            this.txtNombre.Select();
            this.txtNombre.Focus();
        }
        #endregion
        #region Metodos
        public void InicializarControles()
        {
            this.Text = tipoFormulario == 1 ? "Nueva Clasificación" : "Modificar Clasificación";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = tipoFormulario == 2;
            this.txtCodigo.Visible = tipoFormulario == 2;
            this.CargarClasificacion();
            if (tipoFormulario == 2)
            {
                clasificacion = new Clasificacion();
                txtCodigo.Text = ClaveClasifiacion.ToString();
                clasificacion.ClaveClasificacion = ClaveClasifiacion;
                clasificacion.NombreClasificacion = "";
                clasificacion.Status = -1;
                clasificacion.Consultar();
                txtNombre.Text = clasificacion.NombreClasificacion;
                cmbCategorias.SelectedValue = clasificacion.ClaveCategoria;
                this.txtCodigo.ReadOnly = true;
            }
        }
        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
        }
        public void Guardar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensajes.MostrarNotificacion("Nueva Clasificació", "Ingrese el nombre de la clasificación.");
                return;
            }
            if (Mensajes.MostrarConfirmacion("Nueva Clasificación", "Desea ingresar la nueva clasificación."))
            {
                clasificacion = new Clasificacion
                {
                    NombreClasificacion = txtNombre.Text
                    ,
                    ClaveCategoria = int.Parse(cmbCategorias.SelectedValue.ToString())
                };
                clasificacion.Inserta();

                if (clasificacion.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Nueva Clasificación", clasificacion.Mensaje);
                }
                if (clasificacion.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Nueva Clasificación", clasificacion.Mensaje);
                }
            }
        }
        public void ActualizarClase()
        {

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensajes.MostrarNotificacion("Modificar Clasificación", "Ingrese el nombre de la clasificación.");
                return;
            }
            if (Mensajes.MostrarConfirmacion("Modificar clasificación", "Desea modificar la  clasificación."))
            {
                clasificacion.NombreClasificacion = txtNombre.Text;
                clasificacion.Actualizar();

                if (clasificacion.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Nueva clasificación", clasificacion.Mensaje);
                }
                if (clasificacion.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Nueva clasificación", clasificacion.Mensaje);
                }
            }
        }
        public void CargarClasificacion()
        {
            Categoria _categoria = new Categoria
            {
                Descripcion = "",
                Status = -1
            };
            DataTable dt = _categoria.ConsultarCategorias().Tables[0];
            cmbCategorias.DataSource = dt;
            cmbCategorias.ValueMember = "Codigo";
            cmbCategorias.DisplayMember = "Descripcion";
        }
        #endregion

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
