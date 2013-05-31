using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceProcess;

namespace PrintSpoolerControl
{
    class PrintSpoolerControl : System.ServiceProcess.ServiceBase
    {

        static private string folderPath = @"C:\Users\Sam\Desktop\PrintSpoolerControlLog.txt";
        static System.Timers.Timer timer;

        private static void TimerEventProcessor(Object sender, System.Timers.ElapsedEventArgs e)
        {

            string serviceName = "Spooler";

            ServiceController service = new ServiceController(serviceName);

            ServiceControllerStatus status = service.Status;

            if (!status.Equals(ServiceControllerStatus.Running))
            {

                try
                {

                    string msg = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    msg += " Spooler service had stoped";

                    System.IO.StreamWriter file = new System.IO.StreamWriter(folderPath, true);
                    file.WriteLine(msg);

                    file.Close();

                    System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(@"C:\Windows\System32\spool\PRINTERS\");

                    foreach (FileInfo prfile in downloadedMessageInfo.GetFiles())
                    {
                        prfile.Delete();
                    }

                    service.Start();
                }
                catch
                {
                }

            }

        }

        // The main entry point for the process
        static void Main()
        {

            System.ServiceProcess.ServiceBase[] ServicesToRun;
            ServicesToRun =
              new System.ServiceProcess.ServiceBase[] { new PrintSpoolerControl() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServiceName = "PrintSpoolerControl";
        }
        
        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerEventProcessor);
            timer.Interval = 60000;
            timer.Start();

        }
        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()    
        {
            timer.Stop();
        }

    }
}
