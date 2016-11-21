using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        CustomerLibraryController controller = new CustomerLibraryController();
        public CreateCustomer()
        {
            InitializeComponent();

            userCombo.Items.Add(controller.GetUser());
        }
        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            USERS creater = (USERS)userCombo.SelectedItem;
            
            CUSTOMERS customer = new CUSTOMERS();
            customer.CS_CPRNO = cprBox.Text;
            customer.CS_FIRSTNAME = firstNameBox.Text;
            customer.CS_LASTNAME = LastNameBox.Text;
            customer.CS_ADRESS1 = adressBox.Text;
            customer.CS_EMAIL = emailBox.Text;
            customer.CS_PHONEMOBILE = phoneBox.Text;

            if (createCustomer2Button.Text == "Gem")
            {
                Logger.LogThisLine("ansatte: " + creater + " har ændret en kunde ved navn: " + firstNameBox.Text + " " + LastNameBox.Text);
            }
            else if (createCustomer2Button.Text == "Opret")
            {
                Logger.LogThisLine("ansatte: " + creater + " har oprettet en ny kunde ved navn: " + firstNameBox.Text + " " + LastNameBox.Text);
            }



        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
