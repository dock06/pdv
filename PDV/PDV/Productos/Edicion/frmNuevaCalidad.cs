using PDV.Entities.Productos;
using System;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmNuevaCalidad : Form
    {
        #region Propiedades
        public int tipoFormulario;
        public int ClaveCalidad { get; set; }
        #endregion
        private Calidad calidad;
        public frmNuevaCalidad(int opcion)
        {
            InitializeComponent();

            tipoFormulario = opcion;
            calidad = new Calidad();

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
                calidad = new Calidad();
                txtCodigo.Text = ClaveCalidad.ToString();
                calidad.ClaveCalidad = int.Parse(ClaveCalidad.ToString());
                calidad.NombreCalidad = "";
                calidad.Status = -1;
                calidad.Consultar();
                txtNombre.Text = calidad.NombreCalidad;
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
                calidad = new Calidad
                {
                    NombreCalidad = txtNombre.Text
                };
                calidad.Inserta();

                if (calidad.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Nueva Clasificación", calidad.Mensaje);
                }
                if (calidad.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Nueva Clasificación", calidad.Mensaje);
                }
                if (calidad.StatusOP == -1)
                {
                    Mensajes.MostrarAdvertencia("Nueva Clasificación", calidad.MensajeException);
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
                calidad.NombreCalidad = txtNombre.Text;
                calidad.Actualizar();

                if (calidad.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Modificar clasificación", calidad.Mensaje);
                }
                if (calidad.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Modificar clasificación", calidad.Mensaje);
                }
                if (calidad.StatusOP == -1)
                {
                    Mensajes.MostrarAdvertencia("Modificar Clasificación", calidad.MensajeException);
                }
            }
        }
        public void CargarClasificacion()
        {
            //TipoProducto _categoria = new TipoProducto
            //{
            //    //Descripcion = "",
            //    Status = -1
            //};
            //DataTable dt = _categoria.ConsultarCategorias().Tables[0];
            //cmbCategorias.DataSource = dt;
            //cmbCategorias.ValueMember = "Codigo";
            //cmbCategorias.DisplayMember = "Descripcion";
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
