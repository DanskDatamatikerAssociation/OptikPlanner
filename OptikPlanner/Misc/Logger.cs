using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.View;

namespace OptikPlanner.Misc
{
    class Logger
    {
        private static StreamWriter swLog;
        private const string LOG_FILE_PATH = @"C:\Users\Daniel\Desktop\CancelAppointmentLog.txt";

        static Logger()
        {
            Logger.OpenLogger();
        }

        public static void OpenLogger()
        {
            Logger.swLog = new StreamWriter(LOG_FILE_PATH, false);
            Logger.swLog.AutoFlush = true;
        }
        public static void LogThisLine(string sLogLine)
        {
            Logger.swLog.WriteLine(DateTime.Now.ToLongDateString() + " " + sLogLine);
            Logger.swLog.Flush();
        }

        public static void CloseLogger()
        {
            Logger.swLog.Flush();
            Logger.swLog.Close();
        }
    }
}
