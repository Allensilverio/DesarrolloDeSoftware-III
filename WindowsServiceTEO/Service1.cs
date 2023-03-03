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
using System.Timers;

namespace WindowsServiceTEO
{
    public partial class Service1 : ServiceBase
    {
        Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Enabled = true;
            timer.Elapsed += timer_Elapsed;
            timer.Interval = 5000;
            timer.Start();
            
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\log.txt", true);
            sw.WriteLine(DateTime.Now.ToLongTimeString());
            sw.Flush();
            sw.Close();
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

        private void FSWMonitor_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\log.txt", true);
            sw.WriteLine(e.Name + "BORRADO");
            sw.Flush();
            sw.Close();

        }

        private void FSWMonitor_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\log.txt", true);
            sw.WriteLine(e.Name + "RENOMBRADO" + e.OldName);
            sw.Flush();
            sw.Close();

        }
    }
}
