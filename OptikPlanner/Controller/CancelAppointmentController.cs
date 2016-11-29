using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        public static string[] Lines;


        public CancelAppointmentController(ICancelAppointmentView view)
        {
            _view = view;
            _view.SetController(this);
        }

        public static void GetNoShows()
        {
            
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt")))
            {
                return;
            }

            Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"));

            if (Lines == null)
            {
                cancelPhoneList.Add("Log oprettet succesfuldt");
            }
            foreach (string s in Lines)
            {
                if (s.Contains("Kunden ikke"))
                { 
                    noShowList.Add(s);
                }
            }
        }

        public static void GetPhoneCancels()
        {
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt")))
            {
                return;
            }
            Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"));

            foreach (string s in Lines)
            {
               
                if (s.Contains("aflyst telefonisk"))
                {
                    cancelPhoneList.Add(s);
                }
                
            }
        }

        public static void GetElseCancels()
        {
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt")))
            {
                return;
            }
            Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"));

            foreach (string s in Lines)
            {
                if (s.Contains("Andet i vejen"))
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
                catch (Exception)
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
