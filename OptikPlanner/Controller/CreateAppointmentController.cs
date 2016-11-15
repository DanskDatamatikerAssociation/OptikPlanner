﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptikPlanner.Model;

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
         

            APTDETAILS appointment = new APTDETAILS(10, user, room, DateTime.Now, "12:15", "12:30", customer, "Test aftale");

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


        public EYEEXAMROOMS GetRooms()
        {
            EYEEXAMROOMS room = new EYEEXAMROOMS();
            room.ERO_OPENFROM = "12:15";
            room.ERO_OPENTO = "13:00";
            room.ERO_NBR = 5;
            room.ERO_TYPE = "Linse";
            room.ERO_DESC = "linserum 5 første sal til venstre";
            room.ERO_SHORTDESC = "kort";
            

            return room;

        }

        public USERS GetUser()
        {
            USERS user = new USERS();
            user.US_CPRNO = "2001927891";
            user.US_USERNAME = "MyUserName";
            user.US_STAMP = 1;


            return user;
        }

        public CUSTOMERS GetCustomer()
        {
            CUSTOMERS customer = new CUSTOMERS();
            customer.CS_CPRNO = "2001926754";
            customer.CS_FIRSTNAME = "Børge";
            customer.CS_LASTNAME = "Jensen";


            return customer;
        }
        
        
            
    }
}
