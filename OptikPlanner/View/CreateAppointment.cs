using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Controller;
using OptikPlanner.Misc;
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    public partial class CreateAppointment : Form
    {
        CreateAppointmentController _controller = new CreateAppointmentController();
        private DateTime _mPrevDate;
        Random _rnd = new Random();

        public CreateAppointment()
        {
            InitializeComponent();

            //timepicking settings
            timeFromPicker.CustomFormat = "hh:mm";
            timeToPicker.CustomFormat = "hh:mm";
            
            timeFromPicker.ShowUpDown = true;
            timeToPicker.ShowUpDown = true;
            _mPrevDate = dateTimePicker1.Value;

            //initiate text statements
            userSelectionCombo.Text = "Vælg medarbejder...";
            
            //TEST DATA - COMBO´s
            userSelectionCombo.Items.Add(_controller.GetUser());
            aftaleCombo.Items.Add(_controller.GetRooms().ERO_TYPE);
            lokaleCombo.Items.Add(_controller.GetRooms().ERO_NBR);
            timeFromPicker.Text = _controller.GetRooms().ERO_OPENFROM;
            timeToPicker.Text = _controller.GetRooms().ERO_OPENTO;
            telefonBox.Text = _controller.GetCustomer().CS_PHONEMOBILE;
            userCombo.Items.Add(_controller.GetUser());
            if (smsCheck.Checked)
            {
                _controller.GetCustomer().CS_COMMERCIALS_SMS = 1;
            }
            if (emailCheck.Checked)
            {
                _controller.GetCustomer().CS_COMMERCIALS_EMAIL = 1;

            }
            emailBox.Text = _controller.GetCustomer().CS_EMAIL;
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
                    TimeSpan diff = dt - _mPrevDate;
                    if (diff.Ticks < 0) timeFromPicker.Value = _mPrevDate.AddMinutes(-15);
                    else timeFromPicker.Value = _mPrevDate.AddMinutes(15);
                }
            _mPrevDate = timeFromPicker.Value;
        }
        
        

        private void timeToPicker_ValueChanged(object sender, EventArgs e)
        {
            
                DateTime dt = timeToPicker.Value;
                if ((dt.Minute * 60 + dt.Second) % 300 != 0)
                {
                    TimeSpan diff = dt - _mPrevDate;
                    if (diff.Ticks < 0) timeToPicker.Value = _mPrevDate.AddMinutes(-15);
                    else timeToPicker.Value = _mPrevDate.AddMinutes(15);
                }
                
            
            _mPrevDate = timeToPicker.Value;
        }
        

        private void okButton_Click(object sender, EventArgs e)
        {
            USERS deleter = (USERS)userSelectionCombo.SelectedItem;

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

            int id = _rnd.Next(1, 9999);
            DateTime date = dateTimePicker1.Value;
            var text = beskrivelseBox.Text;
            USERS user1 = (USERS) userCombo.SelectedItem;


            APTDETAILS test = new APTDETAILS(id, user1, used, date, used.ERO_OPENFROM, used.ERO_OPENTO, customer,
                text);
            Logger.LogThisLine("ansatte: " + deleter + " har oprettet denne aftale med kunde: " + firstNameBox + " beskrivelse: " + beskrivelseBox);

        }

        private void customerBox_Click(object sender, EventArgs e)
        {
            CustomerLibrary window = new CustomerLibrary();
            window.Show();

            
        }
    }
}
