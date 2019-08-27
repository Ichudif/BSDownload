using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSDownload
{
    public partial class FolgenItem : UserControl
    {
        public Folge ThisFolge;
        public FolgenItem(string Name,bool watched, int availablesize, Folge thisFolge)
        {
            InitializeComponent();
            NameLabel.Text = Name;
            Watchlistanswer.Text = watched ? "ja" : "nein";
            panel1.Width = availablesize;
            ThisFolge = thisFolge;
        }

        public bool Checked()
        {
            ThisFolge.Downloading = herunterladenCB.Checked;
            return herunterladenCB.Checked;
        }
    }
}
