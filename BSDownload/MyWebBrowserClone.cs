using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gecko;

namespace BSDownload
{
    public static class MyWebBrowserClone
    {
        public static string LoadedURL { get; set; } = "";
        public static string DocumentText { get; set; } = "";
        public static GeckoWebBrowser thsi { get; set; } = null;

        public static void Load(string Url)
        {
            thsi.Invoke((MethodInvoker)(() => thsi.Navigate(Url)));//, null, null, "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:62.0) Gecko/20100101 Firefox/62.0"
            System.Threading.Thread.Sleep(1000);
        }

        public static string GetDocument()
        {
            //string outp = "";
            //try
            //{
            //    thsi.Invoke((MethodInvoker)delegate ()
            //    {
            //        while (!File.Exists(Path.Combine(Application.StartupPath, "doc.html")))
            //        {
            //            thsi.SaveDocument(Path.Combine(Application.StartupPath, "doc.html"));
            //        }
            //    });

            //    outp = File.ReadAllText(Path.Combine(Application.StartupPath, "doc.html"));
            //    File.Delete(Path.Combine(Application.StartupPath, "doc.html"));

            //    if (outp == null || outp == "")
            //    {
            //        return GetDocument();
            //    }
            //}
            //catch { }

            //while (outp == "") ;

            string returnme = "";
            try
            {
                thsi.Invoke((MethodInvoker)delegate ()
                {
                    using (AutoJSContext context = new AutoJSContext(thsi.Window))
                    {
                        context.EvaluateScript("document.getElementsByTagName('html')[0].innerHTML", out returnme);
                    }
                });
            }
            catch (Exception e)
            {
                return "";
            }

            while (returnme == "" || returnme == null) ;

            return returnme;
        }

        public static void Bringtofront()
        {
            thsi.Invoke((MethodInvoker)(() => thsi.BringToFront()));
            thsi.Invoke((MethodInvoker)(() => thsi.Visible = true));
        }

        public static void Sendtoback()
        {
            thsi.Invoke((MethodInvoker)(() => thsi.SendToBack()));
            thsi.Invoke((MethodInvoker)(() => thsi.Visible = false));
            Load("");
        }
    }
}
