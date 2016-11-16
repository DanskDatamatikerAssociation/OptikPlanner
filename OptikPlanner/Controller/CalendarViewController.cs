﻿using System;
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
        OptikItDbContext db = new OptikItDbContext();

        private ICalendarView _view;

        public CalendarViewController(ICalendarView view)
        {
            _view = view;
            view.SetController(this);
        }

  

        public void PostAppointment()
        {
            
        }

        private List<APTDETAILS> GetAppointments()
        {
            var appointments = from a in db.APTDETAILS select a;
            return appointments.ToList();
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

                CalendarItem c = new CalendarItem(_view.Calendar, new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day, int.Parse(timeFromHour), int.Parse(timeFromMinute), 0), new DateTime(appointMentDateValue.Year, appointMentDateValue.Month, appointMentDateValue.Day, int.Parse(timeToHour), int.Parse(timeToMinute), 0), Encoding.Default.GetString(a.APD_DESCRIPTION));
                calendarItems.Add(c);
            }

            return calendarItems;
        }



        

    }
}
