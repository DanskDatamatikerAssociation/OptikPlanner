using System;
using System.Collections;
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
    /// <summary>
    /// the CalendarView to handle view-related and controller functions
    /// </summary>
    public partial class CalendarView : Form, ICalendarView
    {
        private CalendarViewController _calendarViewController;
        public Calendar Calendar { get; }
        private const string DayViewMode = "day";
        private const string MonthViewMode = "month";
        private const string WeekViewMode = "week";
        private string _viewMode = WeekViewMode;
        private List<APTDETAILS> _filteredAppointments = new List<APTDETAILS>();
        private bool _filtered = false;
        private List<APTDETAILS> _currentVisibleAppointments;
        public static bool AddedNewAppointment;
        private int _userIndex;


        public CalendarView()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            contextMenuStrip1.Items.Add("Deaktiver");



            Calendar = calendar;
            _calendarViewController = new CalendarViewController(this);

            _currentVisibleAppointments = _calendarViewController.GetAppointments();
            SetupCalendar();
        }

        /// <summary>
        /// Sets up the calendar to match desired view
        /// </summary>
        private void SetupCalendar()
        {
            var rooms = from room in _calendarViewController.GetRooms() orderby room.ERO_NBR select room;
            var users = from user in _calendarViewController.GetUsers() orderby user.US_USERNAME select user;
            var customers = from customer in _calendarViewController.GetCustomers()
                orderby customer.CS_FIRSTNAME
                select customer;

            calendar.MaximumViewDays = 140;
            ShowWeekView();
            monthView.FirstDayOfWeek = DayOfWeek.Monday;
            SetWeekLabel();
            SetMonthLabel();
            SetYearLabel();

            calendar.AllowNew = false;

            foreach (var r in rooms) checkRoomList.Items.Add(r);
            foreach (var u in users) checkUsersList.Items.Add(u);
            foreach (var c in customers) checkCustomerList.Items.Add(c);

            CheckAllCustomersBoxes(true);
            CheckAllRoomsBoxes(true);
            CheckAllUsersBoxes(true);
            resetFilteringButton.Enabled = false;
            filtratingButton.Enabled = false;


            //Changes the current visible timerange on the calendar. 
            calendar.TimeUnitsOffset = -DateTime.Now.Hour * 4;
        }



        public void SetController(CalendarViewController controller)
        {
            _calendarViewController = controller;
        }

        /// <summary>
        /// Item click to access specified appointment details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                CreateAppointment.ClickedAppointment = (APTDETAILS)e.Item.Tag;

                var form = new CreateAppointment();
                form.ShowDialog();
            }
        }

        /// <summary>
        /// add all apointments to the calendar
        /// </summary>
        private void AddAppointmentsToCalendar()
        {
            if (_filtered) calendar.Items.AddRange(_calendarViewController.GetAppointmentsAsCalendarItems(_filteredAppointments));
            else calendar.Items.AddRange(_calendarViewController.GetAppointmentsAsCalendarItems());
            ApplyColorLogicToCalendarItems();
        }


        /// <summary>
        /// Show day mode
        /// </summary>
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

        /// <summary>
        /// Show week mode
        /// </summary>
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
            calendar.SelectedElementStart = null;
        }


        /// <summary>
        /// show two week schedule from present date
        /// </summary>
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
                    lastMonday = new DateTime(today.Year, today.Month, today.Day).AddDays(-daysSinceLastMonday);
                    
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

        /// <summary>
        /// Show month mode
        /// </summary>
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

        /// <summary>
        /// Button to access week view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weekViewButton_Click(object sender, EventArgs e)
        {
            ShowWeekView();
        }

        /// <summary>
        /// button to access day view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dayViewButton_Click(object sender, EventArgs e)
        {
            ShowDayView();
        }

        /// <summary>
        /// button to access month view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthViewButton_Click(object sender, EventArgs e)
        {
            ShowMonthView();
        }


        /// <summary>
        /// Corrects the viewmode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            SetAllLabels();
        }

        /// <summary>
        /// Loads all calendar items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            SetAllLabels();
            AddAppointmentsToCalendar();
        }

        /// <summary>
        /// Apply colors to all appointments (specified by employee)
        /// </summary>
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
                if (appointment.APD_USER == 11) colorIndex = 2 + colorJump;
                Color color = colors[colorIndex];


                i.ApplyColor(color);

            }
        }

        /// <summary>
        /// button to create new appointment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newAppointmentButton_Click(object sender, EventArgs e)
        {
            CreateAppointment.ClickedAppointment = null;
            var newForm = new View.CreateAppointment();
            newForm.ShowDialog();
        }

        /// <summary>
        /// button to show today
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// button to show two weeks view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void twoWeeksButton_Click(object sender, EventArgs e)
        {

            ShowTwoWeeksView();
        }

        /// <summary>
        /// sets the layout for week view
        /// </summary>
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

        /// <summary>
        /// Sets the layout for month view
        /// </summary>
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

        /// <summary>
        /// sets the layout for year view
        /// </summary>
        public void SetYearLabel()
        {

            DateTime currentDate;

            int currentYear;

            currentDate = calendar.ViewStart;

            currentYear = CultureInfo.InvariantCulture.Calendar.GetYear(currentDate);

            yearLabel.Text = currentYear.ToString();


        }

        /// <summary>
        /// mouseover tooltip view to show brief description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Point tooltipPosition = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y + 40));


                APTDETAILS a = (APTDETAILS)i.Tag;
                var type = CalendarViewController.GetAppointmentType(a);
                var room = _calendarViewController.GetAppointmentRoom(a);
                var user = _calendarViewController.GetAppointmentUser(a);
                if (a == null || user == null) return;
                if (a.APD_DESCRIPTION == null || Encoding.Default.GetString(a.APD_DESCRIPTION).Equals("")) a.APD_DESCRIPTION = Encoding.Default.GetBytes("**Ingen beskrivelse**");
                string textToShow = $"{a.APD_TIMEFROM} - {a.APD_TIMETO}\n" +
                                    "\n" +
                                    $"{type}\n" +
                                    $"Lokale nr. {a.APD_ROOM}\n" +
                                    $"{user.US_USERNAME}" +
                                    "\n" +
                                    "\n" +
                                    $"'{Encoding.Default.GetString(a.APD_DESCRIPTION)}'";
                toolTip.Show(textToShow, this, tooltipPosition);
            }
        }

        /// <summary>
        /// refreshes appointments on the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarView_Activated(object sender, EventArgs e)
        {
            calendar.ViewStart = calendar.ViewStart;
            calendar.ViewEnd = calendar.ViewEnd;
        }

        /// <summary>
        /// button to access the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logButton_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "CancelAppointmentLog.txt"));
        }

        /// <summary>
        /// right click function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// show one week ahead (for arrow navigation)
        /// </summary>
        private void OneWeekAhead()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(7), currentViewEnd.AddDays(7));

        }

        /// <summary>
        /// show one week back (for arrow navigation)
        /// </summary>
        private void OneWeekBack()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(-7), currentViewEnd.AddDays(-7));
        }

        /// <summary>
        /// show one month ahead (for arrow navigation)
        /// </summary>
        private void OneMonthAhead()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddMonths(1), currentViewEnd.AddMonths(1));
        }

        /// <summary>
        /// Show one month back (for arrow navigation)
        /// </summary>
        private void OneMonthBack()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddMonths(-1), currentViewEnd.AddMonths(-1));
        }

        /// <summary>
        /// show one day ahead (for arrow navigation)
        /// </summary>
        private void OneDayAhead()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(1), currentViewEnd.AddDays(1));
        }

        /// <summary>
        /// show one day back (for arrow navigation)
        /// </summary>
        private void OneDayBack()
        {
            var currentViewStart = calendar.ViewStart;
            var currentViewEnd = calendar.ViewEnd;
            calendar.SetViewRange(currentViewStart.AddDays(-1), currentViewEnd.AddDays(-1));
        }

        /// <summary>
        /// calendar left click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// calendar doubleclick - accessing detailed view of appointment or create new
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar_DoubleClick(object sender, EventArgs e)
        {

            CreateAppointment.ClickedAppointment = null;
            if (calendar.SelectedElementStart == null) return;
            var form = new CreateAppointment(calendar.SelectedElementStart.Date);
            form.ShowDialog();

        }

        /// <summary>
        /// sets all view labels
        /// </summary>
        private void SetAllLabels()
        {
            SetWeekLabel();
            SetMonthLabel();
            SetYearLabel();
        }

        /// <summary>
        /// button to access statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statisticsButton_Click(object sender, EventArgs e)
        {
            StatisticsView window = new StatisticsView();
            window.Show();
        }

        /// <summary>
        /// button to access Custoemr Library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            CustomerLibrary window = new CustomerLibrary();
            window.Show();
        }

        /// <summary>
        /// specific day click to access specified day only view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            _viewMode = DayViewMode;
            calendar.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
            dayViewButton.Select();
        }


        #region Color changes on activity
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

        private void DisableUserClick()
        {
            checkUsersList.Items.Clear();

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
        #endregion

        #region checkAllLists

        /// <summary>
        /// sorting of checked rooms
        /// </summary>
        /// <returns></returns>
        private List<EYEEXAMROOMS> GetCheckedRooms()
        {
            List<EYEEXAMROOMS> checkedRooms = new List<EYEEXAMROOMS>();
            for (int i = 0; i < checkRoomList.Items.Count; i++)
            {
                var room = (EYEEXAMROOMS)checkRoomList.Items[i];
                var isChecked = checkRoomList.GetItemCheckState(i);
                if (isChecked == CheckState.Checked) checkedRooms.Add(room);
            }

            return checkedRooms;
        }

        /// <summary>
        /// sorting of checked employees
        /// </summary>
        /// <returns></returns>
        private List<USERS> GetCheckedEmployees()
        {
            List<USERS> checkedEmployees = new List<USERS>();
            for (int i = 0; i < checkUsersList.Items.Count; i++)
            {
                var employee = (USERS)checkUsersList.Items[i];
                var isChecked = checkUsersList.GetItemCheckState(i);
                if (isChecked == CheckState.Checked) checkedEmployees.Add(employee);
            }
            return checkedEmployees;
        }

        /// <summary>
        /// sorting of checked customers
        /// </summary>
        /// <returns></returns>
        private List<CUSTOMERS> GetCheckedCustomers()
        {
            List<CUSTOMERS> checkedCustomers = new List<CUSTOMERS>();
            for (int i = 0; i < checkCustomerList.Items.Count; i++)
            {
                var customer = (CUSTOMERS)checkCustomerList.Items[i];
                var isChecked = checkCustomerList.GetItemCheckState(i);
                if (isChecked == CheckState.Checked) checkedCustomers.Add(customer);
            }
            return checkedCustomers;
        }


        /// <summary>
        /// sorting of checked appointments
        /// </summary>
        /// <returns></returns>
        private List<APTDETAILS> GetAllCheckedApt()
        {

            List<APTDETAILS> allApt = _calendarViewController.GetAppointments();

            var checkedRooms = GetCheckedRooms();
            var checkedEmployees = GetCheckedEmployees();
            var checkedCustomers = GetCheckedCustomers();

            List<APTDETAILS> checkedApt = new List<APTDETAILS>();

            var checkedAptQuery = (from room in checkedRooms
                                   from user in checkedEmployees
                                   from customer in checkedCustomers
                                   from apt in allApt
                                   where
                                   room.ERO_STAMP == apt.APD_ROOM && user.US_STAMP == apt.APD_USER && customer.CS_STAMP == apt.APD_CUSTOMER
                                   || room.ERO_STAMP == apt.APD_ROOM && user.US_STAMP == apt.APD_USER
                                   || room.ERO_STAMP == apt.APD_ROOM && customer.CS_STAMP == apt.APD_CUSTOMER
                                   || user.US_STAMP == apt.APD_USER && customer.CS_STAMP == apt.APD_CUSTOMER
                                   select apt).ToList();

            foreach (var apt in checkedAptQuery)
            {
                if (!checkedApt.Contains(apt)) checkedApt.Add(apt);
            }

            //Works
            //var checkAptQuery = allApt.Where(a => checkedRooms.All(r => r.ERO_NBR == a.APD_ROOM));    
            calendar.Items.Clear();
            return checkedApt;
        }

        /// <summary>
        /// button for filtration 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filtratingButton_Click(object sender, EventArgs e)
        {
            _filtered = true;
            _filteredAppointments = GetAllCheckedApt();
            //Calendar.Items.AddRange(_calendarViewController.GetAppointmentsAsCalendarItems(_filteredAppointments));
            AddAppointmentsToCalendar();
            resetFilteringButton.Enabled = true;
            filtratingButton.Enabled = false;
        }
        #endregion


        #region checkAllboxes

        /// <summary>
        /// check if all rooms are checked
        /// </summary>
        /// <param name="checkThem"></param>
        private void CheckAllRoomsBoxes(bool checkThem)
        {
            checkAllRoomsBox.Checked = checkThem;
            for (int i = 0; i < checkRoomList.Items.Count; i++)
            {
                checkRoomList.SetItemChecked(i, checkThem);

            }
        }

        /// <summary>
        /// check of all customers are checked
        /// </summary>
        /// <param name="checkThem"></param>
        private void CheckAllCustomersBoxes(bool checkThem)
        {
            checkAllCustomers.Checked = checkThem;
            for (int i = 0; i < checkCustomerList.Items.Count; i++)
            {
                checkCustomerList.SetItemChecked(i, checkThem);

            }
        }

        /// <summary>
        /// check of all customers are checked
        /// </summary>
        /// <param name="checkThem"></param>
        private void CheckAllUsersBoxes(bool checkThem)
        {
            checkAllUsersBox.Checked = checkThem;
            for (int i = 0; i < checkUsersList.Items.Count; i++)
            {
                checkUsersList.SetItemChecked(i, checkThem);

            }
        }

        ///
        private void checkAllRoomsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllRoomsBox.Checked) CheckAllRoomsBoxes(true);
        }

        private void checkAllUsersBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllUsersBox.Checked) CheckAllUsersBoxes(true);
        }
        private void checkAllCustomers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllCustomers.Checked) CheckAllCustomersBoxes(true);
        }
        #endregion

        /// <summary>
        /// filter reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetFilteringButton_Click(object sender, EventArgs e)
        {
            _filtered = false;
            calendar.Items.Clear();
            AddAppointmentsToCalendar();
            CheckAllCustomersBoxes(true);
            CheckAllRoomsBoxes(true);
            CheckAllUsersBoxes(true);
            resetFilteringButton.Enabled = false;
            filtratingButton.Enabled = false;
        }

        private void checkRoomList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            filtratingButton.Enabled = true;
            if (e.NewValue == CheckState.Unchecked) checkAllRoomsBox.Checked = false;
        }

        private void checkUsersList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            filtratingButton.Enabled = true;
            if (e.NewValue == CheckState.Unchecked) checkAllUsersBox.Checked = false;

        }

        private void checkCustomerList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            filtratingButton.Enabled = true;
            if (e.NewValue == CheckState.Unchecked) checkAllCustomers.Checked = false;

        }

        private void checkUsersList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _userIndex = checkUsersList.IndexFromPoint(e.Location);
                checkUsersList.SetSelected(checkUsersList.IndexFromPoint(e.Location), true);

                contextMenuStrip1.Show();
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            checkUsersList.Items.RemoveAt(_userIndex);
        }

        private void monthView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, this.Bounds);

        }
    }
}
