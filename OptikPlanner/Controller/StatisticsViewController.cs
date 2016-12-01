using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Model;
using OptikPlanner.View;

namespace OptikPlanner.Controller
{
    class StatisticsViewController
    {

        OptikItDbContext db = new OptikItDbContext();
        CancelAppointmentController controller = new CancelAppointmentController();
        

        public int TotalCancelStatistics()
        {
            var dic = controller.noShowDic.Count;
            var dic1 = controller.cancelPhoneDic.Count;
            var dic2 = controller.cancelElseDic.Count;

            return dic + dic1 + dic2;
        }

        //public void NoShowStatistics()
        //{
        //    foreach (var s in controller.noShowDic)
        //    {
        //        test[0].SubItems[0].Text = s.Value;
        //    }
        //}

        public void PhoneCancelStatistics()
        {
            
        }

        public void ElseCancelStatistics()
        {
            
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

        public List<APTDETAILS> GetAppointments()
        {
            List<APTDETAILS> appointments = new List<APTDETAILS>();
            var customer = GetCustomer();

            List<USERS>  user = GetUser();
            EYEEXAMROOMS room = GetRooms();

            APTDETAILS appointment = new APTDETAILS(10, user[0], room, DateTime.Now, "12:15", "12:30", customer, "Test aftale");
            APTDETAILS appointment1 = new APTDETAILS(10, user[1], room, DateTime.Now, "12:15", "12:30", customer, "Test aftale");
            APTDETAILS appointment2 = new APTDETAILS(10, user[2], room, DateTime.Now, "12:15", "12:30", customer, "Test aftale");

            appointments.Add(appointment);
            appointments.Add(appointment1);
            appointments.Add(appointment2);
            return appointments;
        }



        public List<USERS> GetUser()
        {
            USERS user = new USERS();
            user.US_CPRNO = "2001927891";
            user.US_USERNAME = "MyUserName";
            user.US_STAMP = 1;

            USERS user1 = new USERS();
            user.US_CPRNO = "2001927892";
            user.US_USERNAME = "MyUser";
            user.US_STAMP = 2;

            USERS user2 = new USERS();
            user.US_CPRNO = "2001927893";
            user.US_USERNAME = "MyUserHEJ";
            user.US_STAMP = 3;

            List<USERS> users = new List<USERS>();

            users.Add(user);
            users.Add(user1);
            users.Add(user2);

            return users;
        }

        public CUSTOMERS GetCustomer()
        {
            CUSTOMERS customer = new CUSTOMERS();
            customer.CS_CPRNO = "2001926754";
            customer.CS_FIRSTNAME = "Børge";
            customer.CS_LASTNAME = "Jensen";


            return customer;
        }

        public List<APTDETAILS> GetUserAppointments(USERS user)
        {
            List<APTDETAILS> appointmentsByUser = new List<APTDETAILS>();
            var appointments = GetAppointments();

            foreach (var a in appointments)
            {
                if (a.APD_USER == user.US_STAMP) appointmentsByUser.Add(a);
            }

            return appointmentsByUser;

        }
    }
}
