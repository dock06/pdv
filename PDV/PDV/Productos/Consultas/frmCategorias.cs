using PDV.Entities.Productos;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmCategorias : Form
    {
        private Categoria categoria;
        public frmCategorias()
        {
            InitializeComponent();
            categoria = new Categoria();
        }
        #region Eventos        
        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {

            frmNuevaCategoria frmNuevaCategoria = new frmNuevaCategoria(1);
            frmNuevaCategoria.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaCategoria_FormClosed);

            frmNuevaCategoria.Show();


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
                            Categoria categoria = new Categoria();
                            categoria.ClaveCategoria = int.Parse(dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString());
                            categoria.EliminarCategoria();
                            this.ConsultarCategorias();
                        }
                        break;
                    case "Modificar":
                        frmNuevaCategoria frmModificar = new frmNuevaCategoria(2);
                        frmModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevaCategoria_FormClosed);
                        frmModificar.claveCategoria = int.Parse(dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmModificar.Show();
                        break;
                }

            }
        }
        #endregion
        #region Metodos
        public void ConsultarCategorias()
        {
            categoria.Descripcion = "";
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                categoria.Descripcion = txtCodigo.Text;
            }
            if (string.IsNullOrEmpty(cmbEstatus.SelectedValue.ToString()))
            {
                categoria.Status = -1;
            }
            else
            {
                categoria.Status = int.Parse(cmbEstatus.SelectedValue.ToString());
            }

            DataTable dt = categoria.ConsultarCategorias().Tables[0];
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
            dr["Estatus"] = "Eliminados";
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
