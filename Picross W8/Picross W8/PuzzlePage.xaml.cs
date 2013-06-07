using Picross_W8.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Picross_W8
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PuzzlePage : Picross_W8.Common.LayoutAwarePage
    {
        int GameRunning = 0;    //game is not yet over
        int Won = 1;
        int Lost = 2;

        public PuzzlePage()
        {
            this.InitializeComponent();
            
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            Picross data = new Picross();
            this.DataContext = data;
            this.CoolListView.ItemsSource = Picross.GetPicross();
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void Cell_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            int[] dim = getDim(Convert.ToInt32(((Border)sender).Tag));
            if (((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] == 0)
            {
                ((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] = 3;
                ((Picross)PuzzleGrid.DataContext).PicrossColorChart = ((Picross)PuzzleGrid.DataContext).PicrossColorChart;
            }
        }

        private void Cell_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            int[] dim = getDim(Convert.ToInt32(((Border)sender).Tag));
            if (((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] == 3)
            {
                ((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] = 0;
                ((Picross)PuzzleGrid.DataContext).PicrossColorChart = ((Picross)PuzzleGrid.DataContext).PicrossColorChart;
            }
        }

        private void Cell_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            int[] dim = getDim(Convert.ToInt32(((Border)sender).Tag));

            if (((Picross)PuzzleGrid.DataContext).GameState == GameRunning)
            {
                if (((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] != 1 && ((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] != 2)
                {
                    if (Convert.ToBoolean(((Picross)PuzzleGrid.DataContext).PicrossChart[dim[0]][dim[1]]))    //if choice was correct
                    {
                        //Binding dd = new Binding();
                        //dd.Path = new PropertyPath("Setting.CellCorrectBackgroundColor");
                        //((Border)sender).SetBinding(Border.BackgroundProperty, dd);
                        ((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] = 1;
                        ((Picross)PuzzleGrid.DataContext).PicrossColorChart = ((Picross)PuzzleGrid.DataContext).PicrossColorChart;
                        ((Picross)PuzzleGrid.DataContext).NumCorrect++;
                        if (((Picross)PuzzleGrid.DataContext).NumCorrect == ((Picross)PuzzleGrid.DataContext).NumValid)
                        {
                            ((Picross)PuzzleGrid.DataContext).GameState = Won;
                            GameWon();
                        }
                    }
                    else
                    {
                        //Binding dd = new Binding();
                        //dd.Path = new PropertyPath("Setting.CellIncorrectBackgroundColor");
                        //((Border)sender).SetBinding(Border.BackgroundProperty, dd);

                        ((Picross)PuzzleGrid.DataContext).PicrossColorChart[dim[0]][dim[1]] = 2;
                        ((Picross)PuzzleGrid.DataContext).PicrossColorChart = ((Picross)PuzzleGrid.DataContext).PicrossColorChart;
                        ((Picross)PuzzleGrid.DataContext).NumError++;
                        if (((Picross)PuzzleGrid.DataContext).NumError == ((Picross)PuzzleGrid.DataContext).Setting.NumLife)
                        {
                            ((Picross)PuzzleGrid.DataContext).GameState = Lost;
                            GameLost();
                        }
                    }
                }
            }
        }

        private async void GameLost()
        {
            var messageDialog = new MessageDialog("");

            messageDialog = new MessageDialog("You are out of lives.");
            messageDialog.Title = "Game Over";

            messageDialog.Commands.Add(new UICommand(
            "Retry",
            new UICommandInvokedHandler(this.CommandInvokedHandler)));

            messageDialog.Commands.Add(new UICommand(
            "Close"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 1;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog and wait
            await messageDialog.ShowAsync();
        }

        private async void GameWon()
        {
            var messageDialog = new MessageDialog("");

            messageDialog = new MessageDialog("You clear the puzzle.");
            messageDialog.Title = "Congrat";

            messageDialog.Commands.Add(new UICommand(
            "Restart",
            new UICommandInvokedHandler(this.CommandInvokedHandler)));

            messageDialog.Commands.Add(new UICommand(
            "Close"));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 1;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog and wait
            await messageDialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)  //restart the puzzle
        {
            RestartGame();
        }

        private void RestartGame()
        {
            this.CoolListView.ItemsSource = Picross.GetPicross();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Picross data = new Picross();
            this.DataContext = data;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PuzzlePage));
        }

        private int[] getDim(int tag)    //get dimensional from tag value
        {
            int[] dim = new int[2];
            dim[0] = tag / ((Picross)PuzzleGrid.DataContext).Setting.NumSize;
            dim[1] = tag % ((Picross)PuzzleGrid.DataContext).Setting.NumSize;

            return dim;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
    }
}