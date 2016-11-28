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
        
        public int TotalCancelStatistics()
        {
            var list = CancelAppointmentController.noShowList.Count;
            var list1 = CancelAppointmentController.cancelPhoneList.Count;
            var list2 = CancelAppointmentController.cancelElseList.Count;

            return list + list1 + list2;
        }
        public void TotalAmountUsers()
        {
         

            //få alle medarbejdere
            //var dic = controller.noShowDic.Keys;
            //var dic1 = controller.cancelPhoneDic.Keys;
            //var dic2 = controller.cancelElseDic.Keys;

            //List<string> list = new List<string>();

            //foreach (var s in dic)
            //{
            //    list.Add(s.US_USERNAME);
            //}
            //foreach (var s in dic1)
            //{
            //    list.Add(s.US_USERNAME);
            //}
            //foreach (var s in dic2)
            //{
            //    list.Add(s.US_USERNAME);
            //}

            //return list;


        }

        public void NoShowStatistics()
        {
           
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
