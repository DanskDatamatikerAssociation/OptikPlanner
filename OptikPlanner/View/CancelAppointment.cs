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
        OptikItDbContext db = new OptikItDbContext();

        CancelAppointmentController controller = new CancelAppointmentController();
        Logger logger = new Logger();
        int d = 1;


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
                logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + reasonCancel);
                controller.noShowDic.Add(deleter, reasonCancel);
                controller.noShowList.Add(reasonCancel);            }
            if(cuCancelPhoneRadio.Checked)
            {
                logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + phoneCancel);
                controller.cancelPhoneDic.Add(deleter, phoneCancel);
                controller.cancelPhoneList.Add(phoneCancel);
            }

            if (cuCancelElseRadio.Checked)
            {
                logger.LogThisLine("ansatte: " + deleter + " har aflyst denne aftale fordi" + elseCancel);
                controller.cancelElseDic.Add(deleter, elseCancel);
                controller.cancelElseList.Add(elseCancel);
            }
            else if(!cuCancelRadio.Checked || cuCancelPhoneRadio.Checked || cuCancelElseRadio.Checked)
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
        
        
    }
}
