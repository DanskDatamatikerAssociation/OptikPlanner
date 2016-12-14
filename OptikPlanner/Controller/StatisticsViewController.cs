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
using OptikPlanner.Misc;

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

        public List<APTDETAILS> GetAppointments(int monthNr, int year)
        {
            try
            {
                List<APTDETAILS> roomsInTimeSpan = new List<APTDETAILS>();

                using (_db = new OptikItDbContext())
                {
                    foreach (var a in _db.APTDETAILS)
                    {
                        if (a.APD_DATE.Value.Month == monthNr && a.APD_DATE.Value.Year == year) roomsInTimeSpan.Add(a);
                    }
                }

                return roomsInTimeSpan;
            }
            catch (DbException ex)
            {
                Debug.WriteLine("Problem retrieving appointments from the database: '" + ex.Message + "'");
                return new List<APTDETAILS>();
            }
        }

        public string GetAppointmentType(APTDETAILS appointment)
        {
            switch (appointment.APD_TYPE)
            {
                case 0:
                    return "Steljustering";

                case 1:
                    return "Linseopsætning";
                case 2:
                    return "Synsprøve";
            }

            return null;
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
                Debug.WriteLine("Problem retrieving rooms from the database: '" + ex.Message + "'");
                return new List<EYEEXAMROOMS>();

            }
        }

        

        public List<USERS> GetUsers()
        {
            try
            {
                using (_db = new OptikItDbContext())
                {
                    return _db.USERS.ToList();
                }
            }
            catch (DbException ex)
            {
                Debug.WriteLine("Problem retrieving users from the database: '" + ex.Message + "'");
                return new List<USERS>();

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

        public double GetRoomUsageInHours(EYEEXAMROOMS room, int monthNr)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByRoom = new List<APTDETAILS>();

            foreach (var a in allAppointments)
            {
                if (a.APD_ROOM == room.ERO_NBR.Value && a.APD_DATE.Value.Month == monthNr) appointmentsByRoom.Add(a);
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

        public double GetRoomUsageInHours(EYEEXAMROOMS room, int monthNr, int year)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByRoom = new List<APTDETAILS>();

            foreach (var a in allAppointments)
            {
                if (a.APD_ROOM == room.ERO_NBR.Value && a.APD_DATE.Value.Month == monthNr && a.APD_DATE.Value.Year == year) appointmentsByRoom.Add(a);
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

        public double GetRoomAvailabilityInHours(EYEEXAMROOMS room, int totalRoomHoursPerMonth, int monthNr)
        {
            double usageInhours = GetRoomUsageInHours(room, monthNr);

            return totalRoomHoursPerMonth - usageInhours;
        }

        public double GetRoomAvailabilityInHours(EYEEXAMROOMS room, int totalRoomHoursPerMonth, int monthNr, int year)
        {
            double usageInHours = GetRoomUsageInHours(room, monthNr, year);

            return totalRoomHoursPerMonth - usageInHours;
        }

        public string GetValueAsPercentage(double value, double outOf)
        {
            double percentage = value / outOf * 100;
            return percentage.ToString("F") + "%";
        }

        public List<APTDETAILS> ShowMonth()
        {
            return new List<APTDETAILS>();
        }

        public double GetEmployeeUsageInHours(USERS employee)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByEmployee = new List<APTDETAILS>();

            foreach (var a in allAppointments) if (a.APD_USER == employee.US_STAMP) appointmentsByEmployee.Add(a);

            List<TimeSpan> timeSpans = new List<TimeSpan>();

            foreach (var a in appointmentsByEmployee)
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

        public double GetEmployeeUsageInHours(USERS employee, int monthNr)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByEmployee = new List<APTDETAILS>();

            foreach (var a in allAppointments)
            {
                if (a.APD_USER == employee.US_STAMP && a.APD_DATE.Value.Month == monthNr) appointmentsByEmployee.Add(a);
            }

            List<TimeSpan> timeSpans = new List<TimeSpan>();

            foreach (var a in appointmentsByEmployee)
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

        public double GetEmployeeUsageInHours(USERS employee, int monthNr, int year)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByEmployee = new List<APTDETAILS>();

            foreach (var a in allAppointments)
            {
                if (a.APD_USER == employee.US_STAMP && a.APD_DATE.Value.Month == monthNr && a.APD_DATE.Value.Year == year) appointmentsByEmployee.Add(a);
            }

            List<TimeSpan> timeSpans = new List<TimeSpan>();

            foreach (var a in appointmentsByEmployee)
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

        public double GetEmployeeAvailabilityInHours(USERS employee, int totalHoursPerMonth)
        {
            double usageInHours = GetEmployeeUsageInHours(employee);

            return totalHoursPerMonth - usageInHours;
        }

        public double GetEmployeeAvailabilityInHours(USERS employee, int totalHoursPerMonth, int monthNr)
        {
            double usageInHours = GetEmployeeUsageInHours(employee, monthNr);

            return totalHoursPerMonth - usageInHours;
        }

        public double GetEmployeeAvailabilityInHours(USERS employee, int totalHoursPerMonth, int monthNr, int year)
        {
            double usageInHours = GetEmployeeUsageInHours(employee, monthNr, year);

            return totalHoursPerMonth - usageInHours;
        }

        public List<string> GetNoShowCancellations(int monthNr)
        {
            var noShowList = from s in CancelAppointmentController.noShowList where (s.Substring(3, 2).Equals(monthNr.ToString())) select s;
            return noShowList.ToList();
        }
        public List<string> GetNoShowCancellations(int monthNr, int yearNr)
        {
            var noShowList = from s in CancelAppointmentController.noShowList where (s.Substring(3, 2).Equals(monthNr.ToString()) && s.Substring(6, 4).Equals(yearNr.ToString())) select s;
            return noShowList.ToList();
        }

        public List<string> GetPhoneCancellations(int monthNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelPhoneList where (s.Substring(3, 2).Equals(monthNr.ToString())) select s;
            return noShowList.ToList();
        }
        public List<string> GetPhoneCancellations(int monthNr, int yearNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelPhoneList where (s.Substring(3, 2).Equals(monthNr.ToString()) && s.Substring(6, 4).Equals(yearNr.ToString())) select s;
            return noShowList.ToList();
        }

        public List<string> GetOtherReasonCancellations(int monthNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelElseList where (s.Substring(3, 2).Equals(monthNr.ToString())) select s;
            return noShowList.ToList();
        }
        public List<string> GetOtherReasonCancellations(int monthNr, int yearNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelElseList where (s.Substring(3, 2).Equals(monthNr.ToString()) && s.Substring(6, 4).Equals(yearNr.ToString())) select s;
            return noShowList.ToList();
        }


    }
}

