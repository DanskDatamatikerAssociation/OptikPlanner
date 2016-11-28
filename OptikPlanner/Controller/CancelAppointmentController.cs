using System;
using System.Collections.Generic;
using System.IO;
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
        private OptikItDbContext _db;
        private ICancelAppointmentView _view;

        public static List<Cancellation> CancellationUsersList = new List<Cancellation>();
        public static List<string> noShowList = new List<string>();
        public static List<string> cancelPhoneList = new List<string>();
        public static List<string> cancelElseList = new List<string>();
        public static string[] Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"));


        public CancelAppointmentController(ICancelAppointmentView view)
        {
            _view = view;
            _view.SetController(this);
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

        public void DeleteAppointment(APTDETAILS appointment)
        {
            using (_db = new OptikItDbContext())
            {
                var removeQuery = from a in _db.APTDETAILS where a.APD_STAMP == appointment.APD_STAMP select a;
                foreach (var a in removeQuery) _db.APTDETAILS.Remove(a);

                try
                {
                    _db.SaveChanges();

                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        public List<USERS> GetEmployees()
        {
            using (_db = new OptikItDbContext())
            {
                return _db.USERS.ToList();
            }
        }


    }
}
