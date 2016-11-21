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
    public class CancelAppointmentController
    {
        

        public void DeleteAppointment()
        {
            
        }


        //Denne metode skal pege på GetAppointmentsAsCalendarItems under CalendarViewController
        public CalendarItem Appointments()
        {
            CalendarItem CI = new CalendarItem(null, new DateTime(2016, 10, 22, 14, 30, 22), new DateTime(2016, 10, 22, 14, 45, 22), "Jeg er en aftale");

            return CI;
        } 



    }
}
