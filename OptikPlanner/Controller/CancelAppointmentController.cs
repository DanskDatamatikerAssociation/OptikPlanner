using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;
using OptikPlanner.Misc;
using OptikPlanner.Model;
using OptikPlanner.View;

namespace OptikPlanner.Controller
{
    public class CancelAppointmentController
    {

        public static List<Cancellation> CancellationUsersList = new List<Cancellation>();
        public static List<string> noShowList = new List<string>();
        public static List<string> cancelPhoneList = new List<string>();
        public static List<string> cancelElseList = new List<string>();
        public static string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\Daniel\Desktop\CancelAppointmentLog.txt");

        public void DeleteAppointment()
        {
            
        }

        public static void GetNoShows()
        {
            foreach (string s in Lines)
            {
                if (s.Contains("Kunden ikke mødte op"))
                { 
                    noShowList.Add(s);
                }
            }
        }

        public static void GetPhoneCancels()
        {
            foreach (string s in Lines)
            {
                if (s.Contains("Kunden har aflyst telefonisk"))
                {
                    cancelPhoneList.Add(s);
                }
                
            }
        }

        public static void GetElseCancels()
        {
            foreach (string s in Lines)
            {
                if (s.Contains("der har været Andet i vejen"))
                {
                    cancelElseList.Add(s);
                }
                
            }
        }

        public CalendarItem Appointments()
        {
            CalendarItem CI = new CalendarItem(null, new DateTime(2016, 10, 22, 14, 30, 22), new DateTime(2016, 10, 22, 14, 45, 22), "Jeg er en aftale");

            return CI;
        } 
    }
}
