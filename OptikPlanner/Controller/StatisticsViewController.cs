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
    /// <summary>
    /// Manages the connection between the StatisticsView and the model classes mirrored from db
    /// </summary>
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


        /// <summary>
        /// Gets all the log statistics of cancelled appointments
        /// </summary>
        /// <returns></returns>
        public int TotalCancelStatistics()
        {
            var list = CancelAppointmentController.noShowList.Count;
            var list1 = CancelAppointmentController.cancelPhoneList.Count;
            var list2 = CancelAppointmentController.cancelElseList.Count;

            return list + list1 + list2;
        }

        /// <summary>
        /// Gets all the appointments from db
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all apointments in the specified parametre timeslot
        /// </summary>
        /// <param name="monthNr"></param>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// gets all the appointment with the specified appointment type
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public static string GetAppointmentType(APTDETAILS appointment)
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

        /// <summary>
        /// Gets all the rooms from db
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all the users / employees from the db
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the specified room availability in hours
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Gets the specified room availability in hours in the timeslot parametres (month only)
        /// </summary>
        /// <param name="room"></param>
        /// <param name="monthNr"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the specified room availability in hours in the timeslot parametres (month & year)
        /// </summary>
        /// <param name="room"></param>
        /// <param name="monthNr"></param>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the specified room usage per month
        /// </summary>
        /// <param name="room"></param>
        /// <param name="totalRoomHoursPerMonth"></param>
        /// <returns></returns>
        public double GetRoomAvailabilityInHours(EYEEXAMROOMS room, int totalRoomHoursPerMonth)
        {
            double usageInHours = GetRoomUsageInHours(room);

            return totalRoomHoursPerMonth - usageInHours;

        }

        /// <summary>
        /// Gets the specified room usage per month in specified month
        /// </summary>
        /// <param name="room"></param>
        /// <param name="totalRoomHoursPerMonth"></param>
        /// <param name="monthNr"></param>
        /// <returns></returns>
        public double GetRoomAvailabilityInHours(EYEEXAMROOMS room, int totalRoomHoursPerMonth, int monthNr)
        {
            double usageInhours = GetRoomUsageInHours(room, monthNr);

            return totalRoomHoursPerMonth - usageInhours;
        }

        /// <summary>
        /// Gets the specified room usage per month in specified month and year
        /// </summary>
        /// <param name="room"></param>
        /// <param name="totalRoomHoursPerMonth"></param>
        /// <param name="monthNr"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public double GetRoomAvailabilityInHours(EYEEXAMROOMS room, int totalRoomHoursPerMonth, int monthNr, int year)
        {
            double usageInHours = GetRoomUsageInHours(room, monthNr, year);

            return totalRoomHoursPerMonth - usageInHours;
        }

        /// <summary>
        /// Converter for availability in hours to percentage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="outOf"></param>
        /// <returns></returns>
        public string GetValueAsPercentage(double value, double outOf)
        {
            double percentage = value / outOf * 100;
            return percentage.ToString("F") + "%";
        }

        /// <summary>
        /// Gets the specified employee usage hours
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the number of appointments for the specified employee in the specified year and month
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="monthNr"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetEmployeeNumberOfAppointments(USERS employee, int monthNr, int year)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByEmployee = new List<APTDETAILS>();

            foreach (var a in allAppointments)
            {
                if (a.APD_USER == employee.US_STAMP && a.APD_DATE.Value.Month == monthNr && a.APD_DATE.Value.Year == year) appointmentsByEmployee.Add(a);
            }

            return appointmentsByEmployee.Count;

        }

        /// <summary>
        /// Gets the number of appointments for the specified employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int GetEmployeeNumberOfAppointments(USERS employee)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> appointmentsByEmployee = new List<APTDETAILS>();

            foreach (var a in allAppointments)
            {
                if (a.APD_USER == employee.US_STAMP) appointmentsByEmployee.Add(a);
            }

            return appointmentsByEmployee.Count;

        }

        /// <summary>
        /// Gets the number of hours for the specified employee in specific month
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="monthNr"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the amount of hours used by specified employee in specified year & month
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="monthNr"></param>
        /// <param name="year"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the total amount of hours for employees per month
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="totalHoursPerMonth"></param>
        /// <returns></returns>
        public double GetEmployeeAvailabilityInHours(USERS employee, int totalHoursPerMonth)
        {
            double usageInHours = GetEmployeeUsageInHours(employee);

            return totalHoursPerMonth - usageInHours;
        }

        /// <summary>
        /// Gets the total amount of hours for a month for a specified employee in a specific month
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="totalHoursPerMonth"></param>
        /// <param name="monthNr"></param>
        /// <returns></returns>
        public double GetEmployeeAvailabilityInHours(USERS employee, int totalHoursPerMonth, int monthNr)
        {
            double usageInHours = GetEmployeeUsageInHours(employee, monthNr);

            return totalHoursPerMonth - usageInHours;
        }

        /// <summary>
        /// Gets the total amount of hours for a specified employee in a specific month & year
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="totalHoursPerMonth"></param>
        /// <param name="monthNr"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public double GetEmployeeAvailabilityInHours(USERS employee, int totalHoursPerMonth, int monthNr, int year)
        {
            double usageInHours = GetEmployeeUsageInHours(employee, monthNr, year);

            return totalHoursPerMonth - usageInHours;
        }


        /// <summary>
        /// Get no show cancellations from the log in a specified month
        /// </summary>
        /// <param name="monthNr"></param>
        /// <returns></returns>
        public List<string> GetNoShowCancellations(int monthNr)
        {
            var noShowList = from s in CancelAppointmentController.noShowList where (s.Substring(3, 2).Equals(monthNr.ToString())) select s;
            return noShowList.ToList();
        }

        /// <summary>
        /// Get no show cancellations from the log in a specified month & year
        /// </summary>
        /// <param name="monthNr"></param>
        /// <param name="yearNr"></param>
        /// <returns></returns>
        public List<string> GetNoShowCancellations(int monthNr, int yearNr)
        {
            var noShowList = from s in CancelAppointmentController.noShowList where (s.Substring(3, 2).Equals(monthNr.ToString()) && s.Substring(6, 4).Equals(yearNr.ToString())) select s;
            return noShowList.ToList();
        }

        /// <summary>
        /// Get phone cancellationsfrom the log in a specified month
        /// </summary>
        /// <param name="monthNr"></param>
        /// <returns></returns>
        public List<string> GetPhoneCancellations(int monthNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelPhoneList where (s.Substring(3, 2).Equals(monthNr.ToString())) select s;
            return noShowList.ToList();
        }

        /// <summary>
        /// Get phone cancellationsfrom the log in a specified month & year
        /// </summary>
        /// <param name="monthNr"></param>
        /// <param name="yearNr"></param>
        /// <returns></returns>
        public List<string> GetPhoneCancellations(int monthNr, int yearNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelPhoneList where (s.Substring(3, 2).Equals(monthNr.ToString()) && s.Substring(6, 4).Equals(yearNr.ToString())) select s;
            return noShowList.ToList();
        }

        /// <summary>
        /// Get all other reasons for cancellation from the log in a specified month
        /// </summary>
        /// <param name="monthNr"></param>
        /// <returns></returns>
        public List<string> GetOtherReasonCancellations(int monthNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelElseList where (s.Substring(3, 2).Equals(monthNr.ToString())) select s;
            return noShowList.ToList();
        }

        /// <summary>
        /// Get all other reasons for cancellation from the log in a specified month & year
        /// </summary>
        /// <param name="monthNr"></param>
        /// <param name="yearNr"></param>
        /// <returns></returns>
        public List<string> GetOtherReasonCancellations(int monthNr, int yearNr)
        {
            var noShowList = from s in CancelAppointmentController.cancelElseList where (s.Substring(3, 2).Equals(monthNr.ToString()) && s.Substring(6, 4).Equals(yearNr.ToString())) select s;
            return noShowList.ToList();
        }
        
    }
}

