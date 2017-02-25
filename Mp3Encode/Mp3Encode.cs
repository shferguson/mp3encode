using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mp3Encode.Encoding;
using System.IO;
using Mp3Encode.Properties;

namespace Mp3Encode
{
    public partial class Mp3Encode : Form
    {
        public Mp3Encode()
        {
            InitializeComponent();
        }

        private void Mp3Encode_Load(object sender, EventArgs e)
        {
            year.Value = DateTime.Now.Year;
            genre.Items.AddRange(LameInterface.GetGenreList().ToArray());

            RestoreSettings();
            if (samplingRate.Text == string.Empty)
                samplingRate.Text = samplingRate.Items[0].ToString();

            qualityTrackBar_Scroll(encodingTrackBar, EventArgs.Empty);
        }

        private void Mp3Encode_Shown(object sender, EventArgs e)
        {
            //genre.Items.AddRange(LameInterface.GetGenreList().ToArray());
        }

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

        private void encodeButton_Click(object sender, EventArgs e)
        {
            lame = new LameInterface();

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
                lame.AverageBitRate = decimal.Parse(LameInterface.ValidBitRates[encodingTrackBar.Value]);
            }
            else if (constantBitrate.Checked)
            {
                lame.EncodingType = EncodingType.ConstantBitRate;
                lame.BitRate = decimal.Parse(LameInterface.ValidBitRates[encodingTrackBar.Value]);
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

            cancelButton.Enabled = true;
            cancelButton.Visible = true;
            encodeButton.Visible = false;
            tabControl.Enabled = false;
            progressBar.Visible = true;
            encodingStatus.Text = string.Empty;
            encodingStatus.Visible = true;
            if (!encodingBackgroundWorkder.IsBusy)
                encodingBackgroundWorkder.RunWorkerAsync(lame);
        }

        private LameInterface lame = null;

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
            if (closeAfterCancel)
            {
                Close();
                return;
            }

            if (e.Error == null)
            {
                progressBar.Value = 100;lame.AverageBitRate = decimal.Parse(LameInterface.ValidBitRates[encodingTrackBar.Value]);
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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            encodingStatus.Text = "Canceling";
            lame.Cancel = true;
            canceling = true;
            cancelButton.Enabled = false;
        }

        private bool canceling = false;
        private bool closeAfterCancel = false;

        private void Mp3Encode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (encodingBackgroundWorkder.IsBusy)
            {
                canceling = true;
                encodingStatus.Text = "Canceling";
                closeAfterCancel = true;
                lame.Cancel = true;
                e.Cancel = true;
            }
            else
            {
                SaveSettings();
            }
        }

        #region Settings

        public void RestoreSettings()
        {
            if (Enum.IsDefined(typeof(EncodingType), Properties.Settings.Default.EncodingType))
            {
                EncodingType type = (EncodingType)Settings.Default.EncodingType;
                switch (type)
                {
                    case EncodingType.Quality:
                        quality.Checked = true;
                        break;
                    case EncodingType.AverageBitRate:
                        averageBitrate.Checked = true;
                        break;
                    case EncodingType.ConstantBitRate:
                        constantBitrate.Checked = true;
                        break;
                }

                if (Settings.Default.EncodingValue >= encodingTrackBar.Minimum &&
                    Settings.Default.EncodingValue <= encodingTrackBar.Maximum)
                    encodingTrackBar.Value = Settings.Default.EncodingValue;

                if (samplingRate.Items.Contains(Settings.Default.SamplingRate))
                    samplingRate.Text = Settings.Default.SamplingRate;

                monoMode.Checked = Settings.Default.MonoMode;

                artist.Text = Settings.Default.Artist;
                title.Text = Settings.Default.Title;
                album.Text = Settings.Default.Album;
                if (genre.Items.Contains(Settings.Default.Genre))
                    genre.Text = Settings.Default.Genre;
                comment.Text = Settings.Default.Comment;
                        

            }
        }

        public void SaveSettings()
        {
            if (quality.Checked)
                Settings.Default.EncodingType = (int)EncodingType.Quality;
            else if (averageBitrate.Checked)
                Settings.Default.EncodingType = (int)EncodingType.AverageBitRate;
            else if (constantBitrate.Checked)
                Settings.Default.EncodingType = (int)EncodingType.ConstantBitRate;

            Settings.Default.EncodingValue = encodingTrackBar.Value;
            Settings.Default.SamplingRate = samplingRate.Text;
            Settings.Default.MonoMode = monoMode.Checked;

            Settings.Default.Artist = artist.Text;
            Settings.Default.Title = title.Text;
            Settings.Default.Album = album.Text;
            Settings.Default.Genre = genre.Text;
            Settings.Default.Comment = comment.Text;

            Settings.Default.Save();
        }

        #endregion
    }
}
