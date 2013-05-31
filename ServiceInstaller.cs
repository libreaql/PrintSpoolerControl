using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintSpoolerControl
{
    /// <summary>
    ///     Summary description for ProjectInstaller.
    /// </summary>
    [System.ComponentModel.RunInstaller(true)]
    public class ProjectInstaller : System.Configuration.Install.Installer
    {
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        //private System.ComponentModel.Container components;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;
        private System.ServiceProcess.ServiceProcessInstaller
                serviceProcessInstaller;

        public ProjectInstaller()
        {
            // This call is required by the Designer.
            InitializeComponent();
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.serviceProcessInstaller =
              new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // serviceInstaller
            // 
            this.serviceInstaller.Description = "Print Spooler Control Service";
            this.serviceInstaller.DisplayName = "Print Spooler Control";
            this.serviceInstaller.ServiceName = "PrintSpoolerControl";
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account =
              System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            // 
            // ServiceInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            this.serviceInstaller});

        }
    }
}
