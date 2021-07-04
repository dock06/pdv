using PDV.Bussiness.Productos;
using PDV.Entities.Productos;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmNuevoProducto : Form
    {
        public int TipoFormulario;
        public int ClaveProducto { get; set; }

        public Categoria categoria;
        public Clasificacion clasificacion;
        private Presentacion presentacion;
        private Presentaciones bPresentaciones;
        private Categorias bCategorias;
        private Producto producto;
        private Bussiness.Productos.Productos bsProductos;

        public frmNuevoProducto(int Opcion)
        {
            InitializeComponent();
            TipoFormulario = Opcion;
            categoria = new Categoria();
            clasificacion = new Clasificacion();
            presentacion = new Presentacion();

        }
        public void InicializarControles()
        {
            this.Text = TipoFormulario == 1 ? "Nuevo Producto" : "Modificar Producto";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = TipoFormulario == 2;
            this.txtCodigo.Visible = TipoFormulario == 2;
            #region cmbCategorias
            cmbCategoria.SelectedIndexChanged -= new EventHandler(cmbCategoria_SelectedIndexChanged);
            categoria.Descripcion = "";
            categoria.Status = -1;
            bCategorias = new Bussiness.Productos.Categorias(categoria);
            DataTable dtCategoria = bCategorias.Consulta().Tables[0];
            DataRow drCategoria = dtCategoria.NewRow();
            drCategoria[0] = 0;
            drCategoria[1] = "Todos";
            dtCategoria.Rows.Add(drCategoria);
            DataView dtV = dtCategoria.DefaultView;
            dtV.Sort = "Codigo ASC";
            dtCategoria = dtV.ToTable();
            cmbCategoria.DataSource = dtCategoria;
            cmbCategoria.ValueMember = "Codigo";
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.SelectedIndexChanged += new EventHandler(cmbCategoria_SelectedIndexChanged);
            #endregion

            if (TipoFormulario == 2)
            {
                producto = new Producto();
                txtCodigo.Text = ClaveProducto.ToString();
                producto.ClaveProducto = ClaveProducto;
                producto.NombreProducto = "";
                producto.ClaveCategoria = 0;
                producto.ClaveClasificacion = 0;
                producto.ClavePresentacion = 0;
                producto.Status = -1;
                producto.Consultar();
                txtDescripcion.Text = producto.NombreProducto;
                cmbCategoria.SelectedValue = producto.ClaveCategoria;
                cmbClasificacion.SelectedValue = producto.ClaveClasificacion;
                cmbPresentacion.SelectedValue = producto.ClavePresentacion;
                txtPrecio.Text = producto.Precio.ToString();
                txtIva.Text = producto.IVA.ToString();
                if (decimal.Parse(txtIva.Text) > 0)
                {
                    chkAplicarIVA.Checked = true;
                }
                this.txtCodigo.ReadOnly = true;

            }
        }
        private void chkPedido_CheckedChanged(object sender, EventArgs e)
        {
            this.grpPedido.Enabled = chkPedido.Checked;
        }

        private void rbtNumPiezas_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPiezas.Enabled = rbtNumPiezas.Checked;
            if (rbtNumPiezas.Checked)
            {
                this.txtPiezas.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmBuscarCategoria frmBuscarCategoria = new frmBuscarCategoria();
            frmBuscarCategoria.Show();
        }

        private void btnBuscarPresentacion_Click(object sender, EventArgs e)
        {
            frmBuscarPresentacion frmBuscarPresentacion = new frmBuscarPresentacion();
            frmBuscarPresentacion.Show();
        }

        private void frmNuevoProducto_Load(object sender, EventArgs e)
        {
            this.InicializarControles();
            this.txtDescripcion.Select();
            this.txtDescripcion.Focus();
        }
        public void CargarPresentaciones()
        {
            #region Clasificaciones
            cmbPresentacion.SelectedIndexChanged -= new EventHandler(cmbPresentacion_SelectedIndexChanged);
            presentacion.ClavePresentacion = 0;
            presentacion.NombrePresentacion = "";
            presentacion.Estatus = -1;
            if (int.Parse(cmbClasificacion.SelectedValue.ToString()) != 0)
            {
                presentacion.ClaveClasificacion = int.Parse(cmbClasificacion.SelectedValue.ToString());
            }
            bPresentaciones = new Bussiness.Productos.Presentaciones(presentacion);
            DataTable dtPresentaciones = bPresentaciones.Consultar();
            DataRow drPresentacion = dtPresentaciones.NewRow();
            drPresentacion[0] = 0;
            drPresentacion[1] = "Todos";
            dtPresentaciones.Rows.Add(drPresentacion);
            DataView dvPresentaciones = dtPresentaciones.DefaultView;
            dvPresentaciones.Sort = "Clave Presentación ASC";
            dtPresentaciones = dvPresentaciones.ToTable();
            cmbPresentacion.DataSource = dtPresentaciones;
            cmbPresentacion.DisplayMember = "Descripcion";
            cmbPresentacion.ValueMember = "Clave Presentación";
            cmbPresentacion.SelectedValue = 0;
            cmbClasificacion.SelectedIndexChanged += new EventHandler(cmbPresentacion_SelectedIndexChanged);
            #endregion
        }
        public void CargarClasificaciones()
        {
            #region Clasificaciones
            cmbClasificacion.SelectedIndexChanged -= new EventHandler(cmbClasificacion_SelectedIndexChanged);
            clasificacion.NombreClasificacion = "";
            clasificacion.ClaveCategoria = 0;
            if (int.Parse(cmbCategoria.SelectedValue.ToString()) != 0)
            {
                clasificacion.ClaveCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
            }

            clasificacion.Status = -1;
            DataTable dtClasificaciones = clasificacion.Consultar().Tables[0];
            DataRow drClasificacion = dtClasificaciones.NewRow();
            drClasificacion[0] = 0;
            drClasificacion[1] = "Todos";
            dtClasificaciones.Rows.Add(drClasificacion);
            DataView dtC = dtClasificaciones.DefaultView;
            dtC.Sort = "ClaveClasificacion ASC";
            dtClasificaciones = dtC.ToTable();
            cmbClasificacion.DataSource = dtClasificaciones;
            cmbClasificacion.DisplayMember = "Clasificacion";
            cmbClasificacion.ValueMember = "ClaveClasificacion";
            cmbClasificacion.SelectedValue = 0;
            cmbClasificacion.SelectedIndexChanged += new EventHandler(cmbClasificacion_SelectedIndexChanged);

            #endregion
        }

        private void cmbClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarPresentaciones();
        }
        private void cmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarClasificaciones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (TipoFormulario == 1)
            {
                GuardarProducto();
            }
            if (TipoFormulario == 2)
            {
                ModificarProducto();
            }
        }
        public void obtenerFormulario()
        {
            producto = new Entities.Productos.Producto
            {
                ClaveProducto = int.TryParse(txtCodigo.Text, out int x) ? int.Parse(txtCodigo.Text) : 0,
                NombreProducto = txtDescripcion.Text,
                ClaveCategoria = int.Parse(cmbCategoria.SelectedValue.ToString()),
                ClaveClasificacion = int.Parse(cmbClasificacion.SelectedValue.ToString()),
                ClavePresentacion = int.Parse(cmbPresentacion.SelectedValue.ToString()),
                Precio = decimal.Parse(txtPrecio.Text),
                IVA = decimal.Parse(txtIva.Text)
            };
            
        }
        public void GuardarProducto()
        {
            if (Mensajes.MostrarConfirmacion("Nuevo Proveedor", "Desea ingresar el proveedor."))
            {
                obtenerFormulario();
                bsProductos = new Bussiness.Productos.Productos(producto);
                bsProductos.Guardar();
                if (producto.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Presentación", producto.Mensaje);
                }
                if (producto.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Presentación", producto.Mensaje);
                }
                if (producto.StatusOP == -1)
                {
                    Mensajes.MostrarError("Presentación", producto.MensajeException);
                }
            }
        }

        public void ModificarProducto()
        {

            if (Mensajes.MostrarConfirmacion("Nuevo producto", "Desea modificar el producto."))
            {
                obtenerFormulario();
                bsProductos = new Bussiness.Productos.Productos(producto);

                bsProductos.Modificar();
                if (producto.StatusOP == 1)
                {
                    Mensajes.MostrarNotificacion("Productos", producto.Mensaje);
                }
                if (producto.StatusOP == 0)
                {
                    Mensajes.MostrarAdvertencia("Productos", producto.Mensaje);
                }
                if (producto.StatusOP == -1)
                {
                    Mensajes.MostrarError("Productos", producto.MensajeException);
                }
            }
        }

        private void chkAplicarIVA_CheckedChanged(object sender, EventArgs e)
        {
            CalcularIVa();
        }

        public void CalcularIVa()
        {
            decimal IVA = decimal.Parse(ConfigurationManager.AppSettings["IVA"].ToString());

            if (this.chkAplicarIVA.Checked)
            {
                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    Mensajes.MostrarAdvertencia("Productos", "Ingrese el precio para calcular el IVA.");
                    txtIva.Text = "";
                    return;
                }
                this.txtIva.Text = (decimal.Parse(txtPrecio.Text) - decimal.Parse(txtPrecio.Text) / (1 + (IVA / 100))).ToString("N2");
            }
            if (!this.chkAplicarIVA.Checked)
            {
                this.txtIva.Text = "";
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            CalcularIVa();
        }
    }
}
