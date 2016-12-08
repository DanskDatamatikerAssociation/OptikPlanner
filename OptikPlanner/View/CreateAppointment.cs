﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    public partial class CreateAppointment : Form, ICreateAppointmentView
    {
        private CreateAppointmentController _controller;
        Random rnd = new Random();
        private List<CUSTOMERS> _customers;

        ToolTip tip = new ToolTip();


        public static APTDETAILS ClickedAppointment { get; set; }


        public void SetController(CreateAppointmentController controller)
        {
            this._controller = controller;
        }


        public CreateAppointment(DateTime selectedElement = default(DateTime))
        {
            InitializeComponent();

            _controller = new CreateAppointmentController(this);

            _customers = _controller.GetCustomers();


            GetDbData();

            InitializeCprBox();

            //ClickedAppointment = _controller.GetClickedAppointment();

            //timepicking settings
            timeFromPicker.CustomFormat = "HH:mm";
            timeToPicker.CustomFormat = "HH:mm";

            timeFromPicker.ShowUpDown = true;
            timeToPicker.ShowUpDown = true;

            //initiate text statements
            userSelectionCombo.Text = "Vælg medarbejder...";

            if (ClickedAppointment != null) FillOutAppointment();

            if (!selectedElement.Equals(DateTime.MinValue))
            {
                dateTimePicker1.Value = selectedElement.Date;

                var timeFrom = selectedElement;
                timeFromPicker.Text = timeFrom.TimeOfDay.ToString();
                timeToPicker.Text = timeFrom.AddMinutes(15).TimeOfDay.ToString();

            }
        }

        //public CreateAppointment(DateTime selectedElement)
        //{
        //    InitializeComponent();

        //    _controller = new CreateAppointmentController(this);

        //    _customers = _controller.GetCustomers();

        //    GetDbData();

        //    InitializeCprBox();

        //    //ClickedAppointment = _controller.GetClickedAppointment();

        //    //timepicking settings
        //    timeFromPicker.CustomFormat = "HH:mm";
        //    timeToPicker.CustomFormat = "HH:mm";

        //    timeFromPicker.ShowUpDown = true;
        //    timeToPicker.ShowUpDown = true;
        //    mPrevDate = dateTimePicker1.Value;

        //    //initiate text statements
        //    userSelectionCombo.Text = "Vælg medarbejder...";

        //    dateTimePicker1.Value = selectedElement.Date;
        //    timeFromPicker.Text = selectedElement.TimeOfDay.ToString();

   // }

    private void GetDbData()
    {
        var rooms = _controller.GetRooms();
        lokaleCombo.Items.AddRange(rooms.ToArray());

        var users = _controller.GetUsers();
        userSelectionCombo.Items.AddRange(users.ToArray());
        userCombo.Items.AddRange(users.ToArray());



    }

    private void FillOutAppointment()
    {
        var extraDetails = _controller.GetClickedAppointmentDetails();


        userSelectionCombo.Text = extraDetails[2];
        userSelectionCombo.Enabled = false;

        cprBox.Text = ClickedAppointment.APD_CPR;
        cprBox.Enabled = false;

        customerLibraryButton.Enabled = false;

        firstNameBox.Text = ClickedAppointment.APD_FIRST;

        lastNameBox.Text = ClickedAppointment.APD_LAST;


        aftaleCombo.Text = extraDetails[0];
        // aftaleCombo.Enabled = false;

        lokaleCombo.Text = extraDetails[1];
        //lokaleCombo.Enabled = false;

        userCombo.Text = extraDetails[2];
        //userCombo.Enabled = false;

        dateTimePicker1.Value = ClickedAppointment.APD_DATE.GetValueOrDefault();
        //dateTimePicker1.Enabled = false;

        timeFromPicker.Text = ClickedAppointment.APD_TIMEFROM;
        // timeFromPicker.Enabled = false;

        timeToPicker.Text = ClickedAppointment.APD_TIMETO;
        //timeToPicker.Enabled = false;

        telefonBox.Text = ClickedAppointment.APD_MOBILE;
        //telefonBox.Enabled = false;

        //smsCheck.Enabled = false;

        emailBox.Text = ClickedAppointment.APD_EMAIL;
        //emailBox.Enabled = false;

        //emailCheck.Enabled = false;

        string description;
        if (ClickedAppointment.APD_DESCRIPTION == null) description = "**No description**";
        else description = Encoding.Default.GetString(ClickedAppointment.APD_DESCRIPTION);
        beskrivelseBox.Text = description;
        //beskrivelseBox.Enabled = false;

        cancelAppointmentButton.Enabled = true;

        //ClickedAppointment = null;

    }



    private void cancelBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelAppointmentButton_Click(object sender, EventArgs e)
        {
            CancelAppointment.AppointmentToDelete = ClickedAppointment;
            CancelAppointment window = new CancelAppointment();
            window.ShowDialog();
        }

        private void timeFromPicker_ValueChanged(object sender, EventArgs e)
        {
            switch (timeFromPicker.Value.Minute)
            {
                case 1:
                case 16:
                case 31:
                case 46:
                    timeFromPicker.Value = timeFromPicker.Value.AddMinutes(14);
                    break;
                case 14:
                case 29:
                case 44:
                    timeFromPicker.Value = timeFromPicker.Value.AddMinutes(-14);
                    break;
                case 59:
                    timeFromPicker.Value = timeFromPicker.Value.AddMinutes(-74);
                    break;
            }
        }
        
        

        private void timeToPicker_ValueChanged(object sender, EventArgs e)
        {
            switch (timeToPicker.Value.Minute)
            {
                case 1:
                case 16:
                case 31:
                case 46:
                    timeToPicker.Value = timeToPicker.Value.AddMinutes(14);
                    break;
                case 14:
                case 29:
                case 44:
                    timeToPicker.Value = timeToPicker.Value.AddMinutes(-14);
                    break;
                case 59:
                    timeToPicker.Value = timeToPicker.Value.AddMinutes(-74);
                    break;
            }
        }
        

        private void okButton_Click(object sender, EventArgs e)
        {

            int id = _controller.GetNextAppointmentId();
            DateTime date = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, timeFromPicker.Value.Hour, timeFromPicker.Value.Minute, 0);
            string timeFrom = timeFromPicker.Value.ToString("HH:mm");
            string timeTo = timeToPicker.Value.ToString("HH:mm");
            USERS user = (USERS)userCombo.SelectedItem;
            EYEEXAMROOMS room = (EYEEXAMROOMS) lokaleCombo.SelectedItem;
            CUSTOMERS customer = _customers.Find(c => c.CS_CPRNO.Equals(cprBox.Text));
            AppointmentType type;
            switch (aftaleCombo.Text)
            {
                case "Steljustering":
                    type = AppointmentType.Steloptimering;
                    break;
                case "Linseopsætning":
                    type = AppointmentType.Linsejustering;
                    break;
                default:
                    type = AppointmentType.Linsejustering;
                    break;

            }
            var description = beskrivelseBox.Text;

            APTDETAILS appointment = new APTDETAILS();

            //That means to create a new appointment.
            if (ClickedAppointment == null)
            {
                try
                {
                    if (date <= DateTime.Now.AddMinutes(-1))
                    {
                        MessageBox.Show("Du skal vælge et tidspunkt i fremtiden", "Fejl", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    appointment = new APTDETAILS(id, user, room, date, timeFrom, timeTo, customer, type, description);
                    appointment.APD_MOBILE = telefonBox.Text;
                    appointment.APD_EMAIL = emailBox.Text;
                    _controller.PostAppointment(appointment);
                    MessageBox.Show("Success! Aftalen er oprettet.", "Succes!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Der er fejl i den indtastede data. Prøv igen.",
                        "Fejl i oprettelse", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            //To put an appointment
            else
            {

                appointment = new APTDETAILS(ClickedAppointment.APD_STAMP, user, room, date, timeFrom, timeTo, customer, type, description);
                appointment.APD_MOBILE = telefonBox.Text;
                appointment.APD_EMAIL = emailBox.Text;
                _controller.PutAppointment(appointment);
                MessageBox.Show("Success! Aftalen er redigeret.", "Succes!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }





        }




        private void userSelectionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void beskrivelseBox_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void customerLibraryButton_Click(object sender, EventArgs e)
        {
            var form = new CustomerLibrary();
            form.Show();
        }

        private void cprBox_Leave(object sender, EventArgs e)
        {
            foreach (var c in _customers)
            {
                if (cprBox.Text.Equals(c.CS_CPRNO))
                {
                    firstNameBox.Text = c.CS_FIRSTNAME;
                    lastNameBox.Text = c.CS_LASTNAME;
                }
            }
        }

        private void InitializeCprBox()
        {
            AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();

            List<string> cprNumbers = new List<string>();
            foreach (var c in _customers) cprNumbers.Add(c.CS_CPRNO);

            allowedTypes.AddRange(cprNumbers.ToArray());

            cprBox.AutoCompleteCustomSource = allowedTypes;
            cprBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cprBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void previousAppointmentsBoc_MouseEnter(object sender, EventArgs e)
        {
            var customer = _controller.GetCustomers();
            var description = _controller.GetAppointments();

            foreach (var s in _controller.GetCustomers())
            {
                if (s.CS_CPRNO == ClickedAppointment.APD_CPR)
                {
                    previousAppointmentsBoc.Text = "Se " + s.CS_FIRSTNAME + "s tidligere aftale";
                }
            }


            TextBox rtb = (sender as TextBox);
            if (rtb != null)
            {
                this.tip.Show(Encoding.Default.GetString(ClickedAppointment.APD_DESCRIPTION), rtb);
            }
        }



        void previousAppointmentsBoc_MouseLeave(object sender, EventArgs e)
        {
            TextBox rtb = (sender as TextBox);
            if (rtb != null)
            {
                this.tip.Hide(rtb);
            }
        }
    }
}
