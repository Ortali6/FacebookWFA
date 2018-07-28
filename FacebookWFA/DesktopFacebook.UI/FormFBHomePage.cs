using System.Threading;
using System.Windows.Forms;
using System;
using DesktopFacebook.Logic;
using FacebookWrapper.ObjectModel;

// $G$ DSN-999 (-5) Unnecessary redefinition of existing .NET delegate EventHandler
// $G$ THE-001 (-14) your grade on diagrams document - 86. please see comments inside the document. 

namespace DesktopFacebook.UI
{
    public partial class FormFBHomePage : Form
    {
        private readonly FBLogic r_FBLogic;

        public FormFBHomePage()
        {
            InitializeComponent();
            disableButtons();
            r_FBLogic = new FBLogic();
        }

        private void disableButtons()
        {
            ShowMyEventsButton.Enabled = false;
            ShowMyFriendsButton.Enabled = false;
            ShowMyPlacesButton.Enabled = false;
            ShowMyPagesButton.Enabled = false;
            ShowMyPostsButton.Enabled = false;
            NewPostButton.Enabled = false;
            NewPostTextBox.Enabled = false;
            FilteredPictureButton.Enabled = false;
            WorldTimeButton.Enabled = false;
        }

        private void enableButtons()
        {
            ShowMyEventsButton.Enabled = true;
            ShowMyFriendsButton.Enabled = true;
            ShowMyPlacesButton.Enabled = true;
            ShowMyPagesButton.Enabled = true;
            ShowMyPostsButton.Enabled = true;
            NewPostButton.Enabled = true;
            NewPostTextBox.Enabled = true;
            FilteredPictureButton.Enabled = true;
            WorldTimeButton.Enabled = true;
            LoginButton.Enabled = false;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                r_FBLogic.Login();
                new Thread(fetchUserInfo).Start();
                enableButtons();
            }
            catch (NullReferenceException NullException)
            {
                MessageBox.Show(NullException.Message);
            }
        }

        private void fetchUserInfo()
        {
            this.Invoke(new Action(() => Text = r_FBLogic.m_LoggedInUser.Name));
            new Thread(() => ProfilePicture.LoadAsync(r_FBLogic.m_LoggedInUser.PictureLargeURL)).Start();
            new Thread(() => CoverPhoto.LoadAsync(r_FBLogic.m_LoggedInUser.Cover.SourceURL)).Start();
        }

        private void ShowMyPostsButton_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            postBindingSource.DataSource = r_FBLogic.m_LoggedInUser.NewsFeed).Start();
            ListOfPosts.Invoke(new Action(() =>
            {
                ListOfPosts.DisplayMember = "Message";
                ListOfPosts.DataSource = postBindingSource;                
            }));
        }

        private void ShowMyFriendsButton_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            userBindingSource.DataSource = r_FBLogic.m_LoggedInUser.Friends).Start();
            ListOfFriends.Invoke(new Action(() =>
            {
                ListOfFriends.DisplayMember = "Name";
                ListOfFriends.DataSource = userBindingSource;
            }));
        }

        private void ShowMyEventsButton_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            eventBindingSource.DataSource = r_FBLogic.m_LoggedInUser.Events).Start();
            ListOfEvents.Invoke(new Action(() =>
            {
                ListOfEvents.DisplayMember = "Name";
                ListOfEvents.DataSource = eventBindingSource;
            }));
        }

        private void ShowMyPagesButton_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            pageBindingSource.DataSource = r_FBLogic.m_LoggedInUser.LikedPages).Start();
            ListOfPages.Invoke(new Action(() =>
            {
                ListOfPages.DisplayMember = "Name";
                ListOfPages.DataSource = pageBindingSource;
            }));
        }

        private void ShowMyPlacesButton_Click(object sender, EventArgs e)
        {
            ListOfPlaces.Items.Clear();
            new Thread(() =>
            {
                int numberOfPlaces = r_FBLogic.m_LoggedInUser.Checkins.Count;
                if (numberOfPlaces > 0)
                {
                    foreach (Checkin checkin in r_FBLogic.m_LoggedInUser.Checkins)
                    {
                        ListOfPlaces.Invoke(new Action(() => ListOfPlaces.Items.Add(checkin.Place.Name)));
                        checkin.ReFetch(DynamicWrapper.eLoadOptions.Full);
                    }
                }
                else
                {
                    ListOfPlaces.Invoke(new Action(() => ListOfPlaces.Items.Add("You havn't checked in yet")));
                }
            }).Start();
        }

        private void NewPostButton_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                if (NewPostTextBox.Text.Length > 0)
                {
                    r_FBLogic.m_LoggedInUser.PostStatus(NewPostTextBox.Text);
                    string msg = string.Format("Status posted!");
                    MessageBox.Show(msg);
                    NewPostTextBox.Text = string.Empty;
                }
                else
                {
                    string msg = string.Format("Can't post empty string, please try again");
                    MessageBox.Show(msg);
                }
            }).Start();
        }

        private void SearchPictureButton_Click(object sender, EventArgs e)
        {
            FormPhotosSearchByFilter MyPhotosCollectionByFilter = new FormPhotosSearchByFilter(r_FBLogic);
        }

        private void WorldTimeButton_Click(object sender, EventArgs e)
        {
            FormWorldClock m_WorldClock = new FormWorldClock(r_FBLogic);
            m_WorldClock.ShowDialog();
        }
    }
}