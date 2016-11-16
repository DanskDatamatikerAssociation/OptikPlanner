namespace OptikPlanner
{
    partial class CalendarView
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
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.calendar = new System.Windows.Forms.Calendar.Calendar();
            this.monthView2 = new System.Windows.Forms.Calendar.MonthView();
            this.todayButton = new System.Windows.Forms.Button();
            this.twoWeeksButton = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.monthViewButton = new System.Windows.Forms.Button();
            this.weekViewButton = new System.Windows.Forms.Button();
            this.dayViewButton = new System.Windows.Forms.Button();
            this.newAppointmentButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indstillingerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.weekLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.calendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar.Location = new System.Drawing.Point(208, 97);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(901, 462);
            this.calendar.TabIndex = 0;
            this.calendar.TabStop = false;
            this.calendar.Text = "Calendar";
            this.calendar.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.FifteenMinutes;
            this.calendar.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar_LoadItems);
            this.calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            // 
            // monthView2
            // 
            this.monthView2.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView2.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.monthView2.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView2.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView2.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView2.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView2.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView2.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView2.Location = new System.Drawing.Point(2, 97);
            this.monthView2.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView2.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView2.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView2.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView2.Name = "monthView2";
            this.monthView2.Size = new System.Drawing.Size(200, 286);
            this.monthView2.TabIndex = 2;
            this.monthView2.Text = "monthView";
            this.monthView2.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView2.SelectionChanged += new System.EventHandler(this.monthView2_SelectionChanged);
            // 
            // todayButton
            // 
            this.todayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.todayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todayButton.Location = new System.Drawing.Point(154, 25);
            this.todayButton.Name = "todayButton";
            this.todayButton.Size = new System.Drawing.Size(90, 66);
            this.todayButton.TabIndex = 4;
            this.todayButton.Text = "I dag";
            this.todayButton.UseVisualStyleBackColor = true;
            this.todayButton.Click += new System.EventHandler(this.todayButton_Click);
            // 
            // twoWeeksButton
            // 
            this.twoWeeksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoWeeksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoWeeksButton.Location = new System.Drawing.Point(250, 25);
            this.twoWeeksButton.Name = "twoWeeksButton";
            this.twoWeeksButton.Size = new System.Drawing.Size(90, 66);
            this.twoWeeksButton.TabIndex = 5;
            this.twoWeeksButton.Text = "14 Dage";
            this.twoWeeksButton.UseVisualStyleBackColor = true;
            this.twoWeeksButton.Click += new System.EventHandler(this.twoWeeksButton_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(867, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 66);
            this.button8.TabIndex = 11;
            this.button8.Text = "Kunder";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(963, 25);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 66);
            this.button9.TabIndex = 12;
            this.button9.Text = "Log";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mogens",
            "Mads",
            "Morten",
            "Mis"});
            this.comboBox1.Location = new System.Drawing.Point(2, 401);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Text = "Kunder";
            this.comboBox1.UseWaitCursor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(2, 454);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.Text = "Lokaler";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(2, 503);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(200, 21);
            this.comboBox3.TabIndex = 16;
            this.comboBox3.Text = "Medarbejdere";
            // 
            // monthViewButton
            // 
            this.monthViewButton.BackColor = System.Drawing.SystemColors.Window;
            this.monthViewButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.monthViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monthViewButton.Location = new System.Drawing.Point(538, 25);
            this.monthViewButton.Name = "monthViewButton";
            this.monthViewButton.Size = new System.Drawing.Size(90, 66);
            this.monthViewButton.TabIndex = 8;
            this.monthViewButton.Text = "Månedsvisning";
            this.monthViewButton.UseVisualStyleBackColor = false;
            this.monthViewButton.Click += new System.EventHandler(this.monthViewButton_Click);
            // 
            // weekViewButton
            // 
            this.weekViewButton.BackColor = System.Drawing.SystemColors.Window;
            this.weekViewButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.weekViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weekViewButton.Location = new System.Drawing.Point(442, 25);
            this.weekViewButton.Name = "weekViewButton";
            this.weekViewButton.Size = new System.Drawing.Size(90, 66);
            this.weekViewButton.TabIndex = 7;
            this.weekViewButton.Text = "Ugevisning";
            this.weekViewButton.UseVisualStyleBackColor = false;
            this.weekViewButton.Click += new System.EventHandler(this.weekViewButton_Click);
            // 
            // dayViewButton
            // 
            this.dayViewButton.BackColor = System.Drawing.SystemColors.Window;
            this.dayViewButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.dayViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dayViewButton.Location = new System.Drawing.Point(346, 25);
            this.dayViewButton.Name = "dayViewButton";
            this.dayViewButton.Size = new System.Drawing.Size(90, 66);
            this.dayViewButton.TabIndex = 6;
            this.dayViewButton.Text = "Dagsvisning";
            this.dayViewButton.UseVisualStyleBackColor = false;
            this.dayViewButton.Click += new System.EventHandler(this.dayViewButton_Click);
            // 
            // newAppointmentButton
            // 
            this.newAppointmentButton.BackColor = System.Drawing.SystemColors.Window;
            this.newAppointmentButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.newAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAppointmentButton.Location = new System.Drawing.Point(2, 25);
            this.newAppointmentButton.Name = "newAppointmentButton";
            this.newAppointmentButton.Size = new System.Drawing.Size(140, 67);
            this.newAppointmentButton.TabIndex = 3;
            this.newAppointmentButton.Text = "Ny aftale";
            this.newAppointmentButton.UseVisualStyleBackColor = false;
            this.newAppointmentButton.Click += new System.EventHandler(this.newAppointmentButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIlerToolStripMenuItem,
            this.indstillingerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1116, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIlerToolStripMenuItem
            // 
            this.fIlerToolStripMenuItem.Name = "fIlerToolStripMenuItem";
            this.fIlerToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fIlerToolStripMenuItem.Text = "FIler";
            // 
            // indstillingerToolStripMenuItem
            // 
            this.indstillingerToolStripMenuItem.Name = "indstillingerToolStripMenuItem";
            this.indstillingerToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.indstillingerToolStripMenuItem.Text = "Indstillinger";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            ""});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 426);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(202, 19);
            this.checkedListBox1.TabIndex = 19;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            ""});
            this.checkedListBox2.Location = new System.Drawing.Point(0, 478);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(202, 19);
            this.checkedListBox2.TabIndex = 20;
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Items.AddRange(new object[] {
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            "Danny",
            ""});
            this.checkedListBox3.Location = new System.Drawing.Point(0, 530);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(202, 19);
            this.checkedListBox3.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(700, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Uge -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(754, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 23;
            // 
            // monthlabel
            // 
            this.monthlabel.Location = new System.Drawing.Point(0, 0);
            this.monthlabel.Name = "monthlabel";
            this.monthlabel.Size = new System.Drawing.Size(100, 23);
            this.monthlabel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(754, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(666, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(754, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "label5";
            // 
            // weekLabel
            // 
            this.weekLabel.AutoSize = true;
            this.weekLabel.Location = new System.Drawing.Point(742, 34);
            this.weekLabel.Name = "weekLabel";
            this.weekLabel.Size = new System.Drawing.Size(35, 13);
            this.weekLabel.TabIndex = 22;
            this.weekLabel.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(742, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "label7";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(742, 68);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(35, 13);
            this.yearLabel.TabIndex = 24;
            this.yearLabel.Text = "label8";
            // 
            // CalendarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1116, 588);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.weekLabel);
            this.Controls.Add(this.checkedListBox3);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.monthViewButton);
            this.Controls.Add(this.weekViewButton);
            this.Controls.Add(this.dayViewButton);
            this.Controls.Add(this.twoWeeksButton);
            this.Controls.Add(this.todayButton);
            this.Controls.Add(this.newAppointmentButton);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.monthView2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CalendarView";
            this.Text = "OptikPlanner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar calendar;
        private System.Windows.Forms.Calendar.MonthView monthView2;
        private System.Windows.Forms.Button newAppointmentButton;
        private System.Windows.Forms.Button todayButton;
        private System.Windows.Forms.Button twoWeeksButton;
        private System.Windows.Forms.Button dayViewButton;
        private System.Windows.Forms.Button weekViewButton;
        private System.Windows.Forms.Button monthViewButton;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indstillingerToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label monthlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label weekLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label yearLabel;
    }
}

