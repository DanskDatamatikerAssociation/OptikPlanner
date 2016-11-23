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

        public void NoShowStatistics()
        {
            foreach (var s in controller.noShowDic)
            {
                test[0].SubItems[0].Text = s.Value;
            }
        }

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

        public APTDETAILS GetAppointments()
        {
            
            var customer = GetCustomer();

            USERS user = GetUser();
            EYEEXAMROOMS room = GetRooms();

            APTDETAILS appointment = new APTDETAILS(10, user, room, DateTime.Now, "12:15", "12:30", customer, "Test aftale");

            return appointment;
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
