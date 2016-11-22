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
        private List<CUSTOMERS> _customers;

       

        public static APTDETAILS ClickedAppointment { get; set; }


        public void SetController(CreateAppointmentController controller)
        {
            this._controller = controller;
        }


        public CreateAppointment()
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
            mPrevDate = dateTimePicker1.Value;

            //initiate text statements
            userSelectionCombo.Text = "Vælg medarbejder...";

            if (ClickedAppointment != null) FillOutAppointment();
        }

        private void GetDbData()
        {
            var rooms = _controller.GetRooms();
            lokaleCombo.Items.AddRange(rooms.ToArray());

            var users = _controller.GetUsers();
            userSelectionCombo.Items.AddRange(users.ToArray());
            userCombo.Items.AddRange(users.ToArray());       
            
                 

        }
        
        private void cueTextBox1_TextChanged(object sender, EventArgs e)
        {
            //foreach (var c in _customers)
            //{
            //    string fourFirstLetters = c.CS_CPRNO.Substring(0, 4);
            //    if (cprBox.Text.StartsWith(fourFirstLetters))
            //    {
            //        cprBox.Text = c.CS_CPRNO;
            //        cprBox.SelectionStart = fourFirstLetters.Length;
            //        cprBox.SelectionLength = cprBox.Text.Length;

            //    }
            //}


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

            var extraDetails = _controller.GetClickedAppointmentDetails();

            aftaleCombo.Text = extraDetails[0];
           // aftaleCombo.Enabled = false;

            lokaleCombo.Text = extraDetails[1];
            //lokaleCombo.Enabled = false;

            userCombo.Text = extraDetails[2];
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

            ClickedAppointment = null;

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
            //EYEEXAMROOMS used = new EYEEXAMROOMS();
            //used.ERO_TYPE = aftaleCombo.Text;
            //used.ERO_DESC = beskrivelseBox.Text;
            //used.ERO_NBR = int.Parse(lokaleCombo.Text);
            //used.ERO_OPENFROM = timeFromPicker.Text;
            //used.ERO_OPENTO = timeToPicker.Text;

            //CUSTOMERS customer = new CUSTOMERS();
            //customer.CS_CPRNO = cprBox.Text;
            //customer.CS_FIRSTNAME = firstNameBox.Text;
            //customer.CS_LASTNAME = lastNameBox.Text;

            int id = _controller.GetNextAppointmentId();
            DateTime date = dateTimePicker1.Value;
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
            
                try
                {
                    appointment = new APTDETAILS(id, user, room, date, timeFrom, timeTo, customer, type, description);
                    _controller.PostAppointment(appointment);
                    MessageBox.Show("Success! Aftalen er oprettet.", "Success!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some of the data you entered is incorrect. Try again.",
                        "Error creating appointment", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            
            //To put an appointment
     


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
    }
}
