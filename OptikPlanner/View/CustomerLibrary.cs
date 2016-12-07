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

        public CustomerLibrary()
        {
            InitializeComponent();
            ListViewBox.Clear();
            FillInView();
            ListViewBox.View = System.Windows.Forms.View.Details;

           // InitializeCprBox();
        }

        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer window = new CreateCustomer();
           // window.editorLabel.Text = "Retter";
            window.createCustomer2Button.Text = "Gem";
            window.cprBox.Enabled = false;
            var test = ListViewBox.SelectedItems;

            window.cprBox.Text = test[0].SubItems[0].Text;
            window.firstNameBox.Text = test[0].SubItems[1].Text;
            window.LastNameBox.Text = test[0].SubItems[2].Text;

            foreach (var s in CustomerLibraryController.GetCustomer())
            {
                if (test[0].SubItems[0].Text.Equals(s.CS_CPRNO))
                {
                    window.adressBox.Text = s.CS_ADRESS1;
                    window.phoneBox.Text = s.CS_PHONEMOBILE;
                    window.emailBox.Text = s.CS_EMAIL;
                }
            }

            if (window.ShowDialog() == DialogResult.OK)
            {
                FillInView();
            }
        }

        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            //opret ikke eksisterende kunde
            CreateCustomer window = new CreateCustomer();
            //window.editorLabel.Text = "Opretter";
            window.createCustomer2Button.Text = "Opret";
            window.ShowDialog();
        }

        public void FillInView()
        {
            ListViewBox.Columns.Add("CPR Nummer", 100);
            ListViewBox.Columns.Add("Fornavn", 100);
            ListViewBox.Columns.Add("Efternavn", 100);

            foreach (var s in CustomerLibraryController.GetCustomer())
            {
                ListViewBox.Items.Add(new ListViewItem(new string[] { s.CS_CPRNO, s.CS_FIRSTNAME, s.CS_LASTNAME }));
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
           
                    for (int i = 0; i < ListViewBox.Items.Count; i++)
                    {
                        if (ListViewBox.Items[i].Selected)
                        {
                            ListViewBox.Items[i].Remove();
                            i--;
                        }
                    }
                }
        

        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ListViewBox_DoubleClick(object sender, EventArgs e)
        {
            
            if (ListViewBox.SelectedItems.Count == 1)
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
            ListViewBox.Items.AddRange(CustomerLibraryController.GetCustomer()
                .Where(i => string.IsNullOrEmpty(cprBox.Text) || i.CS_CPRNO.StartsWith(cprBox.Text))
                .Select(c => new ListViewItem(new string[] {c.CS_CPRNO, c.CS_FIRSTNAME, c.CS_LASTNAME})).ToArray());
        }
      }
    }
