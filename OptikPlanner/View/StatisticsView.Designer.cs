using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using OptikPlanner.Model;

namespace OptikPlanner.View
{
    partial class StatisticsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chooseTypeCombo = new System.Windows.Forms.ComboBox();
            this.DatoLabel = new System.Windows.Forms.Label();
            this.chooseDataLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.compareLabel = new System.Windows.Forms.Label();
            this.chooseViewLabel = new System.Windows.Forms.Label();
            this.chooseViewButton = new System.Windows.Forms.Button();
            this.chooseperiodLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.compareMonthLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.showMonthCombo = new System.Windows.Forms.ComboBox();
            this.showYearCombo = new System.Windows.Forms.ComboBox();
            this.compareMonthCombo = new System.Windows.Forms.ComboBox();
            this.compareYearCombo = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.resetButton = new System.Windows.Forms.Button();
            this.filterListBox = new System.Windows.Forms.CheckedListBox();
            this.showAllCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseTypeCombo
            // 
            this.chooseTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseTypeCombo.FormattingEnabled = true;
            this.chooseTypeCombo.Items.AddRange(new object[] {
            "Aflysninger",
            "Lokaler",
            "Medarbejdere"});
            this.chooseTypeCombo.Location = new System.Drawing.Point(11, 34);
            this.chooseTypeCombo.Name = "chooseTypeCombo";
            this.chooseTypeCombo.Size = new System.Drawing.Size(135, 21);
            this.chooseTypeCombo.TabIndex = 0;
            this.chooseTypeCombo.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // DatoLabel
            // 
            this.DatoLabel.AutoSize = true;
            this.DatoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatoLabel.Location = new System.Drawing.Point(8, 73);
            this.DatoLabel.Name = "DatoLabel";
            this.DatoLabel.Size = new System.Drawing.Size(152, 13);
            this.DatoLabel.TabIndex = 8;
            this.DatoLabel.Text = "Vælg fremvisningsperiode";
            // 
            // chooseDataLabel
            // 
            this.chooseDataLabel.AutoSize = true;
            this.chooseDataLabel.Location = new System.Drawing.Point(13, 131);
            this.chooseDataLabel.Name = "chooseDataLabel";
            this.chooseDataLabel.Size = new System.Drawing.Size(32, 13);
            this.chooseDataLabel.TabIndex = 11;
            this.chooseDataLabel.Text = "Vælg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Type";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(192, 37);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(416, 273);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // compareLabel
            // 
            this.compareLabel.AutoSize = true;
            this.compareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareLabel.Location = new System.Drawing.Point(8, 231);
            this.compareLabel.Name = "compareLabel";
            this.compareLabel.Size = new System.Drawing.Size(147, 13);
            this.compareLabel.TabIndex = 16;
            this.compareLabel.Text = "Sammenlign periode med";
            // 
            // chooseViewLabel
            // 
            this.chooseViewLabel.AutoSize = true;
            this.chooseViewLabel.Location = new System.Drawing.Point(436, 9);
            this.chooseViewLabel.Name = "chooseViewLabel";
            this.chooseViewLabel.Size = new System.Drawing.Size(88, 13);
            this.chooseViewLabel.TabIndex = 17;
            this.chooseViewLabel.Text = "Vælg fremvisning";
            // 
            // chooseViewButton
            // 
            this.chooseViewButton.Location = new System.Drawing.Point(530, 4);
            this.chooseViewButton.Name = "chooseViewButton";
            this.chooseViewButton.Size = new System.Drawing.Size(75, 23);
            this.chooseViewButton.TabIndex = 18;
            this.chooseViewButton.Text = "Grafisk";
            this.chooseViewButton.UseVisualStyleBackColor = true;
            this.chooseViewButton.Click += new System.EventHandler(this.chooseViewButton_Click);
            // 
            // chooseperiodLabel
            // 
            this.chooseperiodLabel.AutoSize = true;
            this.chooseperiodLabel.Location = new System.Drawing.Point(8, 86);
            this.chooseperiodLabel.Name = "chooseperiodLabel";
            this.chooseperiodLabel.Size = new System.Drawing.Size(39, 13);
            this.chooseperiodLabel.TabIndex = 19;
            this.chooseperiodLabel.Text = "måned";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "år";
            // 
            // compareMonthLabel
            // 
            this.compareMonthLabel.AutoSize = true;
            this.compareMonthLabel.Location = new System.Drawing.Point(8, 244);
            this.compareMonthLabel.Name = "compareMonthLabel";
            this.compareMonthLabel.Size = new System.Drawing.Size(39, 13);
            this.compareMonthLabel.TabIndex = 21;
            this.compareMonthLabel.Text = "måned";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "år";
            // 
            // showMonthCombo
            // 
            this.showMonthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.showMonthCombo.FormattingEnabled = true;
            this.showMonthCombo.Location = new System.Drawing.Point(11, 102);
            this.showMonthCombo.Name = "showMonthCombo";
            this.showMonthCombo.Size = new System.Drawing.Size(54, 21);
            this.showMonthCombo.TabIndex = 23;
            this.showMonthCombo.SelectedIndexChanged += new System.EventHandler(this.showMonthCombo_SelectedIndexChanged);
            // 
            // showYearCombo
            // 
            this.showYearCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.showYearCombo.FormattingEnabled = true;
            this.showYearCombo.Location = new System.Drawing.Point(74, 102);
            this.showYearCombo.Name = "showYearCombo";
            this.showYearCombo.Size = new System.Drawing.Size(72, 21);
            this.showYearCombo.TabIndex = 24;
            this.showYearCombo.SelectedIndexChanged += new System.EventHandler(this.showYearCombo_SelectedIndexChanged);
            // 
            // compareMonthCombo
            // 
            this.compareMonthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compareMonthCombo.FormattingEnabled = true;
            this.compareMonthCombo.Location = new System.Drawing.Point(10, 260);
            this.compareMonthCombo.Name = "compareMonthCombo";
            this.compareMonthCombo.Size = new System.Drawing.Size(55, 21);
            this.compareMonthCombo.TabIndex = 25;
            this.compareMonthCombo.SelectedIndexChanged += new System.EventHandler(this.compareMonthCombo_SelectedIndexChanged);
            // 
            // compareYearCombo
            // 
            this.compareYearCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compareYearCombo.FormattingEnabled = true;
            this.compareYearCombo.Location = new System.Drawing.Point(74, 260);
            this.compareYearCombo.Name = "compareYearCombo";
            this.compareYearCombo.Size = new System.Drawing.Size(72, 21);
            this.compareYearCombo.TabIndex = 26;
            // 
            // SearchButton
            // 
            this.SearchButton.Enabled = false;
            this.SearchButton.Location = new System.Drawing.Point(10, 287);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(81, 23);
            this.SearchButton.TabIndex = 27;
            this.SearchButton.Text = "Sammenlign statistik";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Gray;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(192, 37);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.CustomProperties = "PieLineColor=Black, PieLabelStyle=Outside";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(416, 273);
            this.chart1.TabIndex = 28;
            this.chart1.Text = "chart1";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(93, 287);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(53, 23);
            this.resetButton.TabIndex = 29;
            this.resetButton.Text = "Nulstil";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // filterListBox
            // 
            this.filterListBox.CheckOnClick = true;
            this.filterListBox.FormattingEnabled = true;
            this.filterListBox.Location = new System.Drawing.Point(10, 164);
            this.filterListBox.Name = "filterListBox";
            this.filterListBox.Size = new System.Drawing.Size(120, 64);
            this.filterListBox.TabIndex = 31;
            this.filterListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.filterListBox_ItemCheck);
            // 
            // showAllCheckBox
            // 
            this.showAllCheckBox.AutoSize = true;
            this.showAllCheckBox.Location = new System.Drawing.Point(12, 147);
            this.showAllCheckBox.Name = "showAllCheckBox";
            this.showAllCheckBox.Size = new System.Drawing.Size(59, 17);
            this.showAllCheckBox.TabIndex = 32;
            this.showAllCheckBox.Text = "Vis alle";
            this.showAllCheckBox.UseVisualStyleBackColor = true;
            this.showAllCheckBox.CheckedChanged += new System.EventHandler(this.showAllCheckBox_CheckedChanged);
            // 
            // StatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 339);
            this.Controls.Add(this.showAllCheckBox);
            this.Controls.Add(this.filterListBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.chooseTypeCombo);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.compareYearCombo);
            this.Controls.Add(this.compareMonthCombo);
            this.Controls.Add(this.showYearCombo);
            this.Controls.Add(this.showMonthCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.compareMonthLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chooseperiodLabel);
            this.Controls.Add(this.chooseViewButton);
            this.Controls.Add(this.chooseViewLabel);
            this.Controls.Add(this.compareLabel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chooseDataLabel);
            this.Controls.Add(this.DatoLabel);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StatisticsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Statistik visning";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


   

        #endregion

        private System.Windows.Forms.ComboBox chooseTypeCombo;
        private Label DatoLabel;
        private Label chooseDataLabel;
        private Label label3;
        private ListView listView1;
        private Label compareLabel;
        private Label chooseViewLabel;
        private Button chooseViewButton;
        private Label chooseperiodLabel;
        private Label label4;
        private Label compareMonthLabel;
        private Label label6;
        private ComboBox showMonthCombo;
        private ComboBox showYearCombo;
        private ComboBox compareMonthCombo;
        private ComboBox compareYearCombo;
        private Button SearchButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button resetButton;
        private CheckedListBox filterListBox;
        private CheckBox showAllCheckBox;
    }
}