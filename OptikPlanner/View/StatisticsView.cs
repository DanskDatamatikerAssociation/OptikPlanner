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
using System.Net.Sockets;
using OptikPlanner.Model;

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
            StartPosition = FormStartPosition.CenterScreen;
            Populate();
            _controller = new StatisticsViewController(this);

            showMonthCombo.SelectedIndex = DateTime.Now.Month;
            showYearCombo.Text = DateTime.Now.Year.ToString();
            chooseTypeCombo.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (chooseTypeCombo.Text)
            {
                case "Aftaler":
                    if (!clickedGraf) SetupAppointmentPieChart();
                    FillInAppointmentData();
                    EnableControls(false);
                    break;
                case "Aflysninger":
                    if (!clickedGraf) SetupLoggingBarChart();
                    FillInCancellationData();
                    EnableControls(false);
                    break;
                case "Lokaler":
                    if (!clickedGraf)
                    {
                        FillRoomFilterBox();
                        SetupRoomPieChart();
                    }
                    FillInRoomData();
                    FillRoomFilterBox();
                    CheckAllBoxes(true);
                    EnableControls(true);
                    break;
                case "Medarbejdere":
                    if (!clickedGraf)
                    {
                        FillEmployeeFilterBox();
                        SetUpEmployeePieChart();
                    }
                    FillInEmployeeData();
                    FillEmployeeFilterBox();
                    CheckAllBoxes(true);
                    EnableControls(true);
                    break;

            }

        }

        private void EnableControls(bool enable)
        {
            showAllCheckBox.Enabled = enable;
            filterListBox.Enabled = enable;
            chooseDataLabel.Enabled = enable;
        }

        private void FillRoomFilterBox()
        {
            var rooms = _controller.GetRooms();
            filterListBox.Items.Clear();
            foreach (var r in rooms) filterListBox.Items.Add(r);

        }

        private void FillEmployeeFilterBox()
        {
            var employees = _controller.GetUsers();
            filterListBox.Items.Clear();
            foreach (var e in employees) filterListBox.Items.Add(e);
        }

        private void FillInAppointmentData()
        {
            int currentMonth = showMonthCombo.SelectedIndex;
            int currentYear = int.Parse(showYearCombo.Text);

            var allAppointments = _controller.GetAppointments();
            var appointments = _controller.GetAppointments(currentMonth, currentYear);

            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Antal i alt", 80);

            listView1.Items.Add(appointments.Count.ToString());

            foreach (var a in allAppointments)
            {
                string type = _controller.GetAppointmentType(a);
                if (!ListViewContainsHeader(type))
                {
                    var column = listView1.Columns.Add(type, type, 120);
                    ListViewItem.ListViewSubItem value = new ListViewItem.ListViewSubItem();
                    listView1.Items[0].SubItems.Add(value);
                    List<APTDETAILS> appointmentsWithTag = new List<APTDETAILS>();
                    value.Tag = appointmentsWithTag;
                    column.Tag = value;
                }
            }

            foreach (var a in appointments)
            {
                string type = _controller.GetAppointmentType(a);


                //if (!ListViewContainsHeader(type))
                //{
                //    var column = listView1.Columns.Add(type, type, 120);
                //    ListViewItem.ListViewSubItem value = new ListViewItem.ListViewSubItem();
                //    listView1.Items[0].SubItems.Add(value);
                //    List<APTDETAILS> appointmentsWithTag = new List<APTDETAILS>();
                //    value.Tag = appointmentsWithTag;
                //    column.Tag = value;
                //}

                var matchingColumn = listView1.Columns[type];
                if (matchingColumn.Text.Equals(type))
                {
                    var subItem = (ListViewItem.ListViewSubItem)matchingColumn.Tag;
                    var value = (List<APTDETAILS>)subItem.Tag;
                    value.Add(a);
                }

                filterListBox.Items.Clear();


            }



            for (int i = 1; i < listView1.Columns.Count; i++)
            {
                ColumnHeader c = listView1.Columns[i];
                var subItem = (ListViewItem.ListViewSubItem)c.Tag;
                var value = (List<APTDETAILS>)subItem.Tag;
                subItem.Text = value.Count.ToString();
            }


        }

        private void FillInAppointmentData(int compareMonth, int compareYear)
        {
            int currentMonth = compareMonth;
            int currentYear = compareYear;

            var appointments = _controller.GetAppointments(currentMonth, currentYear);

            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Antal i alt", 80);

            listView1.Items.Add(appointments.Count.ToString());

            foreach (var a in appointments)
            {
                string type = _controller.GetAppointmentType(a);


                if (!ListViewContainsHeader(type))
                {
                    var column = listView1.Columns.Add(type, type, 120);
                    ListViewItem.ListViewSubItem value = new ListViewItem.ListViewSubItem();
                    listView1.Items[0].SubItems.Add(value);
                    List<APTDETAILS> appointmentsWithTag = new List<APTDETAILS>();
                    value.Tag = appointmentsWithTag;
                    column.Tag = value;
                }

                var matchingColumn = listView1.Columns[type];
                if (matchingColumn.Text.Equals(type))
                {
                    var subItem = (ListViewItem.ListViewSubItem)matchingColumn.Tag;
                    var value = (List<APTDETAILS>)subItem.Tag;
                    value.Add(a);
                }

                filterListBox.Items.Clear();


            }



            for (int i = 1; i < listView1.Columns.Count; i++)
            {
                ColumnHeader c = listView1.Columns[i];
                var subItem = (ListViewItem.ListViewSubItem)c.Tag;
                var value = (List<APTDETAILS>)subItem.Tag;
                subItem.Text = value.Count.ToString();
            }


        }

        private bool ListViewContainsHeader(string header)
        {
            foreach (ColumnHeader c in listView1.Columns)
            {
                if (c.Text.Equals(header)) return true;
            }

            return false;
        }



        private void FillInRoomData()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            chooseDataLabel.Text = "Vælg lokale(r)";
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
                listView1.Items[i].SubItems.Add(_controller.GetRoomUsageInHours(room, currentMonth, currentYear).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetRoomAvailabilityInHours(room, 148, currentMonth, currentYear).ToString());

            }



        }


        private void FillInEmployeeData()
        {
            chooseDataLabel.Text = "Vælg medarbejder(e)";
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

        public void FillInCancellationData()
        {

            chooseDataLabel.Text = "Vælg aflysninger";
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Grund", 150);
            listView1.Columns.Add("aflysninger i ", 150);
            listView1.Items.Add("Kunden ikke mødte op.");
            listView1.Items.Add("Kunden har aflyst telefonisk");
            listView1.Items.Add("der har været Andet i vejen.");
            listView1.Items[0].SubItems.Add(CancelAppointmentController.noShowList.Count.ToString());
            listView1.Items[1].SubItems.Add(CancelAppointmentController.cancelPhoneList.Count.ToString());
            listView1.Items[2].SubItems.Add(CancelAppointmentController.cancelElseList.Count.ToString());

            filterListBox.Items.Clear();
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




        private void GraficalButtonClick()
        {
            chooseViewButton.Text = "Talbaseret";
            listView1.Hide();

            if (clickedGraf)
            {
                switch (chooseTypeCombo.Text)
                {
                    case "Aftaler":
                        SetupAppointmentPieChart();
                        break;
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
                        SetupLoggingComparisonChart();
                        //ClearChart();
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
                case "Aftaler":
                    if (!clickedGraf) SetupAppointmentPieChart();
                    FillInAppointmentData();
                    break;
                case "Aflysninger":
                    if (!clickedGraf) SetupLoggingBarChart();
                    else FilterCancellations();
                    break;
                case "Lokaler":
                    if (!clickedGraf) SetupRoomPieChart();
                    else FilterRoomData(GetCheckedRooms());
                    break;
                case "Medarbejdere":
                    if (!clickedGraf) SetUpEmployeePieChart();
                    else FilterEmployeeData(GetCheckedEmployees());
                    break;

            }
        }

        private void compareMonthCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchButton.Enabled = true;
            compareYearCombo.Text = DateTime.Now.Year.ToString();


        }

        private void FilterRoomData()
        {

            int chosenMonth = showMonthCombo.SelectedIndex;
            int chosenYear = DateTime.Now.Year;

            try
            {
                chosenYear = int.Parse(showYearCombo.Text);

            }
            catch (FormatException ex)
            {

            }



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
                listView1.Items[i].SubItems.Add(_controller.GetRoomUsageInHours(room, chosenMonth, chosenYear).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetRoomAvailabilityInHours(room, 148, chosenMonth, chosenYear).ToString());

            }
        }

        private void FilterRoomData(List<EYEEXAMROOMS> roomsToFillIn)
        {

            int chosenMonth = showMonthCombo.SelectedIndex;
            int chosenYear = DateTime.Now.Year;

            try
            {
                chosenYear = int.Parse(showYearCombo.Text);

            }
            catch (FormatException ex)
            {

            }



            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Lokale", 80);
            listView1.Columns.Add("Type", 100);
            listView1.Columns.Add("Timer brugt", 100);
            listView1.Columns.Add("Tilgængelighed i timer", 120);

            for (int i = 0; i < roomsToFillIn.Count; i++)
            {
                var room = roomsToFillIn[i];
                listView1.Items.Add(room.ERO_SHORTDESC);
                listView1.Items[i].SubItems.Add(room.ERO_SHORTDESC);
                listView1.Items[i].SubItems.Add(_controller.GetRoomUsageInHours(room, chosenMonth, chosenYear).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetRoomAvailabilityInHours(room, 148, chosenMonth, chosenYear).ToString());

            }
        }

        private void FilterEmployeeData()
        {
            int chosenMonth = showMonthCombo.SelectedIndex;
            int chosenYear = DateTime.Now.Year;

            try
            {
                chosenYear = int.Parse(showYearCombo.Text);

            }
            catch (FormatException ex)
            {

            }

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
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeUsageInHours(user, chosenMonth, chosenYear).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeAvailabilityInHours(user, 148, chosenMonth, chosenYear).ToString());

            }
        }

        private void FilterEmployeeData(List<USERS> employeesToFillIn)
        {
            int chosenMonth = showMonthCombo.SelectedIndex;
            int chosenYear = DateTime.Now.Year;

            try
            {
                chosenYear = int.Parse(showYearCombo.Text);

            }
            catch (FormatException ex)
            {

            }

            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Navn", 200);
            listView1.Columns.Add("Timer brugt", 80);
            listView1.Columns.Add("Tilgængelighed i timer", 120);


            for (int i = 0; i < employeesToFillIn.Count; i++)
            {
                var user = employeesToFillIn[i];
                listView1.Items.Add(user.US_USERNAME);
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeUsageInHours(user, chosenMonth, chosenYear).ToString());
                listView1.Items[i].SubItems.Add(_controller.GetEmployeeAvailabilityInHours(user, 148, chosenMonth, chosenYear).ToString());

            }
        }

        private void FilterCancellations()
        {

            int monthsNumber = showMonthCombo.SelectedIndex;
            string monthsName = showMonthCombo.SelectedItem.ToString();
            int yearsNumber = DateTime.Now.Year;
            int yearsName = DateTime.Now.Year;

            try
            {
                yearsNumber = int.Parse(showYearCombo.Text);
            }
            catch (Exception)
            {
            }

            listView1.Columns[1].Text = "Aflysninger i " + monthsName + " " + yearsNumber;

            MonthClearList();
            var noShowList = _controller.GetNoShowCancellations(monthsNumber, yearsNumber);
            listView1.Items[0].SubItems.Add(noShowList.Count().ToString());

            var cancelPhoneList = _controller.GetPhoneCancellations(monthsNumber, yearsNumber);
            listView1.Items[1].SubItems.Add(cancelPhoneList.Count().ToString());

            var cancelElseList = _controller.GetOtherReasonCancellations(monthsNumber, yearsNumber);
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

        private void SetupAppointmentPieChart()
        {
            FillInAppointmentData(); //Otherwise we risk that the list is null when trying to show the chart. 
            SetDefaultPieChartSettings();

            Series series1 = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.BlueViolet,
                ChartType = SeriesChartType.Pie
            };

            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.Titles.Add("Typer aftaler");

            //series1.SetCustomProperty("PieLabelStyle", "Outside");
            chart1.Palette = ChartColorPalette.Pastel;


            chart1.Series.Add(series1);

            for (int i = 1; i < listView1.Columns.Count; i++)
            {
                ColumnHeader c = listView1.Columns[i];
                var subItem = (ListViewItem.ListViewSubItem)c.Tag;
                var value = (List<APTDETAILS>)subItem.Tag;
                subItem.Text = value.Count.ToString();

                var piePiece = series1.Points.Add(value.Count);
                piePiece.LegendText = c.Text;

                var valueAsPercentage = _controller.GetValueAsPercentage(value.Count, int.Parse(listView1.Items[0].Text));
                piePiece.Label = $"{value.Count} ({valueAsPercentage})";

            }

            chart1.Invalidate();


        }

        private void SetupRoomPieChart()
        {
            SetDefaultPieChartSettings();

            int chosenMonth = DateTime.Now.Month;
            int chosenYear = DateTime.Now.Year;


            try
            {
                chosenMonth = showMonthCombo.SelectedIndex;
                chosenYear = int.Parse(showYearCombo.Text);

            }
            catch (FormatException ex)
            {

            }

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

            chart1.Series.Add(series1);

            //Generel tilgængelighed
            var p1 = series1.Points.Add(148);
            p1.LegendText = "Tilgængelighed";
            var p1Value = p1.YValues[0];


            //Lokaler
            //var rooms = _controller.GetRooms();
            var checkedRooms = GetCheckedRooms();
            foreach (var r in checkedRooms)
            {
                var roomPiece = series1.Points.Add(_controller.GetRoomUsageInHours(r, chosenMonth, chosenYear));
                roomPiece.LegendText = r.ERO_SHORTDESC;
                var value = roomPiece.YValues[0];
                var valuePercentage = _controller.GetValueAsPercentage(value, p1.YValues[0]);
                roomPiece.Label = $"{value} ({valuePercentage})";
            }

            chart1.Invalidate();
        }

        private void SetUpEmployeePieChart()
        {
            SetDefaultPieChartSettings();

            int chosenMonth = DateTime.Now.Month;
            int chosenYear = DateTime.Now.Year;


            try
            {
                chosenMonth = showMonthCombo.SelectedIndex;
                chosenYear = int.Parse(showYearCombo.Text);

            }
            catch (FormatException ex)
            {

            }

            Series series1 = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };

            series1.SetCustomProperty("PieLabelStyle", "Outside");
            chart1.Palette = ChartColorPalette.Bright;

            chart1.Titles.Add("Lokaletilgængelighed i timer og %");




            chart1.Series.Add(series1);

            //Generel tilgængelighed
            var p1 = series1.Points.Add(148);
            p1.LegendText = "Tilgængelighed";
            var p1Value = p1.YValues[0];


            //Medarbejdere
            //var employees = _controller.GetUsers();
            var checkedEmployees = GetCheckedEmployees();
            foreach (var e in checkedEmployees)
            {
                var userPiece = series1.Points.Add(_controller.GetEmployeeUsageInHours(e, chosenMonth, chosenYear));
                userPiece.LegendText = e.US_USERNAME;
                var value = userPiece.YValues[0];
                var valuePercentage = _controller.GetValueAsPercentage(value, p1.YValues[0]);
                userPiece.Label = $"{value} ({valuePercentage})";
            }

            chart1.Invalidate();
        }

        private void SetupLoggingBarChart()
        {
            SetDefaultBarCharSettings();

            Series series2 = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Column
            };


            chart1.Titles.Add("Aflysninger");
            chart1.Series.Add(series2);

            var noShowBar = series2.Points.Add(_controller.GetNoShowCancellations(showMonthCombo.SelectedIndex).Count);
            noShowBar.AxisLabel = "Ikke mødt op";
            noShowBar.Label = noShowBar.YValues[0].ToString();

            var phoneCancelBar = series2.Points.Add(_controller.GetPhoneCancellations(showMonthCombo.SelectedIndex).Count);
            phoneCancelBar.AxisLabel = "Afylste telefonisk";
            phoneCancelBar.Label = phoneCancelBar.YValues[0].ToString();

            var otherReasonBar = series2.Points.Add(_controller.GetOtherReasonCancellations(showMonthCombo.SelectedIndex).Count);
            otherReasonBar.AxisLabel = "Anden årsag";
            otherReasonBar.Label = otherReasonBar.YValues[0].ToString();

            chart1.Invalidate();
        }

        private void SetupLoggingComparisonChart()
        {
            SetDefaultBarCharSettings();

            Series series = new Series
            {
                Name = "series",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Blue,

                ChartType = SeriesChartType.Column
            };

            Series comparisonSeries = new Series
            {
                Name = "comparsionSeries",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Crimson,
                ChartType = SeriesChartType.Column
            };


            chart1.Titles.Add($"Sammenligning mellem {showMonthCombo.Text} {showYearCombo.Text} og {compareMonthCombo.Text} {compareYearCombo.Text}");
            chart1.ChartAreas[0].AxisY.Title = "Antal";

            series.LegendText = showMonthCombo.Text + " " + showYearCombo.Text;
            comparisonSeries.LegendText = compareMonthCombo.Text + " " + compareYearCombo.Text;

            chart1.Series.Add(series);
            chart1.Series.Add(comparisonSeries);

            var noShowBar = series.Points.Add(_controller.GetNoShowCancellations(showMonthCombo.SelectedIndex).Count);
            noShowBar.AxisLabel = "Ikke mødt op";
            noShowBar.Label = noShowBar.YValues[0].ToString();
            var noShowComparisonBar =
                comparisonSeries.Points.Add(_controller.GetNoShowCancellations(compareMonthCombo.SelectedIndex).Count);
            noShowComparisonBar.Label = noShowComparisonBar.YValues[0].ToString();

            var phoneCancelBar = series.Points.Add(_controller.GetPhoneCancellations(showMonthCombo.SelectedIndex).Count);
            phoneCancelBar.AxisLabel = "Afylste telefonisk";
            phoneCancelBar.Label = phoneCancelBar.YValues[0].ToString();
            var phoneCancelComparisonBar =
                comparisonSeries.Points.Add(_controller.GetPhoneCancellations(compareMonthCombo.SelectedIndex).Count);
            phoneCancelComparisonBar.Label = phoneCancelComparisonBar.YValues[0].ToString();

            var otherReasonBar = series.Points.Add(_controller.GetOtherReasonCancellations(showMonthCombo.SelectedIndex).Count);
            otherReasonBar.AxisLabel = "Anden årsag";
            otherReasonBar.Label = otherReasonBar.YValues[0].ToString();
            var otherReasonComparisonBar =
                comparisonSeries.Points.Add(
                    _controller.GetOtherReasonCancellations(compareMonthCombo.SelectedIndex).Count);
            otherReasonComparisonBar.Label = otherReasonComparisonBar.YValues[0].ToString();

            chart1.Invalidate();
        }

        private void SetupRoomComparisonChart()
        {
            SetDefaultBarCharSettings();

            int chosenMonth = DateTime.Now.Month;
            int chosenYear = DateTime.Now.Year;

            int compareMonth = DateTime.Now.Month;
            int compareYear = DateTime.Now.Year;

            try
            {

                chosenMonth = showMonthCombo.SelectedIndex;
                compareMonth = compareMonthCombo.SelectedIndex;

                chosenYear = int.Parse(showYearCombo.Text);
                compareYear = int.Parse(compareYearCombo.Text);

            }
            catch (FormatException ex) { }



            Series series = new Series
            {
                Name = "series",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Column
            };

            Series comparisonSeries = new Series
            {
                Name = "comparisonSeries",
                IsVisibleInLegend = true,
                Color = Color.OrangeRed,
                ChartType = SeriesChartType.Column

            };


            chart1.Titles.Add($"Sammenligning mellem {showMonthCombo.Text} {chosenYear}  og {compareMonthCombo.Text} {compareYear}.");
            chart1.ChartAreas[0].AxisY.Title = "Timer brugt";

            series.LegendText = showMonthCombo.Text;
            comparisonSeries.LegendText = compareMonthCombo.Text;

            chart1.Series.Add(series);
            chart1.Series.Add(comparisonSeries);


            //var rooms = _controller.GetRooms();
            var checkedRooms = GetCheckedRooms();

            for (int i = 0; i < checkedRooms.Count; i++)
            {
                var room = checkedRooms[i];
                var timeUsedBar =
                    series.Points.Add(_controller.GetRoomUsageInHours(room, chosenMonth, chosenYear));
                timeUsedBar.AxisLabel = room.ERO_SHORTDESC;
                timeUsedBar.Label = timeUsedBar.YValues[0].ToString();
                var timeUsedCompareBar =
                    comparisonSeries.Points.Add(_controller.GetRoomUsageInHours(room, compareMonth, compareYear));
                timeUsedCompareBar.Label = timeUsedCompareBar.YValues[0].ToString();
            }

            chart1.Invalidate();
        }

        private void SetupEmployeeComparisonChart()
        {
            SetDefaultBarCharSettings();

            int chosenMonth = DateTime.Now.Month;
            int chosenYear = DateTime.Now.Year;

            int compareMonth = DateTime.Now.Month;
            int compareYear = DateTime.Now.Year;

            try
            {

                chosenMonth = showMonthCombo.SelectedIndex;
                compareMonth = compareMonthCombo.SelectedIndex;

                chosenYear = int.Parse(showYearCombo.Text);
                compareYear = int.Parse(compareYearCombo.Text);

            }
            catch (FormatException ex) { }

            Series series = new Series
            {
                Name = "series",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Column
            };

            Series comparisonSeries = new Series
            {
                Name = "comparisonSeries",
                IsVisibleInLegend = true,
                Color = Color.Green,
                ChartType = SeriesChartType.Column

            };

            chart1.Titles.Add($"Sammenligning mellem {showMonthCombo.Text} {chosenYear} og {compareMonthCombo.Text} {compareYear}.");
            chart1.ChartAreas[0].AxisY.Title = "Timer brugt";

            series.LegendText = showMonthCombo.Text;
            comparisonSeries.LegendText = compareMonthCombo.Text;

            chart1.Series.Add(series);
            chart1.Series.Add(comparisonSeries);

            //var users = _controller.GetUsers();
            var checkedUsers = GetCheckedEmployees();

            for (int i = 0; i < checkedUsers.Count; i++)
            {
                var user = checkedUsers[i];
                var timeUsedBar =
                    series.Points.Add(_controller.GetEmployeeUsageInHours(user, chosenMonth, chosenYear));
                timeUsedBar.AxisLabel = user.US_USERNAME;
                timeUsedBar.Label = timeUsedBar.YValues[0].ToString();
                var timeUsedCompareBar =
                    comparisonSeries.Points.Add(_controller.GetEmployeeUsageInHours(user,
                        compareMonth, compareYear));
                timeUsedCompareBar.Label = timeUsedCompareBar.YValues[0].ToString();
            }
        }

        private void SetupAppointmentComparisonChart()
        {
            SetDefaultBarCharSettings();

            int chosenMonth = DateTime.Now.Month;
            int chosenYear = DateTime.Now.Year;

            int compareMonth = DateTime.Now.Month;
            int compareYear = DateTime.Now.Year;

            try
            {

                chosenMonth = showMonthCombo.SelectedIndex;
                compareMonth = compareMonthCombo.SelectedIndex;

                chosenYear = int.Parse(showYearCombo.Text);
                compareYear = int.Parse(compareYearCombo.Text);

            }
            catch (FormatException ex) { }

            Series series = new Series
            {
                Name = "series",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.Column
            };

            Series comparisonSeries = new Series
            {
                Name = "comparisonSeries",
                IsVisibleInLegend = true,
                Color = Color.Green,
                ChartType = SeriesChartType.Column

            };

            chart1.Titles.Add($"Sammenligning mellem {showMonthCombo.Text} {chosenYear} og {compareMonthCombo.Text} {compareYear}.");
            chart1.ChartAreas[0].AxisY.Title = "Antal aftaler af type";

            series.LegendText = showMonthCombo.Text;
            comparisonSeries.LegendText = compareMonthCombo.Text;

            chart1.Series.Add(series);
            chart1.Series.Add(comparisonSeries);

            int count = listView1.Columns.Count;
            for (int i = 1; i < count; i++)
            {
                FillInAppointmentData();

                ColumnHeader c = listView1.Columns[i];
                var subItem = (ListViewItem.ListViewSubItem)c.Tag;
                var value = (List<APTDETAILS>)subItem.Tag;
                subItem.Text = value.Count.ToString();

                var firstBar = series.Points.Add(value.Count);
                firstBar.LegendText = c.Text;
                firstBar.Label = value.Count.ToString();
                firstBar.AxisLabel = c.Text;

                FillInAppointmentData(compareMonth, compareYear);

                try
                {
                    c = listView1.Columns[i];
                    subItem = (ListViewItem.ListViewSubItem) c.Tag;
                    value = (List<APTDETAILS>) subItem.Tag;
                    subItem.Text = value.Count.ToString();

                    var compareBar = comparisonSeries.Points.Add(value.Count);
                    compareBar.LegendText = c.Text;
                    compareBar.Label = value.Count.ToString();
                    compareBar.AxisLabel = c.Text;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    var compareBar = comparisonSeries.Points.Add(0);
                    compareBar.LegendText = c.Text;
                    compareBar.Label = "0";
                    compareBar.AxisLabel = "0";
                }



                FillInAppointmentData();


            }





        }

        private void SetDefaultBarCharSettings()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ResetAutoValues();

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].Position.Auto = true;
            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
        }

        private void SetDefaultPieChartSettings()
        {
            chart1.ChartAreas[0].BackColor = Color.Transparent;


            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ResetAutoValues();
            chart1.Palette = ChartColorPalette.None;

            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            chart1.ChartAreas[0].Position = new ElementPosition(-10, 10, 90, 90);
        }

        private void showYearCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (chooseTypeCombo.Text)
            {
                case "Aftaler":
                    if (!clickedGraf) SetupAppointmentPieChart();
                    FillInAppointmentData();
                    break;
                case "Aflysninger":
                    if (!clickedGraf) SetupLoggingBarChart();
                    FilterCancellations();
                    break;
                case "Lokaler":
                    if (!clickedGraf) SetupRoomPieChart();
                    FilterRoomData();
                    break;
                case "Medarbejdere":
                    if (!clickedGraf) SetUpEmployeePieChart();
                    FilterEmployeeData();
                    break;

            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            chooseViewButton.Enabled = false;
            chooseTypeCombo.Enabled = false;
            GraficalButtonClick();

            switch (chooseTypeCombo.Text)
            {
                case "Aftaler":
                    SetupAppointmentComparisonChart();
                    break;
                case "Aflysninger":
                    SetupLoggingComparisonChart();
                    break;
                case "Lokaler":
                    SetupRoomComparisonChart();
                    break;
                case "Medarbejdere":
                    SetupEmployeeComparisonChart();
                    break;

            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            NumericButtonClick();
            chooseViewButton.Enabled = true;
            chooseTypeCombo.Enabled = true;
            compareMonthCombo.SelectedItem = null;
            compareYearCombo.SelectedItem = null;
            SearchButton.Enabled = false;

        }


        private void filterListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chooseTypeCombo.Text.Equals("Lokaler"))
            {
                var checkedRooms = GetCheckedRooms();

                if (e.NewValue == CheckState.Checked)
                {
                    var roomJustChecked = (EYEEXAMROOMS)filterListBox.Items[e.Index];
                    checkedRooms.Add(roomJustChecked);


                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    var roomJustUnchecked = (EYEEXAMROOMS)filterListBox.Items[e.Index];
                    checkedRooms.Remove(roomJustUnchecked);
                    showAllCheckBox.Checked = false;


                }

                var orderedList = from r in checkedRooms orderby r.ERO_STAMP select r;

                FilterRoomData(orderedList.ToList());
                if (!clickedGraf) this.BeginInvoke(new Action(SetupRoomPieChart));
            }
            if (chooseTypeCombo.Text.Equals("Medarbejdere"))
            {
                var checkedEmployees = GetCheckedEmployees();

                if (e.NewValue == CheckState.Checked)
                {
                    var emplyeeJustChecked = (USERS)filterListBox.Items[e.Index];
                    checkedEmployees.Add(emplyeeJustChecked);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    var roomJustUnchecked = (USERS)filterListBox.Items[e.Index];
                    checkedEmployees.Remove(roomJustUnchecked);
                    showAllCheckBox.Checked = false;
                }

                var orderedList = from emp in checkedEmployees orderby emp.US_STAMP select emp;

                FilterEmployeeData(orderedList.ToList());
                if (!clickedGraf)
                    this.BeginInvoke(new Action(SetUpEmployeePieChart));

            }

            //this.BeginInvoke(new Action(() =>
            //{
            //    //Do the after-check tasks here
            //}));


        }

        private void CheckAllBoxes(bool checkThem)
        {
            showAllCheckBox.Checked = checkThem;
            for (int i = 0; i < filterListBox.Items.Count; i++)
            {
                filterListBox.SetItemChecked(i, checkThem);

            }



        }

        private void showAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showAllCheckBox.Checked) CheckAllBoxes(true);

        }

        private List<EYEEXAMROOMS> GetCheckedRooms()
        {
            List<EYEEXAMROOMS> checkedRooms = new List<EYEEXAMROOMS>();
            for (int i = 0; i < filterListBox.Items.Count; i++)
            {
                var room = (EYEEXAMROOMS)filterListBox.Items[i];
                var isChecked = filterListBox.GetItemCheckState(i);
                if (isChecked == CheckState.Checked) checkedRooms.Add(room);
            }

            return checkedRooms;
        }

        private List<USERS> GetCheckedEmployees()
        {
            List<USERS> checkedEmployees = new List<USERS>();
            for (int i = 0; i < filterListBox.Items.Count; i++)
            {
                var employee = (USERS)filterListBox.Items[i];
                var isChecked = filterListBox.GetItemCheckState(i);
                if (isChecked == CheckState.Checked) checkedEmployees.Add(employee);
            }

            return checkedEmployees;
        }
    }
}
