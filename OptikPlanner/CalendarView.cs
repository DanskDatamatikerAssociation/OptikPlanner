﻿using System;
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
using System.IO;
using Calendar = System.Windows.Forms.Calendar.Calendar;

namespace OptikPlanner
{
    public partial class CalendarView : Form, ICalendarView
    {
        private CreateAppointmentController _createAppointmentController;
        private CalendarViewController _calendarViewController;
        public Calendar Calendar { get; }
        private const string DayViewMode = "day";
        private const string MonthViewMode = "month";
        private const string WeekViewMode = "week";
        private string _viewMode = WeekViewMode;
        
        
        private CustomerLibraryController _customerLibraryController = new CustomerLibraryController();
        public CalendarView()
        {
            InitializeComponent();
            CUSTOMERS customer = new CUSTOMERS();
            customer.CS_CPRNO = "20019267454";
            customer.CS_FIRSTNAME = "Børge";
            customer.CS_LASTNAME = "Jensen";
            customer.CS_ADRESS1 = "Børgevej 210";
            customer.CS_PHONEMOBILE = "28706520";
            customer.CS_EMAIL = "enemail@gmail.com";
            customer.CS_STAMP = 1;
            StartPosition = FormStartPosition.CenterScreen;

            //_createAppointmentController.GetFutureAppointments(customer);
            //_createAppointmentController.GetPastAppointments(customer);

            Calendar = calendar;
            _calendarViewController = new CalendarViewController(this);

            SetupCalendar();

         


        }

        private void SetupCalendar()
        {
            calendar.MaximumViewDays = 140;
            ShowWeekView();
            monthView.FirstDayOfWeek = DayOfWeek.Monday;
            SetWeekLabel();
            SetMonthLabel();
            SetYearLabel();

            calendar.AllowNew = false;

            
            //Changes the current visible timerange on the calendar. 
            calendar.TimeUnitsOffset = -DateTime.Now.Hour * 2;
        }



        public void SetController(CalendarViewController controller)
        {
            _calendarViewController = controller;


        }


        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                CreateAppointment.ClickedAppointment = (APTDETAILS)e.Item.Tag;

