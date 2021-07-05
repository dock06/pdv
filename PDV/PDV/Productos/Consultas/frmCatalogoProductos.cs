using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmCatalogo : Form
    {
        public Entities.Productos.Producto producto;
        public Entities.Productos.TipoProducto tipoProducto;
        public Entities.Productos.Calidad calidad;
        public Bussiness.Productos.Productos bProductos;
        public Bussiness.Productos.TipoProducto bTipoProducto;
        public Bussiness.Productos.Calidad bCalidad;
        public frmCatalogo()
        {
            InitializeComponent();
        }
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmNuevoProducto frmNuevoProducto = new frmNuevoProducto(1);
            frmNuevoProducto.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevoProducto_FormClosed);
            frmNuevoProducto.Show();
        }
        private void frmNuevoProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Consultar();
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
            bTipoProducto = new Bussiness.Productos.TipoProducto(tipoProducto);
            DataTable dtCategoria = bTipoProducto.Consulta().Tables[0];
            DataRow drCategoria = dtCategoria.NewRow();
            drCategoria[0] = 0;
            drCategoria[1] = "Todos";
            dtCategoria.Rows.Add(drCategoria);
            DataView dtV = dtCategoria.DefaultView;
            dtV.Sort = "Codigo ASC";
            dtCategoria = dtV.ToTable();
            cmbCategorias.DataSource = dtCategoria;
            cmbCategorias.ValueMember = "Codigo";
            cmbCategorias.DisplayMember = "NombreTipoProducto";
            cmbCategorias.SelectedIndexChanged += new EventHandler(cmbCategorias_SelectedIndexChanged);
            #endregion
            CargarCalidad();

        }
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void cmbClasificaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void cmbPresentaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            producto = new Entities.Productos.Producto();
            tipoProducto = new Entities.Productos.TipoProducto();
            calidad = new Entities.Productos.Calidad();
            InicializarControles();
            Consultar();
        }
        public void CargarCalidad()
        {
            #region Clasificaciones
            cmbClasificaciones.SelectedIndexChanged -= new EventHandler(cmbClasificaciones_SelectedIndexChanged);
            //clasificacion.NombreClasificacion = "";
            //clasificacion.ClaveCategoria = 0;
            if (int.Parse(cmbCategorias.SelectedValue.ToString()) != 0)
            {
                //clasificacion.ClaveCategoria = int.Parse(cmbCategorias.SelectedValue.ToString());
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
            cmbClasificaciones.DataSource = dtClasificaciones;
            cmbClasificaciones.DisplayMember = "Calidad";
            cmbClasificaciones.ValueMember = "ClaveCalidad";
            cmbClasificaciones.SelectedValue = 0;
            cmbClasificaciones.SelectedIndexChanged += new EventHandler(cmbClasificaciones_SelectedIndexChanged);
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
            dgvConsulta.Rows.Clear();
            foreach (DataRow dr in dtConsulta.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvConsulta);
                drNew.Cells[0].Value = dr["ClaveProducto"].ToString();
                drNew.Cells[1].Value = dr["NombreProducto"].ToString();
                drNew.Cells[2].Value = dr["Categoria"].ToString();
                drNew.Cells[3].Value = dr["Clasificacion"].ToString();
                drNew.Cells[4].Value = dr["Presentacion"].ToString();
                drNew.Cells[5].Value = dr["Precio"];
                drNew.Cells[6].Value = dr["IVA"];
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
            dgvConsulta.Columns[5].DefaultCellStyle.Format = "c2";
            dgvConsulta.Columns[5].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-MX");
            dgvConsulta.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvConsulta.Columns[6].DefaultCellStyle.Format = "c2";
            dgvConsulta.Columns[6].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-MX");
            dgvConsulta.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                            producto.ClaveProducto = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                            producto.Eliminar();
                            this.Consultar();
                        }
                        break;
                    case "Modificar":
                        frmNuevoProducto frmModificar = new frmNuevoProducto(2);
                        frmModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevoProducto_FormClosed);
                        frmModificar.ClaveProducto = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmModificar.Show();
                        break;
                }
            }
        }
    }
}
