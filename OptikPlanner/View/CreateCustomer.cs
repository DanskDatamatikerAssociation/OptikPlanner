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
        public CreateCustomer()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            //userCombo.Items.Add(CustomerLibraryController.GetUser());
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

            if (createCustomer2Button.Text == "Gem")
            {
                foreach (var s in CustomerLibraryController.GetCustomer())
                {
                    if (s.CS_CPRNO.Equals(cprBox.Text))
                    {
                        s.CS_CPRNO = cprBox.Text;
                        s.CS_FIRSTNAME = firstNameBox.Text;
                        s.CS_LASTNAME = LastNameBox.Text;
                        s.CS_ADRESS1 = adressBox.Text;
                        s.CS_EMAIL = emailBox.Text;
                        s.CS_PHONEMOBILE = phoneBox.Text;
                        
                    }
                }
                //Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + creater + " har ændret en kunde ved navn: " + firstNameBox.Text + " " + LastNameBox.Text);
            }
            else if (createCustomer2Button.Text == "Opret")
            {
                CustomerLibraryController.GetCustomer().Add(customer);
                //Trace.WriteLine($"\n{DateTime.Now}: ansatte: " + creater + " har oprettet en ny kunde ved navn: " + firstNameBox.Text + " " + LastNameBox.Text);
            }

            this.Close();
            

        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
