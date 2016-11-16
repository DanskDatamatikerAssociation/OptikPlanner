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
using OptikPlanner.Controller;
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    public partial class CancelAppointment : Form
    {
        CancelAppointmentController controller = new CancelAppointmentController();
        CreateAppointmentController controlz = new CreateAppointmentController();


        public CancelAppointment()
        {
            InitializeComponent();
            cancelUserBox.Items.Add(controlz.GetUser());

        }

        private void CancelAppointButton_Click(object sender, EventArgs e)
        {
            USERS deleter = (USERS) cancelUserBox.SelectedItem;
        }
    }
}
