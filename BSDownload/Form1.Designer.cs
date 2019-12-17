namespace BSDownload
{
    partial class Form1
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
            this.webBrowser1 = new Gecko.GeckoWebBrowser();
            this.MenueGB = new System.Windows.Forms.GroupBox();
            this.SettingBtn = new System.Windows.Forms.Button();
            this.DownloadingBtn = new System.Windows.Forms.Button();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.DownloadingPanel = new System.Windows.Forms.Panel();
            this.DownloadPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SeitenCountLabel = new System.Windows.Forms.Label();
            this.backbtn = new System.Windows.Forms.Button();
            this.vorbtn = new System.Windows.Forms.Button();
            this.SerienPanel = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.SettingPanel = new System.Windows.Forms.Panel();
            this.SpeichernBtn = new System.Windows.Forms.Button();
            this.MaxSimDownloadsTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.changeDownFolderBtn = new System.Windows.Forms.Button();
            this.DownloadFolderTB = new System.Windows.Forms.TextBox();
            this.DowloadpathLabel = new System.Windows.Forms.Label();
            this.StaffelPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DescriptionTB = new System.Windows.Forms.RichTextBox();
            this.CoverPB = new System.Windows.Forms.PictureBox();
            this.EpisodenPanel = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.MenueGB.SuspendLayout();
            this.DownloadPanel.SuspendLayout();
            this.SettingPanel.SuspendLayout();
            this.StaffelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoverPB)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.FrameEventsPropagateToMainWindow = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(763, 604);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.UseHttpActivityObserver = false;
            this.webBrowser1.Visible = false;
            // 
            // MenueGB
            // 
            this.MenueGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenueGB.Controls.Add(this.SettingBtn);
            this.MenueGB.Controls.Add(this.DownloadingBtn);
            this.MenueGB.Controls.Add(this.DownloadBtn);
            this.MenueGB.Location = new System.Drawing.Point(1, 0);
            this.MenueGB.Name = "MenueGB";
            this.MenueGB.Size = new System.Drawing.Size(760, 40);
            this.MenueGB.TabIndex = 1;
            this.MenueGB.TabStop = false;
            // 
            // SettingBtn
            // 
            this.SettingBtn.BackColor = System.Drawing.SystemColors.Control;
            this.SettingBtn.Location = new System.Drawing.Point(324, 11);
            this.SettingBtn.Name = "SettingBtn";
            this.SettingBtn.Size = new System.Drawing.Size(150, 23);
            this.SettingBtn.TabIndex = 2;
            this.SettingBtn.Text = "Einstellungen";
            this.SettingBtn.UseVisualStyleBackColor = false;
            this.SettingBtn.Click += new System.EventHandler(this.MenueBtnClick);
            // 
            // DownloadingBtn
            // 
            this.DownloadingBtn.BackColor = System.Drawing.SystemColors.Control;
            this.DownloadingBtn.Location = new System.Drawing.Point(167, 11);
            this.DownloadingBtn.Name = "DownloadingBtn";
            this.DownloadingBtn.Size = new System.Drawing.Size(150, 23);
            this.DownloadingBtn.TabIndex = 1;
            this.DownloadingBtn.Text = "Aktuelle Downloads";
            this.DownloadingBtn.UseVisualStyleBackColor = false;
            this.DownloadingBtn.Click += new System.EventHandler(this.MenueBtnClick);
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.BackColor = System.Drawing.SystemColors.Control;
            this.DownloadBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.DownloadBtn.Location = new System.Drawing.Point(11, 11);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(150, 23);
            this.DownloadBtn.TabIndex = 10;
            this.DownloadBtn.Text = "Download";
            this.DownloadBtn.UseVisualStyleBackColor = false;
            this.DownloadBtn.Click += new System.EventHandler(this.MenueBtnClick);
            // 
            // DownloadingPanel
            // 
            this.DownloadingPanel.AutoScroll = true;
            this.DownloadingPanel.Location = new System.Drawing.Point(1, 41);
            this.DownloadingPanel.Name = "DownloadingPanel";
            this.DownloadingPanel.Size = new System.Drawing.Size(760, 565);
            this.DownloadingPanel.TabIndex = 2;
            this.DownloadingPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.DownloadingPanel_ControlRemoved);
            // 
            // DownloadPanel
            // 
            this.DownloadPanel.Controls.Add(this.button1);
            this.DownloadPanel.Controls.Add(this.SeitenCountLabel);
            this.DownloadPanel.Controls.Add(this.backbtn);
            this.DownloadPanel.Controls.Add(this.vorbtn);
            this.DownloadPanel.Controls.Add(this.SerienPanel);
            this.DownloadPanel.Controls.Add(this.SearchBtn);
            this.DownloadPanel.Controls.Add(this.SearchTB);
            this.DownloadPanel.Location = new System.Drawing.Point(1, 41);
            this.DownloadPanel.Name = "DownloadPanel";
            this.DownloadPanel.Size = new System.Drawing.Size(760, 565);
            this.DownloadPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.DownloadClick);
            // 
            // SeitenCountLabel
            // 
            this.SeitenCountLabel.AutoSize = true;
            this.SeitenCountLabel.Location = new System.Drawing.Point(287, 545);
            this.SeitenCountLabel.Name = "SeitenCountLabel";
            this.SeitenCountLabel.Size = new System.Drawing.Size(0, 13);
            this.SeitenCountLabel.TabIndex = 5;
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(11, 536);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 23);
            this.backbtn.TabIndex = 4;
            this.backbtn.Text = "Zurück";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Visible = false;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // vorbtn
            // 
            this.vorbtn.Location = new System.Drawing.Point(652, 536);
            this.vorbtn.Name = "vorbtn";
            this.vorbtn.Size = new System.Drawing.Size(98, 23);
            this.vorbtn.TabIndex = 3;
            this.vorbtn.Text = "Nächste Seite";
            this.vorbtn.UseVisualStyleBackColor = true;
            this.vorbtn.Visible = false;
            this.vorbtn.Click += new System.EventHandler(this.vorbtn_Click);
            // 
            // SerienPanel
            // 
            this.SerienPanel.AutoScroll = true;
            this.SerienPanel.BackColor = System.Drawing.SystemColors.Control;
            this.SerienPanel.Location = new System.Drawing.Point(11, 32);
            this.SerienPanel.Name = "SerienPanel";
            this.SerienPanel.Size = new System.Drawing.Size(739, 470);
            this.SerienPanel.TabIndex = 2;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(682, 5);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(68, 21);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "Suchen";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchTB
            // 
            this.SearchTB.Location = new System.Drawing.Point(11, 6);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(665, 20);
            this.SearchTB.TabIndex = 0;
            // 
            // SettingPanel
            // 
            this.SettingPanel.Controls.Add(this.SpeichernBtn);
            this.SettingPanel.Controls.Add(this.MaxSimDownloadsTB);
            this.SettingPanel.Controls.Add(this.label1);
            this.SettingPanel.Controls.Add(this.changeDownFolderBtn);
            this.SettingPanel.Controls.Add(this.DownloadFolderTB);
            this.SettingPanel.Controls.Add(this.DowloadpathLabel);
            this.SettingPanel.Location = new System.Drawing.Point(1, 41);
            this.SettingPanel.Name = "SettingPanel";
            this.SettingPanel.Size = new System.Drawing.Size(760, 565);
            this.SettingPanel.TabIndex = 0;
            // 
            // SpeichernBtn
            // 
            this.SpeichernBtn.Location = new System.Drawing.Point(672, 535);
            this.SpeichernBtn.Name = "SpeichernBtn";
            this.SpeichernBtn.Size = new System.Drawing.Size(75, 23);
            this.SpeichernBtn.TabIndex = 8;
            this.SpeichernBtn.Text = "Speichern";
            this.SpeichernBtn.UseVisualStyleBackColor = true;
            this.SpeichernBtn.Click += new System.EventHandler(this.SpeichernBtn_Click);
            // 
            // MaxSimDownloadsTB
            // 
            this.MaxSimDownloadsTB.Location = new System.Drawing.Point(40, 130);
            this.MaxSimDownloadsTB.Name = "MaxSimDownloadsTB";
            this.MaxSimDownloadsTB.Size = new System.Drawing.Size(247, 20);
            this.MaxSimDownloadsTB.TabIndex = 4;
            this.MaxSimDownloadsTB.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Maximale Simultane Downloads";
            // 
            // changeDownFolderBtn
            // 
            this.changeDownFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.changeDownFolderBtn.Location = new System.Drawing.Point(290, 49);
            this.changeDownFolderBtn.Name = "changeDownFolderBtn";
            this.changeDownFolderBtn.Size = new System.Drawing.Size(55, 20);
            this.changeDownFolderBtn.TabIndex = 2;
            this.changeDownFolderBtn.Text = "change";
            this.changeDownFolderBtn.UseVisualStyleBackColor = true;
            this.changeDownFolderBtn.Click += new System.EventHandler(this.changeDownFolderBtn_Click);
            // 
            // DownloadFolderTB
            // 
            this.DownloadFolderTB.Location = new System.Drawing.Point(40, 49);
            this.DownloadFolderTB.Name = "DownloadFolderTB";
            this.DownloadFolderTB.Size = new System.Drawing.Size(247, 20);
            this.DownloadFolderTB.TabIndex = 1;
            this.DownloadFolderTB.TabStop = false;
            // 
            // DowloadpathLabel
            // 
            this.DowloadpathLabel.AutoSize = true;
            this.DowloadpathLabel.Location = new System.Drawing.Point(37, 32);
            this.DowloadpathLabel.Name = "DowloadpathLabel";
            this.DowloadpathLabel.Size = new System.Drawing.Size(76, 13);
            this.DowloadpathLabel.TabIndex = 0;
            this.DowloadpathLabel.Text = "Downloadpfad";
            // 
            // StaffelPanel
            // 
            this.StaffelPanel.Controls.Add(this.panel1);
            this.StaffelPanel.Controls.Add(this.DescriptionTB);
            this.StaffelPanel.Controls.Add(this.CoverPB);
            this.StaffelPanel.Location = new System.Drawing.Point(1, 41);
            this.StaffelPanel.Name = "StaffelPanel";
            this.StaffelPanel.Size = new System.Drawing.Size(760, 530);
            this.StaffelPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 527);
            this.panel1.TabIndex = 0;
            // 
            // DescriptionTB
            // 
            this.DescriptionTB.BackColor = System.Drawing.SystemColors.Control;
            this.DescriptionTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionTB.Enabled = false;
            this.DescriptionTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DescriptionTB.Location = new System.Drawing.Point(156, 299);
            this.DescriptionTB.Name = "DescriptionTB";
            this.DescriptionTB.Size = new System.Drawing.Size(591, 252);
            this.DescriptionTB.TabIndex = 2;
            this.DescriptionTB.Text = "";
            // 
            // CoverPB
            // 
            this.CoverPB.Location = new System.Drawing.Point(156, 3);
            this.CoverPB.Name = "CoverPB";
            this.CoverPB.Size = new System.Drawing.Size(591, 290);
            this.CoverPB.TabIndex = 1;
            this.CoverPB.TabStop = false;
            // 
            // EpisodenPanel
            // 
            this.EpisodenPanel.AutoScroll = true;
            this.EpisodenPanel.Location = new System.Drawing.Point(1, 41);
            this.EpisodenPanel.Name = "EpisodenPanel";
            this.EpisodenPanel.Size = new System.Drawing.Size(760, 530);
            this.EpisodenPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 604);
            this.Controls.Add(this.DownloadPanel);
            this.Controls.Add(this.DownloadingPanel);
            this.Controls.Add(this.EpisodenPanel);
            this.Controls.Add(this.StaffelPanel);
            this.Controls.Add(this.MenueGB);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.SettingPanel);
            this.Name = "Form1";
            this.Text = "BSDownload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenueGB.ResumeLayout(false);
            this.DownloadPanel.ResumeLayout(false);
            this.DownloadPanel.PerformLayout();
            this.SettingPanel.ResumeLayout(false);
            this.SettingPanel.PerformLayout();
            this.StaffelPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CoverPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gecko.GeckoWebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox MenueGB;
        private System.Windows.Forms.Button SettingBtn;
        private System.Windows.Forms.Button DownloadingBtn;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Panel DownloadingPanel;
        private System.Windows.Forms.Panel DownloadPanel;
        private System.Windows.Forms.Panel SettingPanel;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.Panel SerienPanel;
        private System.Windows.Forms.Panel StaffelPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox DescriptionTB;
        private System.Windows.Forms.PictureBox CoverPB;
        private System.Windows.Forms.Panel EpisodenPanel;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button vorbtn;
        private System.Windows.Forms.Label SeitenCountLabel;
        private System.Windows.Forms.TextBox DownloadFolderTB;
        private System.Windows.Forms.Label DowloadpathLabel;
        private System.Windows.Forms.Button changeDownFolderBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox MaxSimDownloadsTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SpeichernBtn;
        //private System.Windows.Forms.Label MaxBitLabel;
        //private System.Windows.Forms.TextBox MaxBitTB;
        //private System.Windows.Forms.Label KbpsLabel;
    }
}

