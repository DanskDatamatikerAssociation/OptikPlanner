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
using System.Globalization;
using Calendar = System.Windows.Forms.Calendar.Calendar;

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
            SetWeekLabel();
            SetMonthLabel();
            SetYearLabel();

        }


        

        public void SetController(CalendarViewController controller)
        {
            _calendarViewController = controller;

            
            //calendar.MaximumViewDays = 21;

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



        private void monthView2_SelectionChanged(object sender, EventArgs e)
        {
            calendar.SetViewRange(monthView2.SelectionStart, monthView2.SelectionEnd);
        }

        private void calendar_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            AddAppointmentsToCalendar();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void newAppointmentButton_Click(object sender, EventArgs e)
        {
            var newForm = new View.CreateAppointment();
            newForm.Show();
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            calendar.SetViewRange(today, today);
        }

        private void twoWeeksButton_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime lastMonday;
            int daysSinceLastMonday = 1;
            while (true)
            {
                lastMonday = new DateTime(today.Year, today.Month, today.Day - daysSinceLastMonday);
                if (lastMonday.DayOfWeek == DayOfWeek.Monday)
                {
                    break;
                }
                daysSinceLastMonday++;
            }
            DateTime oneWeekAhead = lastMonday.AddDays(13);
            calendar.SetViewRange(lastMonday, oneWeekAhead);
        }

        public void SetWeekLabel()
        {
            DateTime currentDate;
            int currentWeek;

            currentDate = calendar.ViewStart;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(currentDate);

            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                currentDate = currentDate.AddDays(3);
            }

            currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            weekLabel.Text = currentWeek.ToString();

        }

        public void SetMonthLabel()
        {
            DateTime currentDate;
            int currentMonth;

            currentDate = calendar.ViewStart;

            currentMonth = CultureInfo.InvariantCulture.Calendar.GetMonth(currentDate);

            switch (currentMonth)
            {
                case 1:
                    label4.Text = ("Januar -");
                    break;
                case 2:
                    label4.Text = ("Februar -");
                    break;
                case 3:
                    label4.Text = ("Marts -");
                    break;
                case 4:
                    label4.Text = ("April -");
                    break;
                case 5:
                    label4.Text = ("Maj -");
                    break;
                case 6:
                    label4.Text = ("Juni -");
                    break;
                case 7:
                    label4.Text = ("Juli -");
                    break;
                case 8:
                    label4.Text = ("August -");
                    break;
                case 9:
                    label4.Text = ("September -");
                    break;
                case 10:
                    label4.Text = ("Oktober -");
                    break;
                case 11:
                    label4.Text = ("November -");
                    break;
                case 12:
                    label4.Text = ("December -");
                    break;

            }
            
        }

        public void SetYearLabel()
        {

            DateTime currentDate;

            int currentYear;

            currentDate = calendar.ViewStart;

            currentYear = CultureInfo.InvariantCulture.Calendar.GetYear(currentDate);

            yearLabel.Text = currentYear.ToString();


        }

        


    }
}
