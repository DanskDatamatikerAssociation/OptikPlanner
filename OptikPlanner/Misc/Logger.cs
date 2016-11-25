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
        static EventLog elog = new EventLog();

        static Logger()
        {
            //Logger.OpenLogger();
            //System.Diagnostics.EventLog optikPlannerEvent = new System.Diagnostics.EventLog();
            //optikPlannerEvent.Source = source;
        }

        public static void GetAllLogs()
        {
            CancelAppointmentController controller = new CancelAppointmentController();
            elog.Source = Source;
            var allentries = elog.Entries;

            
            foreach (EventLogEntry s in allentries)
            {
                if (s.Message.Contains("Kunden har aflyst telefonisk"))
                {
                    controller.cancelPhoneList.Add(s.Message);    
                }
                if (s.Message.Contains("Kunden ikke mødte op."))
                {
                    controller.noShowList.Add(s.Message);
                }
                if (s.Message.Contains("der har været Andet i vejen."))
                {
                    controller.cancelElseList.Add(s.Message);
                }
            }
        }
        public static void LogThisLine(string sLogLine)
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
    }
}
