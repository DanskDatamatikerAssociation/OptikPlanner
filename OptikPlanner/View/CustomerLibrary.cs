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
        CustomerLibraryController _controller = new CustomerLibraryController();
        public static bool FromAppointmentCreation { get; set; }
        public CustomerLibrary()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            ListViewBox.Clear();
            FillInView();
            ListViewBox.View = System.Windows.Forms.View.Details;

            ListViewBox.Columns.Add("CPR Nummer", 100);
            ListViewBox.Columns.Add("Fornavn", 100);
            ListViewBox.Columns.Add("Efternavn", 100);
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer window = new CreateCustomer();
            

            window.createCustomerButtonOK.Text = "Gem";
            
            window.cprBox.Enabled = false;
            var test = ListViewBox.SelectedItems;

            window.cprBox.Text = test[0].SubItems[0].Text;
            window.firstNameBox.Text = test[0].SubItems[1].Text;
            window.LastNameBox.Text = test[0].SubItems[2].Text;

            foreach (var s in _controller.GetCustomers())
            {
                if (test[0].SubItems[0].Text.Equals(s.CS_CPRNO))
                {
                    window.adressBox.Text = s.CS_ADRESS1;
                    window.phoneBox.Text = s.CS_PHONEMOBILE;
                    window.emailBox.Text = s.CS_EMAIL;
                }
            }

            window.ShowDialog();

            if (window.createCustomerButtonOK.DialogResult == DialogResult.OK)
            {
                ListViewBox.Items.Clear();
                FillInView();
                
            }
            

        }

        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            //opret ikke eksisterende kunde

            CreateCustomer window = new CreateCustomer();

            window.createCustomerButtonOK.Text = "Opret";
            //window.ShowDialog();

            if (window.ShowDialog() == DialogResult.OK)
            {
                ListViewBox.Items.Clear();
                FillInView();
                window.Close();
            }
        }

        public void FillInView()
        {
            foreach (var s in _controller.GetCustomers())
            {
                var item = ListViewBox.Items.Add(new ListViewItem(new string[] { s.CS_CPRNO, s.CS_FIRSTNAME, s.CS_LASTNAME }));
                item.Tag = s;
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            CUSTOMERS customer = (CUSTOMERS)ListViewBox.SelectedItems[0].Tag;

            for (int i = 0; i < ListViewBox.Items.Count; i++)
                    {
                        if (ListViewBox.Items[i].Selected)
                        {
                            ListViewBox.Items[i].Remove();
                            i--;
                        }
                    }

            _controller.DeleteCustomer(customer);
        }
        

        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ListViewBox_DoubleClick(object sender, EventArgs e)
        {
            CUSTOMERS selectedCustomer = (CUSTOMERS) ListViewBox.SelectedItems[0].Tag;
            if (FromAppointmentCreation)
            {
                CreateAppointment.SelectedCustomer = selectedCustomer;
                FromAppointmentCreation = false;
                this.Close();
            }
            else if (ListViewBox.SelectedItems.Count == 1)
            {
                editCustomerButton_Click(sender, e);
            }


        }

        private void ListViewBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteCustomerButton.Enabled = true;
            editCustomerButton.Enabled = true;
            if (ListViewBox.SelectedItems.Count < 1)
            {
                deleteCustomerButton.Enabled = false;
                editCustomerButton.Enabled = false;
            }
            
        }
        private void cprBox_TextChanged(object sender, EventArgs e)
        {
            ListViewBox.Items.Clear(); // clear list items before adding 
                                       // filter the items match with search key and add result to list view 
            ListViewBox.Items.AddRange(_controller.GetCustomers()
                .Where(i => string.IsNullOrEmpty(cprBox.Text) || i.CS_CPRNO.StartsWith(cprBox.Text))
                .Select(c => new ListViewItem(new string[] {c.CS_CPRNO, c.CS_FIRSTNAME, c.CS_LASTNAME})).ToArray());
        }
      }
    }
