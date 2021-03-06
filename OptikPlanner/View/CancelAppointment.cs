﻿using System;
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
    /// <summary>
    /// the CancelAppointment view to handle view-related and controller functions
    /// </summary>
    public partial class CancelAppointment : Form, ICancelAppointmentView
    {
        private CancelAppointmentController _controller;
        public static APTDETAILS AppointmentToDelete;

        public CancelAppointment()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterParent;

            _controller = new CancelAppointmentController(this);
            AddUsersToList();
            

        }

        public void SetController(CancelAppointmentController controller)
        {
            _controller = controller;
        }



        private void CancelAppointButton_Click(object sender, EventArgs e)
        {
            if (cancelUserBox.SelectedItem == null)
            {
                MessageBox.Show("Du skal vælge en medarbejder.", "Fejl");
                return;
            }
            Log();
            DeleteAppointment();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gets the specified radio button for cancellation reason then proceeds to save a log of specified reason for cancellation
        /// </summary>
        private void Log()
        {
            try
            {
                USERS deleter = (USERS)cancelUserBox.SelectedItem;
                string reasonCancel = " kunden ikke mødte op";
                string phoneCancel = " kunden har aflyst telefonisk";
                string elseCancel = " der har været Andet i vejen";

                if (cuCancelRadio.Checked)
                {
                    Trace.WriteLine($"\n{DateTime.Now}: ansatte: {deleter} har aflyst denne aftale fordi kunden ikke mødte op");
                    
                    Cancellation name = new Cancellation(Reason.IkkeMødtOp, deleter);
                    CancelAppointmentController.CancellationUsersList.Add(name);
                }
                if (cuCancelPhoneRadio.Checked)
                {
                    Trace.WriteLine($"\n{DateTime.Now}: ansatte: {deleter} har aflyst denne aftale fordi kunden har aflyst telefonisk");
                   
                    Cancellation name = new Cancellation(Reason.AflystTelefonisk, deleter);
                    CancelAppointmentController.CancellationUsersList.Add(name);
                }
                if (cuCancelElseRadio.Checked)
                {
                    Trace.WriteLine($"\n{DateTime.Now}: ansatte: {deleter} har aflyst denne aftale fordi der har været Andet i vejen");
                  
                    Cancellation name = new Cancellation(Reason.Aflyst, deleter);
                    CancelAppointmentController.CancellationUsersList.Add(name);
                }

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// deletes the appointment
        /// </summary>
        private void DeleteAppointment()
        {
            _controller.DeleteAppointment(AppointmentToDelete);
            MessageBox.Show("Aftalen er nu aflyst.", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            var createAppointmentForm = Application.OpenForms["CreateAppointment"];
            createAppointmentForm.Close();
        }

        /// <summary>
        /// adds all users to list of users 
        /// </summary>
        private void AddUsersToList()
        {
            var employees = _controller.GetEmployees();
            foreach (var e in employees) cancelUserBox.Items.Add(e);
        }

        private void cuCancelRadio_CheckedChanged(object sender, EventArgs e)
        {
            CancelAppointButton.Enabled = true;
        }
    }

    

    




}

