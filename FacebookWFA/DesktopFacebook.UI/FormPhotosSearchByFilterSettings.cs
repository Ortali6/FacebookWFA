using System;
using System.Windows.Forms;
using DesktopFacebook.Logic;

namespace DesktopFacebook.UI
{ 
    public partial class FormPhotosSearchByFilterSettings : Form
    {
        private readonly FBLogic r_FBLogic;

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public int AmoutOfPictures { get; private set; }

        public string m_filterBy { get; private set; }

        public FormPhotosSearchByFilterSettings(FBLogic i_FBLogic)
        {
            r_FBLogic = i_FBLogic;
            InitializeComponent();
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today;
            numericUpDownAmount.Maximum = r_FBLogic.MaxAmountOfPicForUser();
            numericUpDownAmount.Enabled = false;
            FindPicsButton.Enabled = false;
            MostCommentsRadioButton.CheckedChanged += RadioButton_checkChanged;
            MostLikesRadioButton.CheckedChanged += RadioButton_checkChanged;
        }

        private void RadioButton_checkChanged(object sender, EventArgs e)
        {
            numericUpDownAmount.Enabled = true;
            FindPicsButton.Enabled = true;
            RadioButton filterByRadioButton = sender as RadioButton;
            m_filterBy = filterByRadioButton.Text;
            FindPicsButton.Text = string.Format("Find my pictures filtered by: {0}!", m_filterBy);
        }

        private void FindPicsButton_Click(object sender, EventArgs e)
        {
            if ((dateTimePickerStartDate.Value <= dateTimePickerEndDate.Value) && (dateTimePickerEndDate.Value <= DateTime.Today))
            {
                AmoutOfPictures = (int)numericUpDownAmount.Value;
                StartTime = dateTimePickerStartDate.Value;
                EndTime = dateTimePickerEndDate.Value;
                this.Close();
            }
            else if (dateTimePickerStartDate.Value > dateTimePickerEndDate.Value)
            {
                MessageBox.Show(
@"Error: the start date is after the end date.
Please enter a valid amount of time and try again", 
"Error: search parameter not valid");
            }
            else
            {
                MessageBox.Show(
@"Error: the last valid end date is today. 
Please enter a valid amount of time and try again", 
"Error");
            }
        }
    }
}
