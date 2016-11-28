using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Model;
using OptikPlanner.View;

namespace OptikPlanner.Controller
{
    public class StatisticsViewController
    {
        private OptikItDbContext _db;
        private IStatisticsView _view;


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

        private List<APTDETAILS> GetAppointments()
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
            return percentage.ToString("#.##") + "%";
        }

    }
}
