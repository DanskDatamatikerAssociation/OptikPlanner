using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Calendar;
using OptikPlanner.Model;
using OptikPlanner.View;

namespace OptikPlanner.Controller
{
    /// <summary>
    /// Manages the connection between the CalendarView and the model classes mirrored from db
    /// </summary>
    //Skal kun håndtere logik der indebærer models. 
    public class CalendarViewController
    {
        private OptikItDbContext db;
        private ICalendarView _view;

        public CalendarViewController(ICalendarView view)
        {
            _view = view;
            view.SetController(this);
        }

        /// <summary>
        /// Gets all the appointments in the db
        /// </summary>
        /// <returns></returns>
        public List<APTDETAILS> GetAppointments()
        {
            using (db = new OptikItDbContext())
            {
                var appointments = from a in db.APTDETAILS select a;
                return appointments.ToList();
            }

        }

        /// <summary>
        /// Gets all the customers in the db
        /// </summary>
        /// <returns></returns>
        public List<CUSTOMERS> GetCustomers()
        {
           using (db = new OptikItDbContext())
            {
                var customers = from c in db.CUSTOMERS select c;
                return customers.ToList();
            }
        }

        /// <summary>
        /// Gets all the rooms in the db
        /// </summary>
        /// <returns></returns>

        public List<EYEEXAMROOMS> GetRooms()
        {
            using (db = new OptikItDbContext())
            {
                var rooms = from r in db.EYEEXAMROOMS select r;
                return rooms.ToList();
            }
        }

        /// <summary>
        /// gets all the users / employees from the db
        /// </summary>
        /// <returns></returns>
        public List<USERS> GetUsers()
        {
            using (db = new OptikItDbContext())
            {
                var users = from u in db.USERS select u;
                return users.ToList();
            }
        }

        /// <summary>
        /// gets specific appointments with specific users.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public List<string> GetExtraAppointmentDetails(APTDETAILS appointment)
        {
            List<string> extraAppointmentDetails = new List<string>();
            
            var users = GetUsers();
            var matchingUser = users.Find(u => u.US_STAMP.Equals(appointment.APD_USER));
            if (matchingUser != null) extraAppointmentDetails.Add(matchingUser.US_USERNAME);
            
            return extraAppointmentDetails;
        }


        /// <summary>
        /// Returns the appointment type of the specified appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public static string GetAppointmentType(APTDETAILS appointment)
        {
            string type = "";
            switch (appointment.APD_TYPE)
            {
                case 1:
                    type = "Synsprøve";
                    break;
                case 2:
                    type = "Ny tilpasning";
                    break;
                case 3:
                    type = "Linsekontrol";
                    break;
                case 4:
                    type = "Udlevering";
                    break;
                case 5:
                    type = "Efterkontrol";
                    break;
                case 6:
                    type = "Svagsynsoptik";
                    break;
                case 7:
                    type = "Møde";
                    break;
                case 8:
                    type = "Genudmåling";
                    break;
                case 9:
                    type = "FRI";
                    break;
                case 10:
                    type = "Leverandør";
                    break;
                case 12:
                    type = "PBS";
                    break;
                case 13:
                    type = "Brevkæde";
                    break;
                case 14:
                    type = "Lukkedag";
                    break;
                case 15:
                    type = "Udlevering af briller";
                    break;
                case 16:
                    type = "Sygehus apotek";
                    break;
                case 17:
                    type = "Værksted arbejde";
                    break;
                default:
                    type = "Synsprøve";
                    break;

            }
            return type;
        }

        /// <summary>
        /// returns the room of the specified appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public EYEEXAMROOMS GetAppointmentRoom(APTDETAILS appointment)
        {
            var rooms = GetRooms();
            var matchingRoom = rooms.Find(r => r.ERO_NBR.Equals(appointment.APD_ROOM));
            return matchingRoom;
        }

        /// <summary>
        /// returns the user / employee of the specified appointment 
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public USERS GetAppointmentUser(APTDETAILS appointment)
        {
            var users = GetUsers();
            var matchingUser = users.Find(u => u.US_STAMP == appointment.APD_USER);
            return matchingUser;
        }

        /// <summary>
        /// converts the db appointments into calendarItems
        /// </summary>
        /// <returns></returns>
        public List<CalendarItem> GetAppointmentsAsCalendarItems()
        {
            List<CalendarItem> calendarItems = new List<CalendarItem>();

            var appointments = GetAppointments();


            foreach (var a in appointments)
            {
                string correctDateFormat = a.APD_DATE.Value.ToString("dd-MM-yy");
                DateTime appointMentDateValue = DateTime.Parse(correctDateFormat);

                string timeFromHour = a.APD_TIMEFROM.Split(':').First();
                string timeFromMinute = a.APD_TIMEFROM.Split(':').Last();

                string timeToHour = a.APD_TIMETO.Split(':').First();
                string timeToMinute = a.APD_TIMETO.Split(':').Last();

                var type = GetAppointmentType(a);
                var room = GetAppointmentRoom(a);
                var user = GetAppointmentUser(a);

                string appointmentString = "";

                if (user != null)
                {
                     appointmentString = $"{type}\n" +
                                               $"Lokale nr. {a.APD_ROOM}\n" +
                                               $"{user.US_USERNAME}";
                }

                CalendarItem c = new CalendarItem(_view.Calendar,
                    new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day,
                        int.Parse(timeFromHour), int.Parse(timeFromMinute), 0),
                    new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day,
                        int.Parse(timeToHour), int.Parse(timeToMinute), 0), appointmentString);
                
                c.Tag = a;
                calendarItems.Add(c);

            }
            return calendarItems;
        }


        /// <summary>
        /// converts the specified appointment into calendarItem
        /// </summary>
        /// <param name="appointments"></param>
        /// <returns></returns>

        public List<CalendarItem> GetAppointmentsAsCalendarItems(List<APTDETAILS> appointments)
        {
            List<CalendarItem> calendarItems = new List<CalendarItem>();
            
            foreach (var a in appointments)
            {
                string correctDateFormat = a.APD_DATE.Value.ToString("dd-MM-yy");
                DateTime appointMentDateValue = DateTime.Parse(correctDateFormat);

                string timeFromHour = a.APD_TIMEFROM.Split(':').First();
                string timeFromMinute = a.APD_TIMEFROM.Split(':').Last();

                string timeToHour = a.APD_TIMETO.Split(':').First();
                string timeToMinute = a.APD_TIMETO.Split(':').Last();

                var type = GetAppointmentType(a);
                var room = GetAppointmentRoom(a);
                var user = GetAppointmentUser(a);

                string appointmentString = "";

                if (user != null)
                {


                     appointmentString = $"{type}\n" +
                                               $"Lokale nr. {a.APD_ROOM}\n" +
                                               $"{user.US_USERNAME}";
                }

                CalendarItem c = new CalendarItem(_view.Calendar,
                    new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day,
                        int.Parse(timeFromHour), int.Parse(timeFromMinute), 0),
                    new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day,
                        int.Parse(timeToHour), int.Parse(timeToMinute), 0), appointmentString);

                c.Tag = a;
                calendarItems.Add(c);

            }

            return calendarItems;
        }

    }
}

