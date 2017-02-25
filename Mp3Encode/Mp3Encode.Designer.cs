namespace Mp3Encode
{
    partial class Mp3Encode
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
            this.encodeButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.encodingBackgroundWorkder = new System.ComponentModel.BackgroundWorker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.encodingStatus = new System.Windows.Forms.Label();
            this.id3TagTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.artist = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.TextBox();
            this.comment = new System.Windows.Forms.TextBox();
            this.album = new System.Windows.Forms.TextBox();
            this.genre = new System.Windows.Forms.ComboBox();
            this.year = new System.Windows.Forms.NumericUpDown();
            this.mp3EncodeTabPage = new System.Windows.Forms.TabPage();
            this.inputFile = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.quality = new System.Windows.Forms.RadioButton();
            this.averageBitrate = new System.Windows.Forms.RadioButton();
            this.constantBitrate = new System.Windows.Forms.RadioButton();
            this.encodingTrackBar = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.encodingLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.samplingRate = new System.Windows.Forms.ComboBox();
            this.monoMode = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.id3TagTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year)).BeginInit();
            this.mp3EncodeTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodingTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(492, 325);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(75, 23);
            this.encodeButton.TabIndex = 2;
            this.encodeButton.Text = "Encode";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(86, 325);
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
            this.encodingBackgroundWorkder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.encodingBackgroundWorkder_RunWorkerCompleted);
            this.encodingBackgroundWorkder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.encodingBackgroundWorkder_ProgressChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(491, 325);
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
            this.encodingStatus.Location = new System.Drawing.Point(13, 330);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Artist";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Genre";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "&Year";
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
            // artist
            // 
            this.artist.Location = new System.Drawing.Point(67, 29);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(221, 20);
            this.artist.TabIndex = 1;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(327, 29);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(208, 20);
            this.title.TabIndex = 3;
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(67, 123);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(468, 20);
            this.comment.TabIndex = 11;
            // 
            // album
            // 
            this.album.Location = new System.Drawing.Point(67, 58);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(221, 20);
            this.album.TabIndex = 5;
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
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Location = new System.Drawing.Point(504, 17);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(28, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
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
            // encodingTrackBar
            // 
            this.encodingTrackBar.LargeChange = 1;
            this.encodingTrackBar.Location = new System.Drawing.Point(17, 66);
            this.encodingTrackBar.Maximum = 9;
            this.encodingTrackBar.Minimum = 1;
            this.encodingTrackBar.Name = "encodingTrackBar";
            this.encodingTrackBar.Size = new System.Drawing.Size(515, 45);
            this.encodingTrackBar.TabIndex = 3;
            this.encodingTrackBar.Value = 1;
            this.encodingTrackBar.Scroll += new System.EventHandler(this.qualityTrackBar_Scroll);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(481, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Maximum";
            // 
            // encodingLabel
            // 
            this.encodingLabel.Location = new System.Drawing.Point(179, 114);
            this.encodingLabel.Name = "encodingLabel";
            this.encodingLabel.Size = new System.Drawing.Size(194, 18);
            this.encodingLabel.TabIndex = 5;
            this.encodingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Sampling Rate";
            // 
            // samplingRate
            // 
            this.samplingRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.samplingRate.FormattingEnabled = true;
            this.samplingRate.Items.AddRange(new object[] {
            "(Automatic)",
            "8.000",
            "11.025",
            "12.000",
            "16.000",
            "22.050",
            "24.000",
            "32.000",
            "44.100",
            "48.000"});
            this.samplingRate.Location = new System.Drawing.Point(96, 23);
            this.samplingRate.MaxDropDownItems = 12;
            this.samplingRate.Name = "samplingRate";
            this.samplingRate.Size = new System.Drawing.Size(121, 21);
            this.samplingRate.TabIndex = 1;
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mp3EncodeTabPage);
            this.tabControl.Controls.Add(this.id3TagTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(558, 307);
            this.tabControl.TabIndex = 0;
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
            // Mp3Encode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 359);
            this.Controls.Add(this.encodingStatus);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.tabControl);
            this.Name = "Mp3Encode";
            this.Text = "MP3 Encoder";
            this.Load += new System.EventHandler(this.Mp3Encode_Load);
            this.Shown += new System.EventHandler(this.Mp3Encode_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mp3Encode_FormClosing);
            this.id3TagTabPage.ResumeLayout(false);
            this.id3TagTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.year)).EndInit();
            this.mp3EncodeTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encodingTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

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
    }
}

