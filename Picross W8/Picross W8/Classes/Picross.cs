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
        public Setting _setting;
        public Setting Setting
        {
            get { return _setting; }
            set
            {
                _setting = value;
            }
        }

        public Picross()
        {
            _setting = new Setting();
        }
    }
}
