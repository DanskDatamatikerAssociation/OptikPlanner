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
    public class CreateAppointmentController
    {
        private OptikItDbContext db;
        List<APTDETAILS> allCustomerAppoinments = new List<APTDETAILS>();
        private List<APTDETAILS> allCustomerAppointments = new List<APTDETAILS>();

        private static ICreateAppointmentView _view;

        public CreateAppointmentController(ICreateAppointmentView view)
        {
            _view = view;
            view.SetController(this);
        }

        public List<APTDETAILS> GetAllAppointments()
        {


            APTDETAILS appointment = new APTDETAILS();
            appointment.APD_CUSTOMER = 1;
            appointment.APD_DATE = new DateTime(2016, 12, 30);

            APTDETAILS appointment1 = new APTDETAILS();
            appointment1.APD_CUSTOMER = 1;
            appointment1.APD_DATE = new DateTime(2016, 12, 27);

            APTDETAILS appointment2 = new APTDETAILS();
            appointment2.APD_CUSTOMER = 1;
            appointment2.APD_DATE = new DateTime(2016, 11, 25);

            APTDETAILS appointment3 = new APTDETAILS();
            appointment3.APD_CUSTOMER = 1;
            appointment3.APD_DATE = new DateTime(2016, 11, 27);

            APTDETAILS appointment4 = new APTDETAILS();
            appointment4.APD_CUSTOMER = 1;
            appointment4.APD_DATE = new DateTime(2016, 10, 27);

            APTDETAILS appointment5 = new APTDETAILS();
            appointment5.APD_CUSTOMER = 1;
            appointment5.APD_DATE = new DateTime(2016, 12, 31);

            APTDETAILS appointment6 = new APTDETAILS();
            appointment6.APD_CUSTOMER = 1;
            appointment6.APD_DATE = new DateTime(2016, 10, 25);

            allCustomerAppointments.Add(appointment);
            allCustomerAppointments.Add(appointment1);
            allCustomerAppointments.Add(appointment2);
            allCustomerAppointments.Add(appointment3);
            allCustomerAppointments.Add(appointment4);
            allCustomerAppointments.Add(appointment5);
            allCustomerAppointments.Add(appointment6);

            return allCustomerAppointments;
        }

        public List<APTDETAILS> GetFutureAppointments(CUSTOMERS customer)

        {
            List<APTDETAILS> futureCustomerAppoinments = new List<APTDETAILS>();

            allCustomerAppointments = GetAllAppointments();
            var now = DateTime.Now;

            foreach (APTDETAILS a in allCustomerAppointments)

                if (a.APD_CUSTOMER == customer.CS_STAMP && a.APD_DATE > now)
                {
                    futureCustomerAppoinments.Add(a);
                }





            return futureCustomerAppoinments;
        }

        public List<APTDETAILS> GetPastAppointments(CUSTOMERS customer)
        {
            allCustomerAppointments = GetAllAppointments();
            List<APTDETAILS> pastAppointments = new List<APTDETAILS>();
            List<APTDETAILS> twoLastAppointments = new List<APTDETAILS>();
            var now = DateTime.Now;

            foreach (APTDETAILS a in allCustomerAppointments)

                if (a.APD_CUSTOMER == customer.CS_STAMP && a.APD_DATE < now)
                {
                    pastAppointments.Add(a);
                }

            for (int i = 0; i < 2; i++)
            {
                twoLastAppointments.Add(pastAppointments[i]);
            }

            return twoLastAppointments;
        }


        public void PostAppointment(APTDETAILS appointment)
        {
            //CUSTOMERS customer = new CUSTOMERS
            //{
            //    CS_STAMP = 1,
            //    CS_FIRSTNAME = "Test",
            //    CS_LASTNAME = "Upload"
            //};

            //USERS user = new USERS {US_STAMP = 1};

            //EYEEXAMROOMS room = new EYEEXAMROOMS() {ERO_STAMP = 1};


            //APTDETAILS appointment = new APTDETAILS(10, user, room, DateTime.Now, "11:15", "14:30", customer, "Test aftale");

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

        public int GetNextAppointmentId()
        {
            var appointments = GetAppointments();
            if (appointments.Count == 0) return 0;

            return appointments.Last().APD_STAMP + 1;


        }

        public List<APTDETAILS> GetAppointments()
        {
            using (db = new OptikItDbContext())
            {
                var appointments = from a in db.APTDETAILS select a;
                return appointments.ToList();
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

        public List<string> GetClickedAppointmentDetails()
        {
            List<string> clickedAppointmentDetails = new List<string>();

            var clickedAppointment = CreateAppointment.ClickedAppointment;

            if (clickedAppointment.APD_TYPE.Equals(1)) clickedAppointmentDetails.Add("Linseopsætning");
            else if (clickedAppointment.APD_TYPE.Equals(0)) clickedAppointmentDetails.Add("Steljustering");

            var rooms = GetRooms();
            var matchingRoom = rooms.Find(r => r.ERO_NBR.Equals(clickedAppointment.APD_ROOM));
            if(matchingRoom != null) clickedAppointmentDetails.Add(matchingRoom.ERO_SHORTDESC);


            var users = GetUsers();
            var matchingUser = users.Find(u => u.US_STAMP.Equals(clickedAppointment.APD_USER));
            if (matchingUser != null) clickedAppointmentDetails.Add(matchingUser.US_USERNAME);

            

            return clickedAppointmentDetails;


        }

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



    }
}
