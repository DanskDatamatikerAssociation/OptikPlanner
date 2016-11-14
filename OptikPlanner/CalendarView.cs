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
    public partial class CalendarView : Form
    {
        public CalendarView()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendarItem calendarItem = new CalendarItem(calendar1, DateTime.Now, DateTime.Now.AddMinutes(10.0),
                "TestItem");
            calendar1.Items.Add(calendarItem);
            
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            CalendarItem calendarItem = e.Item;
            calendarItem.Text = "You just double clicked me!\nLocation";
            
            


        }

        private void CalendarView_Load(object sender, EventArgs e)
        {

        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void monthView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void monthView3_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
