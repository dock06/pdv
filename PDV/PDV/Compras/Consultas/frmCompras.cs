using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Compras.Consultas
{
    public partial class frmCompras : Form
    {
        public Entities.Productos.Producto producto;
        public Entities.Productos.TipoProducto tipoProducto;
        public Entities.Productos.Calidad calidad;
        public Entities.Productos.Presentacion presentacion;
        public Bussiness.Productos.Productos bProductos;
        public Bussiness.Productos.TipoProducto bCategorias;
        public Bussiness.Productos.Calidad bClasificaciones;
        public Bussiness.Productos.Presentaciones bPresentaciones;
        public frmCompras()
        {
            InitializeComponent();
        }
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            //frmNuevoProducto frmNuevoProducto = new frmNuevoProducto(1);
            //frmNuevoProducto.Show();
        }
        public void InicializarControles()
        {
            #region cmbEsatus
            cmbEstatus.SelectedIndexChanged -= new EventHandler(cmbEstatus_SelectedIndexChanged);
            DataTable dtEstatus = new DataTable();
            dtEstatus.TableName = "Estatus";
            dtEstatus.Columns.Add(new DataColumn("intEstatus"));
            dtEstatus.Columns.Add(new DataColumn("Estatus"));
            DataRow dr = dtEstatus.NewRow();
            dr["intEstatus"] = -1;
            dr["Estatus"] = "Todos";
            dtEstatus.Rows.Add(dr);
            dr = dtEstatus.NewRow();
            dr["intEstatus"] = 1;
            dr["Estatus"] = "Activos";
            dtEstatus.Rows.Add(dr);
            dr = dtEstatus.NewRow();
            dr["intEstatus"] = 0;
            dr["Estatus"] = "Inactivos";
            dtEstatus.Rows.Add(dr);
            cmbEstatus.DataSource = dtEstatus;
            cmbEstatus.DisplayMember = "Estatus";
            cmbEstatus.ValueMember = "intEstatus";
            cmbEstatus.SelectedIndexChanged += new EventHandler(cmbEstatus_SelectedIndexChanged);
            #endregion
            #region cmbCategorias
            cmbCategorias.SelectedIndexChanged -= new EventHandler(cmbCategorias_SelectedIndexChanged);
            //categoria.Descripcion = "";
            tipoProducto.Status = -1;
            bCategorias = new Bussiness.Productos.TipoProducto(tipoProducto);
            DataTable dtCategoria = bCategorias.Consulta().Tables[0];
            DataRow drCategoria = dtCategoria.NewRow();
            drCategoria[0] = 0;
            drCategoria[1] = "Todos";
            dtCategoria.Rows.Add(drCategoria);
            DataView dtV = dtCategoria.DefaultView;
            dtV.Sort = "Codigo ASC";
            dtCategoria = dtV.ToTable();
            cmbCategorias.DataSource = dtCategoria;
            cmbCategorias.ValueMember = "Codigo";
            cmbCategorias.DisplayMember = "Descripcion";
            cmbCategorias.SelectedIndexChanged += new EventHandler(cmbCategorias_SelectedIndexChanged);
            #endregion

        }
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarClasificaciones();
        }
        private void cmbClasificaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarPresentaciones();
        }
        private void cmbPresentaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            producto = new Entities.Productos.Producto();
            tipoProducto = new Entities.Productos.TipoProducto();
            calidad = new Entities.Productos.Calidad();
            presentacion = new Entities.Productos.Presentacion();
            InicializarControles();
            Consultar();
        }
        public void CargarClasificaciones()
        {
            #region Clasificaciones
            cmbClasificaciones.SelectedIndexChanged -= new EventHandler(cmbClasificaciones_SelectedIndexChanged);
            calidad.NombreCalidad = "";

            calidad.Status = -1;
            DataTable dtClasificaciones = calidad.Consultar().Tables[0];
            DataRow drClasificacion = dtClasificaciones.NewRow();
            drClasificacion[0] = 0;
            drClasificacion[1] = "Todos";
            dtClasificaciones.Rows.Add(drClasificacion);
            DataView dtC = dtClasificaciones.DefaultView;
            dtC.Sort = "ClaveClasificacion ASC";
            dtClasificaciones = dtC.ToTable();
            cmbClasificaciones.DataSource = dtClasificaciones;
            cmbClasificaciones.DisplayMember = "Clasificacion";
            cmbClasificaciones.ValueMember = "ClaveClasificacion";
            cmbClasificaciones.SelectedValue = 0;
            cmbClasificaciones.SelectedIndexChanged += new EventHandler(cmbClasificaciones_SelectedIndexChanged);
            #endregion
        }
        public void CargarPresentaciones()
        {
            #region Clasificaciones
            cmbPresentaciones.SelectedIndexChanged -= new EventHandler(cmbPresentaciones_SelectedIndexChanged);
            presentacion.ClavePresentacion = 0;
            presentacion.NombrePresentacion = "";
            presentacion.Estatus = -1;
            if (int.Parse(cmbClasificaciones.SelectedValue.ToString()) != 0)
            {
                presentacion.ClaveClasificacion = int.Parse(cmbClasificaciones.SelectedValue.ToString());
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
            cmbPresentaciones.DataSource = dtPresentaciones;
            cmbPresentaciones.DisplayMember = "Descripcion";
            cmbPresentaciones.ValueMember = "Clave Presentación";
            cmbPresentaciones.SelectedValue = 0;
            cmbClasificaciones.SelectedIndexChanged += new EventHandler(cmbPresentaciones_SelectedIndexChanged);
            #endregion
        }
        public void Consultar()
        {
            producto.ClaveProducto = int.TryParse(txtCodigo.Text, out int clave) ? int.Parse(txtCodigo.Text) : 0;
            producto.NombreProducto = txtCodigo.Text;
            //producto.ClaveCategoria = int.Parse(cmbCategorias.SelectedValue.ToString());
            //producto.ClaveClasificacion = cmbClasificaciones.SelectedValue == null ? 0 : int.Parse(cmbClasificaciones.SelectedValue.ToString());
            //producto.ClavePresentacion = cmbPresentaciones.SelectedValue == null ? 0 : int.Parse(cmbPresentaciones.SelectedValue.ToString());
            producto.Status = int.Parse(cmbEstatus.SelectedValue.ToString());
            bProductos = new Bussiness.Productos.Productos(producto);
            DataTable dtConsulta = bProductos.Consultar().Tables[0];
            foreach (DataRow dr in dtConsulta.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvConsulta);
                drNew.Cells[0].Value = dr["ClaveProducto"].ToString();
                drNew.Cells[1].Value = dr["NombreProducto"].ToString();
                drNew.Cells[2].Value = dr["Categoria"].ToString();
                drNew.Cells[3].Value = dr["Clasificacion"].ToString();
                drNew.Cells[4].Value = dr["Presentacion"].ToString();
                drNew.Cells[5].Value = dr["Precio"].ToString();
                drNew.Cells[6].Value = dr["IVA"].ToString();
                drNew.Cells[7].Value = dr["Creacion"].ToString();
                drNew.Cells[8].Value = dr["Modificacion"].ToString();
                drNew.Cells[9].Value = dr["Estado"].ToString();
                string tituloEliminar = dr["Estado"].ToString() == "Activo" ? "Inactivar" : "Activar";
                DataGridViewButtonCell btnModificar = new DataGridViewButtonCell
                {
                    Value = "Modificar"
                };

                DataGridViewButtonCell btnEliminar = new DataGridViewButtonCell
                {
                    Value = tituloEliminar
                };
                drNew.Cells[10] = btnModificar;
                drNew.Cells[11] = btnEliminar;
                dgvConsulta.Rows.Add(drNew);
            }
        }

        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (dgvConsulta.Columns[e.ColumnIndex].Name)
                {
                    case "Eliminar":
                        if (Mensajes.MostrarConfirmacion("Presentaciones", string.Format("¿{0} la Presentación {1}?", dgvConsulta.Rows[e.RowIndex].Cells[5].Value.ToString() == "Activo" ? "Inactivar" : "Activar", dgvConsulta.Rows[e.RowIndex].Cells[1].Value.ToString())))
                        {
                            //producto categoria = new Categoria();
                            producto.ClaveProducto = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                            producto.Eliminar();
                            this.Consultar();
                        }
                        break;
                    case "Modificar":
                        //frmNuevoProducto frmModificar = new frmNuevoProducto(2);
                        ////frmModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaPresentacion_FormClosed);
                        //frmModificar.ClaveProducto = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                        //frmModificar.Show();
                        break;
                }
            }
        }
    }
}
