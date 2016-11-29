using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;
using OptikPlanner.Misc;
using Calendar = System.Globalization.Calendar;

namespace OptikPlanner.View
{
    public partial class StatisticsView : Form, IStatisticsView
    {
        private  StatisticsViewController _controller;
        private bool clickedGraf = true;
        private bool clickedWeek = true;
        List<int> years = new List<int>();

        public void SetController(StatisticsViewController controller)
        {
            _controller = controller;
        }

        public StatisticsView()
        {
            InitializeComponent();
            Populate();
            _controller = new StatisticsViewController(this);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (chooseTypeCombo.SelectedIndex == 0)
            {
                VisningAflysninger();
            }

            if (chooseTypeCombo.SelectedIndex == 1)
            {
                VisningLokaler();
            }
            if (chooseTypeCombo.SelectedIndex == 2)
            {
                VisningMedarbejder();
            }

        }

        private void FillInRoomData()
        {
            chooseDataLabel.Text = "Vælg lokaler";
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Lokale", 80);
            listView1.Columns.Add("Type", 100);
            listView1.Columns.Add("Timer brugt", 100);
            listView1.Columns.Add("Tilgængelighed i timer", 120);
            var rooms = _controller.GetRooms();
            for (int i = 0; i < rooms.Count; i++)
            {
                var room = rooms[i];
                listView1.Items.Add(room.ERO_SHORTDESC);
                listView1.Items[i].SubItems.Add(room.ERO_SHORTDESC);
                listView1.Items[i].SubItems.Add(_controller.GetRoomUsageInHours(room).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetRoomAvailabilityInHours(room, 148).ToString());

            }
        }

        public void Populate()
        {
            chooseperiodLabel.Text = "måned";
            compareMonthLabel.Text = "måned";
            showMonthCombo.Text = null;
            compareMonthCombo.Text = null;
            showMonthCombo.Items.Clear();
            showYearCombo.Items.Clear();
            compareMonthCombo.Items.Clear();
            compareYearCombo.Items.Clear();

            showMonthCombo.Items.Add("Se år");
            showMonthCombo.Items.Add("Jan");
            showMonthCombo.Items.Add("Feb");
            showMonthCombo.Items.Add("Mar");
            showMonthCombo.Items.Add("Apr");
            showMonthCombo.Items.Add("Maj");
            showMonthCombo.Items.Add("Jun");
            showMonthCombo.Items.Add("Jul");
            showMonthCombo.Items.Add("Aug");
            showMonthCombo.Items.Add("Sep");
            showMonthCombo.Items.Add("Okt");
            showMonthCombo.Items.Add("Nov");
            showMonthCombo.Items.Add("Dec");

            compareMonthCombo.Items.Add("Se år");
            compareMonthCombo.Items.Add("Jan");
            compareMonthCombo.Items.Add("Feb");
            compareMonthCombo.Items.Add("Mar");
            compareMonthCombo.Items.Add("Apr");
            compareMonthCombo.Items.Add("Maj");
            compareMonthCombo.Items.Add("Jun");
            compareMonthCombo.Items.Add("Jul");
            compareMonthCombo.Items.Add("Aug");
            compareMonthCombo.Items.Add("Sep");
            compareMonthCombo.Items.Add("Okt");
            compareMonthCombo.Items.Add("Nov");
            compareMonthCombo.Items.Add("Dec");
            for (int i = 1989; i <= DateTime.Now.Year; i++)
            {
                years.Add(i);
            }
            years.Reverse();
            foreach (var s in years)
            {
                showYearCombo.Items.Add(s.ToString());
                compareYearCombo.Items.Add(s.ToString());
            }
        }

        private void chooseViewButton_Click(object sender, EventArgs e)
        {
            if (clickedGraf)
                GraficalButtonClick();
            else
                NumericButtonClick();

            clickedGraf = !clickedGraf;
        }

        //smid i controller
        public void GetCancellations()
        {
            //var test == hent log

            //foreach linebreak in test smid i liste


            //smid i view
            //foreach liste item som indeholder dato 10-12-2016 12 fremvis i listview hvis monthpicker1 == december
        }

        public void VisningAflysninger()
        {
            chooseDataLabel.Text = "Vælg aflysninger";
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
        public void VisningLokaler()
        {
            FillInRoomData();

            //if (showMonthCombo.SelectedItem.ToString() == "Jan")
            //{
            //    foreach (var s in _controller.GetAppointments())
            //    {
            //        if (s.APD_DATE.Value.Month == 1)
            //        {
            //            listView1.Items[0].SubItems.Add(s.APD_DESCRIPTION.ToString());
            //        }
            //    }

            //}
        }
        public void VisningMedarbejder()
        {
            chooseDataLabel.Text = "Vælg medarbejdere";
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Navn", 155);
            listView1.Columns.Add("Mødte ikke op", 100);
            listView1.Columns.Add("Opkald", 100);
        }

        private void GraficalButtonClick()
        {
            chooseViewButton.Text = "Tal baseret";
            listView1.Hide();
           // indsæt fremvisning af Danny's diagrammer
            
        }

        private void NumericButtonClick()
        {
            chooseViewButton.Text = "Grafisk";
            // hide fremvisning af danny's diagrammer her

            listView1.Show();
            
        }
    }
}
