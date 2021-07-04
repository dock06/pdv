using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmClasificaciones : Form
    {
        private Categoria categoria;
        private Clasificacion clasificacion;
        public frmClasificaciones()
        {
            InitializeComponent();
            categoria = new Categoria();
            clasificacion = new Clasificacion();
        }
        #region Eventos        
        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {

            frmNuevaClasificacion frmNuevaClasifiacion = new frmNuevaClasificacion(1);
            frmNuevaClasifiacion.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaClasificacion_Load);

            frmNuevaClasifiacion.Show();
        }
        private void frmNuevaClasificacion_Load(object sender, EventArgs e)
        {
            CargarControles();
            Consultar();
            txtCodigo.Focus();
        }
        private void frmNuevaCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            Consultar();
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
        #region Metodos
        public void Consultar()
        {
            clasificacion.ClaveClasificacion = int.TryParse(txtCodigo.Text, out int clave) ? int.Parse(txtCodigo.Text) : 0;
            clasificacion.NombreClasificacion = txtCodigo.Text;
            clasificacion.ClaveCategoria = int.Parse(cmbCategorias.SelectedValue.ToString());
            clasificacion.Status = int.Parse(cmbEstatus.SelectedValue.ToString());

            DataTable dt = clasificacion.Consultar().Tables[0];
            dgvClasificaciones.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvClasificaciones);
                drNew.Cells[0].Value = dr[0].ToString();
                drNew.Cells[1].Value = dr[1].ToString();
                drNew.Cells[2].Value = dr[3].ToString();
                drNew.Cells[3].Value = dr[4].ToString();
                drNew.Cells[4].Value = dr[5].ToString();
                drNew.Cells[5].Value = dr[6].ToString();
                string tituloEliminar = dr[6].ToString() == "Activo" ? "Inactivar" : "Activar";
                DataGridViewButtonCell btnModificar = new DataGridViewButtonCell
                {
                    Value = "Modificar"
                };

                DataGridViewButtonCell btnEliminar = new DataGridViewButtonCell
                {
                    Value = tituloEliminar
                };
                drNew.Cells[6] = btnModificar;
                drNew.Cells[7] = btnEliminar;
                dgvClasificaciones.Rows.Add(drNew);
            }
        }
        public void CargarControles()
        {

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
            //cmbCategorias
            cmbCategorias.SelectedIndexChanged -= new EventHandler(cmbCategorias_SelectedIndexChanged);
            categoria.Descripcion = "";
            categoria.Status = -1;
            DataTable dtCategoria = categoria.ConsultarCategorias().Tables[0];
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

        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Consultar();


        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Consultar();
        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }

        private void dgvClasificaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (dgvClasificaciones.Columns[e.ColumnIndex].Name)
                {
                    case "Eliminar":
                        if (Mensajes.MostrarConfirmacion("Clasificación", string.Format("¿{0} la Clasificación {1}?", dgvClasificaciones.Rows[e.RowIndex].Cells[5].Value.ToString() == "Activo" ? "Inactivar" : "Activar", dgvClasificaciones.Rows[e.RowIndex].Cells[1].Value.ToString())))
                        {
                            Clasificacion clasificacion = new Clasificacion();
                            clasificacion.ClaveClasificacion = int.Parse(dgvClasificaciones.Rows[e.RowIndex].Cells[0].Value.ToString());
                            clasificacion.Eliminar();
                            this.Consultar();
                        }
                        break;
                    case "Modificar":
                        frmNuevaClasificacion frmModificar = new frmNuevaClasificacion(2);
                        frmModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaCategoria_FormClosed);
                        frmModificar.ClaveClasifiacion = int.Parse(dgvClasificaciones.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmModificar.Show();
                        break;
                }

            }
        }

        private void frmClasificaciones_Load(object sender, EventArgs e)
        {
            CargarControles();
            Consultar();
        }
    }
}
