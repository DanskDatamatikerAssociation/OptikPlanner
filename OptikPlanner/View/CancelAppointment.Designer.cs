namespace OptikPlanner.View
{
    partial class CancelAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelAppointment));
            this.cuCancelElseRadio = new System.Windows.Forms.RadioButton();
            this.cuCancelPhoneRadio = new System.Windows.Forms.RadioButton();
            this.cuCancelRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.AflyserLabel = new System.Windows.Forms.Label();
            this.cancelUserBox = new System.Windows.Forms.ComboBox();
            this.CancelAppointButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cuCancelElseRadio
            // 
            this.cuCancelElseRadio.AutoSize = true;
            this.cuCancelElseRadio.Location = new System.Drawing.Point(103, 143);
            this.cuCancelElseRadio.Name = "cuCancelElseRadio";
            this.cuCancelElseRadio.Size = new System.Drawing.Size(53, 17);
            this.cuCancelElseRadio.TabIndex = 14;
            this.cuCancelElseRadio.TabStop = true;
            this.cuCancelElseRadio.Text = "Andet";
            this.cuCancelElseRadio.UseVisualStyleBackColor = true;
            // 
            // cuCancelPhoneRadio
            // 
            this.cuCancelPhoneRadio.AutoSize = true;
            this.cuCancelPhoneRadio.Location = new System.Drawing.Point(103, 101);
            this.cuCancelPhoneRadio.Name = "cuCancelPhoneRadio";
            this.cuCancelPhoneRadio.Size = new System.Drawing.Size(149, 17);
            this.cuCancelPhoneRadio.TabIndex = 12;
            this.cuCancelPhoneRadio.TabStop = true;
            this.cuCancelPhoneRadio.Text = "Kunde har aflyst telefonisk";
            this.cuCancelPhoneRadio.UseVisualStyleBackColor = true;
            // 
            // cuCancelRadio
            // 
            this.cuCancelRadio.AutoSize = true;
            this.cuCancelRadio.Location = new System.Drawing.Point(103, 67);
            this.cuCancelRadio.Name = "cuCancelRadio";
            this.cuCancelRadio.Size = new System.Drawing.Size(120, 17);
            this.cuCancelRadio.TabIndex = 11;
            this.cuCancelRadio.TabStop = true;
            this.cuCancelRadio.Text = "Kunde ikke mødt op";
            this.cuCancelRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Grund:";
            // 
            // AflyserLabel
            // 
            this.AflyserLabel.AutoSize = true;
            this.AflyserLabel.Location = new System.Drawing.Point(12, 27);
            this.AflyserLabel.Name = "AflyserLabel";
            this.AflyserLabel.Size = new System.Drawing.Size(38, 13);
            this.AflyserLabel.TabIndex = 9;
            this.AflyserLabel.Text = "Aflyser";
            // 
            // cancelUserBox
            // 
            this.cancelUserBox.FormattingEnabled = true;
            this.cancelUserBox.Location = new System.Drawing.Point(102, 24);
            this.cancelUserBox.Name = "cancelUserBox";
            this.cancelUserBox.Size = new System.Drawing.Size(121, 21);
            this.cancelUserBox.TabIndex = 8;
            this.cancelUserBox.Text = "Vælg medarbejder...";
            // 
            // CancelAppointButton
            // 
            this.CancelAppointButton.Location = new System.Drawing.Point(67, 200);
            this.CancelAppointButton.Name = "CancelAppointButton";
            this.CancelAppointButton.Size = new System.Drawing.Size(75, 23);
            this.CancelAppointButton.TabIndex = 16;
            this.CancelAppointButton.Text = "Aflys aftale";
            this.CancelAppointButton.UseVisualStyleBackColor = true;
            this.CancelAppointButton.Click += new System.EventHandler(this.CancelAppointButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(177, 200);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Anuller";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CancelAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 259);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.CancelAppointButton);
            this.Controls.Add(this.cuCancelElseRadio);
            this.Controls.Add(this.cuCancelPhoneRadio);
            this.Controls.Add(this.cuCancelRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AflyserLabel);
            this.Controls.Add(this.cancelUserBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CancelAppointment";
            this.Text = "Aflys valgte aftale";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton cuCancelElseRadio;
        private System.Windows.Forms.RadioButton cuCancelPhoneRadio;
        private System.Windows.Forms.RadioButton cuCancelRadio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AflyserLabel;
        private System.Windows.Forms.ComboBox cancelUserBox;
        private System.Windows.Forms.Button CancelAppointButton;
        private System.Windows.Forms.Button cancelButton;
    }
}