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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange11 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange12 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange13 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange14 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange15 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarView));
            this.calendar = new System.Windows.Forms.Calendar.Calendar();
            this.monthView = new System.Windows.Forms.Calendar.MonthView();
            this.todayButton = new System.Windows.Forms.Button();
            this.twoWeeksButton = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.weekLabel = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.calendarButtonLeft = new System.Windows.Forms.Button();
            this.calendarButtonRight = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.AllowItemEdit = false;
            this.calendar.AllowItemResize = false;
            this.calendar.AllowNew = false;
            this.calendar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.calendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendar.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange11.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange11.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange11.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange12.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange12.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange12.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange13.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange13.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange13.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange14.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange14.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange14.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange15.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange15.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange15.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange11,
        calendarHighlightRange12,
        calendarHighlightRange13,
        calendarHighlightRange14,
        calendarHighlightRange15};
            this.calendar.ItemsTimeFormat = "hh:MM tt";
            this.calendar.Location = new System.Drawing.Point(208, 107);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(901, 452);
            this.calendar.TabIndex = 0;
            this.calendar.TabStop = false;
            this.calendar.Text = "Calendar";
            this.calendar.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar_LoadItems);
            this.calendar.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            this.calendar.DoubleClick += new System.EventHandler(this.calendar_DoubleClick);
            this.calendar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.calendar_MouseMove);
            // 
            // monthView
            // 
            this.monthView.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.monthView.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView.Location = new System.Drawing.Point(2, 107);
            this.monthView.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView.Name = "monthView";
            this.monthView.Size = new System.Drawing.Size(200, 276);
            this.monthView.TabIndex = 2;
            this.monthView.Text = "monthView";
            this.monthView.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView.SelectionChanged += new System.EventHandler(this.monthView2_SelectionChanged);
            // 
            // todayButton
            // 
            this.todayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.todayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todayButton.Image = ((System.Drawing.Image)(resources.GetObject("todayButton.Image")));
            this.todayButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.todayButton.Location = new System.Drawing.Point(154, 25);
            this.todayButton.Name = "todayButton";
            this.todayButton.Size = new System.Drawing.Size(90, 77);
            this.todayButton.TabIndex = 4;
            this.todayButton.Text = "I dag";
            this.todayButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.todayButton.UseVisualStyleBackColor = true;
            this.todayButton.Click += new System.EventHandler(this.todayButton_Click);
            // 
            // twoWeeksButton
            // 
            this.twoWeeksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoWeeksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoWeeksButton.Image = ((System.Drawing.Image)(resources.GetObject("twoWeeksButton.Image")));
            this.twoWeeksButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.twoWeeksButton.Location = new System.Drawing.Point(250, 25);
            this.twoWeeksButton.Name = "twoWeeksButton";
            this.twoWeeksButton.Size = new System.Drawing.Size(90, 76);
            this.twoWeeksButton.TabIndex = 5;
            this.twoWeeksButton.Text = "14 Dage";
            this.twoWeeksButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.twoWeeksButton.UseVisualStyleBackColor = true;
            this.twoWeeksButton.Click += new System.EventHandler(this.twoWeeksButton_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button8.Location = new System.Drawing.Point(840, 26);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 76);
            this.button8.TabIndex = 11;
            this.button8.Text = "Kunder";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // logButton
            // 
            this.logButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logButton.Image = ((System.Drawing.Image)(resources.GetObject("logButton.Image")));
            this.logButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.logButton.Location = new System.Drawing.Point(936, 26);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(87, 76);
            this.logButton.TabIndex = 12;
            this.logButton.Text = "Log";
            this.logButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
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
            this.monthViewButton.Image = ((System.Drawing.Image)(resources.GetObject("monthViewButton.Image")));
            this.monthViewButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.monthViewButton.Location = new System.Drawing.Point(538, 25);
            this.monthViewButton.Name = "monthViewButton";
            this.monthViewButton.Size = new System.Drawing.Size(90, 76);
            this.monthViewButton.TabIndex = 8;
            this.monthViewButton.Text = "Månedsvisning";
            this.monthViewButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.monthViewButton.UseVisualStyleBackColor = false;
            this.monthViewButton.Click += new System.EventHandler(this.monthViewButton_Click);
            // 
            // weekViewButton
            // 
            this.weekViewButton.BackColor = System.Drawing.SystemColors.Window;
            this.weekViewButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.weekViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weekViewButton.Image = ((System.Drawing.Image)(resources.GetObject("weekViewButton.Image")));
            this.weekViewButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.weekViewButton.Location = new System.Drawing.Point(442, 25);
            this.weekViewButton.Name = "weekViewButton";
            this.weekViewButton.Size = new System.Drawing.Size(90, 76);
            this.weekViewButton.TabIndex = 7;
            this.weekViewButton.Text = "Ugevisning";
            this.weekViewButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.weekViewButton.UseVisualStyleBackColor = false;
            this.weekViewButton.Click += new System.EventHandler(this.weekViewButton_Click);
            // 
            // dayViewButton
            // 
            this.dayViewButton.BackColor = System.Drawing.SystemColors.Window;
            this.dayViewButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.dayViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dayViewButton.Image = ((System.Drawing.Image)(resources.GetObject("dayViewButton.Image")));
            this.dayViewButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.dayViewButton.Location = new System.Drawing.Point(346, 25);
            this.dayViewButton.Name = "dayViewButton";
            this.dayViewButton.Size = new System.Drawing.Size(90, 76);
            this.dayViewButton.TabIndex = 6;
            this.dayViewButton.Text = "Dagsvisning";
            this.dayViewButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.dayViewButton.UseVisualStyleBackColor = false;
            this.dayViewButton.Click += new System.EventHandler(this.dayViewButton_Click);
            // 
            // newAppointmentButton
            // 
            this.newAppointmentButton.BackColor = System.Drawing.SystemColors.Window;
            this.newAppointmentButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.newAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAppointmentButton.Image = ((System.Drawing.Image)(resources.GetObject("newAppointmentButton.Image")));
            this.newAppointmentButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newAppointmentButton.Location = new System.Drawing.Point(2, 25);
            this.newAppointmentButton.Name = "newAppointmentButton";
            this.newAppointmentButton.Size = new System.Drawing.Size(140, 77);
            this.newAppointmentButton.TabIndex = 3;
            this.newAppointmentButton.Text = "Ny aftale";
            this.newAppointmentButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newAppointmentButton.UseVisualStyleBackColor = false;
            this.newAppointmentButton.Click += new System.EventHandler(this.newAppointmentButton_Click);
            // 
            // menuStrip1
            // 
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
            this.weekLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekLabel.Location = new System.Drawing.Point(752, 26);
            this.weekLabel.Name = "weekLabel";
            this.weekLabel.Size = new System.Drawing.Size(36, 25);
            this.weekLabel.TabIndex = 22;
            this.weekLabel.Text = "46";
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthLabel.Location = new System.Drawing.Point(697, 49);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(110, 25);
            this.monthLabel.TabIndex = 23;
            this.monthLabel.Text = "November";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLabel.Location = new System.Drawing.Point(718, 69);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(60, 25);
            this.yearLabel.TabIndex = 24;
            this.yearLabel.Text = "2016";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(720, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "Uge";
            // 
            // calendarButtonLeft
            // 
            this.calendarButtonLeft.BackColor = System.Drawing.Color.Transparent;
            this.calendarButtonLeft.Image = global::OptikPlanner.Properties.Resources.arrow_left_small;
            this.calendarButtonLeft.Location = new System.Drawing.Point(694, 30);
            this.calendarButtonLeft.Name = "calendarButtonLeft";
            this.calendarButtonLeft.Size = new System.Drawing.Size(20, 21);
            this.calendarButtonLeft.TabIndex = 26;
            this.calendarButtonLeft.UseVisualStyleBackColor = false;
            this.calendarButtonLeft.Click += new System.EventHandler(this.calendarButtonLeft_Click);
            // 
            // calendarButtonRight
            // 
            this.calendarButtonRight.BackColor = System.Drawing.Color.Transparent;
            this.calendarButtonRight.Image = global::OptikPlanner.Properties.Resources.arrow_right_small;
            this.calendarButtonRight.Location = new System.Drawing.Point(787, 31);
            this.calendarButtonRight.Name = "calendarButtonRight";
            this.calendarButtonRight.Size = new System.Drawing.Size(20, 21);
            this.calendarButtonRight.TabIndex = 27;
            this.calendarButtonRight.UseVisualStyleBackColor = false;
            this.calendarButtonRight.Click += new System.EventHandler(this.calendarButtonRight_Click);
            // statisticShowButton
            // 
            this.statisticShowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticShowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticShowButton.Image = ((System.Drawing.Image)(resources.GetObject("statisticShowButton.Image")));
            this.statisticShowButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.statisticShowButton.Location = new System.Drawing.Point(1029, 25);
            this.statisticShowButton.Name = "statisticShowButton";
            this.statisticShowButton.Size = new System.Drawing.Size(87, 76);
            this.statisticShowButton.TabIndex = 26;
            this.statisticShowButton.Text = "statistik";
            this.statisticShowButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.statisticShowButton.UseVisualStyleBackColor = true;
            this.statisticShowButton.Click += new System.EventHandler(this.statisticShowButton_Click);
            // 
            // CalendarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1116, 588);
            this.Controls.Add(this.calendarButtonRight);
            this.Controls.Add(this.calendarButtonLeft);
            this.ClientSize = new System.Drawing.Size(1116, 598);
            this.Controls.Add(this.statisticShowButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.weekLabel);
            this.Controls.Add(this.checkedListBox3);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.monthViewButton);
            this.Controls.Add(this.weekViewButton);
            this.Controls.Add(this.dayViewButton);
            this.Controls.Add(this.twoWeeksButton);
            this.Controls.Add(this.todayButton);
            this.Controls.Add(this.newAppointmentButton);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.monthView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "CalendarView";
            this.Text = "OptikPlanner";
            this.Activated += new System.EventHandler(this.CalendarView_Activated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar calendar;
        private System.Windows.Forms.Calendar.MonthView monthView;
        private System.Windows.Forms.Button newAppointmentButton;
        private System.Windows.Forms.Button todayButton;
        private System.Windows.Forms.Button twoWeeksButton;
        private System.Windows.Forms.Button dayViewButton;
        private System.Windows.Forms.Button weekViewButton;
        private System.Windows.Forms.Button monthViewButton;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button logButton;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label weekLabel;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button calendarButtonLeft;
        private System.Windows.Forms.Button calendarButtonRight;
        private System.Windows.Forms.Button statisticShowButton;
    }
}

