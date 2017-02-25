namespace Mp3Encode
{
    partial class Mp3EncodeForm
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mp3EncodeForm));
            this.encodeButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.encodingBackgroundWorkder = new System.ComponentModel.BackgroundWorker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.encodingStatus = new System.Windows.Forms.Label();
            this.id3TagTabPage = new System.Windows.Forms.TabPage();
            this.year = new System.Windows.Forms.NumericUpDown();
            this.genre = new System.Windows.Forms.ComboBox();
            this.album = new System.Windows.Forms.TextBox();
            this.comment = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.TextBox();
            this.artist = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mp3EncodeTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inputFile = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.monoMode = new System.Windows.Forms.CheckBox();
            this.samplingRate = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.encodingLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.encodingTrackBar = new System.Windows.Forms.TrackBar();
            this.constantBitrate = new System.Windows.Forms.RadioButton();
            this.averageBitrate = new System.Windows.Forms.RadioButton();
            this.quality = new System.Windows.Forms.RadioButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.profileList = new System.Windows.Forms.ComboBox();
            this.deleteProfileButton = new System.Windows.Forms.Button();
            this.saveProfileButton = new System.Windows.Forms.Button();
            this.newProfileButton = new System.Windows.Forms.Button();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.profileToolTip = new System.Windows.Forms.ToolTip(this.components);
            label1 = new System.Windows.Forms.Label();
            this.id3TagTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year)).BeginInit();
            this.mp3EncodeTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodingTrackBar)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 13);
            label1.TabIndex = 5;
            label1.Text = "Profile:";
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(492, 348);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(75, 23);
            this.encodeButton.TabIndex = 2;
            this.encodeButton.Text = "Encode";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(86, 348);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 23);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // encodingBackgroundWorkder
            // 
            this.encodingBackgroundWorkder.WorkerReportsProgress = true;
            this.encodingBackgroundWorkder.WorkerSupportsCancellation = true;
            this.encodingBackgroundWorkder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.encodingBackgroundWorkder_DoWork);
            this.encodingBackgroundWorkder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.encodingBackgroundWorkder_ProgressChanged);
            this.encodingBackgroundWorkder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.encodingBackgroundWorkder_RunWorkerCompleted);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(492, 348);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // encodingStatus
            // 
            this.encodingStatus.Location = new System.Drawing.Point(13, 353);
            this.encodingStatus.Name = "encodingStatus";
            this.encodingStatus.Size = new System.Drawing.Size(68, 23);
            this.encodingStatus.TabIndex = 0;
            this.encodingStatus.Visible = false;
            // 
            // id3TagTabPage
            // 
            this.id3TagTabPage.Controls.Add(this.year);
            this.id3TagTabPage.Controls.Add(this.genre);
            this.id3TagTabPage.Controls.Add(this.album);
            this.id3TagTabPage.Controls.Add(this.comment);
            this.id3TagTabPage.Controls.Add(this.title);
            this.id3TagTabPage.Controls.Add(this.artist);
            this.id3TagTabPage.Controls.Add(this.label7);
            this.id3TagTabPage.Controls.Add(this.label6);
            this.id3TagTabPage.Controls.Add(this.label5);
            this.id3TagTabPage.Controls.Add(this.label4);
            this.id3TagTabPage.Controls.Add(this.label3);
            this.id3TagTabPage.Controls.Add(this.label2);
            this.id3TagTabPage.Location = new System.Drawing.Point(4, 22);
            this.id3TagTabPage.Name = "id3TagTabPage";
            this.id3TagTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.id3TagTabPage.Size = new System.Drawing.Size(550, 281);
            this.id3TagTabPage.TabIndex = 1;
            this.id3TagTabPage.Text = "ID3 Tags";
            this.id3TagTabPage.UseVisualStyleBackColor = true;
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(327, 85);
            this.year.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.year.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(75, 20);
            this.year.TabIndex = 9;
            this.year.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // genre
            // 
            this.genre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.genre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.genre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genre.FormattingEnabled = true;
            this.genre.Location = new System.Drawing.Point(67, 93);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(148, 21);
            this.genre.Sorted = true;
            this.genre.TabIndex = 7;
            // 
            // album
            // 
            this.album.Location = new System.Drawing.Point(67, 58);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(221, 20);
            this.album.TabIndex = 5;
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(67, 123);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(468, 20);
            this.comment.TabIndex = 11;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(327, 29);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(208, 20);
            this.title.TabIndex = 3;
            // 
            // artist
            // 
            this.artist.Location = new System.Drawing.Point(67, 29);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(221, 20);
            this.artist.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "&Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "&Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "&Comment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Genre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Al&bum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Artist";
            // 
            // mp3EncodeTabPage
            // 
            this.mp3EncodeTabPage.Controls.Add(this.groupBox3);
            this.mp3EncodeTabPage.Controls.Add(this.groupBox2);
            this.mp3EncodeTabPage.Controls.Add(this.groupBox1);
            this.mp3EncodeTabPage.Location = new System.Drawing.Point(4, 22);
            this.mp3EncodeTabPage.Name = "mp3EncodeTabPage";
            this.mp3EncodeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mp3EncodeTabPage.Size = new System.Drawing.Size(550, 281);
            this.mp3EncodeTabPage.TabIndex = 0;
            this.mp3EncodeTabPage.Text = "MP3 Encoding";
            this.mp3EncodeTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inputFile);
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(538, 46);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input File";
            // 
            // inputFile
            // 
            this.inputFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.inputFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.inputFile.Location = new System.Drawing.Point(6, 19);
            this.inputFile.Name = "inputFile";
            this.inputFile.Size = new System.Drawing.Size(492, 20);
            this.inputFile.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(504, 17);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(28, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.monoMode);
            this.groupBox2.Controls.Add(this.samplingRate);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 61);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced";
            // 
            // monoMode
            // 
            this.monoMode.AutoSize = true;
            this.monoMode.Location = new System.Drawing.Point(449, 25);
            this.monoMode.Name = "monoMode";
            this.monoMode.Size = new System.Drawing.Size(83, 17);
            this.monoMode.TabIndex = 2;
            this.monoMode.Text = "Mono Mode";
            this.monoMode.UseVisualStyleBackColor = true;
            // 
            // samplingRate
            // 
            this.samplingRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplingRate.FormattingEnabled = true;
            this.samplingRate.Location = new System.Drawing.Point(96, 23);
            this.samplingRate.MaxDropDownItems = 12;
            this.samplingRate.Name = "samplingRate";
            this.samplingRate.Size = new System.Drawing.Size(121, 21);
            this.samplingRate.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Sampling Rate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.encodingLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.encodingTrackBar);
            this.groupBox1.Controls.Add(this.constantBitrate);
            this.groupBox1.Controls.Add(this.averageBitrate);
            this.groupBox1.Controls.Add(this.quality);
            this.groupBox1.Location = new System.Drawing.Point(6, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 142);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quality";
            // 
            // encodingLabel
            // 
            this.encodingLabel.Location = new System.Drawing.Point(179, 114);
            this.encodingLabel.Name = "encodingLabel";
            this.encodingLabel.Size = new System.Drawing.Size(194, 18);
            this.encodingLabel.TabIndex = 5;
            this.encodingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(481, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Maximum";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Minimum";
            // 
            // encodingTrackBar
            // 
            this.encodingTrackBar.LargeChange = 1;
            this.encodingTrackBar.Location = new System.Drawing.Point(17, 66);
            this.encodingTrackBar.Maximum = 9;
            this.encodingTrackBar.Name = "encodingTrackBar";
            this.encodingTrackBar.Size = new System.Drawing.Size(515, 45);
            this.encodingTrackBar.TabIndex = 3;
            this.encodingTrackBar.Value = 1;
            this.encodingTrackBar.Scroll += new System.EventHandler(this.qualityTrackBar_Scroll);
            // 
            // constantBitrate
            // 
            this.constantBitrate.AutoSize = true;
            this.constantBitrate.Location = new System.Drawing.Point(398, 29);
            this.constantBitrate.Name = "constantBitrate";
            this.constantBitrate.Size = new System.Drawing.Size(100, 17);
            this.constantBitrate.TabIndex = 2;
            this.constantBitrate.TabStop = true;
            this.constantBitrate.Text = "Constant Bitrate";
            this.constantBitrate.UseVisualStyleBackColor = true;
            this.constantBitrate.CheckedChanged += new System.EventHandler(this.constantBitrate_CheckedChanged);
            // 
            // averageBitrate
            // 
            this.averageBitrate.AutoSize = true;
            this.averageBitrate.Location = new System.Drawing.Point(220, 29);
            this.averageBitrate.Name = "averageBitrate";
            this.averageBitrate.Size = new System.Drawing.Size(98, 17);
            this.averageBitrate.TabIndex = 1;
            this.averageBitrate.TabStop = true;
            this.averageBitrate.Text = "Average Bitrate";
            this.averageBitrate.UseVisualStyleBackColor = true;
            this.averageBitrate.CheckedChanged += new System.EventHandler(this.averageBitrate_CheckedChanged);
            // 
            // quality
            // 
            this.quality.AutoSize = true;
            this.quality.Location = new System.Drawing.Point(50, 29);
            this.quality.Name = "quality";
            this.quality.Size = new System.Drawing.Size(90, 17);
            this.quality.TabIndex = 0;
            this.quality.TabStop = true;
            this.quality.Text = "Quality Based";
            this.quality.UseVisualStyleBackColor = true;
            this.quality.CheckedChanged += new System.EventHandler(this.quality_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mp3EncodeTabPage);
            this.tabControl.Controls.Add(this.id3TagTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 35);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(558, 307);
            this.tabControl.TabIndex = 0;
            // 
            // profileList
            // 
            this.profileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileList.FormattingEnabled = true;
            this.profileList.Location = new System.Drawing.Point(72, 8);
            this.profileList.Name = "profileList";
            this.profileList.Size = new System.Drawing.Size(397, 21);
            this.profileList.Sorted = true;
            this.profileList.TabIndex = 4;
            this.profileList.SelectedIndexChanged += new System.EventHandler(this.profileList_SelectedIndexChanged);
            // 
            // deleteProfileButton
            // 
            this.deleteProfileButton.Image = global::Mp3Encode.Properties.Resources.bullet_cross;
            this.deleteProfileButton.Location = new System.Drawing.Point(547, 6);
            this.deleteProfileButton.Name = "deleteProfileButton";
            this.deleteProfileButton.Size = new System.Drawing.Size(23, 23);
            this.deleteProfileButton.TabIndex = 6;
            this.deleteProfileButton.Tag = "Delete Profile";
            this.deleteProfileButton.UseVisualStyleBackColor = true;
            this.deleteProfileButton.Click += new System.EventHandler(this.deleteProfileButton_Click);
            // 
            // saveProfileButton
            // 
            this.saveProfileButton.Image = global::Mp3Encode.Properties.Resources.disk_black;
            this.saveProfileButton.Location = new System.Drawing.Point(518, 6);
            this.saveProfileButton.Name = "saveProfileButton";
            this.saveProfileButton.Size = new System.Drawing.Size(23, 23);
            this.saveProfileButton.TabIndex = 7;
            this.saveProfileButton.Tag = "Save Profile";
            this.saveProfileButton.UseVisualStyleBackColor = true;
            this.saveProfileButton.Click += new System.EventHandler(this.saveProfileButton_Click);
            // 
            // newProfileButton
            // 
            this.newProfileButton.Image = global::Mp3Encode.Properties.Resources.bullet_plus;
            this.newProfileButton.Location = new System.Drawing.Point(489, 6);
            this.newProfileButton.Name = "newProfileButton";
            this.newProfileButton.Size = new System.Drawing.Size(23, 23);
            this.newProfileButton.TabIndex = 8;
            this.newProfileButton.Tag = "New Profile";
            this.newProfileButton.UseVisualStyleBackColor = true;
            this.newProfileButton.Click += new System.EventHandler(this.newProfileButton_Click);
            // 
            // Mp3EncodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 382);
            this.Controls.Add(this.newProfileButton);
            this.Controls.Add(this.saveProfileButton);
            this.Controls.Add(this.deleteProfileButton);
            this.Controls.Add(label1);
            this.Controls.Add(this.profileList);
            this.Controls.Add(this.encodingStatus);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mp3EncodeForm";
            this.Text = "MP3 Encoder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mp3Encode_FormClosing);
            this.Load += new System.EventHandler(this.Mp3Encode_Load);
            this.id3TagTabPage.ResumeLayout(false);
            this.id3TagTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year)).EndInit();
            this.mp3EncodeTabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodingTrackBar)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker encodingBackgroundWorkder;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label encodingStatus;
        private System.Windows.Forms.TabPage id3TagTabPage;
        private System.Windows.Forms.NumericUpDown year;
        private System.Windows.Forms.ComboBox genre;
        private System.Windows.Forms.TextBox album;
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox artist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage mp3EncodeTabPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox inputFile;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox monoMode;
        private System.Windows.Forms.ComboBox samplingRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label encodingLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar encodingTrackBar;
        private System.Windows.Forms.RadioButton constantBitrate;
        private System.Windows.Forms.RadioButton averageBitrate;
        private System.Windows.Forms.RadioButton quality;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ComboBox profileList;
        private System.Windows.Forms.Button deleteProfileButton;
        private System.Windows.Forms.Button saveProfileButton;
        private System.Windows.Forms.Button newProfileButton;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.ToolTip profileToolTip;
    }
}

