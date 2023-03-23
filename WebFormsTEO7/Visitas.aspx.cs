using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTEO7.dsVisitasTableAdapters;

namespace WebFormsTEO7
{
    public partial class Visitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tblVisitaTableAdapter tblVisita = new tblVisitaTableAdapter();
            tblVisita.spInsertVisita(txtNombres.Text, txtApellidos.Text, fuImagen.FileName);
            fuImagen.SaveAs(MapPath("Foto") + "\\" + fuImagen.FileName);
            pbImage.ImageUrl = "Foto/" +fuImagen.FileName;
        }
    }
}