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
    public sealed partial class MainPage : Picross_W8.Common.LayoutAwarePage
    {
        int numError = 0; //hold the number of mistake made
        int numCorrect = 0;
        bool gameOver;  //if game won or lost
        bool won;   //if game is won

        public MainPage()
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
            if (((Border)sender).Background != ((Picross)this.DataContext).Setting.CellCorrectBackgroundColor && ((Border)sender).Background != ((Picross)this.DataContext).Setting.CellIncorrectBackgroundColor)
            {
                int[] dim = getDim(Convert.ToInt32(((Border)sender).Tag));
                ((Picross)this.DataContext).PicrossColorChart[dim[0]][dim[1]] = 3;
            }
        }

        private void Cell_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (((Border)sender).Background != ((Picross)this.DataContext).Setting.CellCorrectBackgroundColor && ((Border)sender).Background != ((Picross)this.DataContext).Setting.CellIncorrectBackgroundColor)
            {
                int[] dim = getDim(Convert.ToInt32(((Border)sender).Tag));
                ((Picross)this.DataContext).PicrossColorChart[dim[0]][dim[1]] = 0;
            }
        }

        private void Cell_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (!gameOver)
            {
                int[] dim = getDim(Convert.ToInt32(((Border)sender).Tag));
                if (Convert.ToBoolean(((Picross)this.DataContext).PicrossChart[dim[0]][dim[1]]))    //if choice was correct
                {
                    //Binding dd = new Binding();
                    //dd.Path = new PropertyPath("Setting.CellCorrectBackgroundColor");
                    //((Border)sender).SetBinding(Border.BackgroundProperty, dd);
                    ((Picross)this.DataContext).PicrossColorChart[dim[0]][dim[1]] = 1;
                    ((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;
                    numCorrect++;
                    if (numCorrect == ((Picross)this.DataContext).NumValid)
                    {
                        GameWon();
                    }
                }
                else
                {
                    //Binding dd = new Binding();
                    //dd.Path = new PropertyPath("Setting.CellIncorrectBackgroundColor");
                    //((Border)sender).SetBinding(Border.BackgroundProperty, dd);
                    ((Picross)this.DataContext).PicrossColorChart[dim[0]][dim[1]] = 2;
                    ((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;
                    numError++;
                    if (numError == ((Picross)this.DataContext).Setting.NumLife)
                    {
                        GameLost();
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

        private void CommandInvokedHandler(IUICommand command)  //restart the puzzle
        {
            RestartGame();
        }

        private void RestartGame()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Picross data = new Picross(1);
            //this.DataContext = data;
            //((Picross)this.DataContext).Setting.TestVal[0] = 3;
            //((Picross)this.DataContext).PicrossColorChart[0][1] = 1;
            //((Picross)this.DataContext).PicrossColorChart[0][2] = 2;
            //((Picross)this.DataContext).PicrossColorChart[0][3] = 3;

            //((Picross)this.DataContext).Setting.TestVal = ((Picross)this.DataContext).Setting.TestVal;

            //((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;

            ((Picross)this.DataContext).PicrossColorChart[0][0] = 1;
            ((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ((Picross)this.DataContext).PicrossColorChart[0][1] = 1;
            ((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;
            ((Picross)this.DataContext).PicrossColorChart[0][2] = 1;
            ((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;
            ((Picross)this.DataContext).PicrossColorChart[0][3] = 1;
            ((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;
            ((Picross)this.DataContext).PicrossColorChart[0][4] = 1;
            ((Picross)this.DataContext).PicrossColorChart = ((Picross)this.DataContext).PicrossColorChart;
        }

        private int[] getDim(int tag)    //get dimensional from tag value
        {
            int[] dim = new int[2];
            dim[0] = tag / ((Picross)this.DataContext).Setting.NumSize;
            dim[1] = tag % ((Picross)this.DataContext).Setting.NumSize;

            return dim;
        }
    }
}
