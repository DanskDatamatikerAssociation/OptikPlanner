using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptikPlanner.Controller
{
    class CreateAppointmentController
    {
        OptikItDbContext db = new OptikItDbContext();

        public void PostAppointment()
        {
            CUSTOMERS customer = new CUSTOMERS
            {
                CS_STAMP = 1,
                CS_FIRSTNAME = "Test",
                CS_LASTNAME = "Upload"
            };

            USERS user = new USERS {US_STAMP = 1};

            EYEEXAMROOMS room = new EYEEXAMROOMS() {ERO_STAMP = 1};
         

            APTDETAILS appointment = new APTDETAILS(8, user, room, DateTime.Now, "12:15", "12:30", customer, "Test aftale");

            db.APTDETAILS.Add(appointment);

            try
            {
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
    }
}
