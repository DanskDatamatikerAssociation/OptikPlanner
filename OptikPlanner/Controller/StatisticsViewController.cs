using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using OptikPlanner.Model;
using OptikPlanner.View;
using System.IO;

namespace OptikPlanner.Controller
{
    public class StatisticsViewController
    {
        private OptikItDbContext _db;
        private IStatisticsView _view;
        public List<Object> Months = new List<Object>();
        public Calendar calendar { get; }


        public StatisticsViewController(IStatisticsView view)
        {
            _view = view;
            _view.SetController(this);

            OptikItDbContext db = new OptikItDbContext();
        }

        public int TotalCancelStatistics()
        {
            var list = CancelAppointmentController.noShowList.Count;
            var list1 = CancelAppointmentController.cancelPhoneList.Count;
            var list2 = CancelAppointmentController.cancelElseList.Count;

            return list + list1 + list2;
        }

        //public List<string> GetCancellations()
        //{
        //    List<string> LogStrings = new List<string>();
        //    string[] Lines = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(
        //        Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"));
        //    foreach (var s in Lines)
        //    {
        //        LogStrings.Add(s);
        //    }
        //    return LogStrings;
        //}



        public List<APTDETAILS> GetAppointments()
        {
            try
            {
                using (_db = new OptikItDbContext())
                {
                    return _db.APTDETAILS.ToList();
                }
            }
            catch (DbException ex)
            {
                Debug.WriteLine("Problem retrieving appointments from the database: '" + ex.Message + "'");
                return new List<APTDETAILS>();
            }
        }

        public List<EYEEXAMROOMS> GetRooms()
        {
            try
            {
                using (_db = new OptikItDbContext())
                {
                    return _db.EYEEXAMROOMS.ToList();
                }
            }
            catch (DbException ex)
            {
                Debug.WriteLine("Problem retrieving appointments from the database: '" + ex.Message + "'");
                return new List<EYEEXAMROOMS>();

            }
        }

        public double GetRoomUsageInHours(EYEEXAMROOMS room)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByRoom = new List<APTDETAILS>();

            foreach (var a in allAppointments)
            {
                if (a.APD_ROOM == room.ERO_NBR.Value) appointmentsByRoom.Add(a);
            }

            List<TimeSpan> timeSpans = new List<TimeSpan>();

            foreach (var a in appointmentsByRoom)
            {
                TimeSpan timeFrom = TimeSpan.Parse(a.APD_TIMEFROM);
                TimeSpan timeTo = TimeSpan.Parse(a.APD_TIMETO);
                TimeSpan timeElapsed = timeTo - timeFrom;

                timeSpans.Add(timeElapsed);


            }

            double totalUsageInHours = 0;
            foreach (var t in timeSpans) totalUsageInHours += t.TotalHours;

            return totalUsageInHours;
        }

        public double GetRoomAvailabilityInHours(EYEEXAMROOMS room, int totalRoomHoursPerMonth)
        {
            double usageInHours = GetRoomUsageInHours(room);

            return totalRoomHoursPerMonth - usageInHours;

        }

        public string GetValueAsPercentage(double value, double outOf)
        {
            double percentage = value/outOf*100;
            return percentage.ToString("F") + "%";
        }

        public List<APTDETAILS> ShowMonth()
        {
            return new List<APTDETAILS>();
        }





    }
}

