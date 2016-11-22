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

        OptikItDbContext db = new OptikItDbContext();

        private static ICreateAppointmentView _view;

        public CreateAppointmentController(ICreateAppointmentView view)
        {
            _view = view;
            view.SetController(this);
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
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                
            }

        }

        public int GetNextAppointmentId()
        {
            var appointment = GetAppointments().Last();
            return appointment.APD_STAMP + 1;


        }

        public List<APTDETAILS> GetAppointments()
        {

            var appointments = from a in db.APTDETAILS select a;
            return appointments.ToList();


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

            var rooms = from r in db.EYEEXAMROOMS select r;
            return rooms.ToList();

        }





        public List<USERS> GetUsers()
        {
            //USERS user = new USERS();
            //user.US_CPRNO = "2001927891";
            //user.US_USERNAME = "MyUserName";
            //user.US_STAMP = 1;


            //return user;

            var users = from u in db.USERS select u;
            return users.ToList();

        }

        public List<CUSTOMERS> GetCustomers()
        {
            //    CUSTOMERS customer = new CUSTOMERS();
            //    customer.CS_CPRNO = "2001926754";
            //    customer.CS_FIRSTNAME = "Børge";
            //    customer.CS_LASTNAME = "Jensen";


            //    return customer;

            var customers = from c in db.CUSTOMERS select c;
            return customers.ToList();
        }

        public List<string> GetClickedAppointmentDetails()
        {
            List<string> clickedAppointmentDetails = new List<string>();

            var clickedAppointment = CreateAppointment.ClickedAppointment;

            if (clickedAppointment.APD_TYPE.Equals(1)) clickedAppointmentDetails.Add("Linseopsætning");
            else if (clickedAppointment.APD_TYPE.Equals(0)) clickedAppointmentDetails.Add("Steljustering");

            var rooms = GetRooms();
            clickedAppointmentDetails.Add(rooms.Find(r => r.ERO_NBR.Equals(clickedAppointment.APD_ROOM)).ERO_SHORTDESC);

            var users = GetUsers();
            clickedAppointmentDetails.Add(users.Find(u => u.US_STAMP.Equals(clickedAppointment.APD_USER)).US_USERNAME);

            

            return clickedAppointmentDetails;


        }

        public void PutAppointment(APTDETAILS appointment)
        {
            var appointments = GetAppointments();
            var appointmentToPut = appointments.Find(a => a.APD_STAMP == appointment.APD_STAMP);

            appointmentToPut = appointment;
            db.APTDETAILS.Add(appointmentToPut);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
        }



    }
}
