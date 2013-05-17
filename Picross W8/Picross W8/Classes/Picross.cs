using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

using Setting = Picross_W8.Classes.Setting;

namespace Picross_W8.Classes
{
    class Picross 
    {
        public Setting setting { get; set; }
        public SolidColorBrush HoverBackgroundColor { get; set; }

        public Picross()
        {
            setting = new Setting();
            this.HoverBackgroundColor = new SolidColorBrush(Colors.Gray);
        }
    }
}
