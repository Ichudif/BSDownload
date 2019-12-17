using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using AForge.Imaging;
using System.Drawing.Imaging;
using System.Net;
using WindowsInput;
using WindowsInput.Native;

namespace BSDownload
{
    class BypassGoogleCaptcha
    {
        private GeckoWebBrowser web;
        private Random rnd = new Random();
        private string Link;
        private Point clickpoint = Point.Empty;
        private Form MainFrm;

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        public BypassGoogleCaptcha(GeckoWebBrowser w, string l)
        {
            web = w;
            Link = l;
            MainFrm = (Form)web.Parent;
        }

        //This simulates a left mouse click
        private void LeftMouseClick(Point p)
        {
            Point old = Cursor.Position;

            MoveMouseToPosition(p);

            Cursor.Position = p;
            mouse_event(MOUSEEVENTF_LEFTDOWN, p.X, p.Y, 0, 0);
            Thread.Sleep(rnd.Next(300, 600));
            mouse_event(MOUSEEVENTF_LEFTUP, p.X, p.Y, 0, 0);

            //MoveMouseToPosition(old);
        }

        private void MoveMouseToPosition(Point Pos)
        {
            //Slowly move the cursor to the position
            while (Cursor.Position != Pos)
            {
                if (Cursor.Position.X < Pos.X)
                {
                    Point temp = Cursor.Position;
                    temp.X += 1;
                    Cursor.Position = temp;
                }
                else if (Cursor.Position.X > Pos.X)
                {
                    Point temp = Cursor.Position;
                    temp.X -= 1;
                    Cursor.Position = temp;
                }
                if (Cursor.Position.Y < Pos.Y)
                {
                    Point temp = Cursor.Position;
                    temp.Y += 1;
                    Cursor.Position = temp;
                }
                else if (Cursor.Position.Y > Pos.Y)
                {
                    Point temp = Cursor.Position;
                    temp.Y -= 1;
                    Cursor.Position = temp;
                }
                Thread.Sleep(rnd.Next(0, 2));
            }
        }

        private bool ready = false;
        public void GetVideoLink()
        {
            web.CreateWindow += CloseWindow;
            new Thread(() =>
            {
                string Url = "";
                web.Invoke((MethodInvoker)delegate ()
                {
                    using (AutoJSContext context = new AutoJSContext(web.Window))
                    {
                        context.EvaluateScript("document.URL;", out Url);
                    }
                });

                while (Url == "") ;

                //if (!Url.Contains("bs.to"))
                //{
                //    web.Navigate(Link);
                //    web.DocumentCompleted += CaptchaSiteBack;
                //}
                //else
                //{
                //    ready = true;
                //}

                ready = true;

                while (!ready) ;

                Point audioBTN = FindPicture("BypassGoogle\\audioBTN.png");
                LeftMouseClick(audioBTN);
                Thread.Sleep(300);
                Point downloadBTN = FindPicture("BypassGoogle\\downloadBTN.png");
                LeftMouseClick(downloadBTN);

                while (AudioLink == "") ;

                WebClient wbc = new WebClient();
                wbc.DownloadFile(AudioLink, "BypassGoogle\\audio.mp3");

                string TextMeaning = UnderstandAudio().Replace("\n", "").Replace("\r", "");

                Thread.Sleep(rnd.Next(100, 200));

                Point Textfield = downloadBTN;
                Textfield.Y -= rnd.Next(33, 43);
                Textfield.X += rnd.Next(0, 50);
                LeftMouseClick(Textfield);

                Thread.Sleep(rnd.Next(10, 50));

                InputSimulator sim = new InputSimulator();
                foreach (char item in TextMeaning)
                {
                    VirtualKeyCode c = VirtualKeyCode.VK_0;

                    switch (item.ToString().ToLower().ToCharArray()[0])
                    {
                        case 'a':
                            c = VirtualKeyCode.VK_A;
                            break;
                        case 'b':
                            c = VirtualKeyCode.VK_B;
                            break;
                        case 'c':
                            c = VirtualKeyCode.VK_C;
                            break;
                        case 'd':
                            c = VirtualKeyCode.VK_D;
                            break;
                        case 'e':
                            c = VirtualKeyCode.VK_E;
                            break;
                        case 'f':
                            c = VirtualKeyCode.VK_F;
                            break;
                        case 'g':
                            c = VirtualKeyCode.VK_G;
                            break;
                        case 'h':
                            c = VirtualKeyCode.VK_H;
                            break;
                        case 'i':
                            c = VirtualKeyCode.VK_I;
                            break;
                        case 'j':
                            c = VirtualKeyCode.VK_J;
                            break;
                        case 'k':
                            c = VirtualKeyCode.VK_K;
                            break;
                        case 'l':
                            c = VirtualKeyCode.VK_L;
                            break;
                        case 'm':
                            c = VirtualKeyCode.VK_M;
                            break;
                        case 'n':
                            c = VirtualKeyCode.VK_N;
                            break;
                        case 'o':
                            c = VirtualKeyCode.VK_O;
                            break;
                        case 'p':
                            c = VirtualKeyCode.VK_P;
                            break;
                        case 'q':
                            c = VirtualKeyCode.VK_Q;
                            break;
                        case 'r':
                            c = VirtualKeyCode.VK_R;
                            break;
                        case 's':
                            c = VirtualKeyCode.VK_S;
                            break;
                        case 't':
                            c = VirtualKeyCode.VK_T;
                            break;
                        case 'u':
                            c = VirtualKeyCode.VK_U;
                            break;
                        case 'v':
                            c = VirtualKeyCode.VK_V;
                            break;
                        case 'w':
                            c = VirtualKeyCode.VK_W;
                            break;
                        case 'x':
                            c = VirtualKeyCode.VK_X;
                            break;
                        case 'y':
                            c = VirtualKeyCode.VK_Y;
                            break;
                        case 'z':
                            c = VirtualKeyCode.VK_Z;
                            break;
                        case ' ':
                            c = VirtualKeyCode.SPACE;
                            break;
                    }

                    sim.Keyboard.KeyPress(c);
                    Thread.Sleep(rnd.Next(50, 100));
                }

                Point submit = FindPicture("BypassGoogle\\submit.png");
                LeftMouseClick(submit);
            }).Start();
        }

