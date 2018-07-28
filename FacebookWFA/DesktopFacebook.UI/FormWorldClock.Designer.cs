namespace DesktopFacebook.UI
{
    public partial class FormWorldClock
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
            this.ListOfCapitalCitys = new System.Windows.Forms.ListBox();
            this.PostTheTimeButton = new System.Windows.Forms.Button();
            this.CityAndTimeTextBox = new System.Windows.Forms.TextBox();
            this.GetCapitalCitysButton = new System.Windows.Forms.Button();
            this.CityPhoto = new System.Windows.Forms.PictureBox();
            this.CityPhotoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PhotoCheckBox = new System.Windows.Forms.CheckBox();
            this.RefreshCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CityPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // ListOfCapitalCitys
            // 
            this.ListOfCapitalCitys.FormattingEnabled = true;
            this.ListOfCapitalCitys.Location = new System.Drawing.Point(407, 54);
            this.ListOfCapitalCitys.Name = "ListOfCapitalCitys";
            this.ListOfCapitalCitys.ScrollAlwaysVisible = true;
            this.ListOfCapitalCitys.Size = new System.Drawing.Size(130, 329);
            this.ListOfCapitalCitys.TabIndex = 0;
            this.ListOfCapitalCitys.SelectedIndexChanged += new System.EventHandler(this.ListOfCapitalCitys_SelectedIndexChanged);
            // 
            // PostTheTimeButton
            // 
            this.PostTheTimeButton.Location = new System.Drawing.Point(11, 85);
            this.PostTheTimeButton.Name = "PostTheTimeButton";
            this.PostTheTimeButton.Size = new System.Drawing.Size(212, 38);
            this.PostTheTimeButton.TabIndex = 3;
            this.PostTheTimeButton.Text = "Post the time!";
            this.PostTheTimeButton.UseVisualStyleBackColor = true;
            this.PostTheTimeButton.Click += new System.EventHandler(this.PostTheTimeButton_Click);
            // 
            // CityAndTimeTextBox
            // 
            this.CityAndTimeTextBox.Location = new System.Drawing.Point(12, 12);
            this.CityAndTimeTextBox.Multiline = true;
            this.CityAndTimeTextBox.Name = "CityAndTimeTextBox";
            this.CityAndTimeTextBox.Size = new System.Drawing.Size(211, 67);
            this.CityAndTimeTextBox.TabIndex = 4;
            // 
            // GetCapitalCitysButton
            // 
            this.GetCapitalCitysButton.Location = new System.Drawing.Point(407, 13);
            this.GetCapitalCitysButton.Name = "GetCapitalCitysButton";
            this.GetCapitalCitysButton.Size = new System.Drawing.Size(130, 35);
            this.GetCapitalCitysButton.TabIndex = 5;
            this.GetCapitalCitysButton.Text = "Get Capital Cities";
            this.GetCapitalCitysButton.UseVisualStyleBackColor = true;
            this.GetCapitalCitysButton.Click += new System.EventHandler(this.GetCapitalCitysButton_Click);
            // 
            // CityPhoto
            // 
            this.CityPhoto.Location = new System.Drawing.Point(11, 171);
            this.CityPhoto.Name = "CityPhoto";
            this.CityPhoto.Size = new System.Drawing.Size(286, 211);
            this.CityPhoto.TabIndex = 6;
            this.CityPhoto.TabStop = false;
            // 
            // CityPhotoLabel
            // 
            this.CityPhotoLabel.AutoSize = true;
            this.CityPhotoLabel.Location = new System.Drawing.Point(13, 152);
            this.CityPhotoLabel.Name = "CityPhotoLabel";
            this.CityPhotoLabel.Size = new System.Drawing.Size(61, 13);
            this.CityPhotoLabel.TabIndex = 8;
            this.CityPhotoLabel.Text = "City Photo: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Refresh cities for current time";
            // 
            // PhotoCheckBox
            // 
            this.PhotoCheckBox.AutoSize = true;
            this.PhotoCheckBox.Location = new System.Drawing.Point(229, 54);
            this.PhotoCheckBox.Name = "PhotoCheckBox";
            this.PhotoCheckBox.Size = new System.Drawing.Size(102, 17);
            this.PhotoCheckBox.TabIndex = 10;
            this.PhotoCheckBox.Text = "Show city photo";
            this.PhotoCheckBox.UseVisualStyleBackColor = true;
            this.PhotoCheckBox.CheckedChanged += new System.EventHandler(this.PhotoCheckBox_CheckedChanged);
            // 
            // RefreshCheckBox
            // 
            this.RefreshCheckBox.AutoSize = true;
            this.RefreshCheckBox.Location = new System.Drawing.Point(229, 31);
            this.RefreshCheckBox.Name = "RefreshCheckBox";
            this.RefreshCheckBox.Size = new System.Drawing.Size(172, 17);
            this.RefreshCheckBox.TabIndex = 11;
            this.RefreshCheckBox.Text = "With refresh timer - 30 seconds";
            this.RefreshCheckBox.UseVisualStyleBackColor = true;
            this.RefreshCheckBox.CheckedChanged += new System.EventHandler(this.RefreshCheckBox_CheckedChanged);
            // 
            // FormWorldClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 389);
            this.Controls.Add(this.RefreshCheckBox);
            this.Controls.Add(this.PhotoCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CityPhotoLabel);
            this.Controls.Add(this.CityPhoto);
            this.Controls.Add(this.GetCapitalCitysButton);
            this.Controls.Add(this.CityAndTimeTextBox);
            this.Controls.Add(this.PostTheTimeButton);
            this.Controls.Add(this.ListOfCapitalCitys);
            this.Name = "FormWorldClock";
            this.Text = "FormWorldClock";
            ((System.ComponentModel.ISupportInitialize)(this.CityPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListOfCapitalCitys;
        private System.Windows.Forms.Button PostTheTimeButton;
        private System.Windows.Forms.TextBox CityAndTimeTextBox;
        private System.Windows.Forms.Button GetCapitalCitysButton;
        private System.Windows.Forms.PictureBox CityPhoto;
        private System.Windows.Forms.Label CityPhotoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox PhotoCheckBox;
        private System.Windows.Forms.CheckBox RefreshCheckBox;
    }
}