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
    public partial class StatisticsView : Form
    {
        public StatisticsView()
        {
            InitializeComponent();

            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.ShowUpDown = true;



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Aflysninger", 155);
                listView1.Columns.Add("Mødte ikke op", 100);
                listView1.Columns.Add("Telefon", 100);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Lokale", 155);
                listView1.Columns.Add("Type", 100);
                listView1.Columns.Add("Tilgængelighed", 100);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                listView1.Columns.Clear();
                listView1.Columns.Add("Navn", 155);
                listView1.Columns.Add("Mødte ikke op", 100);
                listView1.Columns.Add("Opkald", 100);

            }

        }

    }
}
