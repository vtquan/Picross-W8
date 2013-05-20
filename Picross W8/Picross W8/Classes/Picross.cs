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
    class Picross : INotifyPropertyChanged
    {
        private object[][] _chainRowChart;
        public object[][] ChainRowChart
        {
            get { return _chainRowChart; }
            set
            {
                _chainRowChart = value;
                OnPropertyChanged("ChainRowChart");
            }
        }

        private object[][] _chainColChart;
        public object[][] ChainColChart
        {
            get { return _chainColChart; }
            set
            {
                _chainColChart = value;
                OnPropertyChanged("ChainColChart");
            }
        }

        private object[][] _picrossChart;
        public object[][] PicrossChart
        {
            get { return _picrossChart; }
            set
            {
                _picrossChart = value;
                OnPropertyChanged("PicrossChart");
            }
        }

        public Setting _setting;
        public Setting Setting
        {
            get { return _setting; }
            set
            {
                _setting = value;
                OnPropertyChanged("PicrossChart");
            }
        }

        public Picross()
        {
            _picrossChart = new object[5][]
            {
                new object[] {1, 0, 0, 0, 1},
                new object[] {1, 1, 1, 1, 1},
                new object[] {1, 1, 1, 1, 1},
                new object[] {1, 1, 1, 1, 1},
                new object[] {1, 1, 1, 1, 1}
            };

            _setting = new Setting();
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