        private void CaptchaSiteBack(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            web.DocumentCompleted -= CaptchaSiteBack;
            LeftMouseClick(clickpoint);
            ready = true;
        }

        string AudioLink = "";
        private void CloseWindow(object sender, GeckoCreateWindowEventArgs e)
        {
            if (e.Uri.Contains("payload"))
            {
                AudioLink = e.Uri;
            }
            e.Cancel = true;
        }

        public string UnderstandAudio()
        {
            //Convert MP3 to WAV
            ConvertMp3ToWav("BypassGoogle\\audio.mp3", "BypassGoogle\\audio.wav");

            //Use a speech recognition programm, written in Python:
            Process recognizer = new Process();
            recognizer.StartInfo = new ProcessStartInfo()
            {
                FileName = "BypassGoogle\\speech.exe",
                Arguments = "BypassGoogle\\audio.wav",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            recognizer.Start();

            recognizer.WaitForExit();
            string text = recognizer.StandardOutput.ReadToEnd();
            return text;
        }

        private static void ConvertMp3ToWav(string _inPath_, string _outPath_)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(_inPath_))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(_outPath_, pcm);
                }
            }
        }

        private Point FindPicture(string pictolookfor)
        {
            var img = new Bitmap(MainFrm.ClientSize.Width, MainFrm.ClientSize.Height);
            try
            {
                MainFrm.Invoke((MethodInvoker)delegate ()
                {
                    Graphics g = Graphics.FromImage(img);
                    g.CopyFromScreen(MainFrm.PointToScreen(Point.Empty), new Point(0, 0), MainFrm.ClientSize);
                });
            }
            catch (Exception e)
            {
                return Point.Empty;
            }

            System.Drawing.Bitmap template = (Bitmap)Bitmap.FromFile(pictolookfor);

            // create template matching algorithm's instance
            // (set similarity threshold to 92.1%)

            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f);
            // find all matchings with specified above similarity

            TemplateMatch[] matchings = tm.ProcessImage(ConvertToFormat(img, PixelFormat.Format24bppRgb), ConvertToFormat(template, PixelFormat.Format24bppRgb));
            // highlight found matchings

            BitmapData data = img.LockBits(
                 new Rectangle(0, 0, img.Width, img.Height),
                 ImageLockMode.ReadWrite, img.PixelFormat);

            Point returnme = Point.Empty;

            foreach (TemplateMatch m in matchings)
            {

                Drawing.Rectangle(data, m.Rectangle, Color.White);

                //MessageBox.Show(m.Rectangle.Location.ToString());
                // do something else with matching
                returnme = m.Rectangle.Location;
            }
            img.UnlockBits(data);

            Point MainformPointtoscreen = Point.Empty;
            try
            {
                MainFrm.Invoke((MethodInvoker)delegate ()
                {
                    MainformPointtoscreen = MainFrm.PointToScreen(Point.Empty);
                });
            }
            catch (Exception e)
            {
                return Point.Empty;
            }

            while (MainformPointtoscreen.IsEmpty) ;

            if (returnme.IsEmpty)
            {
                return FindPicture(pictolookfor);
            }

            returnme.X += MainformPointtoscreen.X + rnd.Next(2, 20);
            returnme.Y += MainformPointtoscreen.Y + rnd.Next(2, 20);

            return returnme;
        }

        public Bitmap ConvertToFormat(Bitmap image, PixelFormat format)
        {
            Bitmap copy = new Bitmap(image.Width, image.Height, format);
            using (Graphics gr = Graphics.FromImage(copy))
            {
                gr.DrawImage(image, new Rectangle(0, 0, copy.Width, copy.Height));
            }
            return copy;
        }
    }
}
