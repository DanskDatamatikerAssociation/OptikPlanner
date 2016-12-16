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
using System.Diagnostics;

namespace OptikPlanner.View
{
    public partial class CreateAppointment : Form, ICreateAppointmentView
    {
        private CreateAppointmentController _controller;
        private DateTime mPrevDate;
        Random rnd = new Random();
        private bool clickedButton = true;
        private List<CUSTOMERS> _customers;
        private DateTime dateTimeFrom;
        private DateTime dateTimeTo;
        public static CUSTOMERS SelectedCustomer { get; set; }



        public static APTDETAILS ClickedAppointment { get; set; }


        public void SetController(CreateAppointmentController controller)
        {
            this._controller = controller;
        }


        public CreateAppointment(DateTime selectedElement = default(DateTime))
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;

            _controller = new CreateAppointmentController(this);


            GetDbData();

            InitializeCprBox();

            SetupLastAndFutureAppointmentsListView();

            //ClickedAppointment = _controller.GetClickedAppointment();

            //timepicking settings
            timeFromPicker.CustomFormat = "HH:mm";
            timeToPicker.CustomFormat = "HH:mm";

            timeFromPicker.ShowUpDown = true;
            timeToPicker.ShowUpDown = true;
            mPrevDate = dateTimePicker1.Value;

            timeFromPicker.Value = new DateTime(1999, 12, 12, DateTime.Now.Hour, 00, 00);
            timeToPicker.Value = new DateTime(1999, 12, 12, DateTime.Now.Hour, 00, 00);
            
            
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

        //}

        private void GetDbData()
        {
            _customers = _controller.GetCustomers();

            var rooms = _controller.GetRooms();
            lokaleCombo.Items.AddRange(rooms.ToArray());

            var users = _controller.GetUsers();
            userSelectionCombo.Items.AddRange(users.ToArray());
            userCombo.Items.AddRange(users.ToArray());



        }

        private void cueTextBox1_TextChanged(object sender, EventArgs e)
        {




        }

