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
        //private static StreamWriter swLog;
        //private const string LOG_FILE_PATH = @"C:\Users\Daniel\Desktop\";
        private const string Source = "OptikPlannerLog";

        static Logger()
        {
            //Logger.OpenLogger();
            //System.Diagnostics.EventLog optikPlannerEvent = new System.Diagnostics.EventLog();
            //optikPlannerEvent.Source = source;
        }

        //public static void OpenLogger()
        //{
        //    Logger.swLog = new StreamWriter(LOG_FILE_PATH, false);
        //    Logger.swLog.AutoaFlush = true;
        //}
        public static void LogThisLine(string sLogLine)
        {
            //  Logger.swLog.WriteLine("\n" + DateTime.Now.ToLongDateString() + " " + sLogLine);
            string cs = "OptikPlanner";
            EventLog elog = new EventLog();
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
