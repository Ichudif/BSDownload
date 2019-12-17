using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;

namespace BSDownload.LinkExtractors
{
    class VeryStreamExtractor : Extractor
    {
        private GeckoWebBrowser web = new GeckoWebBrowser();
        private string Link = "";

        public VeryStreamExtractor()
        {
            web.CreateWindow += Web_CreateWindow;

            web.Size = new System.Drawing.Size(500, 500);
            web.Location = new System.Drawing.Point(0, 0);
            web.SendToBack();
            web.Visible = false;
            Form1.ActiveForm.Invoke(new Action(() =>
            {
                Form1.ActiveForm.Controls.Add(web);
            }));
        }

        private void Web_CreateWindow(object sender, GeckoCreateWindowEventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString());
            e.InitialHeight = 0;
            e.InitialWidth = 0;
        }

        public override string GetDirectVideoLink(string VeryStreamEmbeddedLink)
        {
            web.DocumentCompleted += Web_DocumentCompleted;
            web.Invoke(new Action(() => { web.Navigate(VeryStreamEmbeddedLink); }));

            while (Link == "") ;

            string returnme = Link;
            Link = "";

            return returnme;
        }

        private void Web_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            web.DocumentCompleted -= Web_DocumentCompleted;

            string Help = "";

            using (AutoJSContext context = new AutoJSContext(web.Window))
            {
                context.EvaluateScript("document.getElementById('videerlay').click();");
                System.Threading.Thread.Sleep(200);
                context.EvaluateScript("document.getElementsByClassName('vjs-play-control vjs-control vjs-button')[0].click();");
                System.Threading.Thread.Sleep(200);
                context.EvaluateScript("document.getElementById('dogevideo_html5_api').src;", out Help);
            }

            web.DocumentCompleted += Web_DocumentCompleted1;
            web.Invoke(new Action(() => { web.Navigate(Help); }));
        }

        private void Web_DocumentCompleted1(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            Link = web.Url.ToString();
        }

        public void Destroy()
        {
            Form1.ActiveForm.Invoke(new Action(() => { Form1.ActiveForm.Controls.Remove(web); }));
        }
    }
}
