using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Controller;
using OptikPlanner.Misc;

namespace OptikPlanner.View
{
    public partial class StatisticsView : Form
    {
        StatisticsViewController statisticController = new StatisticsViewController();
       


        public StatisticsView()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMM/yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Value = DateTime.Today;
            

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CancelAppointmentController cancelController = new CancelAppointmentController();

            if (comboBox1.SelectedIndex == 0)
            {
                Logger.GetAllLogs();
                listView1.Columns.Clear();
                listView1.Items.Clear();
                listView1.Columns.Add("Grund", 150);
                listView1.Columns.Add("Antal aflysninger", 100);
                listView1.Items.Add("Kunden ikke mødte op.");
                listView1.Items.Add("Kunden har aflyst telefonisk");
                listView1.Items.Add("der har været Andet i vejen.");
                listView1.Items[0].SubItems.Add(cancelController.noShowList.Count.ToString());
                listView1.Items[1].SubItems.Add(cancelController.cancelPhoneList.Count.ToString());
                listView1.Items[2].SubItems.Add(cancelController.cancelElseList.Count.ToString());
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
                listView1.Columns.Add("Mødte ikke op", 100);
                listView1.Columns.Add("Opkald", 100);

            }

        }

    }
}
