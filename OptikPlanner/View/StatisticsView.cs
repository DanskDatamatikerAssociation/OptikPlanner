using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

            


            SetupRoomPieChart();






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

        private void SetupRoomPieChart()
        {
            Series series1 = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Pie
            };

            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.Titles.Add("Lokaletilgængelighed i timer og %");

            series1.SetCustomProperty("PieLabelStyle", "Outside");
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            chart1.ChartAreas[0].Position = new ElementPosition(-10, 10, 110, 110);


            chart1.Series.Add(series1);
  
            //Generel tilgængelighed
            var p1 = series1.Points.Add(148);
            p1.LegendText = "Tilgængelighed";
            var p1Value = p1.YValues[0];
            var p1valuePercentage = _controller.GetValueAsPercentage(p1Value, p1.YValues[0]);
   
            

            var rooms = _controller.GetRooms();
            foreach (var r in rooms)
            {
               var roomPiece = series1.Points.Add(_controller.GetRoomUsageInHours(r));
                roomPiece.LegendText = r.ERO_SHORTDESC;
                var value = roomPiece.YValues[0];
                var valuePercentage = _controller.GetValueAsPercentage(value, p1.YValues[0]);
                roomPiece.Label = $"{value} ({valuePercentage})";
            }




        }


    }
}
