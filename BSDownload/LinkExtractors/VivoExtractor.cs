using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BSDownload.LinkExtractors
{
    class VivoExtractor : Extractor
    {
        public override string GetDirectVideoLink(string VivoLink)
        {
            WebClient wbc = new WebClient();
            string test = wbc.DownloadString(VivoLink);
            test = test.Split(new string[] { "source: \'" }, StringSplitOptions.None)[1].Split('\'')[0];
            Console.WriteLine(test);
            return DecodeURI(test);
        }

        private static string DecodeURI(string code)
        {
            string unescaped = Uri.UnescapeDataString(code);
            string finalURI = "";

            foreach (char item in unescaped)
            {
                int help = (int)item + 47;
                if (help > 126)
                {
                    help -= 94;
                }
                finalURI += Convert.ToChar(help);
            }

            return finalURI;
        }
    }
}
