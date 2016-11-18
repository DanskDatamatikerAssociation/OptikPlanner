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
    public partial class CustomerLibrary : Form
    {
        CustomerLibraryController controller = new CustomerLibraryController();
        public CustomerLibrary()
        {
            InitializeComponent();
            ListViewBox.Columns.Add("CPR Nummer", 100);
            ListViewBox.Columns.Add("Fornavn", 100);
            ListViewBox.Columns.Add("Efternavn", 100);
            ListViewBox.Items.Add(new ListViewItem(new string[] { controller.GetCustomer().CS_CPRNO, controller.GetCustomer().CS_FIRSTNAME, controller.GetCustomer().CS_LASTNAME}));
            ListViewBox.View = System.Windows.Forms.View.Details;
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer window = new CreateCustomer();
            createCustomer2Buttom.Text = "Rediger";

            var test = ListViewBox.SelectedItems;

            var cpr = test[0].SubItems[0].Text = controller.GetCustomer().CS_CPRNO;
            var fornavn = test[0].SubItems[1].Text = controller.GetCustomer().CS_FIRSTNAME;
            var efternavn = test[0].SubItems[2].Text = controller.GetCustomer().CS_LASTNAME;

            window.cprBox.Text = cpr;
            window.firstNameBox.Text = fornavn;
            window.LastNameBox.Text = efternavn;
            window.adressBox.Text = controller.GetCustomer().CS_ADRESS1;
            window.emailBox.Text = controller.GetCustomer().CS_EMAIL;
            window.phoneBox.Text = controller.GetCustomer().CS_PHONEMOBILE;
            //skal vise markeret kunde fra list viewet
            window.ShowDialog();




        }

        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            //opret ikke eksisterende kunde
            CreateCustomer window = new CreateCustomer();
            createCustomer2Button.Text = "Opret";
            window.ShowDialog();

        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            //USERS deleter = (USERS)cancelUserBox.SelectedItem;
            //Logger.LogThisLine("ansatte: " + deleter + " har slettet en kunde ved navn: " + firstNameBox + " beskrivelse: " + beskrivelseBox);

        }

        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cprBox_OnTextChanged(object sender, EventArgs e)
        {
            if (cprBox.Text == controller.GetCustomer().CS_CPRNO)
            {

            }
        }
    }
}
