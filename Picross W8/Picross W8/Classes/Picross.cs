using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string PuzzleName { get; set; }

        public int ID { get; set; }

        private int[][] _chainRowChart;
        public int[][] ChainRowChart
        {
            get { return _chainRowChart; }
            set
            {
                _chainRowChart = value;
                OnPropertyChanged("ChainRowChart");
            }
        }

        private int[][] _chainColChart;
        public int[][] ChainColChart
        {
            get { return _chainColChart; }
            set
            {
                _chainColChart = value;
                OnPropertyChanged("ChainColChart");
            }
        }

        private int[][] _picrossChart;   //store which space in chart is valid; 1 = valid, 0 = not valid
        public int[][] PicrossChart
        {
            get { return _picrossChart; }
            set
            {
                _picrossChart = value;
                OnPropertyChanged("PicrossChart");
            }
        }

        private int[][] _picrossColorChart;   //store which background should the corresponding border has; 0 = cellBackgroundColor, 1 = cellCorrectBackgroundColor, 2 = cellIncorrectBackgroundColor, 3 = cellHoverColor
        public int[][] PicrossColorChart
        {
            get { return _picrossColorChart; }
            set
            {
                _picrossColorChart = (int[][])value;
                OnPropertyChanged("PicrossColorChart");
            }
        }

        public int NumValid { get; set; }  //number of valid space in PicrossChart

        public int NumCorrect { get; set; }    //number of correct choices made in game

        public int NumError { get; set; }  //number of errors made in game

        public int GameState { get; set; }  //number of errors made in game

        private Setting _setting;
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
            PuzzleName = "Picross 5x5";
            _picrossChart = new int[5][]
            {
                new int[] {1, 1, 0, 0, 0},
                new int[] {1, 0, 1, 0, 1},
                new int[] {1, 1, 1, 0, 0},
                new int[] {0, 1, 1, 1, 0},
                new int[] {1, 0, 1, 1, 1}
            };

            _picrossColorChart = new int[5][]
            {
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0}
            };

            _chainColChart = new int[3][]
            {
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0}
            };

            FillColChart();

            _chainRowChart = new int[5][]
            {
                new int[] {0, 0, 0},
                new int[] {0, 0, 0},
                new int[] {0, 0, 0},
                new int[] {0, 0, 0},
                new int[] {0, 0, 0}
            };

            FillRowChart();

            FillNumValid();

            this.NumCorrect = 0;

            this.NumError = 0;

            this.GameState = 0;

            _setting = new Setting();
        }

        public Picross(int i)
        {
            ID = i;

            if (ID == 1)
            {
                PuzzleName = "House";

                _picrossChart = new int[5][]
                {
                    new int[] {0, 0, 1, 0, 0},
                    new int[] {0, 1, 1, 1, 0},
                    new int[] {1, 1, 1, 1, 1},
                    new int[] {1, 1, 0, 1, 1},
                    new int[] {1, 1, 0, 1, 1}
                };
            }

            if (ID == 2)
            {
                PuzzleName = "Man";

                _picrossChart = new int[5][]
                {
                    new int[] {1, 0, 1, 0, 1},
                    new int[] {0, 1, 1, 1, 0},
                    new int[] {0, 0, 1, 0, 0},
                    new int[] {0, 1, 0, 1, 0},
                    new int[] {1, 0, 0, 0, 1}
                };
            }

            if (ID == 3)
            {
                PuzzleName = "Bear";

                _picrossChart = new int[5][]
                {
                    new int[] {0, 1, 0, 1, 0},
                    new int[] {1, 1, 0, 1, 1},
                    new int[] {0, 0, 1, 0, 0},
                    new int[] {1, 0, 0, 0, 1},
                    new int[] {1, 1, 1, 1, 1}
                };
            }

            if (ID == 4)
            {
                PuzzleName = "Liver";

                _picrossChart = new int[5][]
                {
                    new int[] {1, 1, 0, 1, 1},
                    new int[] {1, 0, 0, 0, 1},
                    new int[] {1, 1, 1, 0, 0},
                    new int[] {1, 0, 0, 0, 0},
                    new int[] {1, 0, 1, 1, 1}
                };
            }

            if (ID == 5)
            {
                PuzzleName = "Facebook";

                _picrossChart = new int[5][]
                {
                    new int[] {0, 0, 1, 1, 1},
                    new int[] {0, 0, 1, 0, 0},
                    new int[] {0, 0, 1, 0, 0},
                    new int[] {0, 1, 1, 1, 0},
                    new int[] {0, 0, 1, 0, 0}
                };
            }

            if (ID == 6)
            {
                PuzzleName = "Tetris";

                _picrossChart = new int[5][]
                {
                    new int[] {0, 0, 0, 0, 0},
                    new int[] {1, 1, 0, 0, 0},
                    new int[] {0, 1, 1, 0, 0},
                    new int[] {0, 0, 0, 0, 0},
                    new int[] {1, 1, 0, 1, 1}
                };
            }

            _picrossColorChart = new int[5][]
            {
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0}
            };

            _chainColChart = new int[3][]
            {
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0},
                new int[] {0, 0, 0, 0, 0}
            };

            FillColChart();

            _chainRowChart = new int[5][]
            {
                new int[] {0, 0, 0},
                new int[] {0, 0, 0},
                new int[] {0, 0, 0},
                new int[] {0, 0, 0},
                new int[] {0, 0, 0}
            };

            FillRowChart();

            FillNumValid();

            this.NumCorrect = 0;

            this.NumError = 0;

            this.GameState = 0;

            _setting = new Setting();
        }

        public void FillColChart()  //add value to ChainColChart base on PicrossChart
        {//for each column in PicrossChart it starts at the bottom going upand looks for the length the first chain of 1 and place it in the highest row (bottom row) of the same column in ChainColChart. The next chain will go in the the second highest row of the same column and so on.
            int lengthChain = 0;
            int currentRow = 0; //row in ChainColChart to place lengthChain in
            for (int col = 0; col < PicrossChart[0].GetLength(0); col++ )   //for each column in PicrossChart; Assuming it is a rectangular jagged array
            {
                lengthChain = 0;
                currentRow = ChainColChart.GetLength(0) - 1;    
                for (int row = PicrossChart.GetLength(0) - 1; row >=0; row--)   //starting from the bottom row, for each row in PicrossChart; Assuming it is a rectangular jagged array
                {
                    if (Convert.ToBoolean(PicrossChart[row][col]))
                    {
                        lengthChain++;
                        if (row == 0)   //this is the last row to be checked for this column so store it in ChainColChart
                        {
                            ChainColChart[currentRow][col] = lengthChain;
                            currentRow--;
                            lengthChain = 0;
                        }
                    }
                    else
                    {
                        if (lengthChain != 0)
                        {
                            ChainColChart[currentRow][col] = lengthChain;
                            currentRow--;
                            lengthChain = 0;
                        }
                    }
                }
            }
        }

        public void FillRowChart()  //add value to ChainRowChart base on PicrossChart
        {//for each row in PicrossChart it starts at the right going left and looks for the length the first chain of 1 and place it in the highest column (right column) of the same row in ChainRowChart. The next chain will go in the the second highest column of the same row and so on.
            int lengthChain = 0;
            int currentCol = 0; //column in ChainRowChart to place lengthChain in
            for (int row = 0; row < PicrossChart.GetLength(0); row++)   //for each row in PicrossChart; Assuming it is a rectangular jagged array
            {
                lengthChain = 0;
                currentCol = ChainRowChart[0].GetLength(0) - 1;
                for (int col = PicrossChart[0].GetLength(0) - 1; col >= 0; col--)   //starting from the bottom row, for each row in PicrossChart; Assuming it is a rectangular jagged array
                {
                    if (Convert.ToBoolean(PicrossChart[row][col]))
                    {
                        lengthChain++;
                        if (col == 0)   //this is the last row to be checked for this column so store it in ChainColChart
                        {
                            ChainRowChart[row][currentCol] = lengthChain;
                            currentCol--;
                            lengthChain = 0;
                        }
                    }
                    else
                    {
                        if (lengthChain != 0)
                        {
                            ChainRowChart[row][currentCol] = lengthChain;
                            currentCol--;
                            lengthChain = 0;
                        }
                    }
                }
            }
        }

        public void FillNumValid()  //give value to numValid base on PicrossChart
        {
            NumValid = 0;
            for (int row = 0; row < PicrossChart.GetLength(0); row++)   //for each row in PicrossChart; Assuming it is a rectangular jagged array
            {
                for (int col = 0; col < PicrossChart[0].GetLength(0); col++)   //for each column in PicrossChart; Assuming it is a rectangular jagged array
                {
                    if (Convert.ToBoolean(PicrossChart[row][col]))
                    {
                        NumValid++;
                    }
                }
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

        public static ObservableCollection<Picross> GetPicross()
        {
            var picross = new ObservableCollection<Picross>();

            picross.Add(new Picross(1));
            picross.Add(new Picross(2));
            picross.Add(new Picross(3));
            picross.Add(new Picross(4));
            picross.Add(new Picross(5));
            picross.Add(new Picross(6));

            return picross;
        }
    }
}