                var form = new CreateAppointment();
                form.ShowDialog();
            }
            



        }

        private void AddAppointmentsToCalendar()
        {
            calendar.Items.Clear();
            calendar.Items.AddRange(_calendarViewController.GetAppointmentsAsCalendarItems());

        }



        private void ShowDayView()
        {
            SetAllLabels();
            _viewMode = DayViewMode;

            calendar.SetViewRange(DateTime.Today, DateTime.Today);
            if (!monthView.SelectionStart.Equals(DateTime.MinValue))
                calendar.SetViewRange(monthView.SelectionStart, monthView.SelectionStart);
            if (calendar.SelectedElementStart != null) calendar.SetViewRange(calendar.SelectedElementStart.Date, calendar.SelectedElementStart.Date);


            calendar.SelectedElementStart = null;

        }

        private void ShowWeekView()
        {
            SetAllLabels();

            _viewMode = WeekViewMode;

            DateTime today;
            if (monthView.SelectionStart.Equals(DateTime.MinValue)) { today = DateTime.Today; }
            else today = monthView.SelectionStart;
            if (calendar.SelectedElementStart != null) today = calendar.SelectedElementStart.Date;

            DateTime lastMonday;
            int daysSinceLastMonday = 1;
            if (today.DayOfWeek != DayOfWeek.Monday)
            {
                while (true)
                {

                    lastMonday = today.AddDays(-daysSinceLastMonday);
                    if (lastMonday.DayOfWeek == DayOfWeek.Monday)
                    {
                        break;
                    }
                    daysSinceLastMonday++;


                }
            }
            else lastMonday = today;

            DateTime oneWeekAhead = lastMonday.AddDays(6);

            calendar.SetViewRange(lastMonday, oneWeekAhead);

            //if (!monthView.SelectionStart.Equals(DateTime.MinValue) ||
            //    !monthView.SelectionEnd.Equals(DateTime.MinValue))
            //{
            //    monthView.SelectionStart = lastMonday;
            //    monthView.SelectionEnd = oneWeekAhead;
            //}

            calendar.SelectedElementStart = null;


        }

        private void ShowTwoWeeksView()
        {
            //CHECK THE CALENDARRENDERER-CLASS - PerformItemLayout FOR DEBUGGING ~Danny
            SetAllLabels();

            DateTime today = DateTime.Today;
            DateTime lastMonday;
            int daysSinceLastMonday = 1;

            if (today.DayOfWeek != DayOfWeek.Monday)
            {
                while (true)
                {
                    lastMonday = new DateTime(today.Year, today.Month, today.Day - daysSinceLastMonday);
                    if (lastMonday.DayOfWeek == DayOfWeek.Monday)
                    {
                        break;
                    }
                    daysSinceLastMonday++;
                }
            }
            else lastMonday = today;


            DateTime twoWeeksAhead = lastMonday.AddDays(13);

            calendar.SetViewRange(lastMonday, twoWeeksAhead);


        }

        private void ShowMonthView()
        {
            SetAllLabels();

            _viewMode = MonthViewMode;

            DateTime selectedDate = calendar.ViewStart;
            if (!monthView.SelectionStart.Equals(DateTime.MinValue)) selectedDate = monthView.SelectionStart;
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
            switch (_viewMode)
            {
                case DayViewMode:
                    ShowDayView();
                    break;
                case WeekViewMode:
                    ShowWeekView();
                    break;
                case MonthViewMode:
                    ShowMonthView();
                    break;
            }
            //calendar.SetViewRange(monthView.SelectionStart, monthView.SelectionEnd);

            SetAllLabels();
        }

        //private void calendar_LoadItems(object sender, CalendarLoadEventArgs e)
        //{
        //    SetAllLabels();
        //    AddAppointmentsToCalendar();
        //    ApplyColorLogicToCalendarItems();

            


        //}

        private void ApplyColorLogicToCalendarItems()
        {
            //Color logic here
            var items = calendar.Items;

            var systemColors = new ColorConverter().GetStandardValues();
            List<Color> colors = systemColors.Cast<Color>().ToList();

            int colorJump = 50;

            foreach (var i in items)
            {
                APTDETAILS appointment = (APTDETAILS)i.Tag;

                int colorIndex = appointment.APD_USER + colorJump;
                Color color = colors[colorIndex];


                i.ApplyColor(color);

            }
        }


        private void newAppointmentButton_Click(object sender, EventArgs e)
        {
            CreateAppointment.ClickedAppointment = null;
            var newForm = new View.CreateAppointment();
            newForm.ShowDialog();
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            
            DateTime today = DateTime.Today;       
            calendar.SetViewRange(today, today);
            

            monthView.SelectionStart = today;
            monthView.SelectionEnd = today;

            switch (_viewMode)
            {
                case DayViewMode:
                    ShowDayView();
                    break;
                case WeekViewMode:
                    ShowWeekView();
                    break;
                case MonthViewMode:
                    ShowMonthView();
                    break;
            }

        }

        private void twoWeeksButton_Click(object sender, EventArgs e)
        {

            ShowTwoWeeksView();
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
            if (!monthView.SelectionStart.Equals(DateTime.MinValue))
                weekLabel.Text =
                    CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(monthView.SelectionStart,
                        CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();

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

            DateTime currentDate;

            int currentYear;

            currentDate = calendar.ViewStart;

            currentYear = CultureInfo.InvariantCulture.Calendar.GetYear(currentDate);

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
                //Point tooltipPosition = PointToClient(Cursor.Position);
                Point tooltipPosition = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y+40));


                APTDETAILS a = (APTDETAILS)i.Tag;
                var extraDetails = _calendarViewController.GetExtraAppointmentDetails(a);
                if (a == null) return;
                if (a.APD_DESCRIPTION == null || Encoding.Default.GetString(a.APD_DESCRIPTION).Equals("")) a.APD_DESCRIPTION = Encoding.Default.GetBytes("**Ingen beskrivelse**");
                string textToShow = $"{a.APD_TIMEFROM} - {a.APD_TIMETO}\n" +
                                    "\n" +
                                    $"{extraDetails[0]}\n" +
                                    $"Lokale nr. {a.APD_ROOM}\n" +
                                    $"{extraDetails[2]}" +
                                    "\n" +
                                    "\n" +
                                    $"'{Encoding.Default.GetString(a.APD_DESCRIPTION)}'";
                toolTip.Show(textToShow, this, tooltipPosition);
            }
        }

        private void CalendarView_Activated(object sender, EventArgs e)
        {
            //Refreshes the appointment on to view.
            calendar.ViewStart = calendar.ViewStart;
            calendar.ViewEnd = calendar.ViewEnd;
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"));
        }


        private void calendarButtonRight_Click(object sender, EventArgs e)
        {
            switch (_viewMode)
            {
                case DayViewMode:
                    OneDayAhead();   
                    SetAllLabels();                 
                    break;
                case WeekViewMode:
                    OneWeekAhead();
                    SetAllLabels();
                    break;
                case MonthViewMode:
                    OneMonthAhead();
                    SetAllLabels();
                    break;
            }
        }

        private void OneWeekAhead()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(7), currentViewEnd.AddDays(7));
            
        }

        private void OneWeekBack()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(-7), currentViewEnd.AddDays(-7));
        }

        private void OneMonthAhead()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddMonths(1), currentViewEnd.AddMonths(1));
        }

        private void OneMonthBack()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddMonths(-1), currentViewEnd.AddMonths(-1));
        }

        private void OneDayAhead()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(1), currentViewEnd.AddDays(1));
        }

        private void OneDayBack()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(-1), currentViewEnd.AddDays(-1));
        }

        private void calendarButtonLeft_Click(object sender, EventArgs e)
        {
            switch (_viewMode)
            {
                case DayViewMode:
                    OneDayBack();
                    SetAllLabels();
                    break;
                case WeekViewMode:
                    OneWeekBack();
                    SetAllLabels();
                    break;
                case MonthViewMode:
                    OneMonthBack();
                    SetAllLabels();
                    break;
            }
        }

        private void calendar_DoubleClick(object sender, EventArgs e)
        {
            
            CreateAppointment.ClickedAppointment = null;
            if (calendar.SelectedElementStart == null) return;
            var form = new CreateAppointment(calendar.SelectedElementStart.Date);
            form.ShowDialog();

        }

        private void SetAllLabels()
        {
            SetWeekLabel();
            SetMonthLabel();
            SetYearLabel();
        }


        private void statisticsButton_Click(object sender, EventArgs e)
        {
            StatisticsView window = new StatisticsView();
            window.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CustomerLibrary window = new CustomerLibrary();
            window.Show();
        }

        private void calendar_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            _viewMode = DayViewMode;
            calendar.SetViewRange(e.CalendarDay.Date,e.CalendarDay.Date);
            dayViewButton.Select();
        }

        private void monthLabel_Click(object sender, EventArgs e)
        {

        }

        private void monthViewButton_Enter(object sender, EventArgs e)
        {
            monthViewButton.BackColor = Color.LightGray;
        }

        private void monthViewButton_Leave(object sender, EventArgs e)
        {
            monthViewButton.BackColor = Color.White;
        }

        private void weekViewButton_Enter(object sender, EventArgs e)
        {
            weekViewButton.BackColor = Color.LightGray;
        }

        private void weekViewButton_Leave(object sender, EventArgs e)
        {
            weekViewButton.BackColor = Color.White;
        }

        private void dayViewButton_Enter(object sender, EventArgs e)
        {
            dayViewButton.BackColor = Color.LightGray;
        }

        private void dayViewButton_Leave(object sender, EventArgs e)
        {
            dayViewButton.BackColor = Color.White;
        }

        private void twoWeeksButton_Enter(object sender, EventArgs e)
        {
            twoWeeksButton.BackColor = Color.LightGray;
        }

        private void twoWeeksButton_Leave(object sender, EventArgs e)
        {
            twoWeeksButton.BackColor = Color.White;
        }

        private void todayButton_Enter(object sender, EventArgs e)
        {
            todayButton.BackColor = Color.LightGray;
        }

        private void todayButton_Leave(object sender, EventArgs e)
        {
            todayButton.BackColor = Color.White;
        }

        private void newAppointmentButton_Enter(object sender, EventArgs e)
        {
            newAppointmentButton.BackColor = Color.LightGray;
        }

        private void newAppointmentButton_Leave(object sender, EventArgs e)
        {
            newAppointmentButton.BackColor = Color.White;
        }


        private void button8_Enter(object sender, EventArgs e)
        {
            button8.BackColor = Color.LightGray;
        }

        private void button8_Leave(object sender, EventArgs e)
        {
            button8.BackColor = Color.White;
        }

        private void logButton_Enter(object sender, EventArgs e)
        {
            logButton.BackColor = Color.LightGray;
        }

        private void logButton_Leave(object sender, EventArgs e)
        {
            logButton.BackColor = Color.White;
        }
    }
}
