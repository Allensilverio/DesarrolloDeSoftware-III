namespace WindowsServiceLab5
{
    partial class ProjectInstaller
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
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "Windows Service Registrador de Nombres";
            this.serviceInstaller1.DisplayName = "RegistradorMonitor";
            this.serviceInstaller1.ServiceName = "RegistradorMonitor";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}