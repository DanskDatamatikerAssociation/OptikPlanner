using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptikPlanner.View
{
    public partial class CreateAppointment : Form
    {
        public CreateAppointment()
        {
            InitializeComponent();
            timeFromPicker.CustomFormat = "hh mm";
            timeToPicker.CustomFormat = "hh mm";
            timeFromPicker.ShowUpDown = true;
            timeToPicker.ShowUpDown = true;
            userSelectionCombo.Text = "Vælg medarbejder...";

        }

        private void cprBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void aftaleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lokaleCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void telefonBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void smsCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void emailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void beskrivelseBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelAppointmentButton_Click(object sender, EventArgs e)
        {

        }
    }
}
