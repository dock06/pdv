using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.Productos
{
    public partial class frmImportar : Form
    {
        public frmImportar()
        {
            InitializeComponent();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmNuevoProducto frmNuevoProducto = new frmNuevoProducto(1);
            frmNuevoProducto.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlgImportacion = new OpenFileDialog();
            dlgImportacion.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            dlgImportacion.ShowDialog();
        }
    }
}
