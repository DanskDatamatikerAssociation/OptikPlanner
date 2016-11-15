using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;
using OptikPlanner.Model;
using OptikPlanner.View;

namespace OptikPlanner
{
    public partial class CalendarView : Form, ICalendarView
    {
        private CalendarViewController _calendarViewController;
        public Calendar Calendar { get; }

        public CalendarView()
        {
            InitializeComponent();
            Calendar = calendar;
            _calendarViewController = new CalendarViewController(this);
            calendar.MaximumViewDays = 140;
            ShowWeekView();
            monthView2.FirstDayOfWeek = DayOfWeek.Monday;

        }



        public void SetController(CalendarViewController controller)
        {
            _calendarViewController = controller;
        }


        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            CalendarItem calendarItem = e.Item;
            calendarItem.Text = "You just double clicked me!\nLocation";




        }

        private void AddAppointmentsToCalendar()
        {

            calendar.Items.AddRange(_calendarViewController.GetAppointmentsAsCalendarItems());

        }



        private void ShowDayView()
        {
            calendar.SetViewRange(DateTime.Today, DateTime.Today);
        }

        private void ShowWeekView()
        {
            DateTime today;
            if (monthView2.SelectionStart.Equals(DateTime.MinValue)) { today = DateTime.Today; }
            else today = monthView2.SelectionStart;
            //DateTime today = DateTime.Today;   


            DateTime lastMonday;
            int daysSinceLastMonday = 1;
            while (true)
            {

                lastMonday = today.AddDays(-daysSinceLastMonday);
                if (lastMonday.DayOfWeek == DayOfWeek.Monday)
                {
                    break;
                }
                daysSinceLastMonday++;


            }

            DateTime oneWeekAhead = lastMonday.AddDays(6);

            calendar.SetViewRange(lastMonday, oneWeekAhead);

            if (!monthView2.SelectionStart.Equals(DateTime.MinValue) ||
                !monthView2.SelectionEnd.Equals(DateTime.MinValue))
            {
                monthView2.SelectionStart = lastMonday;
                monthView2.SelectionEnd = oneWeekAhead;
            }




        }

        private void ShowMonthView()
        {
            DateTime today = DateTime.Today;
            int daysInCurrentMonth = DateTime.DaysInMonth(today.Year, today.Month);

            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayofMonth = new DateTime(today.Year, today.Month, daysInCurrentMonth);

            calendar.SetViewRange(firstDayOfMonth, lastDayofMonth);
        }

        private void weekViewButton_Click(object sender, EventArgs e)
        {
            ShowWeekView();
        }

        private void dayViewButton_Click(object sender, EventArgs e)
        {
            ShowDayView();
        }

        private void monthViewButton_Click(object sender, EventArgs e)
        {
            ShowMonthView();
        }

        private void newAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointmentsToCalendar();

        }

        private void monthView2_SelectionChanged(object sender, EventArgs e)
        {
            calendar.SetViewRange(monthView2.SelectionStart, monthView2.SelectionEnd);
        }

        private void calendar_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            AddAppointmentsToCalendar();
        }
    }
}
