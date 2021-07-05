using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmTipoProducto : Form
    {
        private TipoProducto tipoProducto;
        private Bussiness.Productos.TipoProducto bTipoProducto;
        public frmTipoProducto()
        {
            InitializeComponent();
            tipoProducto = new TipoProducto();
        }
        #region Eventos        
        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {

            frmNuevoTipoProducto frmTipoProducto = new frmNuevoTipoProducto(1);
            frmTipoProducto.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaCategoria_FormClosed);

            frmTipoProducto.Show();


        }
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarControles();
            ConsultarCategorias();
        }
        private void frmNuevaCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConsultarCategorias();
        }
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (dgvCategorias.Columns[e.ColumnIndex].Name)
                {
                    case "Eliminar":
                        if (Mensajes.MostrarConfirmacion("Categorias", string.Format("¿{0} la Categoria {1}?", dgvCategorias.Rows[e.RowIndex].Cells[4].Value.ToString() == "Activo" ? "Inactivar" : "Activar", dgvCategorias.Rows[e.RowIndex].Cells[1].Value.ToString())))
                        {
                            TipoProducto tipoProducto = new TipoProducto();
                            tipoProducto.ClaveTipoProducto = int.Parse(dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString());
                            bTipoProducto = new Bussiness.Productos.TipoProducto(tipoProducto);
                            bTipoProducto.Eliminar();
                            if (tipoProducto.StatusOP == -1)
                            {
                                Mensajes.MostrarError("Tipo Producto", tipoProducto.MensajeException);
                            }
                            this.ConsultarCategorias();
                        }
                        break;
                    case "Modificar":
                        frmNuevoTipoProducto frmTipoProducto = new frmNuevoTipoProducto(2);
                        frmTipoProducto.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaCategoria_FormClosed);
                        frmTipoProducto.claveTipoProducto = int.Parse(dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmTipoProducto.Show();
                        break;
                }

            }
        }
        #endregion
        #region Metodos
        public void ConsultarCategorias()
        {
            tipoProducto.NombreTipoProducto = "";
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                tipoProducto.NombreTipoProducto = txtCodigo.Text;
            }
            if (string.IsNullOrEmpty(cmbEstatus.SelectedValue.ToString()))
            {
                tipoProducto.Status = -1;
            }
            else
            {
                tipoProducto.Status = int.Parse(cmbEstatus.SelectedValue.ToString());
            }

            DataTable dt = tipoProducto.Consultar().Tables[0];
            dgvCategorias.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvCategorias);
                drNew.Cells[0].Value = dr[0].ToString();
                drNew.Cells[1].Value = dr[1].ToString();
                drNew.Cells[2].Value = dr[2].ToString();
                drNew.Cells[3].Value = dr[3].ToString();
                drNew.Cells[4].Value = dr[4].ToString();
                //si el valor de la columna 4 (estatus) = activo entonces pondra la etiqueta de eliminar
                //si el valor de la columna 4 (estatus) != de activo pondra la etiqueta de activar
                string tituloEliminar = dr[4].ToString() == "Activo" ? "Inactivar" : "Activar";
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
                dgvCategorias.Rows.Add(drNew);
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
            ConsultarCategorias();


        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ConsultarCategorias();
        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultarCategorias();
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
