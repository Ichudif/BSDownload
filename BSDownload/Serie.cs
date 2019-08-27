using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDownload
{
    public class Serie
    {
        //Everything except Name can be null, if the User had never selected this Series
        public string SerienName { get; set; }
        public List<Staffel> Staffeln { get; set; }
        public string Description { get; set; }
        public Uri ImageLink { get; set; }
        public List<string> Genres { get; set; }

        public Serie(string name, List<Staffel> staffeln, string descr, Uri imagelink,List<string> genres) 
        {
            SerienName = name;
            Staffeln = staffeln;
            Description = descr;
            ImageLink = imagelink;
            Genres = genres;
        }
    }

    public class Staffel
    {
        public string StaffelName { get; set; }
        public List<Folge> Folgen { get; set; }

        public Staffel(string name, List<Folge> folgen)
        {
            StaffelName = name;
            Folgen = folgen;
        }
    }

    public class Folge
    {
        public string FolgenName { get; set; }
        public Dictionary<string,string> HosterandLink { get; set; }
        public string FolgenURL { get; set; }
        public bool Downloading { get; set; }
        public bool Watched { get; set; }

        public Folge(string name, Dictionary<string,string> hoster,string folgenurl, bool down, bool watched)
        {
            FolgenName = name;
            HosterandLink = hoster;
            FolgenURL = folgenurl;
            Downloading = down;
            Watched = watched;
        }
    }
}
