using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTEO7.dsVisitasTableAdapters;
using static WebFormsTEO7.dsVisitas;

namespace WebFormsTEO7
{
    public partial class ListadoVisitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarId_Click(object sender, EventArgs e)
        {
           
            
            this.ReportViewer1.LocalReport.DataSources.Clear(); //Limpiar el dataset del reporte
            tblVisitaTableAdapter tblVisitaAdapter = new tblVisitaTableAdapter();
            tblVisitaDataTable tblVisitas = tblVisitaAdapter.GetDataById(int.Parse(txtId.Text));
            this.ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
            {
                Name = "dsVisitas",
                Value = tblVisitas
            });

            
            

        }
    }
}