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

        private SolidColorBrush _cellIncorrectBackgroundColor;
        public SolidColorBrush CellIncorrectBackgroundColor
        {
            get { return _cellIncorrectBackgroundColor; }
            set
            {
                _cellIncorrectBackgroundColor = value;
            }
        }

        private SolidColorBrush _cellCorrectBackgroundColor;
        public SolidColorBrush CellCorrectBackgroundColor
        {
            get { return _cellCorrectBackgroundColor; }
            set
            {
                _cellCorrectBackgroundColor = value;
            }
        }

        public Setting()
        {
            this.ChainBackgroundColor = new SolidColorBrush(Colors.Green);
            this.ChainBorderColor = new SolidColorBrush(Colors.White);
            this.CellBackgroundColor = new SolidColorBrush(Colors.LightGray);
            this.CellHoverBackgroundColor = new SolidColorBrush(Colors.Gray);
            this.CellBorderColor = new SolidColorBrush(Colors.White);
            this.CellCorrectBackgroundColor = new SolidColorBrush(Colors.DarkGray);
            this.CellIncorrectBackgroundColor = new SolidColorBrush(Colors.LightCyan);
        }
    }
}
