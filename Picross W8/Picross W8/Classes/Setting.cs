using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Picross_W8.Classes
{
    class Setting
    {
        public SolidColorBrush _chainBackground { get; set; }
        public SolidColorBrush ChainBackground
        {
            get { return _chainBackground; }
            set
            {
                _chainBackground = value;
            }
        }

        public Setting()
        {
            this.ChainBackground = new SolidColorBrush(Colors.Red);
        }
    }
}
