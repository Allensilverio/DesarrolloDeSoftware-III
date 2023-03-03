using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceLab5
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }

        private void FSWMonitor_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\log.txt", true);
            sw.WriteLine(e.Name + "CAMBIADO");
            sw.Flush();
            sw.Close();

        }

        private void FSWMonitor_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\log.txt", true);
            sw.WriteLine(e.Name + "CREADO");
            sw.Flush();
            sw.Close();
        }

      
    }
    }
