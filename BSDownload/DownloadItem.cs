using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BSDownload.Properties;
using System.IO;
using System.Threading;

namespace BSDownload
{
    public partial class DownloadItem : UserControl
    {
        private Folge Folgetodownload;
        private int Staffel;
        private string SerienName;
        private Process p = new Process();
        private Random rnd = new Random();

        public DownloadItem(Folge folgetodownload, int staffel, string serienname)
        {
            InitializeComponent();

            Folgetodownload = folgetodownload;
            Staffel = staffel;
            SerienName = serienname;

            label1.Text = folgetodownload.FolgenName.Split('/')[0];
        }

        public void BeginDownload()
        {
            Thread.Sleep(1000);

            string Link = Folgetodownload.HosterandLink.Where(x => x.Value != "").First().Value;
            string safelink = Settings.Default.Path + "\\" + SerienName + "-S" + Staffel + "-E" + Folgetodownload.FolgenName.Split('/')[0] + ".mp4";
            string framerate = int.Parse(Settings.Default.Framerate) != 0 ? " -r " + Settings.Default.Framerate + " " + Settings.Default.FramerateEinheit : "";

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.OutputDataReceived += P_OutputDataReceived;
            p.StartInfo.Arguments = Link + " -o \"" + safelink;
            p.StartInfo.FileName = "youtube-dl.exe";
            p.StartInfo.UseShellExecute = false;
            p.Start();

            p.BeginErrorReadLine();
            p.BeginOutputReadLine();

            label3.Text += safelink;
        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
                return;
            if (e.Data.StartsWith("[download]") && e.Data.Contains("%"))
            {
                if (e.Data.Contains("Destination"))
                {

                }
                else
                {
                    if (this != null || progressBar1.Handle != null || label1 != null)
                    {
                        string Data = e.Data.Replace(" ", "");
                        Data = Data.Split(new[] { "[download]" }, StringSplitOptions.None)[1].Split('%')[0];
                        double percent = double.Parse(Data.Replace(".", ","));
                        string valuewert = percent.ToString().Split(',')[0];

                        try
                        {
                            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = int.Parse(valuewert)));

                            label2.Invoke((MethodInvoker)(() => label2.Text = percent + " %"));
                        }
                        catch { }

                        if (percent == 100)
                        {
                            try
                            {
                                Thread.Sleep(2000);
                                this.Dispose();
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Kill();
            p.Dispose();
            this.Dispose();
        }
    }
}
