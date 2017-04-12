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
    /// Game page
    /// </summary>
    public sealed partial class GamePage : Page
    {
        //score at start
        //private int Score = 0;
        //list of aliens
        //private List<Alien> aliens;
        //player
        private Player player;
        //left pressed
        private bool LeftPressed;
        //right pressed
        private bool RightPressed;
        //space pressed
        private bool SpacePressed;
        //timer
        private DispatcherTimer timer;
        //bullet list
        private List<Bullet> bullets;

        public GamePage()
        {
            this.InitializeComponent();

            //add player to location
            player = new Player
            {
                LocationX = MyCanvas.Width / 2- 30,   //center of window
                LocationY = MyCanvas.Height - 60  //at the bottom of window
            };

            //add player to canvas
            MyCanvas.Children.Add(player);

            //player location set
            player.SetLocation();

            //listener if ket down
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

            //timer
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        //timer
        private void Timer_Tick(object sender, object e)
        {
            //siirrä ammuksia ja vihollisia
            if (SpacePressed) player.Shoot();
        }

        //buttons down
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:       //move left
                    player.MoveLeft();
                    break;
                case VirtualKey.Right:      //move right
                    player.MoveRight();
                    break;
                    case VirtualKey.Space:    //space to shoot
                    Bullet bullet = new Bullet()
                    {
                        LocationX = player.LocationX + 30,
                        LocationY = player.LocationY + 30,
                    };
                    MyCanvas.Children.Add(bullet);

                    bullet.SetLocation();
                    break;
            }
        }

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

        public void ResetScore()
        {
            Score = 0;
        }
        */

        //navigation between pages
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
