namespace DesktopFacebook.UI
{
    public partial class FormFBHomePage
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.ListOfPosts = new System.Windows.Forms.ListBox();
            this.postBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShowMyPostsButton = new System.Windows.Forms.Button();
            this.ShowMyPagesButton = new System.Windows.Forms.Button();
            this.ListOfPages = new System.Windows.Forms.ListBox();
            this.pageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShowMyPlacesButton = new System.Windows.Forms.Button();
            this.ListOfPlaces = new System.Windows.Forms.ListBox();
            this.ShowMyEventsButton = new System.Windows.Forms.Button();
            this.ListOfEvents = new System.Windows.Forms.ListBox();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShowMyFriendsButton = new System.Windows.Forms.Button();
            this.ListOfFriends = new System.Windows.Forms.ListBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NewPostButton = new System.Windows.Forms.Button();
            this.NewPostTextBox = new System.Windows.Forms.TextBox();
            this.FriendPhotoLabel = new System.Windows.Forms.Label();
            this.FilteredPictureButton = new System.Windows.Forms.Button();
            this.WorldTimeButton = new System.Windows.Forms.Button();
            this.FriendsPhoto = new System.Windows.Forms.PictureBox();
            this.CoverPhoto = new System.Windows.Forms.PictureBox();
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FriendsPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoverPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 125);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(173, 30);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.Login_Click);
            // 
            // ListOfPosts
            // 
            this.ListOfPosts.DataSource = this.postBindingSource;
            this.ListOfPosts.DisplayMember = "Message";
            this.ListOfPosts.FormattingEnabled = true;
            this.ListOfPosts.HorizontalScrollbar = true;
            this.ListOfPosts.Location = new System.Drawing.Point(12, 224);
            this.ListOfPosts.Name = "ListOfPosts";
            this.ListOfPosts.ScrollAlwaysVisible = true;
            this.ListOfPosts.Size = new System.Drawing.Size(124, 147);
            this.ListOfPosts.TabIndex = 3;
            this.ListOfPosts.ValueMember = "Caption";
            // 
            // postBindingSource
            // 
            this.postBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Post);
            // 
            // ShowMyPostsButton
            // 
            this.ShowMyPostsButton.Location = new System.Drawing.Point(12, 188);
            this.ShowMyPostsButton.Name = "ShowMyPostsButton";
            this.ShowMyPostsButton.Size = new System.Drawing.Size(124, 30);
            this.ShowMyPostsButton.TabIndex = 4;
            this.ShowMyPostsButton.Text = "My posts";
            this.ShowMyPostsButton.UseVisualStyleBackColor = true;
            this.ShowMyPostsButton.Click += new System.EventHandler(this.ShowMyPostsButton_Click);
            // 
            // ShowMyPagesButton
            // 
            this.ShowMyPagesButton.Location = new System.Drawing.Point(142, 188);
            this.ShowMyPagesButton.Name = "ShowMyPagesButton";
            this.ShowMyPagesButton.Size = new System.Drawing.Size(124, 30);
            this.ShowMyPagesButton.TabIndex = 6;
            this.ShowMyPagesButton.Text = "Pages I like";
            this.ShowMyPagesButton.UseVisualStyleBackColor = true;
            this.ShowMyPagesButton.Click += new System.EventHandler(this.ShowMyPagesButton_Click);
            // 
            // ListOfPages
            // 
            this.ListOfPages.DataSource = this.pageBindingSource;
            this.ListOfPages.DisplayMember = "Name";
            this.ListOfPages.FormattingEnabled = true;
            this.ListOfPages.HorizontalScrollbar = true;
            this.ListOfPages.Location = new System.Drawing.Point(142, 224);
            this.ListOfPages.Name = "ListOfPages";
            this.ListOfPages.ScrollAlwaysVisible = true;
            this.ListOfPages.Size = new System.Drawing.Size(124, 147);
            this.ListOfPages.TabIndex = 5;
            // 
            // pageBindingSource
            // 
            this.pageBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Page);
            // 
            // ShowMyPlacesButton
            // 
            this.ShowMyPlacesButton.Location = new System.Drawing.Point(272, 188);
            this.ShowMyPlacesButton.Name = "ShowMyPlacesButton";
            this.ShowMyPlacesButton.Size = new System.Drawing.Size(124, 30);
            this.ShowMyPlacesButton.TabIndex = 18;
            this.ShowMyPlacesButton.Text = "Places i\'ve been";
            this.ShowMyPlacesButton.Click += new System.EventHandler(this.ShowMyPlacesButton_Click);
            // 
            // ListOfPlaces
            // 
            this.ListOfPlaces.DisplayMember = "Id";
            this.ListOfPlaces.FormattingEnabled = true;
            this.ListOfPlaces.HorizontalScrollbar = true;
            this.ListOfPlaces.Location = new System.Drawing.Point(272, 224);
            this.ListOfPlaces.Name = "ListOfPlaces";
            this.ListOfPlaces.ScrollAlwaysVisible = true;
            this.ListOfPlaces.Size = new System.Drawing.Size(124, 147);
            this.ListOfPlaces.TabIndex = 7;
            this.ListOfPlaces.ValueMember = "Id";
            // 
            // ShowMyEventsButton
            // 
            this.ShowMyEventsButton.Location = new System.Drawing.Point(402, 188);
            this.ShowMyEventsButton.Name = "ShowMyEventsButton";
            this.ShowMyEventsButton.Size = new System.Drawing.Size(124, 30);
            this.ShowMyEventsButton.TabIndex = 10;
            this.ShowMyEventsButton.Text = "List of events";
            this.ShowMyEventsButton.UseVisualStyleBackColor = true;
            this.ShowMyEventsButton.Click += new System.EventHandler(this.ShowMyEventsButton_Click);
            // 
            // ListOfEvents
            // 
            this.ListOfEvents.DataSource = this.eventBindingSource;
            this.ListOfEvents.DisplayMember = "Name";
            this.ListOfEvents.FormattingEnabled = true;
            this.ListOfEvents.HorizontalScrollbar = true;
            this.ListOfEvents.Location = new System.Drawing.Point(402, 224);
            this.ListOfEvents.Name = "ListOfEvents";
            this.ListOfEvents.ScrollAlwaysVisible = true;
            this.ListOfEvents.Size = new System.Drawing.Size(124, 147);
            this.ListOfEvents.TabIndex = 9;
            this.ListOfEvents.ValueMember = "AttendingUsers";
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Event);
            // 
            // ShowMyFriendsButton
            // 
            this.ShowMyFriendsButton.Location = new System.Drawing.Point(532, 188);
            this.ShowMyFriendsButton.Name = "ShowMyFriendsButton";
            this.ShowMyFriendsButton.Size = new System.Drawing.Size(124, 30);
            this.ShowMyFriendsButton.TabIndex = 12;
            this.ShowMyFriendsButton.Text = "My friends";
            this.ShowMyFriendsButton.UseVisualStyleBackColor = true;
            this.ShowMyFriendsButton.Click += new System.EventHandler(this.ShowMyFriendsButton_Click);
            // 
            // ListOfFriends
            // 
            this.ListOfFriends.DataSource = this.userBindingSource;
            this.ListOfFriends.DisplayMember = "Name";
            this.ListOfFriends.FormattingEnabled = true;
            this.ListOfFriends.HorizontalScrollbar = true;
            this.ListOfFriends.Location = new System.Drawing.Point(532, 224);
            this.ListOfFriends.Name = "ListOfFriends";
            this.ListOfFriends.ScrollAlwaysVisible = true;
            this.ListOfFriends.Size = new System.Drawing.Size(124, 147);
            this.ListOfFriends.TabIndex = 11;
            this.ListOfFriends.ValueMember = "Albums";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // NewPostButton
            // 
            this.NewPostButton.Location = new System.Drawing.Point(532, 125);
            this.NewPostButton.Name = "NewPostButton";
            this.NewPostButton.Size = new System.Drawing.Size(124, 57);
            this.NewPostButton.TabIndex = 15;
            this.NewPostButton.Text = "Post";
            this.NewPostButton.UseVisualStyleBackColor = true;
            this.NewPostButton.Click += new System.EventHandler(this.NewPostButton_Click);
            // 
            // NewPostTextBox
            // 
            this.NewPostTextBox.Location = new System.Drawing.Point(211, 125);
            this.NewPostTextBox.Multiline = true;
            this.NewPostTextBox.Name = "NewPostTextBox";
            this.NewPostTextBox.Size = new System.Drawing.Size(315, 57);
            this.NewPostTextBox.TabIndex = 16;
            // 
            // FriendPhotoLabel
            // 
            this.FriendPhotoLabel.AutoSize = true;
            this.FriendPhotoLabel.Location = new System.Drawing.Point(694, 202);
            this.FriendPhotoLabel.Name = "FriendPhotoLabel";
            this.FriendPhotoLabel.Size = new System.Drawing.Size(66, 13);
            this.FriendPhotoLabel.TabIndex = 17;
            this.FriendPhotoLabel.Text = "Friend photo";
            // 
            // FilteredPictureButton
            // 
            this.FilteredPictureButton.Location = new System.Drawing.Point(532, 13);
            this.FilteredPictureButton.Name = "FilteredPictureButton";
            this.FilteredPictureButton.Size = new System.Drawing.Size(260, 36);
            this.FilteredPictureButton.TabIndex = 19;
            this.FilteredPictureButton.Text = "Find out your photos by filter!";
            this.FilteredPictureButton.UseVisualStyleBackColor = true;
            this.FilteredPictureButton.Click += new System.EventHandler(this.SearchPictureButton_Click);
            // 
            // WorldTimeButton
            // 
            this.WorldTimeButton.Location = new System.Drawing.Point(532, 55);
            this.WorldTimeButton.Name = "WorldTimeButton";
            this.WorldTimeButton.Size = new System.Drawing.Size(260, 36);
            this.WorldTimeButton.TabIndex = 20;
            this.WorldTimeButton.Text = "See world time and post!";
            this.WorldTimeButton.UseVisualStyleBackColor = true;
            this.WorldTimeButton.Click += new System.EventHandler(this.WorldTimeButton_Click);
            // 
            // FriendsPhoto
            // 
            this.FriendsPhoto.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.userBindingSource, "ImageLarge", true));
            this.FriendsPhoto.Image = global::DesktopFacebook.UI.Properties.Resources.profilepic;
            this.FriendsPhoto.Location = new System.Drawing.Point(662, 224);
            this.FriendsPhoto.Name = "FriendsPhoto";
            this.FriendsPhoto.Size = new System.Drawing.Size(125, 146);
            this.FriendsPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FriendsPhoto.TabIndex = 13;
            this.FriendsPhoto.TabStop = false;
            // 
            // CoverPhoto
            // 
            this.CoverPhoto.Image = global::DesktopFacebook.UI.Properties.Resources.profilepic;
            this.CoverPhoto.Location = new System.Drawing.Point(211, 13);
            this.CoverPhoto.Name = "CoverPhoto";
            this.CoverPhoto.Size = new System.Drawing.Size(315, 106);
            this.CoverPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CoverPhoto.TabIndex = 1;
            this.CoverPhoto.TabStop = false;
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.Image = global::DesktopFacebook.UI.Properties.Resources.profilepic;
            this.ProfilePicture.Location = new System.Drawing.Point(12, 12);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(173, 107);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePicture.TabIndex = 0;
            this.ProfilePicture.TabStop = false;
            // 
            // FormFBHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 377);
            this.Controls.Add(this.WorldTimeButton);
            this.Controls.Add(this.FilteredPictureButton);
            this.Controls.Add(this.FriendPhotoLabel);
            this.Controls.Add(this.NewPostTextBox);
            this.Controls.Add(this.NewPostButton);
            this.Controls.Add(this.FriendsPhoto);
            this.Controls.Add(this.ShowMyFriendsButton);
            this.Controls.Add(this.ListOfFriends);
            this.Controls.Add(this.ShowMyEventsButton);
            this.Controls.Add(this.ListOfEvents);
            this.Controls.Add(this.ShowMyPlacesButton);
            this.Controls.Add(this.ListOfPlaces);
            this.Controls.Add(this.ShowMyPagesButton);
            this.Controls.Add(this.ListOfPages);
            this.Controls.Add(this.ShowMyPostsButton);
            this.Controls.Add(this.ListOfPosts);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.CoverPhoto);
            this.Controls.Add(this.ProfilePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormFBHomePage";
            this.Text = "FormFBHomePage";
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FriendsPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoverPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfilePicture;
        private System.Windows.Forms.PictureBox CoverPhoto;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.ListBox ListOfPosts;
        private System.Windows.Forms.Button ShowMyPostsButton;
        private System.Windows.Forms.Button ShowMyPagesButton;
        private System.Windows.Forms.ListBox ListOfPages;
        private System.Windows.Forms.Button ShowMyPlacesButton;
        private System.Windows.Forms.ListBox ListOfPlaces;
        private System.Windows.Forms.Button ShowMyEventsButton;
        private System.Windows.Forms.ListBox ListOfEvents;
        private System.Windows.Forms.Button ShowMyFriendsButton;
        private System.Windows.Forms.ListBox ListOfFriends;
        private System.Windows.Forms.PictureBox FriendsPhoto;
        private System.Windows.Forms.Button NewPostButton;
        private System.Windows.Forms.TextBox NewPostTextBox;
        private System.Windows.Forms.Label FriendPhotoLabel;
        private System.Windows.Forms.Button FilteredPictureButton;
        private System.Windows.Forms.Button WorldTimeButton;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.BindingSource pageBindingSource;
        private System.Windows.Forms.BindingSource postBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource;
    }
}