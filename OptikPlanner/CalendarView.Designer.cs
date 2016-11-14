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
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.monthView2 = new System.Windows.Forms.Calendar.MonthView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indstillingerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar1
            // 
            this.calendar1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar1.Location = new System.Drawing.Point(148, 97);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(901, 462);
            this.calendar1.TabIndex = 0;
            this.calendar1.TabStop = false;
            this.calendar1.Text = "Calendar";
            this.calendar1.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.FifteenMinutes;
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            // 
            // monthView2
            // 
            this.monthView2.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView2.ArrowsSelectedColor = System.Drawing.Color.Gold;
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
            this.monthView2.Size = new System.Drawing.Size(140, 308);
            this.monthView2.TabIndex = 2;
            this.monthView2.Text = "monthView2";
            this.monthView2.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView2.SelectionChanged += new System.EventHandler(this.monthView2_SelectionChanged);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(154, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 66);
            this.button3.TabIndex = 4;
            this.button3.Text = "I dag";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(250, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 66);
            this.button4.TabIndex = 5;
            this.button4.Text = "14 Dage";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
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
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.Text = "Lokaler";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(2, 503);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(140, 21);
            this.comboBox3.TabIndex = 16;
            this.comboBox3.Text = "Medarbejdere";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Window;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = global::OptikPlanner.Properties.Resources.calendar_64x64;
            this.button7.Location = new System.Drawing.Point(538, 25);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 66);
            this.button7.TabIndex = 8;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Window;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::OptikPlanner.Properties.Resources.Calendar_2_64x64;
            this.button6.Location = new System.Drawing.Point(442, 25);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 66);
            this.button6.TabIndex = 7;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Window;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::OptikPlanner.Properties.Resources.calendar1_64x64;
            this.button5.Location = new System.Drawing.Point(346, 25);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 66);
            this.button5.TabIndex = 6;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::OptikPlanner.Properties.Resources.Calendar_Add_64x64;
            this.button2.Location = new System.Drawing.Point(2, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 67);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(647, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 54);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Uge - 45\r\n\r\nNovember - 2016";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIlerToolStripMenuItem,
            this.indstillingerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1061, 24);
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
            this.checkedListBox1.Size = new System.Drawing.Size(142, 19);
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
            this.checkedListBox2.Size = new System.Drawing.Size(142, 19);
            this.checkedListBox2.TabIndex = 20;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.checkedListBox2_SelectedIndexChanged);
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
            this.checkedListBox3.Size = new System.Drawing.Size(142, 19);
            this.checkedListBox3.TabIndex = 21;
            // 
            // CalendarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1061, 546);
            this.Controls.Add(this.checkedListBox3);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.monthView2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CalendarView";
            this.Text = "OptikPlanner";
            this.Load += new System.EventHandler(this.CalendarView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.Calendar.MonthView monthView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indstillingerToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
    }
}

