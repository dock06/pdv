using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Proveedores
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }
        #region Eventos        
        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {
            Edicion.frmNuevoProveedor frmNuevoProveedor = new Edicion.frmNuevoProveedor(1);
            frmNuevoProveedor.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevoProveedor_FormClosed);
            frmNuevoProveedor.Show();


        }
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            //CargarControles();
            //ConsultarCategorias();
        }
        private void frmNuevoProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Consultar();
        }
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (dgvConsulta.Columns[e.ColumnIndex].Name)
                {
                    case "Inactivar":
                        if (Mensajes.MostrarConfirmacion("Categorias", string.Format("¿{0} el Proveedor {1}?", dgvConsulta.Rows[e.RowIndex].Cells[9].Value.ToString() == "Activo" ? "Inactivar" : "Activar", dgvConsulta.Rows[e.RowIndex].Cells[1].Value.ToString())))
                        {
                            Entities.Proveedores.Proveedor proveedor = new Entities.Proveedores.Proveedor();
                            proveedor.ClaveProveedor = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                            Bussiness.Proveedores.Proveedores bProveedor = new Bussiness.Proveedores.Proveedores(proveedor);
                            bProveedor.Eliminar();
                            this.Consultar();
                        }
                        break;
                    case "Modificar":
                        Edicion.frmNuevoProveedor frmNuevoProveedor = new Edicion.frmNuevoProveedor(2);
                        frmNuevoProveedor.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevoProveedor_FormClosed);
                        frmNuevoProveedor.Clave = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmNuevoProveedor.ShowDialog();
                        break;
                }

            }
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void cmbTipoProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            this.CargarControles();
            this.Consultar();
        }
        #endregion
        #region Metodos
        public void Consultar()
        {
            int clave = 0;
            Entities.Proveedores.Proveedor proveedor = new Entities.Proveedores.Proveedor
            {
                ClaveProveedor = int.TryParse(txtCodigo.Text, out clave) ? int.Parse(txtCodigo.Text) : 0,
                Nombre = int.TryParse(txtCodigo.Text, out clave) ? "" : txtCodigo.Text,
                Status = int.Parse(cmbEstatus.SelectedValue.ToString()),
                ClaveTipoProveedor = int.Parse(cmbTipoProveedor.SelectedValue.ToString())
            };
            Bussiness.Proveedores.Proveedores bProveedor = new Bussiness.Proveedores.Proveedores(proveedor);
            DataTable dtRegistros = bProveedor.Consulta().Tables[0];
            dgvConsulta.Rows.Clear();
            foreach (DataRow dr in dtRegistros.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvConsulta);
                drNew.Cells[0].Value = dr["CodigoProveedor"].ToString();
                drNew.Cells[1].Value = dr["NombreCompleto"].ToString();
                drNew.Cells[2].Value = dr["Direccion"].ToString();
                drNew.Cells[3].Value = dr["Telefono"].ToString();
                drNew.Cells[4].Value = dr["Contacto"].ToString();
                drNew.Cells[5].Value = dr["Correo"].ToString();
                drNew.Cells[6].Value = dr["RFC"].ToString();
                drNew.Cells[7].Value = dr["TipoProveedor"].ToString();
                drNew.Cells[8].Value = dr["FechaRegistro"].ToString();
                drNew.Cells[9].Value = dr["FechaModificacion"].ToString();
                drNew.Cells[10].Value = dr["Estado"].ToString();
                //si el valor de la columna (estatus) = activo entonces pondra la etiqueta de eliminar
                //si el valor de la columna (estatus) != de activo pondra la etiqueta de activar
                string tituloEliminar = dr["Estado"].ToString() == "Activo" ? "Inactivar" : "Activar";
                DataGridViewButtonCell btnModificar = new DataGridViewButtonCell
                {
                    Value = "Modificar"
                };

                DataGridViewButtonCell btnEliminar = new DataGridViewButtonCell
                {
                    Value = tituloEliminar
                };
                drNew.Cells[11] = btnModificar;
                drNew.Cells[12] = btnEliminar;
                dgvConsulta.Rows.Add(drNew);
                dgvConsulta.PerformLayout();

            }

        }
        public void CargarControles()
        {
            #region cmbEstatus
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
            #region cmbTipoProveedor
            cmbTipoProveedor.SelectedIndexChanged -= new EventHandler(cmbTipoProveedor_SelectedIndexChanged);
            DataTable dtTipoProveedor = new DataTable();
            dtTipoProveedor.TableName = "Estatus";
            dtTipoProveedor.Columns.Add(new DataColumn("intClaveProveedor"));
            dtTipoProveedor.Columns.Add(new DataColumn("ClaveProveedor"));
            DataRow drProv = dtTipoProveedor.NewRow();
            drProv["intClaveProveedor"] = 0;
            drProv["ClaveProveedor"] = "Todos";
            dtTipoProveedor.Rows.Add(drProv);
            drProv = dtTipoProveedor.NewRow();
            drProv["intClaveProveedor"] = 1;
            drProv["ClaveProveedor"] = "Persona Fisica";
            dtTipoProveedor.Rows.Add(drProv);
            drProv = dtTipoProveedor.NewRow();
            drProv["intClaveProveedor"] = 2;
            drProv["ClaveProveedor"] = "Persona Moral";
            dtTipoProveedor.Rows.Add(drProv);
            cmbTipoProveedor.DataSource = dtTipoProveedor;
            cmbTipoProveedor.DisplayMember = "ClaveProveedor";
            cmbTipoProveedor.ValueMember = "intClaveProveedor";
            cmbTipoProveedor.SelectedIndexChanged += new EventHandler(cmbTipoProveedor_SelectedIndexChanged);
            #endregion
        }
        #endregion





    }
}
