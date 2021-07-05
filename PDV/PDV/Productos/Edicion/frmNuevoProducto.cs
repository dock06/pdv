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

        public Entities.Productos.TipoProducto tipoProducto;
        public Entities.Productos.Calidad calidad;
        private Bussiness.Productos.TipoProducto bTipoProducto;
        private Producto producto;
        private Bussiness.Productos.Productos bsProductos;

        public frmNuevoProducto(int Opcion)
        {
            InitializeComponent();
            TipoFormulario = Opcion;
            tipoProducto = new Entities.Productos.TipoProducto();
            calidad = new Entities.Productos.Calidad();
        }
        public void InicializarControles()
        {
            this.Text = TipoFormulario == 1 ? "Nuevo Producto" : "Modificar Producto";
            this.lblTitulo.Text = this.Text;
            this.lblCodigo.Visible = TipoFormulario == 2;
            this.txtCodigo.Visible = TipoFormulario == 2;
            #region cmbCategorias
            cmbCategoria.SelectedIndexChanged -= new EventHandler(cmbCategoria_SelectedIndexChanged);
            //categoria./*Descripcion*/ = "";
            tipoProducto.Status = -1;
            bTipoProducto = new Bussiness.Productos.TipoProducto(tipoProducto);
            DataTable dtCategoria = bTipoProducto.Consulta().Tables[0];
            DataRow drCategoria = dtCategoria.NewRow();
            drCategoria[0] = 0;
            drCategoria[1] = "Todos";
            dtCategoria.Rows.Add(drCategoria);
            DataView dtV = dtCategoria.DefaultView;
            dtV.Sort = "Codigo ASC";
            dtCategoria = dtV.ToTable();
            cmbCategoria.DataSource = dtCategoria;
            cmbCategoria.ValueMember = "Codigo";
            cmbCategoria.DisplayMember = "NombreTipoProducto";
            cmbCategoria.SelectedIndexChanged += new EventHandler(cmbCategoria_SelectedIndexChanged);
            #endregion
            this.CargarClasificaciones();
            if (TipoFormulario == 2)
            {
                producto = new Producto();
                txtCodigo.Text = ClaveProducto.ToString();
                producto.ClaveProducto = ClaveProducto;
                producto.NombreProducto = "";
                //producto.ClaveCategoria = 0;
                //producto.ClaveClasificacion = 0;
                //producto.ClavePresentacion = 0;
                producto.Status = -1;
                producto.Consultar();
                txtDescripcion.Text = producto.NombreProducto;
                //cmbCategoria.SelectedValue = producto.ClaveCategoria;
                //cmbClasificacion.SelectedValue = producto.ClaveClasificacion;
                //cmbPresentacion.SelectedValue = producto.ClavePresentacion;
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
      
        public void CargarClasificaciones()
        {
            #region Clasificaciones
            cmbClasificacion.SelectedIndexChanged -= new EventHandler(cmbClasificacion_SelectedIndexChanged);
            //clasificacion.NombreClasificacion = "";
            //clasificacion.ClaveCategoria = 0;
            if (int.Parse(cmbCategoria.SelectedValue.ToString()) != 0)
            {
                //clasificacion.ClaveCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
            }

            calidad.Status = -1;
            DataTable dtClasificaciones = calidad.Consultar().Tables[0];
            DataRow drClasificacion = dtClasificaciones.NewRow();
            drClasificacion[0] = 0;
            drClasificacion[1] = "Todos";
            dtClasificaciones.Rows.Add(drClasificacion);
            DataView dtC = dtClasificaciones.DefaultView;
            dtC.Sort = "ClaveCalidad ASC";
            dtClasificaciones = dtC.ToTable();
            cmbClasificacion.DataSource = dtClasificaciones;
            cmbClasificacion.DisplayMember = "Calidad";
            cmbClasificacion.ValueMember = "ClaveCalidad";
            cmbClasificacion.SelectedValue = 0;
            cmbClasificacion.SelectedIndexChanged += new EventHandler(cmbClasificacion_SelectedIndexChanged);

            #endregion
        }

        private void cmbClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                ClaveTipoProducto = int.Parse(cmbCategoria.SelectedValue.ToString()),
                ClaveCalidad = int.Parse(cmbClasificacion.SelectedValue.ToString()),
                Precio = decimal.Parse(txtPrecio.Text),
                IVA = decimal.Parse(txtIva.Text),
                GruesoCompra = decimal.Parse(txtGruesoCompra.Text),
                AnchoCompra = decimal.Parse(txtAnchoCompra.Text),
                LargoCompra = decimal.Parse(txtLargoCompra.Text),
                GruesoVenta = decimal.Parse(txtGruesoVenta.Text),
                AnchoVenta = decimal.Parse(txtAnchoVenta.Text),
                LargoVenta = decimal.Parse(txtLargoVenta.Text)
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
