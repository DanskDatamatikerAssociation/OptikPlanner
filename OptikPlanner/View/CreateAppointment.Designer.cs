namespace OptikPlanner.View
{
    partial class CreateAppointment
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelBox = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.telefonBox = new System.Windows.Forms.TextBox();
            this.beskrivelseBox = new System.Windows.Forms.RichTextBox();
            this.userSelectionCombo = new System.Windows.Forms.ComboBox();
            this.aftaleCombo = new System.Windows.Forms.ComboBox();
            this.lokaleCombo = new System.Windows.Forms.ComboBox();
            this.userCombo = new System.Windows.Forms.ComboBox();
            this.customerLibraryButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.smsCheck = new System.Windows.Forms.CheckBox();
            this.emailCheck = new System.Windows.Forms.CheckBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cancelAppointmentButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.timeFromPicker = new System.Windows.Forms.DateTimePicker();
            this.timeToPicker = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cprBox = new CueTextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(38, 448);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok / Gem";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelBox
            // 
            this.cancelBox.Location = new System.Drawing.Point(141, 448);
            this.cancelBox.Name = "cancelBox";
            this.cancelBox.Size = new System.Drawing.Size(75, 23);
            this.cancelBox.TabIndex = 1;
            this.cancelBox.Text = "Anuller";
            this.cancelBox.UseVisualStyleBackColor = true;
            this.cancelBox.Click += new System.EventHandler(this.cancelBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Opretter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Aftaletype";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Find kunde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fornavn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Efternavn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Lokale";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Medarbejder";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Reminders";
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(165, 75);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.ReadOnly = true;
            this.firstNameBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameBox.TabIndex = 11;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(271, 75);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.ReadOnly = true;
            this.lastNameBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameBox.TabIndex = 12;
            // 
            // telefonBox
            // 
            this.telefonBox.Location = new System.Drawing.Point(19, 264);
            this.telefonBox.Name = "telefonBox";
            this.telefonBox.Size = new System.Drawing.Size(137, 20);
            this.telefonBox.TabIndex = 13;
            // 
            // beskrivelseBox
            // 
            this.beskrivelseBox.Location = new System.Drawing.Point(20, 360);
            this.beskrivelseBox.Name = "beskrivelseBox";
            this.beskrivelseBox.Size = new System.Drawing.Size(327, 57);
            this.beskrivelseBox.TabIndex = 14;
            this.beskrivelseBox.Text = "";
            this.beskrivelseBox.TextChanged += new System.EventHandler(this.beskrivelseBox_TextChanged);
            // 
            // userSelectionCombo
            // 
            this.userSelectionCombo.FormattingEnabled = true;
            this.userSelectionCombo.Location = new System.Drawing.Point(93, 21);
            this.userSelectionCombo.Name = "userSelectionCombo";
            this.userSelectionCombo.Size = new System.Drawing.Size(136, 21);
            this.userSelectionCombo.TabIndex = 15;
            this.userSelectionCombo.Tag = "";
            this.userSelectionCombo.Text = "Vælg medarbejder";
            this.userSelectionCombo.SelectedIndexChanged += new System.EventHandler(this.userSelectionCombo_SelectedIndexChanged);
            // 
            // aftaleCombo
            // 
            this.aftaleCombo.FormattingEnabled = true;
            this.aftaleCombo.Location = new System.Drawing.Point(16, 132);
            this.aftaleCombo.Name = "aftaleCombo";
            this.aftaleCombo.Size = new System.Drawing.Size(121, 21);
            this.aftaleCombo.TabIndex = 16;
            this.aftaleCombo.Tag = "";
            this.aftaleCombo.Text = "Vælg aftaletype";
            // 
            // lokaleCombo
            // 
            this.lokaleCombo.FormattingEnabled = true;
            this.lokaleCombo.Location = new System.Drawing.Point(143, 132);
            this.lokaleCombo.Name = "lokaleCombo";
            this.lokaleCombo.Size = new System.Drawing.Size(121, 21);
            this.lokaleCombo.TabIndex = 17;
            this.lokaleCombo.Text = "Vælg lokale";
            // 
            // userCombo
            // 
            this.userCombo.FormattingEnabled = true;
            this.userCombo.Location = new System.Drawing.Point(270, 132);
            this.userCombo.Name = "userCombo";
            this.userCombo.Size = new System.Drawing.Size(121, 21);
            this.userCombo.TabIndex = 18;
            this.userCombo.Text = "Vælg medarbejder";
            // 
            // customerLibraryButton
            // 
            this.customerLibraryButton.Location = new System.Drawing.Point(128, 75);
            this.customerLibraryButton.Name = "customerLibraryButton";
            this.customerLibraryButton.Size = new System.Drawing.Size(31, 23);
            this.customerLibraryButton.TabIndex = 19;
            this.customerLibraryButton.Text = "adr";
            this.customerLibraryButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Telefonnummer";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(71, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Email";
            // 
            // smsCheck
            // 
            this.smsCheck.AutoSize = true;
            this.smsCheck.Location = new System.Drawing.Point(162, 266);
            this.smsCheck.Name = "smsCheck";
            this.smsCheck.Size = new System.Drawing.Size(88, 17);
            this.smsCheck.TabIndex = 25;
            this.smsCheck.Text = "SMS Service";
            this.smsCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smsCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.smsCheck.UseVisualStyleBackColor = true;
            // 
            // emailCheck
            // 
            this.emailCheck.AutoSize = true;
            this.emailCheck.Location = new System.Drawing.Point(162, 317);
            this.emailCheck.Name = "emailCheck";
            this.emailCheck.Size = new System.Drawing.Size(83, 17);
            this.emailCheck.TabIndex = 26;
            this.emailCheck.Text = "Nyhedsbrev";
            this.emailCheck.UseVisualStyleBackColor = true;
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(19, 314);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(137, 20);
            this.emailBox.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Beskrivelse af aftale";
            // 
            // cancelAppointmentButton
            // 
            this.cancelAppointmentButton.Location = new System.Drawing.Point(243, 448);
            this.cancelAppointmentButton.Name = "cancelAppointmentButton";
            this.cancelAppointmentButton.Size = new System.Drawing.Size(75, 23);
            this.cancelAppointmentButton.TabIndex = 29;
            this.cancelAppointmentButton.Text = "Aflys...";
            this.cancelAppointmentButton.UseVisualStyleBackColor = true;
            this.cancelAppointmentButton.Click += new System.EventHandler(this.cancelAppointmentButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 179);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // timeFromPicker
            // 
            this.timeFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeFromPicker.Location = new System.Drawing.Point(222, 179);
            this.timeFromPicker.Name = "timeFromPicker";
            this.timeFromPicker.Size = new System.Drawing.Size(51, 20);
            this.timeFromPicker.TabIndex = 32;
            this.timeFromPicker.ValueChanged += new System.EventHandler(this.timeFromPicker_ValueChanged);
            // 
            // timeToPicker
            // 
            this.timeToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeToPicker.Location = new System.Drawing.Point(296, 179);
            this.timeToPicker.Name = "timeToPicker";
            this.timeToPicker.Size = new System.Drawing.Size(51, 20);
            this.timeToPicker.TabIndex = 33;
            this.timeToPicker.ValueChanged += new System.EventHandler(this.timeToPicker_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(71, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Vælg dato";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(231, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "fra";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(308, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "til";
            // 
            // cprBox
            // 
            this.cprBox.Cue = "Indtast CPR";
            this.cprBox.Location = new System.Drawing.Point(22, 75);
            this.cprBox.Name = "cprBox";
            this.cprBox.Size = new System.Drawing.Size(100, 20);
            this.cprBox.TabIndex = 38;
            this.cprBox.TextChanged += new System.EventHandler(this.cueTextBox1_TextChanged);
            // 
            // CreateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 492);
            this.Controls.Add(this.cprBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.timeToPicker);
            this.Controls.Add(this.timeFromPicker);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cancelAppointmentButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.emailCheck);
            this.Controls.Add(this.smsCheck);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customerLibraryButton);
            this.Controls.Add(this.userCombo);
            this.Controls.Add(this.lokaleCombo);
            this.Controls.Add(this.aftaleCombo);
            this.Controls.Add(this.userSelectionCombo);
            this.Controls.Add(this.beskrivelseBox);
            this.Controls.Add(this.telefonBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBox);
            this.Controls.Add(this.okButton);
            this.Name = "CreateAppointment";
            this.Text = "CreateAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox telefonBox;
        private System.Windows.Forms.RichTextBox beskrivelseBox;
        private System.Windows.Forms.ComboBox userSelectionCombo;
        private System.Windows.Forms.ComboBox aftaleCombo;
        private System.Windows.Forms.ComboBox lokaleCombo;
        private System.Windows.Forms.ComboBox userCombo;
        private System.Windows.Forms.Button customerLibraryButton;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox smsCheck;
        private System.Windows.Forms.CheckBox emailCheck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Button cancelAppointmentButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker timeFromPicker;
        private System.Windows.Forms.DateTimePicker timeToPicker;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private CueTextBox cprBox;
    }
}