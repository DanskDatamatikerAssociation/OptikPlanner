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

    /// <summary>
    /// Manages the connection between the CancelAppointment and the model classes mirrored from db
    /// </summary>
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

        /// <summary>
        /// Get all the cancellations from log that has been cancelled by customer not showing
        /// </summary>
        public static void GetNoShows()
        {
            
            //if (!File.Exists(Path.Combine(Environment.GetFolderPath(
            //    Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt")))
            //{
            //    return;
            //}

            ////Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
            ////    Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"), Encoding.UTF8);

            //if (Lines == null)
            //{
            //    cancelPhoneList.Add("Log oprettet succesfuldt");
            //}
            //foreach (string s in Lines)
            //{
            //    if (s.Contains("Kunden ikke"))
            //    { 
            //        noShowList.Add(s);
            //    }
            //}
            
        }

        /// <summary>
        /// Get all the cancellations from log that has been cancelled by phone
        /// </summary>
        public static void GetPhoneCancels()
        {
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt")))
            {
                return;
            }
            Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"), Encoding.UTF8);

            foreach (string s in Lines)
            {
               
                if (s.Contains("aflyst telefonisk"))
                {
                    cancelPhoneList.Add(s);
                }
                
            }
        }

        /// <summary>
        /// Get all the cancellations from log that has been cancelled by another reason
        /// </summary>
        public static void GetElseCancels()
        {
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(
                   Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt")))
            {
                return;
            }
            Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"), Encoding.UTF8);

            foreach (string s in Lines)
            {
                if (s.Contains("Andet i vejen"))
                {
                    cancelElseList.Add(s);
                }
                
            }
        }

        /// <summary>
        /// cancels / deletes the specified appointment from db
        /// </summary>
        /// <param name="appointment"></param>
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


        /// <summary>
        /// Gets all the employees from the db
        /// </summary>
        /// <returns></returns>
        public List<USERS> GetEmployees()
        {
            using (_db = new OptikItDbContext())
            {
                return _db.USERS.ToList();
            }
        }


    }
}
