using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BSDownload.Properties;
using Gecko;
using Microsoft.Win32;

namespace BSDownload
{
    public partial class Form1 : Form
    {
        #region Variables and Constructors
        Management MyManager = new Management();
        List<Serie> SerienListe;
        string selectedPanel = "";
        Thread MaintainTH;

        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("firefox");

            if (Settings.Default.Path == "")
            {
                Settings.Default.Path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString() + "\\BSDownload";
            }
            
            MaintainTH = new Thread(Maintain);
            MaintainTH.Start();
        }
        #endregion

        #region WebbrowserUpdating
        private void WebBrowser1_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            MyWebBrowserClone.thsi = webBrowser1;
            MyWebBrowserClone.LoadedURL = webBrowser1.Url.AbsoluteUri;
            MyWebBrowserClone.DocumentText = webBrowser1.Document.TextContent;
        }
        #endregion

        #region MenueManagement
        private void MenueBtnClick(object sender, EventArgs e)
        {
            Button clickedbtn = sender as Button;
            switch (clickedbtn.Name)
            {
                case "DownloadBtn":
                    DownloadPanel.BringToFront();
                    selectedPanel = "DownloadPanel";
                    break;
                case "DownloadingBtn":
                    DownloadingPanel.BringToFront();
                    selectedPanel = "DownloadingPanel";
                    break;
                case "SettingBtn":
                    SettingPanel.BringToFront();
                    selectedPanel = "SettingPanel";
                    break;
            }
        }
        #endregion

        #region SearchZeugs
        string aktsearchstring = "";
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            aktseite = 1;
            aktsearchstring = SearchTB.Text;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync(aktsearchstring);
            vorbtn.Visible = true;
            backbtn.Visible = true;
        }

        int aktseite = 1;
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string kriterium = (string)e.Argument;
            int addedcount = 0;
            int count = 0;
            SerienPanel.Invoke((MethodInvoker)(() => SerienPanel.Controls.Clear()));
            foreach (Serie item in SerienListe)
            {
                if (item.SerienName.Replace("-", " ").ToLower().StartsWith(kriterium.ToLower()))
                {
                    if ((aktseite - 1) * 100 <= count && addedcount < 100)
                    {
                        EpisodenItem ei = new EpisodenItem(item.SerienName.Replace("-", " "))
                        {
                            Location = new Point(0, addedcount * 60)
                        };
                        ei.Controls.Find("panel1", true)[0].Click += searchedforitemsclick;
                        ei.Controls.Find("label1", true)[0].Click += searchedforitemsclick;

                        SerienPanel.Invoke((MethodInvoker)(() => SerienPanel.Controls.Add(ei)));
                        addedcount++;
                    }
                    count++;
                }
            }
            SeitenCountLabel.Invoke((MethodInvoker)(() => SeitenCountLabel.Text = aktseite + " / " + Math.Ceiling(count / 100.0)));
        }

        private void vorbtn_Click(object sender, EventArgs e)
        {
            if (aktseite + 1 <= int.Parse(SeitenCountLabel.Text.Split(new[] { " / " }, StringSplitOptions.None)[1]))
            {
                aktseite++;
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += Bw_DoWork;
                bw.RunWorkerAsync(aktsearchstring);
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            if (aktseite != 1)
            {
                aktseite--;
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += Bw_DoWork;
                bw.RunWorkerAsync(aktsearchstring);
            }
        }
        #endregion

        #region StaffelZeugs
        Serie SelectedSerie;
        int selectedStaffel = 1;
        private void searchedforitemsclick(object sender, EventArgs e)
        {
            SeitenCountLabel.Visible = false;
            vorbtn.Visible = false;
            backbtn.Click -= backbtn_Click;
            backbtn.Click += StaffelBackBtnClick;

            string value;
            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                value = (sender as Label).Text;
            }
            else
            {
                value = (sender as Panel).Controls.Find("label1", true)[0].Text;
            }

            StaffelPanel.BringToFront();
            selectedPanel = "StaffelPanel";
            panel1.Controls.Clear();
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += CreateStaffelDescrandPictureBackgroundWorkerDoEvent;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync(value);
        }

        private void StaffelBackBtnClick(object sender, EventArgs e)
        {
            DownloadPanel.BringToFront();
            selectedPanel = "DownloadPanel";
            SeitenCountLabel.Visible = true;
            vorbtn.Visible = true;
            backbtn.Click -= StaffelBackBtnClick;
            backbtn.Click += backbtn_Click;
        }

        private void CreateStaffelDescrandPictureBackgroundWorkerDoEvent(object sender, DoWorkEventArgs e)
        {
            string Text = (string)e.Argument;
            SelectedSerie = SerienListe.Find(x => x.SerienName == Text.Replace(" ", "-"));

            if (SelectedSerie.ImageLink == null || SelectedSerie.Staffeln == null || SelectedSerie.Description == null)
            {
                Serie s = MyManager.LoadStaffel(SelectedSerie);
                if (s == null)
                {
                    MessageBox.Show("Die Serie konnte leider nicht Geladen werden");
                    backbtn.Invoke((MethodInvoker)(() => backbtn.PerformClick()));
                    (sender as BackgroundWorker).CancelAsync();
                    return;
                }
                SerienListe[SerienListe.IndexOf(SelectedSerie)] = s;
                SelectedSerie = s;
            }

            for (int i = 0; i < SelectedSerie.Staffeln.Count; i++)
            {
                StaffelItem sf = new StaffelItem(SelectedSerie.Staffeln[i].StaffelName)
                {
                    Location = new Point(5, i * 60 + 10)
                };
                sf.Controls.Find("panel1", true)[0].Click += StaffelAuswahlClick;
                sf.Controls.Find("label1", true)[0].Click += StaffelAuswahlClick;

                panel1.Invoke((MethodInvoker)(() => panel1.Controls.Add(sf)));
            }

            //CoverPB.Invoke((MethodInvoker)(() => CoverPB.Load(SelectedSerie.ImageLink.AbsoluteUri)));
            DescriptionTB.Invoke((MethodInvoker)(() => DescriptionTB.Text = SelectedSerie.Description));
        }
        #endregion

        #region EpisodenZeugs
        private void StaffelAuswahlClick(object sender, EventArgs e)
        {
            backbtn.Click -= StaffelBackBtnClick;
            backbtn.Click += EpisodenBackBtnClick;

            if (sender.GetType().ToString() == "System.Windows.Forms.Label")
            {
                selectedStaffel = int.Parse((sender as Label).Text.Split(' ')[1]);
            }
            else
            {
                selectedStaffel = int.Parse((sender as Panel).Controls.Find("label1", true)[0].Text.Split(' ')[1]);
            }

            if (SelectedSerie.Staffeln.Find(x => x.StaffelName == "Staffel " + selectedStaffel).Folgen == null)
            {
                SelectedSerie = MyManager.LoadFolgen(SelectedSerie, selectedStaffel);
                SerienListe[SerienListe.IndexOf(SerienListe.Find(x => x.SerienName == SelectedSerie.SerienName))] = SelectedSerie;
            }

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += createEpisodeElementsDoWork;
            bw.RunWorkerAsync();
        }

        private void EpisodenBackBtnClick(object sender, EventArgs e)
        {
            StaffelPanel.BringToFront();
            selectedPanel = "StaffelPanel";
            backbtn.Click -= EpisodenBackBtnClick;
            backbtn.Click += StaffelBackBtnClick;
        }

        private void createEpisodeElementsDoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            EpisodenPanel.Invoke((MethodInvoker)(() => EpisodenPanel.Controls.Clear()));
            EpisodenPanel.Invoke((MethodInvoker)(() => EpisodenPanel.BringToFront()));
            selectedPanel = "EpisodenPanel";
            foreach (Folge item in SelectedSerie.Staffeln.Find(x => x.StaffelName == "Staffel " + selectedStaffel).Folgen)
            {
                FolgenItem fi = new FolgenItem(item.FolgenName.Replace("-", " "), item.Watched, EpisodenPanel.Width - 25, item)
                {
                    Location = new Point(10, 10 + 110 * count),
                    Name = "FolgenItem"
                };

                EpisodenPanel.Invoke((MethodInvoker)(() => EpisodenPanel.Controls.Add(fi)));
                count++;
            }
        }
        #endregion

        #region Download
        private void DownloadClick(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                foreach (FolgenItem item in EpisodenPanel.Controls.Find("FolgenItem", true))
                {
                    if (item.Checked())
                    {
                        item.ThisFolge = MyManager.getDownloadLinks(item.ThisFolge, selectedStaffel);

                        Download(item.ThisFolge, selectedStaffel, SelectedSerie.SerienName);
                    }
                }
            }).Start();
        }

        public void Download(Folge folgetodownload, int selectedstaffel, string SerienName)
        {
            while (int.Parse(Settings.Default.MaxSimDownloads) != 0 && int.Parse(Settings.Default.MaxSimDownloads) > Form1.ActiveForm.Controls.Find("DownloadingPanel", true)[0].Controls.Count) ;
            if (folgetodownload.Downloading)
            {
                DownloadItem di = new DownloadItem(folgetodownload, selectedstaffel, SerienName);
                di.BeginDownload();
                di.Location = new System.Drawing.Point(10, Form1.ActiveForm.Controls.Find("DownloadingPanel", true)[0].Controls.Count * 260 + 10);
                DownloadingPanel.Invoke((MethodInvoker)(() => DownloadingPanel.Controls.Add(di)));
            }
        }
        #endregion

        #region Einstellungen und Maintenance
        private void changeDownFolderBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Settings.Default.Path;
            folderBrowserDialog1.ShowDialog();
            Settings.Default.Path = folderBrowserDialog1.SelectedPath;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MaintainTH.Abort();
        }

        private void DownloadingPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            Panel thispanel = sender as Panel;
            if (thispanel.Controls.Count > 0)
            {
                int count = 0;
                foreach (Control item in thispanel.Controls)
                {
                    item.Location = new Point(10, 260 * count + 10);
                    count++;
                }
            }
        }

        public void Maintain()
        {
            while (true)
            {
                Thread.Sleep(1000);

                if (selectedPanel == "EpisodenPanel")
                    button1.Invoke((MethodInvoker)(() => button1.Visible = true));
                else
                    button1.Invoke((MethodInvoker)(() => button1.Visible = false));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyWebBrowserClone.thsi = webBrowser1;
            SerienListe = MyManager.loadSeries();
        }

        private void SpeichernBtn_Click(object sender, EventArgs e)
        {
            Settings.Default.Path = DownloadFolderTB.Text;
            Settings.Default.MaxSimDownloads = MaxSimDownloadsTB.Text;
            Settings.Default.Save();
            MessageBox.Show("Erfolgreich gespeichert");
        }
        #endregion
    }
}
