namespace UPVApp
{
    partial class SelectAddress
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
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressLineOneLabel = new System.Windows.Forms.Label();
            this.addressLineOneTextBox = new System.Windows.Forms.TextBox();
            this.addressLineTwoLabel = new System.Windows.Forms.Label();
            this.addressLineTwotextBox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.zipLabel = new System.Windows.Forms.Label();
            this.zipTextBox = new System.Windows.Forms.TextBox();
            this.editButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectAddressComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(148, 281);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Enabled = false;
            this.previousButton.Location = new System.Drawing.Point(55, 281);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 23);
            this.previousButton.TabIndex = 1;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(17, 29);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(38, 13);
            this.addressLabel.TabIndex = 3;
            this.addressLabel.Text = "Name:";
            // 
            // addressLineOneLabel
            // 
            this.addressLineOneLabel.AutoSize = true;
            this.addressLineOneLabel.Location = new System.Drawing.Point(17, 74);
            this.addressLineOneLabel.Name = "addressLineOneLabel";
            this.addressLineOneLabel.Size = new System.Drawing.Size(80, 13);
            this.addressLineOneLabel.TabIndex = 5;
            this.addressLineOneLabel.Text = "Address Line 1:";
            // 
            // addressLineOneTextBox
            // 
            this.addressLineOneTextBox.Location = new System.Drawing.Point(20, 90);
            this.addressLineOneTextBox.Name = "addressLineOneTextBox";
            this.addressLineOneTextBox.ReadOnly = true;
            this.addressLineOneTextBox.Size = new System.Drawing.Size(230, 20);
            this.addressLineOneTextBox.TabIndex = 4;
            // 
            // addressLineTwoLabel
            // 
            this.addressLineTwoLabel.AutoSize = true;
            this.addressLineTwoLabel.Location = new System.Drawing.Point(17, 115);
            this.addressLineTwoLabel.Name = "addressLineTwoLabel";
            this.addressLineTwoLabel.Size = new System.Drawing.Size(80, 13);
            this.addressLineTwoLabel.TabIndex = 7;
            this.addressLineTwoLabel.Text = "Address Line 2:";
            // 
            // addressLineTwotextBox
            // 
            this.addressLineTwotextBox.Location = new System.Drawing.Point(20, 131);
            this.addressLineTwotextBox.Name = "addressLineTwotextBox";
            this.addressLineTwotextBox.ReadOnly = true;
            this.addressLineTwotextBox.Size = new System.Drawing.Size(230, 20);
            this.addressLineTwotextBox.TabIndex = 6;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(17, 156);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 9;
            this.cityLabel.Text = "City:";
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(20, 172);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.ReadOnly = true;
            this.cityTextBox.Size = new System.Drawing.Size(230, 20);
            this.cityTextBox.TabIndex = 8;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(17, 196);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(35, 13);
            this.stateLabel.TabIndex = 11;
            this.stateLabel.Text = "State:";
            // 
            // stateTextBox
            // 
            this.stateTextBox.Location = new System.Drawing.Point(20, 212);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.ReadOnly = true;
            this.stateTextBox.Size = new System.Drawing.Size(230, 20);
            this.stateTextBox.TabIndex = 10;
            // 
            // zipLabel
            // 
            this.zipLabel.AutoSize = true;
            this.zipLabel.Location = new System.Drawing.Point(17, 239);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(27, 13);
            this.zipLabel.TabIndex = 13;
            this.zipLabel.Text = "ZIP:";
            // 
            // zipTextBox
            // 
            this.zipTextBox.Location = new System.Drawing.Point(20, 255);
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.ReadOnly = true;
            this.zipTextBox.Size = new System.Drawing.Size(230, 20);
            this.zipTextBox.TabIndex = 12;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(33, 330);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(97, 31);
            this.editButton.TabIndex = 14;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(148, 330);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(97, 31);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectAddressComboBox
            // 
            this.selectAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectAddressComboBox.FormattingEnabled = true;
            this.selectAddressComboBox.Location = new System.Drawing.Point(20, 45);
            this.selectAddressComboBox.Name = "selectAddressComboBox";
            this.selectAddressComboBox.Size = new System.Drawing.Size(230, 21);
            this.selectAddressComboBox.TabIndex = 16;
            this.selectAddressComboBox.SelectedIndexChanged += new System.EventHandler(this.selectAddressComboBox_SelectedIndexChanged);
            // 
            // SelectAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 373);
            this.Controls.Add(this.selectAddressComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.zipLabel);
            this.Controls.Add(this.zipTextBox);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.addressLineTwoLabel);
            this.Controls.Add(this.addressLineTwotextBox);
            this.Controls.Add(this.addressLineOneLabel);
            this.Controls.Add(this.addressLineOneTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Name = "SelectAddress";
            this.Text = "Select Address to Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label addressLineOneLabel;
        private System.Windows.Forms.TextBox addressLineOneTextBox;
        private System.Windows.Forms.Label addressLineTwoLabel;
        private System.Windows.Forms.TextBox addressLineTwotextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.TextBox zipTextBox;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox selectAddressComboBox;
    }
}