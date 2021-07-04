using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Clientes.Edicion
{
    public partial class frmNuevoCliente : Form
    {
        #region Propiedades
        public int tipoFormulario;
        public int Clave { get; set; }
        public Entities.Clientes.Cliente cliente;
        public Bussiness.Clientes.Clientes bClientes;
        public frmNuevoCliente(int opcion)
        {
            InitializeComponent();

            tipoFormulario = opcion;
            cliente = new Entities.Clientes.Cliente();
        }
        #endregion
        #region Métodos
        public void InicializarControles()
        {
            this.Text = tipoFormulario == 1 ? "Nuevo Cliente" : "Modificar Cliente";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = tipoFormulario == 2;
            this.txtCodigo.Visible = tipoFormulario == 2;
            this.txtNombre.Select();
            this.txtNombre.Focus();
            this.grpCredito.Enabled = false;
            btnDisponible.Enabled = false;
            if (tipoFormulario == 2)
            {
                cliente.ClaveCliente = Clave;
                cliente.Status = -1;
                cliente.Consultar();
                this.lblDisponible.Visible = true;
                this.txtDisponible.Visible = true;
                this.btnDisponible.Visible = true;
                this.txtCodigo.Text = Clave.ToString();
                this.txtNombre.Text = cliente.Nombre;
                this.txtApPaterno.Text = cliente.ApPaterno;
                this.txtApMaterno.Text = cliente.ApMaterno;
                this.txtDireccion.Text = cliente.Direccion;
                this.txtTelefono.Text = cliente.Telefono;
                this.txtContacto.Text = cliente.Contacto;
                this.txtCorreo.Text = cliente.Correo;
                this.txtRFC.Text = cliente.RFC;
                this.rbtMoral.Checked = cliente.ClaveTipoCliente == 2;
                this.rbtFisica.Checked = cliente.ClaveTipoCliente == 1;
                this.txtCodigo.ReadOnly = true;
                this.rbtCreditoNo.Checked = cliente.intAplicaCredito == 2;
                this.rbtCreditoSi.Checked = cliente.intAplicaCredito == 1;
            }
        }
        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
        }
        public void CargarClasificacion()
        {
            Clasificacion _Clasificacion = new Clasificacion
            {
                NombreClasificacion = "",
                ClaveCategoria = 0,
                Status = -1
            };
            DataTable dt = _Clasificacion.Consultar().Tables[0];
        }
        public void Guardar()
        {
            if (!validarFormulario())
            {
                return;
            }

            if (Mensajes.MostrarConfirmacion("Nuevo Cliente", "Desea ingresar el cliente."))
            {
                obtenerFormulario();
                bClientes = new Bussiness.Clientes.Clientes(cliente);
                bClientes.Guardar();
                if (cliente.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Cliente", cliente.Mensaje);
                }
                if (cliente.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Cliente", cliente.Mensaje);
                }
                if (cliente.StatusOP == -1)
                {
                    Mensajes.MostrarError("Cliente", cliente.MensajeException);
                }
            }

        }
        public void Actualizar()
        {

            if (!validarFormulario())
            {
                return;
            }

            if (Mensajes.MostrarConfirmacion("Nuevo Cliente", "Desea modificar el cliente."))
            {
                obtenerFormulario();
                bClientes = new Bussiness.Clientes.Clientes(cliente);

                bClientes.Modificar();
                if (cliente.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Clientes", cliente.Mensaje);
                }
                if (cliente.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Clientes", cliente.Mensaje);
                }
                if (cliente.StatusOP == -1)
                {
                    Mensajes.MostrarError("Clientes", cliente.MensajeException);
                }
            }
        }
        public bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Cliente", rbtFisica.Checked ? "Ingrese el nombre del Cliente." : "Ingrese la Razón Social del Cliente.");
                return false;
            }
            if (string.IsNullOrEmpty(txtApPaterno.Text) && rbtFisica.Checked)
            {
                Mensajes.MostrarNotificacion("Nuevo Cliente", "Ingrese el apellido paterno del Cliente.");
                return false;
            }
            if (string.IsNullOrEmpty(txtApMaterno.Text) && rbtFisica.Checked)
            {
                Mensajes.MostrarNotificacion("Nuevo Cliente", "Ingrese el apellido materno del Cliente.");
                return false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Cliente", "Ingrese la dirección del Cliente.");
                return false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Cliente", "Ingrese el teléfono del Cliente.");
                return false;
            }
            if (string.IsNullOrEmpty(txtContacto.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Cliente", "Ingrese el contacto del Cliente.");
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                Mensajes.MostrarNotificacion("Nuevo Cliente", "Ingrese el correo del Cliente.");
                return false;
            }
            return true;
        }
        public void HabilitarTipoPersona()
        {
            txtApPaterno.Enabled = rbtFisica.Checked;
            txtApMaterno.Enabled = rbtFisica.Checked;
        }
        public void obtenerFormulario()
        {
            cliente = new Entities.Clientes.Cliente
            {
                ClaveCliente = int.TryParse(txtCodigo.Text, out int x) ? int.Parse(txtCodigo.Text) : 0,
                Nombre = txtNombre.Text,
                ApPaterno = txtApPaterno.Text,
                ApMaterno = txtApMaterno.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Contacto = txtContacto.Text,
                Correo = txtCorreo.Text,
                ClaveTipoCliente = rbtFisica.Checked ? 1 : 2,
                RFC = txtRFC.Text
            };
        }
        #endregion
        #region Eventos
        private void frmNuevaPresentacion_Load(object sender, EventArgs e)
        {
            this.InicializarControles();

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void rbtFisica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarTipoPersona();
            this.txtNombre.Focus();
        }
        private void rbtMoral_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarTipoPersona();
            this.txtNombre.Focus();
            this.txtApMaterno.Text = this.txtApPaterno.Text = "";
        }
        #endregion

        private void rbtCreditoSi_CheckedChanged(object sender, EventArgs e)
        {
            grpCredito.Enabled = true;
            this.txtCredito.Focus();
            btnDisponible.Enabled = true;
        }

        private void rbtCreditoNo_CheckedChanged(object sender, EventArgs e)
        {
            grpCredito.Enabled = false;
            btnDisponible.Enabled = false;
        }

        private void rbtnLibre_CheckedChanged(object sender, EventArgs e)
        {
            txtCredito.Enabled = false;
            txtDireccion.Focus();
            txtCredito.Text = "";
        }

        private void rbtLimitado_CheckedChanged(object sender, EventArgs e)
        {
            txtCredito.Enabled = true;
            txtCredito.Focus();
        }
    }
}

