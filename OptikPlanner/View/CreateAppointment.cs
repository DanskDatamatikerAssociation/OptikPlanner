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
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    public partial class CreateAppointment : Form
    {
        CreateAppointmentController controlz = new CreateAppointmentController();
        private DateTime mPrevDate;
        private bool mBusy;
        Random rnd = new Random();

        public CreateAppointment()
        {
            InitializeComponent();

            //timepicking settings
            timeFromPicker.CustomFormat = "hh:mm";
            timeToPicker.CustomFormat = "hh:mm";
            
            timeFromPicker.ShowUpDown = true;
            timeToPicker.ShowUpDown = true;
            mPrevDate = dateTimePicker1.Value;

            //initiate text statements
            userSelectionCombo.Text = "Vælg medarbejder...";
            
            //TEST DATA - COMBO´s
            userSelectionCombo.Items.Add(controlz.GetUser());
            aftaleCombo.Items.Add(controlz.GetRooms().ERO_TYPE);
            lokaleCombo.Items.Add(controlz.GetRooms().ERO_NBR);
            timeFromPicker.Text = controlz.GetRooms().ERO_OPENFROM;
            timeToPicker.Text = controlz.GetRooms().ERO_OPENTO;
            telefonBox.Text = controlz.GetCustomer().CS_PHONEMOBILE;
            userCombo.Items.Add(controlz.GetUser());
            if (smsCheck.Checked)
            {
                controlz.GetCustomer().CS_COMMERCIALS_SMS = 1;
            }
            if (emailCheck.Checked)
            {
                controlz.GetCustomer().CS_COMMERCIALS_EMAIL = 1;

            }
            emailBox.Text = controlz.GetCustomer().CS_EMAIL;
        }
        
        private void cueTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (cprBox.Text == controlz.GetCustomer().CS_CPRNO)
            {
                firstNameBox.Text = controlz.GetCustomer().CS_FIRSTNAME;
                lastNameBox.Text = controlz.GetCustomer().CS_LASTNAME;
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
    }
}
