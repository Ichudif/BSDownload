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
using System.Net;

namespace BSDownload
{
    public partial class DownloadItem : UserControl
    {
        private Folge Folgetodownload;
        private int Staffel;
        private string SerienName;
        private Process p = new Process();
        private Thread DWTH;
        private Random rnd = new Random();

        public DownloadItem(Folge folgetodownload, int staffel, string serienname)
        {
            InitializeComponent();

            Folgetodownload = folgetodownload;
            Staffel = staffel;
            SerienName = serienname;

            //MessageBox.Show("Folge: " + folgetodownload.FolgenName + Environment.NewLine + "Staffel: " + staffel + Environment.NewLine + "Serie: " + serienname);

            label1.Text = folgetodownload.FolgenName.Split('/')[0];
        }

        public void BeginDownload()
        {
            Thread.Sleep(1000);

            string Link = Folgetodownload.HosterandLink.Where(x => x.Value != "").First().Value;
            string hoster = Folgetodownload.HosterandLink.Where(x => x.Value != "").First().Key;
            string safelink = Settings.Default.Path + "\\" + SerienName + "-S" + Staffel + "-E" + Folgetodownload.FolgenName.Split('/')[0] + ".mp4";
            string framerate = int.Parse(Settings.Default.Framerate) != 0 ? " -r " + Settings.Default.Framerate + " " + Settings.Default.FramerateEinheit : "";

            Settings.Default.DownloadLinks.Add(Link);
            //return;

            if(hoster != "vivo")
            {
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
            }
            else
            {
                LinkExtractors.VivoExtractor vd = new LinkExtractors.VivoExtractor();
                string DirectLink = vd.GetDirectVideoLink(Link);
                //MessageBox.Show("Link: " + DirectLink);
                DWTH = new Thread(delegate ()
                {
                    DownloadFileWithProgress(DirectLink, safelink, progressBar1, label2);
                });
                DWTH.Start();
            }

            label3.Text += safelink;
        }

        private void DownloadFileWithProgress(string DownloadLink, string TargetPath, ProgressBar progress, Label labelProgress)
        {
            //Start Download
            // Function will return the number of bytes processed
            // to the caller. Initialize to 0 here.
            int bytesProcessed = 0;

            // Assign values to these objects here so that they can
            // be referenced in the finally block
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;

            // Use a try/catch/finally block as both the WebRequest and Stream
            // classes throw exceptions upon error
            try
            {
                // Create a request for the specified remote file name
                WebRequest request = WebRequest.Create(DownloadLink);
                if (request != null)
                {
                    // Send the request to the server and retrieve the
                    // WebResponse object 

                    // Get the Full size of the File
                    double TotalBytesToReceive = 0;
                    var SizewebRequest = HttpWebRequest.Create(new Uri(DownloadLink));
                    SizewebRequest.Method = "HEAD";

                    using (var webResponse = SizewebRequest.GetResponse())
                    {
                        var fileSize = webResponse.Headers.Get("Content-Length");
                        TotalBytesToReceive = Convert.ToDouble(fileSize);
                    }

                    response = request.GetResponse();
                    if (response != null)
                    {
                        // Once the WebResponse object has been retrieved,
                        // get the stream object associated with the response's data
                        remoteStream = response.GetResponseStream();

                        // Create the local file

                        string filePath = TargetPath;


                        localStream = File.Create(filePath);

                        // Allocate a 1k buffer
                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;

                        // Simple do/while loop to read from stream until
                        // no bytes are returned
                        do
                        {

                            // Read data (up to 1k) from the stream
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);

                            // Write the data to the local file
                            localStream.Write(buffer, 0, bytesRead);

                            // Increment total bytes processed
                            bytesProcessed += bytesRead;


                            double bytesIn = double.Parse(bytesProcessed.ToString());
                            double percentage = bytesIn / TotalBytesToReceive * 100;
                            percentage = Math.Round(percentage, 0);


                            // Safe Update
                            //Increment the progress bar
                            if (progress.InvokeRequired)
                            {
                                progress.Invoke(new Action(() => progress.Value = int.Parse(Math.Truncate(percentage).ToString())));
                            }
                            else
                            {
                                progress.Value = int.Parse(Math.Truncate(percentage).ToString());
                            }

                            //Set the label progress Text
                            if (labelProgress.InvokeRequired)
                            {
                                labelProgress.Invoke(new Action(() => labelProgress.Text = int.Parse(Math.Truncate(percentage).ToString()).ToString() + " %"));
                            }
                            else
                            {
                                labelProgress.Text = int.Parse(Math.Truncate(percentage).ToString()).ToString() + " %";
                            }



                        } while (bytesRead > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any errors
            }
            finally
            {
                // Close the response and streams objects here 
                // to make sure they're closed even if an exception
                // is thrown at some point
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }
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
            DWTH.Abort();
            p.Dispose();
            this.Dispose();
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if(label2.Text == "100 %")
            {
                button1_Click(null, null);
            }
        }
    }
}
