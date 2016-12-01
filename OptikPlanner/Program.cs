using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Controller;
using OptikPlanner.Misc;
using OptikPlanner.Model;
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
            OptikItDbContext db;

            using (db = new OptikItDbContext())
            {
                Debug.WriteLine(db.Database.Connection.ConnectionString);
                //db.Database.Connection.ConnectionString = db.Database.Connection.ConnectionString.Replace("DANNY-MSI", "");

            }



            CancelAppointmentController.GetNoShows();
            CancelAppointmentController.GetPhoneCancels();
            CancelAppointmentController.GetElseCancels();

            Logger.SetupTracing();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new CalendarView());
           Application.Run(new StatisticsView());
            //Application.Run(new CancelAppointment());
           


        }
    }
}
