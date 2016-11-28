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
    public partial class CancelAppointment : Form, ICancelAppointmentView
    {
        private CancelAppointmentController _controller;
        public static APTDETAILS AppointmentToDelete;

        public CancelAppointment()
        {
            InitializeComponent();
            _controller = new CancelAppointmentController(this);


        }

        public void SetController(CancelAppointmentController controller)
        {
            _controller = controller;
        }



        private void CancelAppointButton_Click(object sender, EventArgs e)
        {
            //Log();
            try
            {
                _controller.DeleteAppointment(AppointmentToDelete);
                MessageBox.Show("Aftalen er nu aflyst.", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                var createAppointmentForm = Application.OpenForms["CreateAppointment"];
                createAppointmentForm.Close();



            }
            catch (Exception ex)
            {
                
            }





        }

        //private void Log()
        //{
        //    USERS deleter = (USERS)cancelUserBox.SelectedItem;

        //    if (cuCancelRadio.Checked)
        //    {
        //        Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + reasonCancel);
        //        controller.noShowDic.Add(d++, deleter);
        //    }
        //    if (cuCancelPhoneRadio.Checked)
        //    {
        //        Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + " Kunden har aflyst telefonisk.");
        //    }
        //    if (cuCancelShownRadio.Checked)
        //    {
        //        Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + " Kunden har aflyst ved personligt fremmøde.");
        //    }
        //    if (cuCancelElseRadio.Checked && cuCancelReasonBox.Text != null)
        //    {
        //        Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi " + cuCancelReasonBox.Text);
        //    }
          
        //    if (cuCancelElseRadio.Checked)
        //    {
        //        Logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + elseCancel);
        //        controller.cancelElseDic.Add(d++, deleter);
        //    }
        //    else if (!cuCancelRadio.Checked || cuCancelPhoneRadio.Checked || cuCancelShownRadio.Checked || cuCancelElseRadio.Checked)
        //    {
        //        throw new ArgumentException("Du skal vælge en af de angivede muligheder!");
        //    }
        //    if (deleter == null)
        //    {
        //        throw new ArgumentException("Du skal vælge medarbejderen som aflyser aftalen");
        //    }


        //}



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void cuCancelElseRadio_CheckedChanged(object sender, EventArgs e)
        //{
        //    cuCancelReasonBox.Enabled = true;
        //}


    }
}
