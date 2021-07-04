using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmPresentaciones : Form
    {
        private Presentacion presentacion;
        private Clasificacion clasificacion;
        public frmPresentaciones()
        {
            InitializeComponent();
            presentacion = new Presentacion();
            clasificacion = new Clasificacion();
        }
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            frmNuevaPresentacion frmNuevaPresentacion = new frmNuevaPresentacion(1);
            frmNuevaPresentacion.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaPresentacion_FormClosed);
            frmNuevaPresentacion.Show();
        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (dgvDatos.Columns[e.ColumnIndex].Name)
                {
                    case "Eliminar":
                        if (Mensajes.MostrarConfirmacion("Presentaciones", string.Format("¿{0} la Presentación {1}?", dgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString() == "Activo" ? "Inactivar" : "Activar", dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString())))
                        {
                            Categoria categoria = new Categoria();
                            presentacion.ClavePresentacion = int.Parse(dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                            presentacion.Eliminar();
                            this.Consultar();
                        }
                        break;
                    case "Modificar":
                        frmNuevaPresentacion frmModificar = new frmNuevaPresentacion(2);
                        frmModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaPresentacion_FormClosed);
                        frmModificar.ClavePresentacion = int.Parse(dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmModificar.Show();
                        break;
                }
            }
        }
        private void frmNuevaPresentacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Consultar();
        }
        private void cmbClasificaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void frmPresentaciones_Load(object sender, EventArgs e)
        {
            CargarControles();
            Consultar();
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        public void Consultar()
        {
            presentacion.ClavePresentacion = int.TryParse(txtCodigo.Text, out int clave) ? int.Parse(txtCodigo.Text) : 0;
            presentacion.NombrePresentacion = txtCodigo.Text;
            presentacion.ClaveClasificacion = int.Parse(cmbClasificaciones.SelectedValue.ToString());
            presentacion.Estatus = int.Parse(cmbEstatus.SelectedValue.ToString());
            DataTable dt = presentacion.Consultar();
            if (presentacion.StatusOP == -1)
            {
                Mensajes.MostrarError("Presentaciónes", presentacion.MensajeException);
            }
            dgvDatos.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvDatos);
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
                dgvDatos.Rows.Add(drNew);
            }

        }
        public void CargarControles()
        {
            try
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
                cmbEstatus.SelectedValue = -1;
                cmbEstatus.SelectedIndexChanged += new EventHandler(cmbEstatus_SelectedIndexChanged);
                //cmbCategorias
                cmbClasificaciones.SelectedIndexChanged -= new EventHandler(cmbClasificaciones_SelectedIndexChanged);
                clasificacion.NombreClasificacion = "";
                clasificacion.ClaveCategoria = 0;
                clasificacion.Status = -1;
                DataTable dtClasificaciones = clasificacion.Consultar().Tables[0];
                DataRow drCategoria = dtClasificaciones.NewRow();
                drCategoria[0] = 0;
                drCategoria[1] = "Todos";
                dtClasificaciones.Rows.Add(drCategoria);
                DataView dtV = dtClasificaciones.DefaultView;
                dtV.Sort = "ClaveClasificacion ASC";
                dtClasificaciones = dtV.ToTable();
                cmbClasificaciones.DataSource = dtClasificaciones;
                cmbClasificaciones.DisplayMember = "Clasificacion";
                cmbClasificaciones.ValueMember = "ClaveClasificacion";
                cmbClasificaciones.SelectedValue = 0;
                cmbClasificaciones.SelectedIndexChanged += new EventHandler(cmbClasificaciones_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                Mensajes.MostrarError("Presentaciones", ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }

        }
    }
}
