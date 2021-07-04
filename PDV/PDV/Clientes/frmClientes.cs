using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Clientes
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        #region Eventos        
        private void frmNuevoCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Consultar();
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.CargarControles();
            this.Consultar();
        }
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Edicion.frmNuevoCliente frmNuevoCliente = new Edicion.frmNuevoCliente(1);
            frmNuevoCliente.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevoCliente_FormClosed);
            frmNuevoCliente.Show();
        }
        private void cmbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        private void dgvConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (dgvConsulta.Columns[e.ColumnIndex].Name)
                {
                    case "Inactivar":
                        if (Mensajes.MostrarConfirmacion("Clientes", string.Format("¿{0} el Cliente {1}?", dgvConsulta.Rows[e.RowIndex].Cells[10].Value.ToString() == "Activo" ? "Inactivar" : "Activar", dgvConsulta.Rows[e.RowIndex].Cells[1].Value.ToString())))
                        {
                            Entities.Clientes.Cliente cliente = new Entities.Clientes.Cliente
                            {
                                ClaveCliente = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString())
                            };
                            Bussiness.Clientes.Clientes bClientes = new Bussiness.Clientes.Clientes(cliente);
                            bClientes.Eliminar();
                            if (cliente.StatusOP == -1)
                            {
                                Mensajes.MostrarError("Clientes", cliente.MensajeException);
                            }
                            else
                            {
                                this.Consultar();
                            }
                        }
                        break;
                    case "Modificar":
                        Edicion.frmNuevoCliente frmNuevoCliente = new Edicion.frmNuevoCliente(2);
                        frmNuevoCliente.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmNuevoCliente_FormClosed);
                        frmNuevoCliente.Clave = int.Parse(dgvConsulta.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmNuevoCliente.ShowDialog();
                        break;
                }

            }
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Consultar();
        }
        #endregion
        #region Metodos
        public void Consultar()
        {
            int clave = 0;
            Entities.Clientes.Cliente cliente = new Entities.Clientes.Cliente
            {
                ClaveCliente = int.TryParse(txtCodigo.Text, out clave) ? int.Parse(txtCodigo.Text) : 0,
                Nombre = int.TryParse(txtCodigo.Text, out clave) ? "" : txtCodigo.Text,
                Status = int.Parse(cmbEstatus.SelectedValue.ToString()),
                ClaveTipoCliente = int.Parse(cmbTipoCliente.SelectedValue.ToString())
            };
            Bussiness.Clientes.Clientes bCliente = new Bussiness.Clientes.Clientes(cliente);
            DataTable dtRegistros = bCliente.Consulta().Tables[0];
            dgvConsulta.Rows.Clear();
            foreach (DataRow dr in dtRegistros.Rows)
            {
                DataGridViewRow drNew = new DataGridViewRow();
                drNew.CreateCells(dgvConsulta);
                drNew.Cells[0].Value = dr["Codigo"].ToString();
                drNew.Cells[1].Value = dr["NombreCompleto"].ToString();
                drNew.Cells[2].Value = dr["Direccion"].ToString();
                drNew.Cells[3].Value = dr["Telefono"].ToString();
                drNew.Cells[4].Value = dr["Contacto"].ToString();
                drNew.Cells[5].Value = dr["Correo"].ToString();
                drNew.Cells[6].Value = dr["RFC"].ToString();
                drNew.Cells[7].Value = dr["TipoCliente"].ToString();
                drNew.Cells[8].Value = dr["AplicaCredito"].ToString();
                drNew.Cells[9].Value = dr["TipoCredito"].ToString();
                drNew.Cells[10].Value = dr["LimiteCredito"].ToString();
                drNew.Cells[11].Value = dr["CreditoDisponible"].ToString();
                drNew.Cells[12].Value = dr["FechaRegistro"].ToString();
                drNew.Cells[13].Value = dr["FechaModificacion"].ToString();
                drNew.Cells[14].Value = dr["Estado"].ToString();
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
                drNew.Cells[15] = btnModificar;
                drNew.Cells[16] = btnEliminar;
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
            cmbTipoCliente.SelectedIndexChanged -= new EventHandler(cmbTipoCliente_SelectedIndexChanged);
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
            cmbTipoCliente.DataSource = dtTipoProveedor;
            cmbTipoCliente.DisplayMember = "ClaveProveedor";
            cmbTipoCliente.ValueMember = "intClaveProveedor";
            cmbTipoCliente.SelectedIndexChanged += new EventHandler(cmbTipoCliente_SelectedIndexChanged);
            #endregion
        }
        #endregion


    }
}
