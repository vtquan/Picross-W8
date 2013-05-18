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
        private object[][] _picrossChart;
        public object[][] PicrossChart
        {
            get { return _picrossChart; }
            set
            {
                _picrossChart = value;
            }
        }

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
            _picrossChart = new object[5][];
            _picrossChart[0] = new object[5];
            _picrossChart[1] = new object[5];
            _picrossChart[2] = new object[5];
            _picrossChart[3] = new object[5];
            _picrossChart[4] = new object[5];

            _picrossChart[0][0] = true;

            _setting = new Setting();
        }
    }
}
