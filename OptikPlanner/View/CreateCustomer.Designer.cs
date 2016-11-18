namespace OptikPlanner.View
{
    partial class CreateCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.cprBox = new CueTextBox();
            this.createCustomer2Button = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.firstNameBox = new CueTextBox();
            this.LastNameBox = new CueTextBox();
            this.adressBox = new CueTextBox();
            this.emailBox = new CueTextBox();
            this.phoneBox = new CueTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.userCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Opretter";
            // 
            // cprBox
            // 
            this.cprBox.Cue = null;
            this.cprBox.Location = new System.Drawing.Point(127, 63);
            this.cprBox.Name = "cprBox";
            this.cprBox.Size = new System.Drawing.Size(121, 20);
            this.cprBox.TabIndex = 1;
            // 
            // createCustomer2Button
            // 
            this.createCustomer2Button.Location = new System.Drawing.Point(27, 322);
            this.createCustomer2Button.Name = "createCustomer2Button";
            this.createCustomer2Button.Size = new System.Drawing.Size(75, 23);
            this.createCustomer2Button.TabIndex = 2;
            this.createCustomer2Button.Text = "Opret";
            this.createCustomer2Button.UseVisualStyleBackColor = true;
            this.createCustomer2Button.Click += new System.EventHandler(this.createCustomerButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(173, 322);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Anuller";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // firstNameBox
            // 
            this.firstNameBox.Cue = null;
            this.firstNameBox.Location = new System.Drawing.Point(27, 117);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameBox.TabIndex = 4;
            // 
            // LastNameBox
            // 
            this.LastNameBox.Cue = null;
            this.LastNameBox.Location = new System.Drawing.Point(148, 117);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(100, 20);
            this.LastNameBox.TabIndex = 5;
            // 
            // adressBox
            // 
            this.adressBox.Cue = null;
            this.adressBox.Location = new System.Drawing.Point(27, 171);
            this.adressBox.Name = "adressBox";
            this.adressBox.Size = new System.Drawing.Size(221, 20);
            this.adressBox.TabIndex = 6;
            // 
            // emailBox
            // 
            this.emailBox.Cue = null;
            this.emailBox.Location = new System.Drawing.Point(27, 222);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(221, 20);
            this.emailBox.TabIndex = 8;
            // 
            // phoneBox
            // 
            this.phoneBox.Cue = null;
            this.phoneBox.Location = new System.Drawing.Point(27, 278);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(100, 20);
            this.phoneBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fornavn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "CPR nummer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Efternavn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Adresse";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Telefonnummer";
            // 
            // userCombo
            // 
            this.userCombo.FormattingEnabled = true;
            this.userCombo.Location = new System.Drawing.Point(127, 21);
            this.userCombo.Name = "userCombo";
            this.userCombo.Size = new System.Drawing.Size(121, 21);
            this.userCombo.TabIndex = 17;
            this.userCombo.Text = "Vælg Medarbejder";
            // 
            // CreateCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 375);
            this.Controls.Add(this.userCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.adressBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.firstNameBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createCustomer2Button);
            this.Controls.Add(this.cprBox);
            this.Controls.Add(this.label1);
            this.Name = "CreateCustomer";
            this.Text = "CreateCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public CueTextBox cprBox;
        public System.Windows.Forms.Button createCustomer2Button;
        private System.Windows.Forms.Button cancelButton;
        public CueTextBox LastNameBox;
        public CueTextBox adressBox;
        public CueTextBox emailBox;
        public CueTextBox phoneBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox userCombo;
        public CueTextBox firstNameBox;
    }
}