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

namespace OptikPlanner
{
    public partial class CalendarView : Form
    {
        public CalendarView()
        {
            InitializeComponent();
            //calendar.MaximumViewDays = 21;
        }


        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            CalendarItem calendarItem = e.Item;
            calendarItem.Text = "You just double clicked me!\nLocation";
            
            


        }

        private void ShowDayView()
        {
            calendar.SetViewRange(DateTime.Today, DateTime.Today);
        }

        private void ShowWeekView()
        {
            DateTime today = DateTime.Today;
            DateTime oneWeekAhead = today.AddDays(6);

           calendar.SetViewRange(today, oneWeekAhead);
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
    }
}
