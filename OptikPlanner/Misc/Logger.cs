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
        public static void SetupTracing()
        {
            var filename = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt");

            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            Trace.Listeners.Add(new TextWriterTraceListener(fs));
            Trace.AutoFlush = true;
            
        }
    }
}
