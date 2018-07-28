namespace DesktopFacebook.UI
{
    public partial class FormPhotosSearchByFilterSettings
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
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.FindPicsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MostCommentsRadioButton = new System.Windows.Forms.RadioButton();
            this.MostLikesRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(10, 10);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(82, 13);
            this.StartDateLabel.TabIndex = 0;
            this.StartDateLabel.Text = "Enter start date:\r\n";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(10, 30);
            this.dateTimePickerStartDate.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 1;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(260, 10);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(80, 13);
            this.EndDateLabel.TabIndex = 0;
            this.EndDateLabel.Text = "Enter end date:";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(260, 30);
            this.dateTimePickerEndDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerEndDate.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "please select the amount of pictures";
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(260, 150);
            this.numericUpDownAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(40, 20);
            this.numericUpDownAmount.TabIndex = 3;
            this.numericUpDownAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FindPicsButton
            // 
            this.FindPicsButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.FindPicsButton.Location = new System.Drawing.Point(134, 178);
            this.FindPicsButton.Name = "FindPicsButton";
            this.FindPicsButton.Size = new System.Drawing.Size(206, 57);
            this.FindPicsButton.TabIndex = 4;
            this.FindPicsButton.Text = "Find my pictures!";
            this.FindPicsButton.UseVisualStyleBackColor = true;
            this.FindPicsButton.Click += new System.EventHandler(this.FindPicsButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter By";
            // 
            // MostCommentsRadioButton
            // 
            this.MostCommentsRadioButton.AutoSize = true;
            this.MostCommentsRadioButton.Location = new System.Drawing.Point(10, 170);
            this.MostCommentsRadioButton.Name = "MostCommentsRadioButton";
            this.MostCommentsRadioButton.Size = new System.Drawing.Size(74, 17);
            this.MostCommentsRadioButton.TabIndex = 8;
            this.MostCommentsRadioButton.TabStop = true;
            this.MostCommentsRadioButton.Text = "Comments";
            this.MostCommentsRadioButton.UseVisualStyleBackColor = true;
            // 
            // MostLikesRadioButton
            // 
            this.MostLikesRadioButton.AutoSize = true;
            this.MostLikesRadioButton.Location = new System.Drawing.Point(10, 150);
            this.MostLikesRadioButton.Name = "MostLikesRadioButton";
            this.MostLikesRadioButton.Size = new System.Drawing.Size(50, 17);
            this.MostLikesRadioButton.TabIndex = 9;
            this.MostLikesRadioButton.TabStop = true;
            this.MostLikesRadioButton.Text = "Likes";
            this.MostLikesRadioButton.UseVisualStyleBackColor = true;
            // 
            // FormPhotosSearchByFilterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 247);
            this.Controls.Add(this.MostLikesRadioButton);
            this.Controls.Add(this.MostCommentsRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FindPicsButton);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.StartDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormPhotosSearchByFilterSettings";
            this.Text = "Photo Search By Filter Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Button FindPicsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton MostCommentsRadioButton;
        private System.Windows.Forms.RadioButton MostLikesRadioButton;
    }
}