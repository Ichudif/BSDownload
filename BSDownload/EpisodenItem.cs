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
    public partial class EpisodenItem : UserControl
    {
        public EpisodenItem(string Name)
        {
            InitializeComponent();
            label1.Text = Name;
        }
    }
}
