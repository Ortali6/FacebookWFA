using System.Threading;
using System;
using System.Windows.Forms;
using DesktopFacebook.Logic;

namespace DesktopFacebook.UI
{
    public partial class FormWorldClock : Form
    {
        private readonly FBLogic r_FBLogic;

        public FormWorldClock(FBLogic i_FBLogic)
        {
            InitializeComponent();
            r_FBLogic = i_FBLogic;
            disableButtons();
            r_FBLogic.CreateWorldClockLogic(new RefreshPostTextDelegate(ListOfCapitalCitys_SelectedIndexChanged));
            CityPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void disableButtons()
        {
            PostTheTimeButton.Enabled = false;
            PhotoCheckBox.Enabled = false;
            RefreshCheckBox.Enabled = false;
        }

        private void enableButtons()
        {
            PostTheTimeButton.Invoke(new Action(() => PostTheTimeButton.Enabled = true));
            PhotoCheckBox.Invoke(new Action(() => PhotoCheckBox.Enabled = true));
            RefreshCheckBox.Invoke(new Action(() => RefreshCheckBox.Enabled = true));
        }

        private void ListOfCapitalCitys_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_FBLogic.SetCurrentCity = getCurrentCityName();
            CityAndTimeTextBox.Text = r_FBLogic.GetPostCityAndTime();
            PostTheTimeButton.Enabled = true;
            if (PhotoCheckBox.Checked)
            {
                seeCityPhoto();
            }
        }

        private void PostTheTimeButton_Click(object sender, EventArgs e)
        {
            if (CityAndTimeTextBox.Text.Length > 0)
            {
                r_FBLogic.PostStatus(CityAndTimeTextBox.Text);
                string msg = string.Format("Status posted!");
                MessageBox.Show(msg);
                CityAndTimeTextBox.Text = string.Empty;
                PostTheTimeButton.Enabled = false;
            }
            else
            {
                string msg = string.Format("Can't post empty string, please try again");
                MessageBox.Show(msg);
            }
        }

        private string getCurrentCityName()
        {
            return ListOfCapitalCitys.SelectedItem.ToString();
        }

        private void seeCityPhoto()
        {
            if (r_FBLogic.IsSourcePhotoAvailable())
            {
                if (r_FBLogic.IsAvailablePhotoInURL())
                {
                    CityPhoto.LoadAsync(r_FBLogic.CurrentPhotoURL);
                }
                else
                {
                    CityPhoto.Image = Properties.Resources.profilepic;
                }
            }
            else
            {
                CityPhoto.Image = Properties.Resources.profilepic;
            }

            CityPhotoLabel.Text = r_FBLogic.CurrentCityMessage;
        }

        private void GetCapitalCitysButton_Click(object sender, EventArgs e)
        {
            GetCapitalCitysButton.Enabled = false;
            new Thread(() =>
            {
                ListOfCapitalCitys.Invoke(new Action(() => ListOfCapitalCitys.Items.Clear()));
                r_FBLogic.SetListOfCitys();

                foreach (string cityName in r_FBLogic.GetListOfCitys)
                {
                    ListOfCapitalCitys.Invoke(new Action(() => ListOfCapitalCitys.Items.Add(cityName)));
                }

                ListOfCapitalCitys.Invoke(new Action(() => ListOfCapitalCitys.Sorted = true));
                ListOfCapitalCitys.Invoke(new Action(() => ListOfCapitalCitys.SetSelected(0, true)));
                enableButtons();
            }).Start();
        }

        private void PhotoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PhotoCheckBox.Checked)
            {
                seeCityPhoto();
            }
            else
            {
                if (CityPhoto.Image != null)
                {
                    CityPhoto.Image = null;
                    CityPhotoLabel.Text = "City photo: ";
                }
            }
        }

        private void RefreshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RefreshCheckBox.Checked)
            {
                r_FBLogic.StartRefreshTimer();
            }
            else
            {
                r_FBLogic.StopRefreshTimer();
            }
        }
    }
}