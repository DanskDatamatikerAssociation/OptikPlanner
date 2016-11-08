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

namespace OptikPlanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendarItem calendarItem = new CalendarItem(calendar1, DateTime.Now, DateTime.Now.AddMinutes(10.0),
                "TestItem");
            calendar1.Items.Add(calendarItem);
            //hejehj
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            CalendarItem calendarItem = e.Item;
            calendarItem.Text = "You just double clicked me!";
            
            //Danny lugter lidt af egerntisserier

            //det løgn det gør han slet ikk heeh
        }
    }
}
