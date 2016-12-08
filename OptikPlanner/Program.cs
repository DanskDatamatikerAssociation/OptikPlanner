using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Controller;
using OptikPlanner.Misc;
using OptikPlanner.View;

namespace OptikPlanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CancelAppointmentController.GetNoShows();
            CancelAppointmentController.GetPhoneCancels();
            CancelAppointmentController.GetElseCancels();

            Logger.SetupTracing();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateAppointment());
           //Application.Run(new CustomerLibrary());
            //Application.Run(new CancelAppointment());
           


        }
    }
}
