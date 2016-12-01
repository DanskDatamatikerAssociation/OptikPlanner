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
using System.Windows.Forms.DataVisualization.Charting;
using OptikPlanner.Controller;
using OptikPlanner.Misc;
using Calendar = System.Globalization.Calendar;
using System.IO;

namespace OptikPlanner.View
{
    public partial class StatisticsView : Form, IStatisticsView
    {
        private StatisticsViewController _controller;
        private bool clickedGraf = true;
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
                if (!clickedGraf) SetupLoggingBarChart();
                FillInCancellationData();
            }

            if (chooseTypeCombo.SelectedIndex == 1)
            {
                if (!clickedGraf) SetupRoomPieChart();
                FillInRoomData();
            }
            if (chooseTypeCombo.SelectedIndex == 2)
            {
                if(!clickedGraf) SetUpEmployeePieChart();
                FillInEmployeeData();
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

        private void FillInEmployeeData()
        {
            chooseDataLabel.Text = "Vælg medarbejder";
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Navn", 200);
            listView1.Columns.Add("Timer brugt", 80);
            listView1.Columns.Add("Tilgængelighed i timer", 120);

            var users = _controller.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                listView1.Items.Add(user.US_USERNAME);
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeUsageInHours(user).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeAvailabilityInHours(user, 148).ToString());

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
        public void FillInCancellationData()
        {

            chooseDataLabel.Text = "Vælg aflysninger";
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Grund", 150);
            listView1.Columns.Add("aflysninger i ", 100);
            listView1.Columns.Add("aflysninger i ", 120);
            listView1.Items.Add("Kunden ikke mødte op.");
            listView1.Items.Add("Kunden har aflyst telefonisk");
            listView1.Items.Add("der har været Andet i vejen.");
            listView1.Items[0].SubItems.Add(CancelAppointmentController.noShowList.Count.ToString());
            listView1.Items[1].SubItems.Add(CancelAppointmentController.cancelPhoneList.Count.ToString());
            listView1.Items[2].SubItems.Add(CancelAppointmentController.cancelElseList.Count.ToString());
        }



        private void GraficalButtonClick()
        {
            chooseViewButton.Text = "Talbaseret";
            listView1.Hide();

            if (clickedGraf)
            {
                switch (chooseTypeCombo.Text)
                {
                    case "Lokaler":
                        SetupRoomPieChart();
                        break;
                    case "Aflysninger":
                        SetupLoggingBarChart();
                        break;
                    case "Medarbejdere":
                        SetUpEmployeePieChart();
                        break;
                    default:
                        ClearChart();
                        break;
                }
            }

            chart1.Show();

            // indsæt fremvisning af Danny's diagrammer

        }

        private void NumericButtonClick()
        {
            chooseViewButton.Text = "Grafisk";
            // hide fremvisning af danny's diagrammer her        

            chart1.Hide();
            listView1.Show();

        }

        private void showMonthCombo_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (chooseTypeCombo.Text)
            {
                case "Aflysninger":
                    FilterCancellations();
                    break;
                case "Lokaler":
                    FilterRoomData();
                    break;
                case "Medarbejdere":
                    FilterEmployeeData();
                    break;

            }





        }

