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
    public partial class CancelAppointment : Form, ICancelAppointmentView
    {
        private CancelAppointmentController _controller;
        public static APTDETAILS AppointmentToDelete;

        public CancelAppointment()
        {
            InitializeComponent();
            _controller = new CancelAppointmentController(this);
            AddUsersToList();
            

        }

        public void SetController(CancelAppointmentController controller)
        {
            _controller = controller;
        }



        private void CancelAppointButton_Click(object sender, EventArgs e)
        {
            Log();
            DeleteAppointment();





        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Log()
        {
            try
            {
                USERS deleter = (USERS)cancelUserBox.SelectedItem;
                string reasonCancel = " Kunden ikke mødte op.";
                string phoneCancel = " Kunden har aflyst telefonisk";
                string elseCancel = " der har været Andet i vejen.";

                if (cuCancelRadio.Checked)
                {
                    Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + deleter + " har aflyst denne aftale fordi" +
                                    reasonCancel);


                    Cancellation name = new Cancellation(Reason.IkkeMødtOp, deleter);
                    CancelAppointmentController.CancellationUsersList.Add(name);
                }
                if (cuCancelPhoneRadio.Checked)
                {
                    Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + deleter + " har aflyst denne aftale fordi" +
                                    phoneCancel);

                    Cancellation name = new Cancellation(Reason.AflystTelefonisk, deleter);
                    CancelAppointmentController.CancellationUsersList.Add(name);
                }
                if (cuCancelElseRadio.Checked)
                {
                    Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + deleter + " har aflyst denne aftale fordi" +
                                    elseCancel);

                    Cancellation name = new Cancellation(Reason.Aflyst, deleter);
                    CancelAppointmentController.CancellationUsersList.Add(name);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteAppointment()
        {
            _controller.DeleteAppointment(AppointmentToDelete);
            MessageBox.Show("Aftalen er nu aflyst.", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            var createAppointmentForm = Application.OpenForms["CreateAppointment"];
            createAppointmentForm.Close();
        }

        private void AddUsersToList()
        {
            var employees = _controller.GetEmployees();
            foreach (var e in employees) cancelUserBox.Items.Add(e);
        }


    }

    

    




}

