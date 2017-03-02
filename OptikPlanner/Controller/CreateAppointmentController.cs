using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Model;
using System.Windows.Forms.Calendar;
using OptikPlanner.View;


namespace OptikPlanner.Controller
{
    /// <summary>
    /// Manages the connection between the CreateAppointment and the model classes mirrored from db
    /// </summary>
    public class CreateAppointmentController
    {
        private OptikItDbContext db;

        private static ICreateAppointmentView _view;

        public CreateAppointmentController(ICreateAppointmentView view)
        {
            _view = view;
            view.SetController(this);
        }

        /// <summary>
        /// post new appointment to the db
        /// </summary>
        /// <param name="appointment"></param>
        public void PostAppointment(APTDETAILS appointment)
        {
            using (db = new OptikItDbContext())
            {
                try
                {
                    db.APTDETAILS.Add(appointment);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Gets the next appoint ID
        /// </summary>
        /// <returns></returns>
        public int GetNextAppointmentId()
        {
            var appointments = GetAppointments();
            if (appointments.Count == 0) return 0;

            return appointments.Last().APD_STAMP + 1;
            
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
        /// Gets all rooms from the db
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
        /// Gets all users / employees from the db
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
        /// Gets all the customers from the db
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
        /// gets the appointment with specificed room
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
        /// Gets the appointment with the specified user / employee
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
        /// edits the specified appoint in the db
        /// </summary>
        /// <param name="appointment"></param>
        public void PutAppointment(APTDETAILS appointment)
        {
            using (db = new OptikItDbContext())
            {
                var appointmentToEditQuery = from a in db.APTDETAILS where a.APD_STAMP == appointment.APD_STAMP select a;
                foreach (var a in appointmentToEditQuery)
                {
                    a.APD_DATE = appointment.APD_DATE;
                    a.APD_TIMEFROM = appointment.APD_TIMEFROM;
                    a.APD_TIMETO = appointment.APD_TIMETO;
                    a.APD_USER = appointment.APD_USER;
                    a.APD_DESCRIPTION = appointment.APD_DESCRIPTION;
                    a.APD_TYPE = appointment.APD_TYPE;
                    a.APD_ROOM = appointment.APD_ROOM;
                    a.APD_MOBILE = appointment.APD_MOBILE;
                    a.APD_EMAIL = appointment.APD_EMAIL;
                 }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }


        /// <summary>
        /// find specified customer with cpr
        /// </summary>
        /// <param name="cpr"></param>
        /// <returns></returns>
        public CUSTOMERS FindCustomerWithCpr(string cpr)
        {
            var customers = GetCustomers();
            var matchingCustomer = customers.Find(c => c.CS_CPRNO == cpr);
            return matchingCustomer;
        }

        /// <summary>
        /// Gets all future appointments of specified customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<APTDETAILS> GetFutureAppointments(CUSTOMERS customer)

        {
            List<APTDETAILS> futureCustomerAppoinments = new List<APTDETAILS>();

            var allAppointments = GetAppointments();
            var now = DateTime.Now;

            foreach (APTDETAILS a in allAppointments)

                if (a.APD_CUSTOMER == customer.CS_STAMP && a.APD_DATE > now)
                {
                    futureCustomerAppoinments.Add(a);
                }



            var sorted = (from a in futureCustomerAppoinments orderby a.APD_DATE select a).ToList();

            return sorted;
        }

        /// <summary>
        /// Gets the last 2 appointments from specified customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<APTDETAILS> GetPastAppointments(CUSTOMERS customer)
        {
            var allAppointments = GetAppointments();
            List<APTDETAILS> pastAppointments = new List<APTDETAILS>();
            List<APTDETAILS> twoLastAppointments = new List<APTDETAILS>();
            var now = DateTime.Now;

            foreach (APTDETAILS a in allAppointments)

                if (a.APD_CUSTOMER == customer.CS_STAMP && a.APD_DATE < now)
                {
                    pastAppointments.Add(a);
                }

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    twoLastAppointments.Add(pastAppointments[i]);

                }
                catch (ArgumentOutOfRangeException) { }
            }

            var sorted = (from a in twoLastAppointments orderby a.APD_DATE select a).ToList();

            return sorted;
        }
    }
}