        private void compareMonthCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (chooseTypeCombo.Text)
            {
                case "Aflysninger":
                    CompareCancellations();
                    break;
                case "Lokaler":

                    break;

            }

        }

        private void FilterRoomData()
        {
            int chosenMonth = showMonthCombo.SelectedIndex;

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
                listView1.Items[i].SubItems.Add(_controller.GetRoomUsageInHours(room, chosenMonth).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetRoomAvailabilityInHours(room, 148, chosenMonth).ToString());

            }
        }

        private void FilterEmployeeData()
        {
            int chosenMonth = showMonthCombo.SelectedIndex;

            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Navn", 200);
            listView1.Columns.Add("Timer brugt", 80);
            listView1.Columns.Add("Tilgængelighed i timer", 120);

            var users = _controller.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                listView1.Items.Add(user.US_USERNAME);
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeUsageInHours(user, chosenMonth).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeAvailabilityInHours(user, 148, chosenMonth).ToString());

            }
        }

        private void CompareCancellations()
        {
            IEnumerable<string> noShowList;
            IEnumerable<string> cancelPhoneList;
            IEnumerable<string> cancelElseList;
            int monthsNumber = compareMonthCombo.SelectedIndex;
            string compareName = compareMonthCombo.SelectedItem.ToString();
            listView1.Columns[2].Text = "aflysninger i " + compareName;

            CompareClearList();
            noShowList = from s in CancelAppointmentController.noShowList where (s.Substring(3, 2).Equals(monthsNumber.ToString())) select s;
            listView1.Items[0].SubItems.Add(noShowList.Count().ToString());
            cancelPhoneList = from s in CancelAppointmentController.cancelPhoneList where (s.Substring(3, 2).Equals(monthsNumber.ToString())) select s;
            listView1.Items[1].SubItems.Add(cancelPhoneList.Count().ToString());
            cancelElseList = from s in CancelAppointmentController.cancelElseList where (s.Substring(3, 2).Equals(monthsNumber.ToString())) select s;
            listView1.Items[2].SubItems.Add(cancelElseList.Count().ToString());
        }

        private void FilterCancellations()
        {
            IEnumerable<string> noShowList;
            IEnumerable<string> cancelPhoneList;
            IEnumerable<string> cancelElseList;
            int monthsNumber = showMonthCombo.SelectedIndex;
            string monthsName = showMonthCombo.SelectedItem.ToString();
            listView1.Columns[1].Text = "aflysninger i " + monthsName;

            MonthClearList();
            noShowList = from s in CancelAppointmentController.noShowList where (s.Substring(3, 2).Equals(monthsNumber.ToString())) select s;
            listView1.Items[0].SubItems.Add(noShowList.Count().ToString());
            cancelPhoneList = from s in CancelAppointmentController.cancelPhoneList where (s.Substring(3, 2).Equals(monthsNumber.ToString())) select s;
            listView1.Items[1].SubItems.Add(cancelPhoneList.Count().ToString());
            cancelElseList = from s in CancelAppointmentController.cancelElseList where (s.Substring(3, 2).Equals(monthsNumber.ToString())) select s;
            listView1.Items[2].SubItems.Add(cancelElseList.Count().ToString());
        }

        public void MonthClearList()
        {
            while (listView1.Items[0].SubItems.Count > 1 && listView1.Items[1].SubItems.Count > 1 && listView1.Items[2].SubItems.Count > 1)
            {
                listView1.Items[0].SubItems.RemoveAt(1);
                listView1.Items[1].SubItems.RemoveAt(1);
                listView1.Items[2].SubItems.RemoveAt(1);
            }

        }
        public void CompareClearList()
        {
            while (listView1.Items[0].SubItems.Count > 2 && listView1.Items[1].SubItems.Count > 2 && listView1.Items[2].SubItems.Count > 2)
            {
                listView1.Items[0].SubItems.RemoveAt(2);
                listView1.Items[1].SubItems.RemoveAt(2);
                listView1.Items[2].SubItems.RemoveAt(2);
            }

        }

        private void SetupRoomPieChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ResetAutoValues();
            chart1.Palette = ChartColorPalette.None;


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

            chart1.ChartAreas[0].Position = new ElementPosition(-10, 10, 90, 90);


            chart1.Series.Add(series1);

            //Generel tilgængelighed
            var p1 = series1.Points.Add(148);
            p1.LegendText = "Tilgængelighed";
            var p1Value = p1.YValues[0];


            //Lokaler
            var rooms = _controller.GetRooms();
            foreach (var r in rooms)
            {
                var roomPiece = series1.Points.Add(_controller.GetRoomUsageInHours(r));
                roomPiece.LegendText = r.ERO_SHORTDESC;
                var value = roomPiece.YValues[0];
                var valuePercentage = _controller.GetValueAsPercentage(value, p1.YValues[0]);
                roomPiece.Label = $"{value} ({valuePercentage})";
            }

            chart1.Invalidate();
        }

        private void SetUpEmployeePieChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ResetAutoValues();
            chart1.Palette = ChartColorPalette.None;


            Series series1 = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };

            chart1.Palette = ChartColorPalette.Bright;

            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.Titles.Add("Lokaletilgængelighed i timer og %");

            series1.SetCustomProperty("PieLabelStyle", "Outside");
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            chart1.ChartAreas[0].Position = new ElementPosition(-10, 10, 90, 90);


            chart1.Series.Add(series1);

            //Generel tilgængelighed
            var p1 = series1.Points.Add(148);
            p1.LegendText = "Tilgængelighed";
            var p1Value = p1.YValues[0];


            //Medarbejdere
            var employees = _controller.GetUsers();
            foreach (var e in employees)
            {
                var userPiece = series1.Points.Add(_controller.GetEmployeeUsageInHours(e));
                userPiece.LegendText = e.US_USERNAME;
                var value = userPiece.YValues[0];
                var valuePercentage = _controller.GetValueAsPercentage(value, p1.YValues[0]);
                userPiece.Label = $"{value} ({valuePercentage})";
            }

            chart1.Invalidate();
        }

        private void SetupLoggingBarChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ResetAutoValues();

            Series series2 = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Column
            };

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart1.ChartAreas[0].Position.Auto = true;

            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart1.Titles.Add("Aflysninger");

            chart1.Series.Add(series2);

            //var noShowBar = series2.Points.Add(CancelAppointmentController.noShowList.Count);
            var noShowBar = series2.Points.Add(CancelAppointmentController.noShowList.Count);
            noShowBar.AxisLabel = "Ikke mødt op";

            var phoneCancelBar = series2.Points.Add(CancelAppointmentController.cancelPhoneList.Count);
            phoneCancelBar.AxisLabel = "Afylste telefonisk";

            var otherReasonBar = series2.Points.Add(CancelAppointmentController.cancelElseList.Count);
            otherReasonBar.AxisLabel = "Anden årsag";

            chart1.Invalidate();
        }

        private void ClearChart()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
        }
    }
}
