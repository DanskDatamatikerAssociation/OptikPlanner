using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        OptikItDbContext db = new OptikItDbContext();
        CancelAppointmentController controller = new CancelAppointmentController();

        public CancelAppointment()
        {
            InitializeComponent();

        }

        private void CancelAppointButton_Click(object sender, EventArgs e)
        {
            USERS deleter = (USERS) cancelUserBox.SelectedItem;
            string reasonCancel = " Kunden ikke mødte op.";
            string phoneCancel = " Kunden har aflyst telefonisk";
            string elseCancel = " der har været Andet i vejen.";
            
            if (cuCancelRadio.Checked)
            {
                Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + deleter + " har aflyst denne aftale fordi" + reasonCancel);
                

                Cancellation name = new Cancellation(Reason.IkkeMødtOp, deleter);
                CancelAppointmentController.CancellationUsersList.Add(name);
            }
            if(cuCancelPhoneRadio.Checked)
            {
                Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + deleter + " har aflyst denne aftale fordi" + phoneCancel);

                Cancellation name = new Cancellation(Reason.AflystTelefonisk, deleter);
                CancelAppointmentController.CancellationUsersList.Add(name);
            }
            if (cuCancelElseRadio.Checked)
            {
                Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + deleter + " har aflyst denne aftale fordi" + elseCancel);
                
                Cancellation name = new Cancellation(Reason.Aflyst, deleter);
                CancelAppointmentController.CancellationUsersList.Add(name);
            }

            if(!cuCancelRadio.Checked && !cuCancelPhoneRadio.Checked && !cuCancelElseRadio.Checked)
            {
                throw new ArgumentException("Du skal vælge en af de angivede muligheder!");
            }
            //if (deleter == null)
            //{
            //    throw new ArgumentException("Du skal vælge medarbejderen som aflyser aftalen");
            //}
            CalendarItem i = new CalendarItem(new Calendar());

            APTDETAILS appointment = (APTDETAILS) i.Tag;

            db.APTDETAILS.Remove(appointment);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
