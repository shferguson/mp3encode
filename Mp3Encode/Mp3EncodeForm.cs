#region usings

using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Mp3Encode.Encoding;
using Mp3Encode.Properties;
using System.Collections.Generic;
using Mp3Encode.Data;

#endregion

namespace Mp3Encode
{
    public partial class Mp3EncodeForm : Form
    {
        #region Private Fields

        // Interface to lame -- couldn't figure out a good way to make this local and still get access from CancelEncoding
        private LameInterface lame = null;

        // Mark that we are waiting for canceling encoding
        private bool canceling = false;

        // Mark that we will close immediate after encoding stops
        private bool closeAfterEncoding = false;

        private UserSettings userSettings = new UserSettings();

        #endregion

        #region Constructor

        public Mp3EncodeForm()
        {
            InitializeComponent();

            profileToolTip.SetToolTip(newProfileButton, "New Profile");
            profileToolTip.SetToolTip(saveProfileButton, "Save Profile");
            profileToolTip.SetToolTip(deleteProfileButton, "Delete Profile");
        }

        #endregion

        #region Form Events

        private void Mp3Encode_Load(object sender, EventArgs e)
        {
            // Always default to this year
            year.Value = DateTime.Now.Year;

            // Load the list of Genre's before restoring settings, or else
            // we can't restore the last used Genre
            genre.Items.AddRange(LameInterface.GetGenreList().ToArray());

            samplingRate.Items.Add("(Automatic)");
            List<decimal> sortedSamplingRate = LameInterface.ValidSamplingRates.ToList();
            sortedSamplingRate.Sort();
            sortedSamplingRate.ForEach(rate => samplingRate.Items.Add(rate.ToString("0.000")));

               if (samplingRate.Text == string.Empty)
                samplingRate.Text = samplingRate.Items[0].ToString();

            // Call the scroll event handler directly to update the scroll data
            qualityTrackBar_Scroll(encodingTrackBar, EventArgs.Empty);

            profileList.DataSource = userSettings.GetAllRecordingSettings();
            profileList.ValueMember = "Id";
            profileList.DisplayMember = "Name";

            RestoreSettings();
        }

        private void Mp3Encode_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If we are in the middle of encoding set the closeAfterCancel flag 
            // so that we will exit as soon as encoding stops
            if (encodingBackgroundWorkder.IsBusy)
            {
                CancelEncoding();
                closeAfterEncoding = true;
            }
            else
            {
                SaveSettings();
                SaveProfile();
            }
        }

        #endregion

        #region Control Event Handlers

        private void quality_CheckedChanged(object sender, EventArgs e)
        {
            if (quality.Checked)
            {
                encodingTrackBar.Minimum = 0;
                encodingTrackBar.Maximum = 9;
                encodingTrackBar.Value = 0;
                qualityTrackBar_Scroll(encodingTrackBar, EventArgs.Empty);
            }
        }

        private void averageBitrate_CheckedChanged(object sender, EventArgs e)
        {
            if (averageBitrate.Checked)
            {
                encodingTrackBar.Minimum = 0;
                encodingTrackBar.Value = 0;
                encodingTrackBar.Maximum = LameInterface.ValidBitRates.Length - 1;
                qualityTrackBar_Scroll(encodingTrackBar, EventArgs.Empty);
            }
        }

        private void constantBitrate_CheckedChanged(object sender, EventArgs e)
        {
            if (constantBitrate.Checked)
            {
                encodingTrackBar.Minimum = 0;
                encodingTrackBar.Value = 0;
                encodingTrackBar.Maximum = LameInterface.ValidBitRates.Length - 1;
                qualityTrackBar_Scroll(encodingTrackBar, EventArgs.Empty);
            }
        }

        private void qualityTrackBar_Scroll(object sender, EventArgs e)
        {
            SetEncodingLabelText();
        }

