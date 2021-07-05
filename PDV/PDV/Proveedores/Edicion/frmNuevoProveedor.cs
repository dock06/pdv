using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Proveedores.Edicion
{
    public partial class frmNuevoProveedor : Form
    {
        public int tipoFormulario;
        public int Clave { get; set; }

        public Entities.Proveedores.Proveedor proveedor;
        public Bussiness.Proveedores.Proveedores bProveedor;
        public frmNuevoProveedor(int opcion)
        {
            InitializeComponent();

            tipoFormulario = opcion;
            proveedor = new Entities.Proveedores.Proveedor();
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
            this.Text = tipoFormulario == 1 ? "Nuevo Proveedor" : "Modificar Proveedor";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = tipoFormulario == 2;
            this.txtCodigo.Visible = tipoFormulario == 2;
            this.CargarClasificacion();
            if (tipoFormulario == 2)
            {
                proveedor.ClaveProveedor = Clave;
                proveedor.Status = -1;
                proveedor.Consultar();

                this.txtCodigo.Text = Clave.ToString();
                this.txtNombre.Text = proveedor.Nombre;
                this.txtApPaterno.Text = proveedor.ApPaterno;
                this.txtApMaterno.Text = proveedor.ApMaterno;
                this.txtDireccion.Text = proveedor.Direccion;
                this.txtTelefono.Text = proveedor.Telefono;
                this.txtContacto.Text = proveedor.Contacto;
                this.txtCorreo.Text = proveedor.Correo;
                this.txtRFC.Text = proveedor.RFC;
                this.rbtMoral.Checked = proveedor.ClaveTipoProveedor == 2;
                this.rbtFisica.Checked = proveedor.ClaveTipoProveedor == 1;
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
            validarFormulario();

            if (Mensajes.MostrarConfirmacion("Nuevo Proveedor", "Desea ingresar el proveedor."))
            {
                obtenerFormulario();
                bProveedor = new Bussiness.Proveedores.Proveedores(proveedor);
                bProveedor.Guardar();
                if (proveedor.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Presentación", proveedor.Mensaje);
                }
                if (proveedor.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Presentación", proveedor.Mensaje);
                }
                if (proveedor.StatusOP == -1)
                {
                    Mensajes.MostrarError("Presentación", proveedor.MensajeException);
                }
            }

        }
        public void Actualizar()
        {

            validarFormulario();

            if (Mensajes.MostrarConfirmacion("Nuevo Proveedor", "Desea modificar el proveedor."))
            {
                obtenerFormulario();
                bProveedor = new Bussiness.Proveedores.Proveedores(proveedor);

                bProveedor.Modificar();
                if (proveedor.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Presentación", proveedor.Mensaje);
                }
                if (proveedor.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Presentación", proveedor.Mensaje);
                }
                if (proveedor.StatusOP == -1)
                {
                    Mensajes.MostrarError("Presentación", proveedor.MensajeException);
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
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (tipoFormulario == 1)
            {
                Guardar();
            }
            if (tipoFormulario == 2)
            {
                Actualizar();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void rbtFisica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarTipoPersona();
        }

        public void HabilitarTipoPersona()
        {
            txtApPaterno.Enabled = rbtFisica.Checked;
            txtApMaterno.Enabled = rbtFisica.Checked;
        }

        private void rbtMoral_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarTipoPersona();
        }
        public void validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Proveedor", rbtFisica.Checked ? "Ingrese el nombre del Proveedor." : "Ingrese la Razón Social del Proveedor.");
                return;
            }
            if (string.IsNullOrEmpty(txtApPaterno.Text) && rbtFisica.Checked)
            {
                Mensajes.MostrarNotificacion("Nuevo Proveedor", "Ingrese el apellido paterno del Proveedor.");
                return;
            }
            if (string.IsNullOrEmpty(txtApMaterno.Text) && rbtFisica.Checked)
            {
                Mensajes.MostrarNotificacion("Nuevo Proveedor", "Ingrese el apellido materno del Proveedor.");
                return;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Proveedor", "Ingrese la dirección del Proveedor.");
                return;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Proveedor", "Ingrese el teléfono del Proveedor.");
                return;
            }
            if (string.IsNullOrEmpty(txtContacto.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Proveedor", "Ingrese el contacto del Proveedor.");
                return;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Proveedor", "Ingrese el correo del Proveedor.");
                return;
            }
        }
        public void obtenerFormulario()
        {
            proveedor = new Entities.Proveedores.Proveedor
            {
                ClaveProveedor = int.TryParse(txtCodigo.Text, out int x) ? int.Parse(txtCodigo.Text) : 0,
                Nombre = txtNombre.Text,
                ApPaterno = txtApPaterno.Text,
                ApMaterno = txtApMaterno.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Contacto = txtContacto.Text,
                Correo = txtCorreo.Text,
                ClaveTipoProveedor = rbtFisica.Checked ? 1 : 2,
                RFC = txtRFC.Text
            };
        }
    }
}

