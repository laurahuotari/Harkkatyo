using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AlienAttackApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        private int Score = 0;

        public string Player { get; set; }
        private List<Alien> aliens;

        /* Score
        public void CurrentScore()
        {
            PlayerScore.text = score;
        }

        public void AddScore()
        {
            if alien.BeenHit(){     //voiks näin sanoo? eli jos alieniin osuu, niin lisätään piste
                score++;
            }
        }

        public void Reset()
        {
            score = 0;
        }
        */

        public GamePage()
        {
            this.InitializeComponent();

            //create player
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null) return;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
    }
}
