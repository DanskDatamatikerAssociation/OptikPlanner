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
    public partial class StatisticsView : Form, IStatisticsView
    {
        private StatisticsViewController _controller;

        public void SetController(StatisticsViewController controller)
        {
            _controller = controller;
        }

        public StatisticsView()
        {
            InitializeComponent();

            _controller = new StatisticsViewController(this);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMM/yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Value = DateTime.Today;
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                listView1.Columns.Clear();
                listView1.Items.Clear();
                listView1.Columns.Add("Grund", 150);
                listView1.Columns.Add("Antal aflysninger", 100);
                listView1.Items.Add("Kunden ikke mødte op.");
                listView1.Items.Add("Kunden har aflyst telefonisk");
                listView1.Items.Add("der har været Andet i vejen.");
                listView1.Items[0].SubItems.Add(CancelAppointmentController.noShowList.Count.ToString());
                listView1.Items[1].SubItems.Add(CancelAppointmentController.cancelPhoneList.Count.ToString());
                listView1.Items[2].SubItems.Add(CancelAppointmentController.cancelElseList.Count.ToString());
            }

            if (comboBox1.SelectedIndex == 1)
            {
                
                FillInRoomData();

            }
            if (comboBox1.SelectedIndex == 2)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Navn", 155);
                listView1.Columns.Add("Mødte ikke op", 100);
                listView1.Columns.Add("Opkald", 100);

            }

        }

        private void FillInRoomData()
        {
            listView1.Columns.Clear();

            listView1.Columns.Add("Lokale", 80);
            listView1.Columns.Add("Type", 100);
            listView1.Columns.Add("Timer brugt", 100);
            listView1.Columns.Add("Tilgængelighed i timer", 120);
            //var roomColumnItems = listView1.Items[0];

            var rooms = _controller.GetRooms();
            for(int i=0; i<rooms.Count; i++)
            {
                var room = rooms[i];
                listView1.Items.Add(room.ERO_SHORTDESC);
                listView1.Items[i].SubItems.Add(room.ERO_SHORTDESC);
                listView1.Items[i].SubItems.Add(_controller.GetRoomUsageInHours(room).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetRoomAvailabilityInHours(room, 148).ToString());

            }
            
            
        }


    }
}
