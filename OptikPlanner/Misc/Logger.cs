using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.View;
using System.Diagnostics;
using OptikPlanner.Controller;

namespace OptikPlanner.Misc
{
    class Logger
    {
        //private static StreamWriter swLog;
        //private const string LOG_FILE_PATH = @"C:\Users\Daniel\Desktop\";
        private const string Source = "OptikPlannerLog";
        EventLog elog = new EventLog();
        CancelAppointmentController controller = new CancelAppointmentController();

        static Logger()
        {
            //Logger.OpenLogger();
            //System.Diagnostics.EventLog optikPlannerEvent = new System.Diagnostics.EventLog();
            //optikPlannerEvent.Source = source;
        }

        public void GetAllLogs()
        {
            var allentries = elog.Entries;

            foreach (var s in allentries)
            {
                if (s.ToString().Contains("Kunden har aflyst telefonisk"))
                {
                    controller.cancelPhoneList.Add(s.ToString());    
                }
                if (s.ToString().Contains("Kunden ikke mødte op."))
                {
                    controller.noShowList.Add(s.ToString());
                }
                if (s.ToString().Contains("der har været Andet i vejen."))
                {
                    controller.cancelElseList.Add(s.ToString());
                }
            }
        }
        public void LogThisLine(string sLogLine)
        {
            //  Logger.swLog.WriteLine("\n" + DateTime.Now.ToLongDateString() + " " + sLogLine);
            string cs = "OptikPlanner";
            
            if (!EventLog.SourceExists(cs))
            {
                EventLog.CreateEventSource(cs, Source);
            }
            elog.Source = Source;
            elog.EnableRaisingEvents = true;
            if (!EventLog.SourceExists(Source))
                EventLog.CreateEventSource(Source, sLogLine);

            EventLog.WriteEntry(Source, " " + sLogLine);
        }
        // Logger.swLog.Flush();
    }

        //public static void CloseLogger()
        //{
        //    Logger.swLog.Flush();
        //    Logger.swLog.Close();
        //}
    //}
}
