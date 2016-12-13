using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OptikPlanner.Controller;
using OptikPlanner.Misc;
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    public partial class CreateCustomer : Form
    {
        CustomerLibraryController _controller = new CustomerLibraryController();
        public CreateCustomer()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }
        private void createCustomerButton_Click(object sender, EventArgs e)
        {
           // USERS creater = (USERS)userCombo.SelectedItem;
            CUSTOMERS customer = new CUSTOMERS();

            customer.CS_CPRNO = cprBox.Text;
            customer.CS_FIRSTNAME = firstNameBox.Text;
            customer.CS_LASTNAME = LastNameBox.Text;
            customer.CS_ADRESS1 = adressBox.Text;
            customer.CS_EMAIL = emailBox.Text;
            customer.CS_PHONEMOBILE = phoneBox.Text;

            if (createCustomerButtonOK.Text == "Gem")
            {
                _controller.PutCustomer(customer);
                Trace.WriteLine($"\n Ny kunde med navn: {firstNameBox.Text} {LastNameBox.Text} er blevet oprettet d. {DateTime.Now}");
            }
            if (createCustomerButtonOK.Text == "Opret")
            {
                _controller.PostCustomer(customer);
                Trace.WriteLine($"\n Ny kunde med navn: {firstNameBox.Text} {LastNameBox.Text} er blevet rettet i d. {DateTime.Now}");
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
