using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BSDownload.LinkExtractors
{
    class DynamicExtractor : Extractor
    {
        public override string GetDirectVideoLink(string Link)
        {
            WebClient wbc = new WebClient();
            string Site = wbc.DownloadString(Link);
            string directlink = "";
            try
            {
                directlink = Site.Split(new string[] { "<video " }, StringSplitOptions.None)[1].Split(new string[] { "src=\"" }, StringSplitOptions.None)[1].Split('\"')[0];
            }
            catch (Exception ex)
            {
                return "";
            }
            return directlink;
        }
    }
}
