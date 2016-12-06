namespace OptikPlanner.View
{
    partial class CustomerLibrary
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
            this.editCustomerButton = new System.Windows.Forms.Button();
            this.createCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ListViewBox = new System.Windows.Forms.ListView();
            this.closeWindowButton = new System.Windows.Forms.Button();
            this.cprBox = new CueTextBox();
            this.SuspendLayout();
            // 
            // editCustomerButton
            // 
            this.editCustomerButton.Enabled = false;
            this.editCustomerButton.Location = new System.Drawing.Point(48, 63);
            this.editCustomerButton.Name = "editCustomerButton";
            this.editCustomerButton.Size = new System.Drawing.Size(123, 23);
            this.editCustomerButton.TabIndex = 2;
            this.editCustomerButton.Text = "Vis / rediger kunde";
            this.editCustomerButton.UseVisualStyleBackColor = true;
            this.editCustomerButton.Click += new System.EventHandler(this.editCustomerButton_Click);
            // 
            // createCustomerButton
            // 
            this.createCustomerButton.Location = new System.Drawing.Point(48, 92);
            this.createCustomerButton.Name = "createCustomerButton";
            this.createCustomerButton.Size = new System.Drawing.Size(123, 23);
            this.createCustomerButton.TabIndex = 4;
            this.createCustomerButton.Text = "Opret kunde";
            this.createCustomerButton.UseVisualStyleBackColor = true;
            this.createCustomerButton.Click += new System.EventHandler(this.createCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Enabled = false;
            this.deleteCustomerButton.Location = new System.Drawing.Point(177, 63);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(123, 23);
            this.deleteCustomerButton.TabIndex = 6;
            this.deleteCustomerButton.Text = "Slet kunde";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Find kunde";
            // 
            // ListViewBox
            // 
            this.ListViewBox.Location = new System.Drawing.Point(25, 121);
            this.ListViewBox.Name = "ListViewBox";
            this.ListViewBox.Size = new System.Drawing.Size(305, 274);
            this.ListViewBox.TabIndex = 10;
            this.ListViewBox.UseCompatibleStateImageBehavior = false;
            this.ListViewBox.SelectedIndexChanged += new System.EventHandler(this.ListViewBox_SelectedIndexChanged);
            this.ListViewBox.DoubleClick += new System.EventHandler(this.ListViewBox_DoubleClick);
            // 
            // closeWindowButton
            // 
            this.closeWindowButton.Location = new System.Drawing.Point(177, 92);
            this.closeWindowButton.Name = "closeWindowButton";
            this.closeWindowButton.Size = new System.Drawing.Size(123, 23);
            this.closeWindowButton.TabIndex = 11;
            this.closeWindowButton.Text = "Luk vindue";
            this.closeWindowButton.UseVisualStyleBackColor = true;
            this.closeWindowButton.Click += new System.EventHandler(this.closeWindowButton_Click);
            // 
            // cprBox
            // 
            this.cprBox.Cue = "Indtast CPR";
            this.cprBox.Location = new System.Drawing.Point(48, 37);
            this.cprBox.Name = "cprBox";
            this.cprBox.Size = new System.Drawing.Size(252, 20);
            this.cprBox.TabIndex = 9;
            this.cprBox.TextChanged += new System.EventHandler(this.cprBox_TextChanged);
            // 
            // CustomerLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 458);
            this.Controls.Add(this.closeWindowButton);
            this.Controls.Add(this.ListViewBox);
            this.Controls.Add(this.cprBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.createCustomerButton);
            this.Controls.Add(this.editCustomerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CustomerLibrary";
            this.Text = "Kundekartotek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editCustomerButton;
        private System.Windows.Forms.Button createCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Label label1;
        private CueTextBox cprBox;
        private System.Windows.Forms.ListView ListViewBox;
        private System.Windows.Forms.Button closeWindowButton;
    }
}