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
        private DateTime mPrevDate;
        Random rnd = new Random();

       

        public static APTDETAILS ClickedAppointment { get; set; }


        public void SetController(CreateAppointmentController controller)
        {
            this._controller = controller;
        }


        public CreateAppointment()
        {
            InitializeComponent();

            //ClickedAppointment = _controller.GetClickedAppointment();

            //timepicking settings
            timeFromPicker.CustomFormat = "hh:mm";
            timeToPicker.CustomFormat = "hh:mm";
            
            timeFromPicker.ShowUpDown = true;
            timeToPicker.ShowUpDown = true;
            mPrevDate = dateTimePicker1.Value;

            //initiate text statements
            userSelectionCombo.Text = "Vælg medarbejder...";

            if (ClickedAppointment != null) FillOutAppointment();
        }
        
        private void cueTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (cprBox.Text == _controller.GetCustomer().CS_CPRNO)
            {
                firstNameBox.Text = _controller.GetCustomer().CS_FIRSTNAME;
                lastNameBox.Text = _controller.GetCustomer().CS_LASTNAME;
            }
            #region til reel data
            //if (cprBox.Text.Length > 0)
            //{
            //    if (cprBox.Text.(c => c.))


            //int cpr;
            //if (int.TryParse(cprBox.Text, out cpr))
            //{

            //firstNameBox.DataBindings.Add(customer1.CS_FIRSTNAME, customer1, customer1.CS_LASTNAME);

            //using (var ctx = new OptikItDbContext())
            //{
            //    // get customer name by Id, for example:
            //    var name = ctx.CUSTOMERS.Where(c => c.CS_CPRNO == cpr.ToString())
            //             .Select(c => c.CS_FIRSTNAME)
            //             .FirstOrDefault();

            //    if (name != null) firstNameBox.Text = name;

            //    var lastname = ctx.CUSTOMERS.Where(c => c.CS_CPRNO == cpr.ToString())
            //             .Select(c => c.CS_LASTNAME)
            //             .FirstOrDefault();

            //    if (lastname != null) lastNameBox.Text = lastname;
            //}
            // }
            //} 
            #endregion

        }

        private void FillOutAppointment()
        {

            userSelectionCombo.SelectedItem = ClickedAppointment.APD_USER;
            userSelectionCombo.Enabled = false;

            cprBox.Cue = ClickedAppointment.APD_CPR;
            cprBox.Enabled = false;

            customerLibraryButton.Enabled = false;

            firstNameBox.Text = ClickedAppointment.APD_FIRST;

            lastNameBox.Text = ClickedAppointment.APD_LAST;

            aftaleCombo.SelectedItem = ClickedAppointment.APD_TYPE;
           // aftaleCombo.Enabled = false;

            lokaleCombo.Text = ClickedAppointment.APD_ROOM.ToString();
            //lokaleCombo.Enabled = false;

            userCombo.SelectedItem = ClickedAppointment.APD_USER;
            //userCombo.Enabled = false;

            dateTimePicker1.Value =  ClickedAppointment.APD_DATE.GetValueOrDefault();
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



        }
        

        private void cancelBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelAppointmentButton_Click(object sender, EventArgs e)
        {
            //lav if statement som enabler / disabler knap alt efter om det er aflys eller opret knap der bliver trykket på.
            CancelAppointment window = new CancelAppointment();
            window.ShowDialog();
        }

        private void timeFromPicker_ValueChanged(object sender, EventArgs e)
        {
                DateTime dt = timeFromPicker.Value;
                if ((dt.Minute * 60 + dt.Second) % 300 != 0)
                {
                    TimeSpan diff = dt - mPrevDate;
                    if (diff.Ticks < 0) timeFromPicker.Value = mPrevDate.AddMinutes(-15);
                    else timeFromPicker.Value = mPrevDate.AddMinutes(15);
                }
            mPrevDate = timeFromPicker.Value;
        }
        
        

        private void timeToPicker_ValueChanged(object sender, EventArgs e)
        {
            
                DateTime dt = timeToPicker.Value;
                if ((dt.Minute * 60 + dt.Second) % 300 != 0)
                {
                    TimeSpan diff = dt - mPrevDate;
                    if (diff.Ticks < 0) timeToPicker.Value = mPrevDate.AddMinutes(-15);
                    else timeToPicker.Value = mPrevDate.AddMinutes(15);
                }
                
            
            mPrevDate = timeToPicker.Value;
        }
        

        private void okButton_Click(object sender, EventArgs e)
        {
            EYEEXAMROOMS used = new EYEEXAMROOMS();
            used.ERO_TYPE = aftaleCombo.Text;
            used.ERO_DESC = beskrivelseBox.Text;
            used.ERO_NBR = int.Parse(lokaleCombo.Text);
            used.ERO_OPENFROM = timeFromPicker.Text;
            used.ERO_OPENTO = timeToPicker.Text;

            CUSTOMERS customer = new CUSTOMERS();
            customer.CS_CPRNO = cprBox.Text;
            customer.CS_FIRSTNAME = firstNameBox.Text;
            customer.CS_LASTNAME = lastNameBox.Text;

            int id = rnd.Next(1, 9999);
            DateTime date = dateTimePicker1.Value;
            var text = beskrivelseBox.Text;
            USERS user1 = (USERS) userCombo.SelectedItem;


            APTDETAILS test = new APTDETAILS(id, user1, used, date, used.ERO_OPENFROM, used.ERO_OPENTO, customer,
                text);
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
    }
}
