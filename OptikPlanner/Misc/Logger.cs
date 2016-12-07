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
            
            Trace.AutoFlush = true;
            var filename = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            Trace.Listeners.Add(new TextWriterTraceListener(fs));
            //fs.Close();
        }
    }
}
