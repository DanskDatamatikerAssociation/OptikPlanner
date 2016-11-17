using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            monthView.FirstDayOfWeek = DayOfWeek.Monday;
            SetWeekLabel();
            SetMonthLabel();
            SetYearLabel();

            customersCheckedListBox.Items.AddRange(_calendarViewController.GetCustomers().ToArray());

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
            if (monthView.SelectionStart.Equals(DateTime.MinValue)) { today = DateTime.Today; }
            else today = monthView.SelectionStart;

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

            if (!monthView.SelectionStart.Equals(DateTime.MinValue) ||
                !monthView.SelectionEnd.Equals(DateTime.MinValue))
            {
                monthView.SelectionStart = lastMonday;
                monthView.SelectionEnd = oneWeekAhead;
            }


        }

        private void ShowMonthView()
        {
            DateTime selectedDate = calendar.ViewStart;
            int daysInCurrentMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);
            DateTime firstDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            DateTime lastDayOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, daysInCurrentMonth);

            calendar.SetViewRange(firstDayOfMonth, lastDayOfMonth);

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
            calendar.SetViewRange(monthView.SelectionStart, monthView.SelectionEnd);
        }

        private void calendar_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            AddAppointmentsToCalendar();


            //Color logic here
            var items = e.Calendar.Items;

            var systemColors = new ColorConverter().GetStandardValues();
            List<Color> colors = systemColors.Cast<Color>().ToList();

            int colorJump = 50;

            foreach (var i in items)
            {
                APTDETAILS appointment = (APTDETAILS)i.Tag;

                int colorIndex = appointment.APD_USER+colorJump;
                Color color = colors[colorIndex];


                i.ApplyColor(color);

            }


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
                    monthLabel.Text = ("Januar");
                    break;
                case 2:
                    monthLabel.Text = ("Februar");
                    break;
                case 3:
                    monthLabel.Text = ("Marts");
                    break;
                case 4:
                    monthLabel.Text = ("April");
                    break;
                case 5:
                    monthLabel.Text = ("Maj");
                    break;
                case 6:
                    monthLabel.Text = ("Juni");
                    break;
                case 7:
                    monthLabel.Text = ("Juli");
                    break;
                case 8:
                    monthLabel.Text = ("August");
                    break;
                case 9:
                    monthLabel.Text = ("September");
                    break;
                case 10:
                    monthLabel.Text = ("Oktober");
                    break;
                case 11:
                    monthLabel.Text = ("November");
                    break;
                case 12:
                    monthLabel.Text = ("December");
                    break;

            }

        }

        public void SetYearLabel()
        {
            var currentDate = calendar.ViewStart;

            var currentYear = CultureInfo.InvariantCulture.Calendar.GetYear(currentDate);

            yearLabel.Text = currentYear.ToString();


        }

        private void calendar_MouseMove(object sender, MouseEventArgs e)
        {
            CalendarItem i = calendar.ItemAt(calendar.PointToClient(Cursor.Position));
            if (i == null)
            {
                toolTip.Active = false;
                toolTip.Hide(this);
            }
            else if (toolTip.Active == false)
            {
                toolTip.Active = true;
                Point tooltipPosition = PointToClient(Cursor.Position);

                APTDETAILS a = (APTDETAILS)i.Tag;
                if (a == null) return;
                if (a.APD_DESCRIPTION == null) a.APD_DESCRIPTION = Encoding.Default.GetBytes("**Ingen beskrivelse**");
                string textToShow = $"{a.APD_TIMEFROM} - {a.APD_TIMETO}\n" +
                                    "Linseoptimering\n" +
                                    $"Room number {a.APD_ROOM}\n" +
                                    "\n" +
                                    $"'{Encoding.Default.GetString(a.APD_DESCRIPTION)}'";
                toolTip.Show(textToShow, this, tooltipPosition);
            }
        }

        private void customersCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<CUSTOMERS> checkedCustomers = new List<CUSTOMERS>();
            foreach (var c in customersCheckedListBox.SelectedItems)
            {
                checkedCustomers.Add((CUSTOMERS) c);
            }

            if(e.NewValue == CheckState.Checked) checkedCustomers.Add((CUSTOMERS) customersCheckedListBox.Items[e.Index]);

            



        }
    }
}
