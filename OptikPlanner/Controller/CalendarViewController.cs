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

        public List<APTDETAILS> GetAppointments()
        {
            using (db = new OptikItDbContext())
            {
                var appointments = from a in db.APTDETAILS select a;
                return appointments.ToList();
            }

        }

        public List<CUSTOMERS> GetCustomers()
        {
            //    CUSTOMERS customer = new CUSTOMERS();
            //    customer.CS_CPRNO = "2001926754";
            //    customer.CS_FIRSTNAME = "Børge";
            //    customer.CS_LASTNAME = "Jensen";


            //    return customer;

            using (db = new OptikItDbContext())
            {
                var customers = from c in db.CUSTOMERS select c;
                return customers.ToList();
            }
        }

        public List<EYEEXAMROOMS> GetRooms()
        {
            //TESTDATA

            //EYEEXAMROOMS room = new EYEEXAMROOMS();
            //room.ERO_OPENFROM = "12:15";
            //room.ERO_OPENTO = "13:00";
            //room.ERO_NBR = 5;
            //room.ERO_TYPE = "Linse";
            //room.ERO_DESC = "linserum 5 første sal til venstre";
            //room.ERO_SHORTDESC = "kort";


            //return room;

            using (db = new OptikItDbContext())
            {
                var rooms = from r in db.EYEEXAMROOMS select r;
                return rooms.ToList();
            }
        }





        public List<USERS> GetUsers()
        {
            //USERS user = new USERS();
            //user.US_CPRNO = "2001927891";
            //user.US_USERNAME = "MyUserName";
            //user.US_STAMP = 1;


            //return user;

            using (db = new OptikItDbContext())
            {
                var users = from u in db.USERS select u;
                return users.ToList();
            }
        }

        public List<string> GetExtraAppointmentDetails(APTDETAILS appointment)
        {
            List<string> extraAppointmentDetails = new List<string>();

            

            


            var users = GetUsers();
            var matchingUser = users.Find(u => u.US_STAMP.Equals(appointment.APD_USER));
            if (matchingUser != null) extraAppointmentDetails.Add(matchingUser.US_USERNAME);



            return extraAppointmentDetails;
        }

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

        public EYEEXAMROOMS GetAppointmentRoom(APTDETAILS appointment)
        {
            var rooms = GetRooms();
            var matchingRoom = rooms.Find(r => r.ERO_NBR.Equals(appointment.APD_ROOM));
            return matchingRoom;
        }

        public USERS GetAppointmentUser(APTDETAILS appointment)
        {
            var users = GetUsers();
            var matchingUser = users.Find(u => u.US_STAMP == appointment.APD_USER);
            return matchingUser;
        }

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

            //public List<CalendarItem> GetAppointmentsAsCalendarItems()
            //{
            //    List<CalendarItem> calendarItems = new List<CalendarItem>();

            //    var appointments = GetAppointments();


            //    foreach (var a in appointments)
            //    {
            //        string correctDateFormat = a.APD_DATE.Value.ToString("dd-MM-yy");
            //        DateTime appointMentDateValue = DateTime.Parse(correctDateFormat);

            //        string timeFromHour = a.APD_TIMEFROM.Split(':').First();
            //        string timeFromMinute = a.APD_TIMEFROM.Split(':').Last();

            //        string timeToHour = a.APD_TIMETO.Split(':').First();
            //        string timeToMinute = a.APD_TIMETO.Split(':').Last();

            //        string appointmentString = $"**Aftaletype her**\n" +
            //                                   $"Lokale nr. {a.APD_ROOM}\n" +
            //                                   $"**Kundenavn her**";

            //        CalendarItem c = new CalendarItem(_view.Calendar, new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day, int.Parse(timeFromHour), int.Parse(timeFromMinute), 0), new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day, int.Parse(timeToHour), int.Parse(timeToMinute), 0), appointmentString);
            //        c.Tag = a;
            //        calendarItems.Add(c);
            //    }

            //    return calendarItems;
            //}
        }

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

