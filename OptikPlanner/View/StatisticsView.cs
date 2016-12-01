using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Controller;
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    public partial class StatisticsView : Form
    {
        private int totalMinutes = 0;
        private int totalAvailibity = new int();
        private int availibilityLeft = new int();
        private List<USERS> employees = new List<USERS>();
        private StatisticsViewController controller = new StatisticsViewController(); 
        private List<APTDETAILS> appointments = new List<APTDETAILS>(); 
        private int totalHours = 0;

        public StatisticsView()
        {
            InitializeComponent();
  
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.ShowUpDown = true;
            //CreateAppointments();
            GetUserAvailability();
            
        }

        //public void CreateAppointments()
        //{
        //    employees = controller.GetUser();
        //    foreach (var user in employees)
        //    {
        //        appointments = controller.GetUserAppointments(user);
        //    }
            

        //    foreach (APTDETAILS e in appointments)
        //    {
        //        DateTime timeTo = DateTime.Parse(e.APD_TIMETO);
        //        DateTime timeFrom = DateTime.Parse(e.APD_TIMEFROM);

        //        TimeSpan totalTime = timeTo.Subtract(timeFrom);

        //        totalMinutes = (int)totalTime.TotalMinutes;
        //    }
        //}

        public void GetUserAvailability()
        {
            totalMinutes = new int();
            totalHours = new int();
            totalAvailibity = 142;
            employees = controller.GetUser();
            foreach (var user in employees)
            {

                appointments = controller.GetUserAppointments(user);

                ListViewItem item = new ListViewItem();
                item.Text = "";
                item.SubItems.Add("");
                item.SubItems.Add("");

                listView1.Items.Add(item);


                listView1.Items[0].SubItems[0].Text = user.US_USERNAME;

                foreach (var app in appointments)
                {
                    DateTime timeTo = DateTime.Parse(app.APD_TIMETO);
                    DateTime timeFrom = DateTime.Parse(app.APD_TIMEFROM);

                    TimeSpan totalTime = timeTo.Subtract(timeFrom);

                    totalHours = (int) totalTime.TotalMinutes%60;
                    availibilityLeft = totalAvailibity - totalHours;

                   
                    listView1.Items[1].SubItems[2].Text = totalAvailibity.ToString();
                    listView1.Items[0].SubItems[1].Text = availibilityLeft.ToString();
                    
                }
                for (int i = 0; 1 < employees.Count; i++)
                {
                    var u = employees[i];
                    listView1.Items.Add(u.US_USERNAME);
                    listView1.Items[i].SubItems.Add(availibilityLeft.ToString());
                    listView1.Items[i].SubItems.Add(totalAvailibity.ToString());
                }

            }

        }


     

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Aflysninger", 155);
                listView1.Columns.Add("Mødte ikke op", 100);
                listView1.Columns.Add("Telefon", 100);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Lokale", 155);
                listView1.Columns.Add("Type", 100);
                listView1.Columns.Add("Tilgængelighed", 100);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Navn", 155);
                listView1.Columns.Add("Tilgængelighed", 100);
                listView1.Columns.Add("Totaltilgængelighed", 100);
                
            }

        }

    }
}