        private void SetEncodingLabelText()
        {
            if (quality.Checked)
                encodingLabel.Text = "Level " + (9 - encodingTrackBar.Value).ToString();
            else
                encodingLabel.Text = LameInterface.ValidBitRates[encodingTrackBar.Value] + " kbps";
        }


        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Select Input File";
                dlg.Filter = "Wave Files (*.wav)|*.wav|All File (*.*)|*.*";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    inputFile.Text = dlg.FileName;
            }
        }

        #endregion

        #region Encoding

        private void encodeButton_Click(object sender, EventArgs e)
        {
            lame = new LameInterface();
            SetEncodingOptions();

            cancelButton.Enabled = true;
            cancelButton.Visible = true;
            encodeButton.Visible = false;
            tabControl.Enabled = false;
            progressBar.Visible = true;
            encodingStatus.Text = string.Empty;
            encodingStatus.Visible = true;
            if (!encodingBackgroundWorkder.IsBusy)
                encodingBackgroundWorkder.RunWorkerAsync(lame);

            SaveProfile();
        }

        private void SetEncodingOptions()
        {
            lame.InputFile = inputFile.Text;
            lame.OutputFile = Path.ChangeExtension(inputFile.Text, ".mp3");

            if (quality.Checked)
            {
                lame.EncodingType = EncodingType.Quality;
                lame.Quality = 9 - encodingTrackBar.Value;
            }
            else if (averageBitrate.Checked)
            {
                lame.EncodingType = EncodingType.AverageBitRate;
                lame.AverageBitRate = LameInterface.ValidBitRates[encodingTrackBar.Value];
            }
            else if (constantBitrate.Checked)
            {
                lame.EncodingType = EncodingType.ConstantBitRate;
                lame.BitRate = LameInterface.ValidBitRates[encodingTrackBar.Value];
            }

            lame.MonoMode = monoMode.Checked;

            lame.Artist = artist.Text;
            lame.Title = title.Text;
            lame.Album = album.Text;
            lame.Year = (int)year.Value;

            lame.Genre = genre.Text;
            lame.Comment = comment.Text;

            if (samplingRate.Text != samplingRate.Items[0].ToString())
                lame.SamplingRate = decimal.Parse(samplingRate.Text);
            else
                lame.SamplingRate = null;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelEncoding();
        }

        private void encodingBackgroundWorkder_DoWork(object sender, DoWorkEventArgs e)
        {
            LameInterface lame = (LameInterface)e.Argument;
            lame.EncodingProgress += new EncodingProgressEventHandler(lame_EncodingProgress);
            lame.Encode();
        }

        void lame_EncodingProgress(object sender, EncodingProgressEventArgs e)
        {
            encodingBackgroundWorkder.ReportProgress(e.PercentComplete, e.TimeLeft);
        }

        private void encodingBackgroundWorkder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!canceling)
            {
                progressBar.Value = e.ProgressPercentage;
                encodingStatus.Text = ((TimeSpan)e.UserState).ToString();
            }
        }

        private void encodingBackgroundWorkder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closeAfterEncoding)
            {
                Close();
                return;
            }

            if (e.Error == null)
            {
                progressBar.Value = 100;
                MessageBox.Show(this, "Encoding Complete", this.Text);
            }
            else 
            {
                MessageBox.Show(this, e.Error.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            progressBar.Value = 0;
            cancelButton.Visible = false;
            encodeButton.Visible = true;
            tabControl.Enabled = true;

            progressBar.Visible = false;
            encodingStatus.Visible = false;
            canceling = false;

            lame = null;
        }

        private void CancelEncoding()
        {
            if (!canceling)
            {
                encodingStatus.Text = "Canceling";
                lame.Cancel = true; // Tell the encoder to stop
                canceling = true;   // Mark canceling so we don't update the status text
                cancelButton.Enabled = false;
            }
        }

        #endregion

        #region Settings

        public void RestoreSettings()
        {
            profileList.Text = Settings.Default.LastProfile;
        }

        public void SaveSettings()
        {
            Settings.Default.LastProfile = profileList.Text;
            Settings.Default.Save();
        }

        #endregion

        #region DataBinding

        public void SetDataBinding(DataRowView settings)
        {
            ClearDataBinding();

            bindingSource.DataSource = settings;

            samplingRate.DataBindings.Add("SelectedItem", bindingSource, "SamplingRate");

            monoMode.DataBindings.Add("Checked", bindingSource, "MonoMode");
            artist.DataBindings.Add("Text", bindingSource, "Artist");
            title.DataBindings.Add("Text", bindingSource, "Title");
            album.DataBindings.Add("Text", bindingSource, "Album");
            genre.DataBindings.Add("Text", bindingSource, "Genre");
            comment.DataBindings.Add("Text", bindingSource, "Comment");

            Binding binding = new Binding("Checked", bindingSource, "QualityType");
            binding.Parse += new ConvertEventHandler(qualityCheckBoxBinding_Parse);
            binding.Format += new ConvertEventHandler(qualityCheckBoxBinding_Format);
            quality.DataBindings.Add(binding);

            binding = new Binding("Checked", bindingSource, "QualityType");
            binding.Parse += new ConvertEventHandler(qualityCheckBoxBinding_Parse);
            binding.Format += new ConvertEventHandler(qualityCheckBoxBinding_Format);
            averageBitrate.DataBindings.Add(binding);

            binding = new Binding("Checked", bindingSource, "QualityType");
            binding.Parse += new ConvertEventHandler(qualityCheckBoxBinding_Parse);
            binding.Format += new ConvertEventHandler(qualityCheckBoxBinding_Format);
            constantBitrate.DataBindings.Add(binding);

            encodingTrackBar.DataBindings.Add("Value", bindingSource, "QualityLevel");

            SetEncodingLabelText();
        }

        private void qualityCheckBoxBinding_Format(object sender, ConvertEventArgs e)
        {
            Binding binding = (Binding)sender;

            EncodingType type = (EncodingType)Convert.ToInt32(e.Value);
            if (binding.Control == quality && type == EncodingType.Quality)
                e.Value = true;
            else if (binding.Control == constantBitrate && type == EncodingType.ConstantBitRate)
                e.Value = true;
            else if (binding.Control == averageBitrate && type == EncodingType.AverageBitRate)
                e.Value = true;
            else
                e.Value = false;
        }

        private void qualityCheckBoxBinding_Parse(object sender, ConvertEventArgs e)
        {
            if (quality.Checked)
                e.Value = (int)EncodingType.Quality;
            else if (averageBitrate.Checked)
                e.Value = (int)EncodingType.AverageBitRate;
            else
                e.Value = (int)EncodingType.ConstantBitRate;
        }

        public void ClearDataBinding()
        {
            profileList.DataBindings.Clear();
            samplingRate.DataBindings.Clear();
            encodingTrackBar.DataBindings.Clear();
            monoMode.DataBindings.Clear();
            artist.DataBindings.Clear();
            title.DataBindings.Clear();
            album.DataBindings.Clear();
            genre.DataBindings.Clear();
            comment.DataBindings.Clear();
            quality.DataBindings.Clear();
            constantBitrate.DataBindings.Clear();
            averageBitrate.DataBindings.Clear();
        }

        #endregion

        #region Profiles

        private void SaveProfile()
        {
            if (profileList.SelectedItem != null)
            {
                var view = (DataRowView)profileList.SelectedItem;
                view.Row.EndEdit();
            }

            DataTable table = (DataTable)profileList.DataSource;
            userSettings.SaveRecordingSettings(table);

            string profile = profileList.Text;
            profileList.DataSource = userSettings.GetAllRecordingSettings();
            profileList.ValueMember = "Id";
            profileList.DisplayMember = "Name";
            profileList.Text = profile;
        }

        private void deleteProfileButton_Click(object sender, EventArgs e)
        {
            if (profileList.SelectedItem != null)
            {
                if (MessageBox.Show(this, "Delete " + profileList.Text + "?", "Delete Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var recordingSettings = (DataRowView)profileList.SelectedItem;
                    recordingSettings.Row.Delete();
                    SaveProfile();
                }
            }
        }

        private void profileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profileList.SelectedItem != null)
            {
                SetDataBinding((DataRowView)profileList.SelectedItem);
            }
        }

        private void saveProfileButton_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void newProfileButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new NewProfileNameDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DataTable table = (DataTable)profileList.DataSource;
                    DataRow newRow = table.NewRow();
                    if (profileList.SelectedItem != null)
                    {
                        var view = (DataRowView)profileList.SelectedItem;
                        view.Row.EndEdit();

                        newRow.ItemArray = view.Row.ItemArray;
                    }
                    else
                    {
                        newRow["SamplingRate"] = "0";
                        newRow["MonoMode"] = 0;
                        newRow["QualityLevel"] = 0;
                        newRow["QualityType"] = 0;
                    }
                    
                    newRow["Name"] = dlg.ProfileName;
                    table.Rows.Add(newRow);
                    profileList.SelectedItem = table.DefaultView[table.Rows.Count - 1];
                }
            }
        }

        #endregion
    }
}