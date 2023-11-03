using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Minimarket.Presentacion.Reportes
{
    public partial class Frm_RPT_Categprias : Form
    {
        public Frm_RPT_Categprias()
        {
            InitializeComponent();
        }

        private void Frm_RPT_Categprias_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_caTableAdapter.Fill(this.dataSet_MiniMaket.USP_Listado_ca, textBox1.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
