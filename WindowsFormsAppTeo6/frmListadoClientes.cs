using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppTeo6.dsClientesTableAdapters;

namespace WindowsFormsAppTeo6
{
    public partial class frmListadoClientes : Form
    {
        public frmListadoClientes()
        {
            InitializeComponent();
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            tblClientesTableAdapter tblClientesTableAdapter = new tblClientesTableAdapter();
            var registro = tblClientesTableAdapter.GetData();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = registro,
                Name = "dsClientes"
            });

            this.reportViewer1.RefreshReport();
        }
    }
}
