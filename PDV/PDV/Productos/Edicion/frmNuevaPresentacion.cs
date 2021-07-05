using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmNuevaPresentacion : Form
    {
        public int tipoFormulario;
        public int ClavePresentacion { get; set; }

        public Calidad clasificacion = new Calidad();
        private Presentacion presentacion;

        public frmNuevaPresentacion(int opcion)
        {
            InitializeComponent();

            tipoFormulario = opcion;
            clasificacion = new Calidad();
            presentacion = new Presentacion();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmNuevaPresentacion_Load(object sender, EventArgs e)
        {
            this.InicializarControles();
            this.txtNombre.Select();
            this.txtNombre.Focus();
        }
        public void InicializarControles()
        {
            this.Text = tipoFormulario == 1 ? "Nueva Presentación" : "Modificar Presentación";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = tipoFormulario == 2;
            this.txtCodigo.Visible = tipoFormulario == 2;
            this.CargarClasificacion();
            if (tipoFormulario == 2)
            {
                presentacion = new Presentacion();
                txtCodigo.Text = ClavePresentacion.ToString();
                presentacion.ClavePresentacion = ClavePresentacion;
                presentacion.NombrePresentacion = "";
                presentacion.ClaveClasificacion = 0;
                presentacion.Estatus = -1;
                presentacion.Consultar();
                txtNombre.Text = presentacion.NombrePresentacion;
                cmbClasificaciones.SelectedValue = presentacion.ClaveClasificacion;
                this.txtCodigo.ReadOnly = true;
            }
        }
        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
        }
        public void GuardarPresentacion()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensajes.MostrarNotificacion("Nueva Presentación", "Ingrese el nombre de la Presentación.");
                return;
            }
            if (Mensajes.MostrarConfirmacion("Nueva Presentación", "Desea ingresar la nueva Presentación."))
            {
                presentacion = new Presentacion
                {
                    NombrePresentacion = txtNombre.Text
                    ,
                    ClaveClasificacion = int.Parse(cmbClasificaciones.SelectedValue.ToString())
                };
                presentacion.Insertar();

                if (clasificacion.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Presentación", presentacion.Mensaje);
                }
                if (clasificacion.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Presentación", presentacion.Mensaje);
                }
            }

        }
        public void ActualizarPresentacion()
        {

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensajes.MostrarNotificacion("Modificar presentación", "Ingrese el nombre de la presentación.");
                return;
            }
            if (Mensajes.MostrarConfirmacion("Modificar presentación", "Desea modificar la presentación."))
            {
                presentacion.NombrePresentacion = txtNombre.Text;
                presentacion.ClavePresentacion = int.Parse(txtCodigo.Text.ToString());
                presentacion.ClaveClasificacion = int.Parse(cmbClasificaciones.SelectedValue.ToString());
                presentacion.Actualizar();

                if (clasificacion.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Presentacion", presentacion.Mensaje);
                }
                if (clasificacion.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Presentacion", presentacion.Mensaje);
                }
            }
        }
        public void CargarClasificacion()
        {
            Calidad _Clasificacion = new Calidad
            {
                //NombreClasificacion = "",
                //ClaveCategoria = 0,
                Status = -1
            };
            DataTable dt = _Clasificacion.Consultar().Tables[0];
            cmbClasificaciones.DataSource = dt;
            cmbClasificaciones.ValueMember = "ClaveClasificacion";
            cmbClasificaciones.DisplayMember = "Clasificacion";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (tipoFormulario == 1)
            {
                GuardarPresentacion();
            }
            if (tipoFormulario == 2)
            {
                ActualizarPresentacion();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

