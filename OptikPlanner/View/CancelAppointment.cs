using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using OptikPlanner.Controller;
using OptikPlanner.Misc;
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    public partial class CancelAppointment : Form
    {
        CreateAppointmentController controlz = new CreateAppointmentController();
        OptikItDbContext db = new OptikItDbContext();


        public CancelAppointment()
        {
            InitializeComponent();
            cancelUserBox.Items.Add(controlz.GetUser());
            cuCancelReasonBox.Enabled = false;

        }

        private void CancelAppointButton_Click(object sender, EventArgs e)
        {
            USERS deleter = (USERS) cancelUserBox.SelectedItem;

            if(cuCancelRadio.Checked)
            {
                Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + " Kunden ikke mødte op.");
            }
            if(cuCancelPhoneRadio.Checked)
            {
                Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + " Kunden har aflyst telefonisk");
            }
            if(cuCancelShownRadio.Checked)
            {
                Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + " Kunden har aflyst ved personligt fremmøde");
            }
            if (cuCancelElseRadio.Checked && cuCancelReasonBox.Text != null)
            {
                Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi " + cuCancelReasonBox.Text);
            }
            else if(!cuCancelRadio.Checked || cuCancelPhoneRadio.Checked || cuCancelShownRadio.Checked || cuCancelElseRadio.Checked)
            {
                throw new ArgumentException("Du skal vælge en af de angivede muligheder!");
            }
            if (deleter == null)
            {
                throw new ArgumentException("Du skal vælge medarbejderen som aflyser aftalen");
            }
            CalendarItem i = new CalendarItem(new Calendar());

            APTDETAILS appointment = (APTDETAILS) i.Tag;

            db.APTDETAILS.Remove(appointment);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cuCancelElseRadio_CheckedChanged(object sender, EventArgs e)
        {
            cuCancelReasonBox.Enabled = true;
        }
    }
}
