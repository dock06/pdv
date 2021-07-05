using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmCalidad : Form
    {
        private TipoProducto tipoProducto;
        private Calidad calidad;
        public frmCalidad()
        {
            InitializeComponent();
            tipoProducto = new TipoProducto();
            calidad = new Calidad();
        }
        #region Eventos        
        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {

            frmNuevaCalidad frmNuevaCalidad = new frmNuevaCalidad(1);
            frmNuevaCalidad.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaCalidad_Load);

            frmNuevaCalidad.Show();
        }
        private void frmNuevaCalidad_Load(object sender, EventArgs e)
        {
            CargarControles();
            Consultar();
            txtCodigo.Focus();
        }
        private void frmNuevaCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            Consultar();
        }

        #endregion
        #region Metodos
        public void Consultar()
        {
            calidad.ClaveCalidad = int.TryParse(txtCodigo.Text, out int clave) ? int.Parse(txtCodigo.Text) : 0;
            calidad.NombreCalidad = txtCodigo.Text;
            calidad.Status = int.Parse(cmbEstatus.SelectedValue.ToString());

            DataTable dt = calidad.Consultar().Tables[0];
            dgvClasificaciones.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvClasificaciones);
                drNew.Cells[0].Value = dr["ClaveCalidad"].ToString();
                drNew.Cells[1].Value = dr["Calidad"].ToString();
                drNew.Cells[2].Value = dr["Creacion"].ToString();
                drNew.Cells[3].Value = dr["Modificacion"].ToString();
                drNew.Cells[4].Value = dr["Estado"].ToString();
                string tituloEliminar = dr["Estado"].ToString() == "Activo" ? "Inactivar" : "Activar";
                DataGridViewButtonCell btnModificar = new DataGridViewButtonCell
                {
                    Value = "Modificar"
                };

                DataGridViewButtonCell btnEliminar = new DataGridViewButtonCell
                {
                    Value = tituloEliminar
                };
                drNew.Cells[5] = btnModificar;
                drNew.Cells[6] = btnEliminar;
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
                            Calidad calidad = new Calidad();
                            calidad.ClaveCalidad = int.Parse(dgvClasificaciones.Rows[e.RowIndex].Cells[0].Value.ToString());
                            calidad.Eliminar();
                            if (calidad.StatusOP == -1)
                            {
                                Mensajes.MostrarError("Clasificación", calidad.MensajeException);
                            }
                            this.Consultar();
                        }
                        break;
                    case "Modificar":
                        frmNuevaCalidad frmModificar = new frmNuevaCalidad(2);
                        frmModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaCategoria_FormClosed);
                        frmModificar.ClaveCalidad = int.Parse(dgvClasificaciones.Rows[e.RowIndex].Cells[0].Value.ToString());
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
