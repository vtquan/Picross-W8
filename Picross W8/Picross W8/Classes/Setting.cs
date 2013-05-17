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
        private SolidColorBrush _chainBackgroundColor;
        public SolidColorBrush ChainBackgroundColor
        {
            get { return _chainBackgroundColor; }
            set
            {
                _chainBackgroundColor = value;
            }
        }

        private SolidColorBrush _chainBorderColor;
        public SolidColorBrush ChainBorderColor
        {
            get { return _chainBorderColor; }
            set
            {
                _chainBorderColor = value;
            }
        }

        private SolidColorBrush _cellBackgroundColor;
        public SolidColorBrush CellBackgroundColor
        {
            get { return _cellBackgroundColor; }
            set
            {
                _cellBackgroundColor = value;
            }
        }

        private SolidColorBrush _cellHoverBackgroundColor;
        public SolidColorBrush CellHoverBackgroundColor
        {
            get { return _cellHoverBackgroundColor; }
            set
            {
                _cellHoverBackgroundColor = value;
            }
        }

        private SolidColorBrush _cellBorderColor;
        public SolidColorBrush CellBorderColor
        {
            get { return _cellBorderColor; }
            set
            {
                 _cellBorderColor = value;
            }
        }

        public Setting()
        {
            this.ChainBackgroundColor = new SolidColorBrush(Colors.RoyalBlue);
            this.ChainBorderColor = new SolidColorBrush(Colors.White);
            this.CellBackgroundColor = new SolidColorBrush(Colors.Gray);
            this.CellHoverBackgroundColor = new SolidColorBrush(Colors.Red);
            this.CellBorderColor = new SolidColorBrush(Colors.White);
        }
    }
}
