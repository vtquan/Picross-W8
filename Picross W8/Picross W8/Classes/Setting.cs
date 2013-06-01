using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Picross_W8.Classes
{
    class Setting : INotifyPropertyChanged
    {
        private int _numLife;   //number of incorrect choice made before game over
        public int NumLife
        {
            get { return _numLife; }
            set
            {
                _numLife = value;
                OnPropertyChanged("NumLife");
            }
        }

        private int _numSize;   //size of picross chart
        public int NumSize
        {
            get { return _numSize; }
            set
            {
                _numSize = value;
                OnPropertyChanged("NumSize");
            }
        }

        private SolidColorBrush _chainBackgroundColor;
        public SolidColorBrush ChainBackgroundColor
        {
            get { return _chainBackgroundColor; }
            set
            {
                _chainBackgroundColor = value;
                OnPropertyChanged("ChainBackgroundColor");
            }
        }

        private SolidColorBrush _chainBorderColor;
        public SolidColorBrush ChainBorderColor
        {
            get { return _chainBorderColor; }
            set
            {
                _chainBorderColor = value;
                OnPropertyChanged("ChainBorderColor");
            }
        }

        private SolidColorBrush _cellBackgroundColor;
        public SolidColorBrush CellBackgroundColor
        {
            get { return _cellBackgroundColor; }
            set
            {
                _cellBackgroundColor = value;
                OnPropertyChanged("CellBackgroundColor");
            }
        }

        private SolidColorBrush _cellHoverBackgroundColor;
        public SolidColorBrush CellHoverBackgroundColor
        {
            get { return _cellHoverBackgroundColor; }
            set
            {
                _cellHoverBackgroundColor = value;
                OnPropertyChanged("CellHoverBackgroundColor");
            }
        }

        private SolidColorBrush _cellBorderColor;
        public SolidColorBrush CellBorderColor
        {
            get { return _cellBorderColor; }
            set
            {
                _cellBorderColor = value;
                OnPropertyChanged("CellBorderColor");
            }
        }

        private SolidColorBrush _cellIncorrectBackgroundColor;
        public SolidColorBrush CellIncorrectBackgroundColor
        {
            get { return _cellIncorrectBackgroundColor; }
            set
            {
                _cellIncorrectBackgroundColor = value;
                OnPropertyChanged("CellIncorrectBackgroundColor");
            }
        }

        private SolidColorBrush _cellCorrectBackgroundColor;
        public SolidColorBrush CellCorrectBackgroundColor
        {
            get { return _cellCorrectBackgroundColor; }
            set
            {
                _cellCorrectBackgroundColor = value;
                OnPropertyChanged("CellCorrectBackgroundColor");
            }
        }

        private int[] _testVal;
        public int[] TestVal
        {
            get { return _testVal; }
            set
            {
                _testVal = value;
                OnPropertyChanged("TestVal");
            }
        }

        public Setting()
        {
            this.TestVal = new int[] { 1, 2 };
            this.NumLife = 3;
            this.NumSize = 5;
            this.ChainBackgroundColor = new SolidColorBrush(Colors.Green);
            this.ChainBorderColor = new SolidColorBrush(Colors.White);
            this.CellBackgroundColor = new SolidColorBrush(Colors.LightGray);
            this.CellHoverBackgroundColor = new SolidColorBrush(Colors.Gray);
            this.CellBorderColor = new SolidColorBrush(Colors.Red);
            this.CellCorrectBackgroundColor = new SolidColorBrush(Colors.Blue);
            this.CellIncorrectBackgroundColor = new SolidColorBrush(Colors.Red);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
