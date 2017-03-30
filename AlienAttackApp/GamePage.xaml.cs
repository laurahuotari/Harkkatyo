using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
        private List<Alien> aliens;
        private Player player;
        private bool LeftPressed;
        private bool RightPressed;
        private DispatcherTimer timer;

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

            //player location
            player = new Player
            {
                LocationX = MyCanvas.Width/2,
                LocationY = MyCanvas.Height-60
            };

            //add player to canvas
            MyCanvas.Children.Add(player);
            player.SetLocation();

            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            //siirrä ammuksia ja vihollisia

        }

        //buttons down
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    player.MoveLeft();
                    break;
                case VirtualKey.Right:
                    player.MoveRight();
                    break;
            }
        }

        //navigation
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
