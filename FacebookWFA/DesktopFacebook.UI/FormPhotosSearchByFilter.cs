using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using DesktopFacebook.Logic;

namespace DesktopFacebook.UI
{
    public partial class FormPhotosSearchByFilter : Form
    {
        private const int k_SpeaceBetweenPictureBoxs = 10;
        private readonly FBLogic r_FBLogic;
        private bool m_ToClose = false;
        private IEnumerator<Photo> m_MyCollectionPicIterator;
        private FormPhotosSearchByFilterSettings m_CollectionPicSettings;
        private FadePictureBox m_ViewPicture = null;
        private Label m_CurrPictureDate;
        private Label m_AmountOfFilterPerCurrPic;

        public FormPhotosSearchByFilter(FBLogic i_FBLogic)
        {
            InitializeComponent();
            r_FBLogic = i_FBLogic;
            r_FBLogic.CreatePhotosSearchByFilterLogic();
            m_CollectionPicSettings = new FormPhotosSearchByFilterSettings(r_FBLogic);
            m_CurrPictureDate = new Label();
            m_AmountOfFilterPerCurrPic = new Label();
            m_ViewPicture = new FadePictureBox();
            BuildForm();
            if (!m_ToClose)
            {
                ShowDialog();
            }
            else
            {
                Close();
            }
        }

        public void BuildForm()
        {
            DialogResult DR = m_CollectionPicSettings.ShowDialog();
            clearPhotos();
            Invalidate();

            if (m_MyCollectionPicIterator != null)
            {
                m_MyCollectionPicIterator.Dispose();
            }

            if (DR == DialogResult.OK)
            {
                if(m_ViewPicture.ImageLocation != null)
                {
                    m_ViewPicture.Image = null;                    
                    m_AmountOfFilterPerCurrPic.Text = null;
                    m_AmountOfFilterPerCurrPic.Refresh();
                    m_ViewPicture.Refresh();
                }

                Text = string.Format("Photos search by {0}", m_CollectionPicSettings.m_filterBy);
                Refresh();
                m_MyCollectionPicIterator = r_FBLogic.MyPhotosSearchByFilter(m_CollectionPicSettings.AmoutOfPictures, m_CollectionPicSettings.StartTime, m_CollectionPicSettings.EndTime, m_CollectionPicSettings.m_filterBy);

                if (m_MyCollectionPicIterator.MoveNext())
                {                    
                    buildAndDisplayPictureBoard();
                }
                else
                {
                    MessageBox.Show(@"You haven't uploaded any pictures during the given search parameter", "Error: no picture found");
                }
            }
            else
            {
                m_ToClose = true;
            }
        }

        private void displayCurrPic(string i_PhotoUrl, int i_CurrentTag)
        {
            m_ViewPicture.LoadAsync(i_PhotoUrl);
            m_ViewPicture.Update();
            m_ViewPicture.Refresh();
            m_AmountOfFilterPerCurrPic.Text = string.Format("This picture has {0} {1}", r_FBLogic.GetAmountOfFiltered(i_CurrentTag), m_CollectionPicSettings.m_filterBy);         
        }

        private void buildAndDisplayPictureBoard()
        {
            int indexOfCurrPicAndLabel = 0;
            int pictureBoxsLocationWidth = k_SpeaceBetweenPictureBoxs;
            int pictureBoxsLocationHeight = 0;
            int pictureBoxsSize = 120;
            int labelLocationHeght = pictureBoxsLocationHeight + pictureBoxsSize + pictureBoxsLocationWidth;
            m_MyCollectionPicIterator.Reset();
            while (m_MyCollectionPicIterator.MoveNext())
            {
                FadePictureBox buildPictures = new FadePictureBox();
                buildPictures.Size = new Size(pictureBoxsSize, pictureBoxsSize);
                buildPictures.Location = new Point(pictureBoxsLocationWidth, pictureBoxsLocationHeight);
                pictureBoxsLocationWidth += pictureBoxsSize + k_SpeaceBetweenPictureBoxs;
                buildPictures.Load(m_MyCollectionPicIterator.Current.PictureNormalURL);
                buildPictures.SizeMode = PictureBoxSizeMode.StretchImage;
                Label numOfFilteredLabel = new Label();
                numOfFilteredLabel.AutoSize = true;
                numOfFilteredLabel.Text = string.Format("Number of {0}: {1}", m_CollectionPicSettings.m_filterBy, r_FBLogic.GetAmountBySorterPerPhoto(m_MyCollectionPicIterator.Current));
                numOfFilteredLabel.Location = new Point(pictureBoxsLocationWidth - pictureBoxsSize, labelLocationHeght);
                buildPictures.Tag = indexOfCurrPicAndLabel;
                Controls.Add(numOfFilteredLabel);
                panel1.Controls.Add(buildPictures);
                panel1.Controls.Add(numOfFilteredLabel);
                buildPictures.MouseClick += BuildPictures_MouseClick;
                indexOfCurrPicAndLabel++;
                panel1.Refresh();
            }

            panel1.VerticalScroll.Maximum = 0;
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;
            pictureBoxsLocationWidth += k_SpeaceBetweenPictureBoxs;
            buildViewPicture();
        }

        private void BuildPictures_MouseClick(object sender, MouseEventArgs e)
        {
            FadePictureBox pic = sender as FadePictureBox;
            displayCurrPic(pic.ImageLocation, (int)pic.Tag);
        }

        private void buildViewPicture()
        {
            int width, Height;
            Height = k_SpeaceBetweenPictureBoxs;
            m_ViewPicture.Width = this.Width / 2;
            m_ViewPicture.Height = this.Height / 2;
            width = (Width / 2) - (m_ViewPicture.Width / 2);
            m_CurrPictureDate.Location = new Point(width, Height);
            m_CurrPictureDate.AutoSize = true;
            Controls.Add(m_CurrPictureDate);
            Height += m_CurrPictureDate.Height + k_SpeaceBetweenPictureBoxs;
            m_ViewPicture.Location = new Point(width, Height);
            m_ViewPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(m_ViewPicture);
            Height += m_ViewPicture.Height + k_SpeaceBetweenPictureBoxs;
            m_AmountOfFilterPerCurrPic.Location = new Point(width, Height);
            m_AmountOfFilterPerCurrPic.AutoSize = true;
            Controls.Add(m_AmountOfFilterPerCurrPic);
            Height += m_AmountOfFilterPerCurrPic.Height + k_SpeaceBetweenPictureBoxs;
            m_MyCollectionPicIterator.Reset();
            m_MyCollectionPicIterator.MoveNext();
            displayCurrPic(m_MyCollectionPicIterator.Current.PictureNormalURL, 0);
        }

        private void clearPhotos()
        {
            panel1.Controls.Clear();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            BuildForm();
        }
    }
}