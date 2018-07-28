using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DesktopFacebook.UI
{
    internal class FadePictureBox : PictureBox
    {
        private const int k_Interval = 200;
        private Timer m_FadeTimer;
        private float m_CurrentOpacity = 1F;
        private string m_ImageUrl;

        public FadePictureBox()
        {
            m_FadeTimer = new Timer();
            m_FadeTimer.Interval = k_Interval;
            m_FadeTimer.Tick += fadeTimer_Tick;
        }

        public new void Load(string i_ImageUrl)
        {
            m_ImageUrl = i_ImageUrl;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if(ImageLocation == null)
            {
                ImageLocation = m_ImageUrl;
            }

            base.OnPaint(pe);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            m_FadeTimer.Start();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_FadeTimer.Stop();
            refreshCurrentImage();
            Image = changeOpacity(Image, m_CurrentOpacity);
            base.OnMouseLeave(e);
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (m_CurrentOpacity > 0F)
            {
                m_CurrentOpacity -= 0.10F;
                this.Image = changeOpacity(this.Image, m_CurrentOpacity);
            }
            else
            {
                refreshCurrentImage();
            }          
        }

        private void refreshCurrentImage()
        {
            LoadAsync(ImageLocation);
            Update();
            m_CurrentOpacity = 1F;
        }

        private Bitmap changeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix { Matrix33 = opacityvalue };
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();
            return bmp;
        }
    }
}
