using Lab7.dsEstudiantesTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class ReporteEstudiante : Form
    {
        int TipoDocumento;
        string Documento;
        public ReporteEstudiante(int TipoDocumento, string Documento)
        {
            
            InitializeComponent();
            
        }



        private void ReporteEstudiante_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            tblEstudiantesTableAdapter Estudiante = new tblEstudiantesTableAdapter();
            Estudiante.Connection.Open();

            frmRegistroEstudiante frmRegistroEstudiante = new frmRegistroEstudiante();
            
            
            Estudiante.spSelectLastEstudiante(TipoDocumento, Documento);



        }
    }
}
