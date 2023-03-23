using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTeo6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes formCliente = new frmClientes();
            formCliente.MdiParent = this;
            formCliente.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas Seguro?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txbCodigo.Text);
        }

        private async void btnExplroar_Click(object sender, EventArgs e)
        {
            ofdArchivo.ShowDialog();
            pbImagen.ImageLocation = ofdArchivo.FileName;
            string photo = ofdArchivo.FileName;
            Amazon.Rekognition.Model.Image image = new Amazon.Rekognition.Model.Image();

            try
            {
                using (FileStream fs = new FileStream(photo, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = null;
                    data = new byte[fs.Length];
                    fs.Read(data, 0, (int)fs.Length);
                    image.Bytes = new MemoryStream(data);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load file" + photo);
                throw;
            }

            // AmazonRekognitionClient rkClient = new AmazonRekognitionClient("");

            DetectLabelsRequest request = new DetectLabelsRequest()
            {
                Image = image
            };

            //DetectLabelsResponse response = await rkClient.DetectLabelsAsync(request);

            //foreach (var item in response.Labels)
            //{
            //    txtSalida.Text = item.Name + "\r\n";

            //}

        }

        private void listadoClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoClientes formListadoCliente = new frmListadoClientes();
            formListadoCliente.MdiParent = this;
            formListadoCliente.Show();

        }
    }
}

