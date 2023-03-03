namespace WindowsServiceTEO
{
    partial class Service1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FSWMonitor = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.FSWMonitor)).BeginInit();
            // 
            // FSWMonitor
            // 
            this.FSWMonitor.EnableRaisingEvents = true;
            this.FSWMonitor.Path = "C:\\";
            this.FSWMonitor.Changed += new System.IO.FileSystemEventHandler(this.FSWMonitor_Changed);
            this.FSWMonitor.Created += new System.IO.FileSystemEventHandler(this.FSWMonitor_Created);
            this.FSWMonitor.Deleted += new System.IO.FileSystemEventHandler(this.FSWMonitor_Deleted);
            this.FSWMonitor.Renamed += new System.IO.RenamedEventHandler(this.FSWMonitor_Renamed);
            // 
            // Service1
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.FSWMonitor)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher FSWMonitor;
    }
}
