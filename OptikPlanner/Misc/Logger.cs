using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.View;
using System.Diagnostics;

namespace OptikPlanner.Misc
{
    class Logger
    {
        private static StreamWriter swLog;
        private const string LOG_FILE_PATH = @"C:\Users\Daniel\Desktop\";
        private const string source = "OptikPlannerLog";

        static Logger()
        {
            //Logger.OpenLogger();
            System.Diagnostics.EventLog OptikPlannerEvent = new System.Diagnostics.EventLog();
            OptikPlannerEvent.Source = source;
        }

        //public static void OpenLogger()
        //{
        //    Logger.swLog = new StreamWriter(LOG_FILE_PATH, false);
        //    Logger.swLog.AutoFlush = true;
        //}
        public static void LogThisLine(string sLogLine)
        {
            Logger.swLog.WriteLine("\n" + DateTime.Now.ToLongDateString() + " " + sLogLine);
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, sLogLine);

            EventLog.WriteEntry(source, DateTime.Now.ToLongDateString() + " " + sLogLine);
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
