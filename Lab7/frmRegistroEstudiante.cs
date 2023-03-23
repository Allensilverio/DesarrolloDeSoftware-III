using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Lab7.dsEstudiantesTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class frmRegistroEstudiante : Form
    {
        bool celebridad;
        public frmRegistroEstudiante()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            tblEstudiantesTableAdapter Estudiante = new tblEstudiantesTableAdapter();
            Estudiante.Connection.Open();
            SqlTransaction transaction = Estudiante.Connection.BeginTransaction();
            Estudiante.Transaction = transaction;

            try
            {
                Estudiante.spInsertEstudiante(int.Parse(txtTipoDocumento.Text), txtDocumento.Text, txtNombres.Text, txtApellidos.Text, dtpFechaNacimiento.Value, bool.Parse(txtCelebridad.Text), ofdImage.FileName);
                transaction.Commit();

                ReporteEstudiante formReporteEstudiante = new ReporteEstudiante(int.Parse(txtTipoDocumento.Text), txtDocumento.Text);
                formReporteEstudiante.MdiParent = this;
                formReporteEstudiante.Show();






            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            
            ofdImage.ShowDialog();
            pbFotoEstudiante.ImageLocation = ofdImage.FileName;
            string foto = ofdImage.FileName;

            Amazon.Rekognition.Model.Image image = new Amazon.Rekognition.Model.Image();

            try
            {
                using (FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = null;
                    data = new byte[fs.Length];
                    fs.Read(data, 0, (int)fs.Length);
                    image.Bytes = new MemoryStream(data);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load file" + foto);
                throw;
            }

            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient("AKIAIE5LZMZN4CR6IO5Q", "xUtzMH5IxZmuZYrc9KSN83JE+pgf5J60+FajM65J", RegionEndpoint.USEast1);

            DetectTextRequest detectTextRequest = new DetectTextRequest()
            {
                Image = image
            };

            DetectTextResponse detectTextResponse = rekognitionClient.DetectText(detectTextRequest);

            bool textoDetectado = (detectTextResponse.TextDetections.Count() > 0);

            DetectFacesRequest detectFacesRequest = new DetectFacesRequest()
            {
                Image = image
            };

            DetectFacesResponse detectFacesResponse = rekognitionClient.DetectFaces(detectFacesRequest);

            bool rostroDetectado = (detectFacesResponse.FaceDetails.Count() > 0);

            DetectModerationLabelsRequest detectLabelsRequest = new DetectModerationLabelsRequest()
            {
                Image = image
            };

            DetectModerationLabelsResponse detectLabelsResponse = rekognitionClient.DetectModerationLabels(detectLabelsRequest);

            bool imagenApta = true;
            foreach (var item in detectLabelsResponse.ModerationLabels)
            {
                if (item.Confidence < 90)
                {
                    imagenApta = false;
                    break;
                }
            }

            if (imagenApta && textoDetectado == false && rostroDetectado)
            {
                RecognizeCelebritiesRequest celebridadesRequest = new RecognizeCelebritiesRequest() { Image = image };

                RecognizeCelebritiesResponse celebridadesResponse = rekognitionClient.RecognizeCelebrities(celebridadesRequest);

                celebridad = (celebridadesResponse.CelebrityFaces.Count() > 0);

                pbFotoEstudiante.ImageLocation = foto;
            }
            else
            {
                MessageBox.Show("La imagen ingresada no es valida para introducir en el sistema", "Error");
            }
        }
    }
}
