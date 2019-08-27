namespace BSDownload
{
    partial class FolgenItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.herunterladenCB = new System.Windows.Forms.CheckBox();
            this.Watchlistanswer = new System.Windows.Forms.Label();
            this.AlreadyWatchedLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.herunterladenCB);
            this.panel1.Controls.Add(this.Watchlistanswer);
            this.panel1.Controls.Add(this.AlreadyWatchedLabel);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 100);
            this.panel1.TabIndex = 0;
            // 
            // herunterladenCB
            // 
            this.herunterladenCB.AutoSize = true;
            this.herunterladenCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.herunterladenCB.Location = new System.Drawing.Point(6, 73);
            this.herunterladenCB.Name = "herunterladenCB";
            this.herunterladenCB.Size = new System.Drawing.Size(118, 21);
            this.herunterladenCB.TabIndex = 7;
            this.herunterladenCB.Text = "Herunterladen";
            this.herunterladenCB.UseVisualStyleBackColor = true;
            // 
            // Watchlistanswer
            // 
            this.Watchlistanswer.AutoSize = true;
            this.Watchlistanswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Watchlistanswer.Location = new System.Drawing.Point(451, 77);
            this.Watchlistanswer.Name = "Watchlistanswer";
            this.Watchlistanswer.Size = new System.Drawing.Size(46, 17);
            this.Watchlistanswer.TabIndex = 6;
            this.Watchlistanswer.Text = "label1";
            // 
            // AlreadyWatchedLabel
            // 
            this.AlreadyWatchedLabel.AutoSize = true;
            this.AlreadyWatchedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AlreadyWatchedLabel.Location = new System.Drawing.Point(338, 77);
            this.AlreadyWatchedLabel.Name = "AlreadyWatchedLabel";
            this.AlreadyWatchedLabel.Size = new System.Drawing.Size(119, 17);
            this.AlreadyWatchedLabel.TabIndex = 5;
            this.AlreadyWatchedLabel.Text = "Bereits gesehen: ";
            // 
            // NameLabel
            // 
            this.NameLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.NameLabel.Location = new System.Drawing.Point(6, 2);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(486, 48);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "label1";
            // 
            // FolgenItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "FolgenItem";
            this.Size = new System.Drawing.Size(500, 100);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox herunterladenCB;
        private System.Windows.Forms.Label Watchlistanswer;
        private System.Windows.Forms.Label AlreadyWatchedLabel;
        private System.Windows.Forms.Label NameLabel;
    }
}