        private void FillOutAppointment()
        {

            this.Text = "Ret Aftale";
            label1.Text = "Retter";
            okButton.Text = "Ret";

            var user = _controller.GetAppointmentUser(ClickedAppointment);

            userSelectionCombo.Text = user.US_USERNAME;
            userSelectionCombo.Enabled = false;

            cprBox.Text = ClickedAppointment.APD_CPR;
            cprBox.Enabled = false;

            customerLibraryButton.Enabled = false;

            firstNameBox.Text = ClickedAppointment.APD_FIRST;

            lastNameBox.Text = ClickedAppointment.APD_LAST;

            var type = CalendarViewController.GetAppointmentType(ClickedAppointment);

            aftaleCombo.Text = type;
            // aftaleCombo.Enabled = false;

            var room = _controller.GetAppointmentRoom(ClickedAppointment);

            lokaleCombo.Text = room.ERO_SHORTDESC;
            //lokaleCombo.Enabled = false;

            userCombo.Text = user.US_USERNAME;
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
            DateTime dtfrom = timeFromPicker.Value;

            if ((dtfrom.Minute * 60 + dtfrom.Second) % 300 != 0)
            {
                TimeSpan diff = dtfrom - mPrevDate;
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

            int id = _controller.GetNextAppointmentId();
            DateTime date = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                dateTimePicker1.Value.Day, timeFromPicker.Value.Hour, timeFromPicker.Value.Minute, 0);
            if (date < DateTime.Today)
            {
                if (ClickedAppointment == null)
                {
                    MessageBox.Show("Du skal vælge et tidspunkt i fremtiden", "Fejl", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Du kan ikke redigere en aftale der er overstået.", "Fejl", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

            }
            string timeFrom = timeFromPicker.Value.ToString("HH:mm");
            string timeTo = timeToPicker.Value.ToString("HH:mm");
            USERS user = (USERS)userCombo.SelectedItem;
            EYEEXAMROOMS room = (EYEEXAMROOMS)lokaleCombo.SelectedItem;
            CUSTOMERS customer = _customers.Find(c => c.CS_CPRNO.Equals(cprBox.Text));
            AppointmentType type;
            switch (aftaleCombo.Text)
            {
                case "Synsprøve":
                    type = AppointmentType.Synsprøve;
                    break;
                case "Ny tilpasning":
                    type = AppointmentType.NyTilpasning;
                    break;
                case "Linsekontrol":
                    type = AppointmentType.LinseKontrol;
                    break;
                case "Udlevering":
                    type = AppointmentType.Udlevering;
                    break;
                case "Efterkontrol":
                    type = AppointmentType.Efterkontrol;
                    break;
                case "Svagsynsoptik":
                    type = AppointmentType.Svagsynsoptik;
                    break;
                case "Møde":
                    type = AppointmentType.Møde;
                    break;
                case "Genudmåling":
                    type = AppointmentType.Genudmåling;
                    break;
                case "FRI":
                    type = AppointmentType.FRI;
                    break;
                case "Leverandør":
                    type = AppointmentType.Leverandør;
                    break;
                case "PBS":
                    type = AppointmentType.PBS;
                    break;
                case "Brevkæde":
                    type = AppointmentType.Brevkæde;
                    break;
                case "Lukkedag":
                    type = AppointmentType.Lukkedag;
                    break;
                case "Udlevering af briller":
                    type = AppointmentType.UdleveringAfBriller;
                    break;
                case "Sygehus apotek":
                    type = AppointmentType.SygehusApotek;
                    break;
                case "Værksted arbejde":
                    type = AppointmentType.Værkstedarbejde;
                    break;
                default:
                    type = AppointmentType.Synsprøve;
                    break;

            }
            var description = beskrivelseBox.Text;

            APTDETAILS appointment = new APTDETAILS();

            //That means to create a new appointment.
            if (ClickedAppointment == null)
            {
                dateTimeFrom = timeFromPicker.Value;
                dateTimeTo = timeToPicker.Value;

                int result = DateTime.Compare(dateTimeFrom, dateTimeTo);

                try
                {
                    if (result > 0)
                    //(date <= DateTime.Now.AddMinutes(-1))
                    {
                        MessageBox.Show("Du skal vælge et tidspunkt i fremtiden", "Fejl", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        //ny aftale
                        Trace.WriteLine(
                            $"\n Ansatte: {userSelectionCombo.SelectedIndex} har Oprettet en ny aftale d. {DateTime.Now}");
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

                    CalendarView.AddedNewAppointment = true;

                }

            }
            //To put an appointment
            else
            {

                appointment = new APTDETAILS(ClickedAppointment.APD_STAMP, user, room, date, timeFrom, timeTo, customer,
                    type, description);
                appointment.APD_MOBILE = telefonBox.Text;
                appointment.APD_EMAIL = emailBox.Text;
                _controller.PutAppointment(appointment);


                MessageBox.Show("Success! Aftalen er redigeret.", "Succes!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Trace.WriteLine(
                    $"\n{DateTime.Now}: Aftale på dato {appointment.APD_DATE} med kunde {appointment.APD_FIRST} {appointment.APD_LAST} er blevet rettet.");
                this.Close();

                CalendarView.AddedNewAppointment = true;
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
            CustomerLibrary.FromAppointmentCreation = true;
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

                    PopulateLastAndFutureAppointments();
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

        private void CreateAppointment_Activated(object sender, EventArgs e)
        {
            if (SelectedCustomer != null)
            {
                cprBox.Text = SelectedCustomer.CS_CPRNO;

                firstNameBox.Text = SelectedCustomer.CS_FIRSTNAME;

                lastNameBox.Text = SelectedCustomer.CS_LASTNAME;

                PopulateLastAndFutureAppointments();

                SelectedCustomer = null;

            }
        }


        private void PopulateLastAndFutureAppointments()
        {
            if (cprBox.Text.Equals("")) return;
            customerAppLabel.Enabled = true;
            showPreviousButton.Enabled = true;

            lastFutureAppointmentsListView.Items.Clear();

            var customer = _controller.FindCustomerWithCpr(cprBox.Text);
            var twoLastAppointments = _controller.GetPastAppointments(customer);
            var futureAppointments = _controller.GetFutureAppointments(customer);

            var forrigeItem = lastFutureAppointmentsListView.Items.Add("Forrige");
            forrigeItem.Font = new Font(forrigeItem.Font, FontStyle.Bold | FontStyle.Underline);

            foreach (var appointment in twoLastAppointments)
            {
                var appointmentItem = lastFutureAppointmentsListView.Items.Add(appointment.APD_DATE.ToString());
                var type = StatisticsViewController.GetAppointmentType(appointment);
                appointmentItem.SubItems.Add(type);
                var description = Encoding.Default.GetString(appointment.APD_DESCRIPTION);
                appointmentItem.SubItems.Add(description);
            }

            var fremtidigeItem = lastFutureAppointmentsListView.Items.Add("Fremtidige");
            fremtidigeItem.Font = new Font(fremtidigeItem.Font, FontStyle.Bold | FontStyle.Underline);
            foreach (var appointment in futureAppointments)
            {
                var appointmentItem = lastFutureAppointmentsListView.Items.Add(appointment.APD_DATE.ToString());
                var type = StatisticsViewController.GetAppointmentType(appointment);
                appointmentItem.SubItems.Add(type);
                var description = Encoding.Default.GetString(appointment.APD_DESCRIPTION);
                appointmentItem.SubItems.Add(description);
            }

        }

        private void SetupLastAndFutureAppointmentsListView()
        {

            lastFutureAppointmentsListView.Columns.Add("Dato", 125);
            lastFutureAppointmentsListView.Columns.Add("Type", 100);
            lastFutureAppointmentsListView.Columns.Add("Beskrivelse", 120);
        }


        private void showPreviousButton_Click(object sender, EventArgs e)
        {
            if (clickedButton)
                ExpandButtonClick();
            else
                CollapseButtonClick();

            clickedButton = !clickedButton;
        }

        private void ExpandButtonClick()
        {
            showPreviousButton.Image = Image.FromFile(@"C:\Users\Danny\Documents\GitHub\OptikPlanner\OptikPlanner\Resources\arrow_up_small.png");
            this.Size = new System.Drawing.Size(420, 800);
            lastFutureAppointmentsListView.Enabled = true;
            lastFutureAppointmentsListView.Visible = true;
        }
        private void CollapseButtonClick()
        {
            showPreviousButton.Image = Image.FromFile(@"C:\Users\Danny\Documents\GitHub\OptikPlanner\OptikPlanner\Resources\arrow_down_small.png");
            this.Size = new System.Drawing.Size(420, 555);
            lastFutureAppointmentsListView.Enabled = false;
            lastFutureAppointmentsListView.Visible = false;


        }

        private void label16_Click(object sender, EventArgs e)
        {
            showPreviousButton_Click(sender, e);
        }
    }
}