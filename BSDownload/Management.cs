using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using BSDownload.Properties;
using mshtml;
using Gecko;

namespace BSDownload
{
    class Management
    {
        public List<Serie> loadSeries()
        {
            List<Serie> SerienListe = new List<Serie>();
            string sitemap_bsto = new WebClient().DownloadString("http://www.bs.to/sitemap.xml");

            XmlDocument sitemap = new XmlDocument();
            sitemap.LoadXml(sitemap_bsto);

            XmlNodeList locations = sitemap.GetElementsByTagName("loc");

            foreach (XmlElement item in locations)
            {
                string[] SerienName = item.InnerText.Split(new[] { "bs.to/serie/" }, StringSplitOptions.None);
                if (SerienName.Length > 1)
                    SerienListe.Add(new Serie(SerienName[1], null, null, null, null));
            }

            SerienListe.RemoveAll(x => x.SerienName.Replace("-", "") == "");

            return SerienListe;
        }

        public Serie LoadStaffel(Serie Name)
        {
            string serien_site = new WebClient().DownloadString("http://www.bs.to/serie/" + Name.SerienName + "/");
            if (serien_site.Contains("Serie nicht gefunden!"))
            {
                return null;
            }
            List<string> GenreList = new List<string>();
            foreach (string item in serien_site.Split(new[] { "Genres" }, StringSplitOptions.None)[1].Split(new[] { "</p>" }, StringSplitOptions.None)[0].Split(new[] { "<span>" }, StringSplitOptions.None))
            {
                GenreList.Add(item.Split(new[] { "</span>" }, StringSplitOptions.None)[0]);
            }
            GenreList.RemoveAll(x => x == "");

            Name.Genres = GenreList;
            Name.Description = serien_site.Split(new[] { "<p>" }, StringSplitOptions.None)[1].Split(new[] { "</p>" }, StringSplitOptions.None)[0].Replace("&quot;", "");
            Name.ImageLink = new Uri("http://www.bs.to/public/images/cover/" + serien_site.Split(new[] { "/public/images/cover/" }, StringSplitOptions.None)[1].Split('\"')[0]);

            Name.Staffeln = new List<Staffel>();

            if (serien_site.Contains("serie/" + Name.SerienName + "/0"))
                Name.Staffeln.Add(new Staffel("Staffel 0", null));

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (serien_site.Contains("serie/" + Name.SerienName + "/" + i))
                {
                    Name.Staffeln.Add(new Staffel("Staffel " + i, null));
                }
                else { break; }
            }

            return Name;
        }

        string[] PossibleHoster = new string[] { "vivo", "Streamango", "FlashX", "OpenLoadHD", "theVideo", "vidto" };

        public Serie LoadFolgen(Serie Name, int Staffel)
        {
            string StaffelSite = new WebClient().DownloadString("http://www.bs.to/serie/" + Name.SerienName + "/" + Staffel + "/de");

            Name.Staffeln.Find(x => x.StaffelName == "Staffel " + Staffel).Folgen = new List<Folge>();

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (StaffelSite.Contains("<a href=\"serie/" + Name.SerienName + "/" + Staffel + "/" + i))
                {
                    string EpisodenName = i + StaffelSite.Split(new[] { "<a href=\"serie/" + Name.SerienName + "/" + Staffel + "/" + i }, StringSplitOptions.None)[1].Split('\"')[0];
                    //EpisodenName = EpisodenName.Replace("/en", "/de");
                    Dictionary<string, string> hoster = new Dictionary<string, string>();
                    foreach (string onehoster in PossibleHoster)
                    {
                        if (StaffelSite.Contains(Name.SerienName + "/" + Staffel + "/" + EpisodenName + "/" + onehoster))
                        {
                            hoster.Add(onehoster, "");
                        }
                    }

                    Name.Staffeln.Find(x => x.StaffelName == "Staffel " + Staffel).Folgen.Add(new Folge(EpisodenName, hoster, "http://www.bs.to/serie/" + Name.SerienName + "/" + Staffel + "/" + EpisodenName + "/", false, false));
                }
                else { break; }
            }

            return Name;
        }

        public Folge getDownloadLinks(Folge SelectedFolge, int SelectedStaffel)
        {
            if (Settings.Default.AutoSolve)
            {
                MessageBox.Show("Please dont move your mouse and keep this window in the foreground\nStarting Autosolver ...");
            }

            foreach (KeyValuePair<string, string> host in SelectedFolge.HosterandLink)
            {
                MyWebBrowserClone.Load(SelectedFolge.FolgenURL + host.Key);
                MyWebBrowserClone.DocumentText = "";
                while (MyWebBrowserClone.DocumentText == "") ;

                MyWebBrowserClone.Bringtofront();

                if (Settings.Default.AutoSolve)
                {
                    BypassGoogleCaptcha bypass = new BypassGoogleCaptcha(MyWebBrowserClone.thsi, SelectedFolge.FolgenURL + host.Key);
                    bypass.GetVideoLink();
                }

                while (!MyWebBrowserClone.GetDocument().Split(new string[] { "hoster-player" },StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "<a" },StringSplitOptions.None)[1].Split(new string[] { "</a>" },StringSplitOptions.None)[0].Contains(host.Key)) Thread.Sleep(1000);
                MyWebBrowserClone.Sendtoback();

                SelectedFolge.HosterandLink[host.Key] = MyWebBrowserClone.GetDocument().Split(new string[] { "hoster-player" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "<a href=\"" }, StringSplitOptions.None)[1].Split('\"')[0];

                break;
            }

            return SelectedFolge;
        }

        public bool checkforupdate()
        {
            string NewestVersion = new WebClient().DownloadString("http://www.bsdownload.bplaced.net/aktuelleversion");
            return true;
        }
    }
}
