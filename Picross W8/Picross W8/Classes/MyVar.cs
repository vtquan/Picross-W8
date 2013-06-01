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
    class MyInt : INotifyPropertyChanged
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set { 
                _value = value; 
                OnPropertyChanged("Value"); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public MyInt()
        {
            this.Value = 0;
        }
    }
}
