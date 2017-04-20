﻿using System;
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
        //alien timer
        private DispatcherTimer alientimer;
        //bullet list
        private List<Bullet> bullets;                
        //alien list
        private List<Alien> aliens;
        //score at start
        private int Score = 0;
        private int HitCount = 0;

        public GamePage()
        {
            this.InitializeComponent();

            //init alien list
            aliens = new List<Alien>();
            //init bullet list
            bullets = new List<Bullet>();

            //add player to location
            player = new Player
            {
                LocationX = MyCanvas.Width / 2- 30,   //center of window
                LocationY = MyCanvas.Height - 60  //at the bottom of window
            };

            //add player to canvas
            MyCanvas.Children.Add(player);


            Random r = new Random();
            int x = r.Next(0, 770);

            Alien alien = new Alien()
            {
                LocationX = x,
                LocationY = MyCanvas.Height - 640
            };
            //SetLocation
            alien.SetLocation();

            //Add alien
            aliens.Add(alien);

            MyCanvas.Children.Add(alien);

            //player location set
            player.SetLocation();

            //add score
            AddScore();

            //listener if key down
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

            //game loop
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Tick += Timer_Tick;
            timer.Start();

            //alien loop
            alientimer = new DispatcherTimer();
            alientimer.Interval = new TimeSpan(0, 0, 0, 2);
            alientimer.Tick += AlienTimer_Tick;
            alientimer.Start();

        }

        //buttons down
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:           //move left
                    player.MoveLeft();
                    break;
                case VirtualKey.Right:          //move right
                    player.MoveRight();
                    break;
                case VirtualKey.Space:          //space to shoot
                    SpacePressed = false;
                    Bullet bullet = new Bullet()
                    {
                        LocationX = player.LocationX + 30,
                        LocationY = player.LocationY + 5,
                    };
                    //add bullet to canvas
                    MyCanvas.Children.Add(bullet);

                    //set bullet location
                    bullet.SetLocation();

                    //add to list
                    bullets.Add(bullet);
                    break;
            }
        }

        //timer
        private void Timer_Tick(object sender, object e)
        {
            //siirrä ammuksia ja vihollisia
            foreach(Bullet bullet in bullets)
            {
                bullet.Shoot();
                if(bullet.LocationY == 0)
                {
                    MyCanvas.Children.Remove(bullet);
                    bullets.Remove(bullet);
                }
            }           
              
            foreach(Alien alien in aliens)
            {
                alien.Move();
            }

           CheckCollision();
        }

        //alien timer
        private void AlienTimer_Tick(object sender, object e)
        {
            //EI TOIMI, PITÄÄKÖ OLLA LOOP?

                Random r = new Random();
                int x = r.Next(0, 770);

                Alien alien = new Alien()
                {
                    LocationX = x,
                    LocationY = -60
                };
                //SetLocation
                alien.SetLocation();

                //Add alien
                aliens.Add(alien);

                //add alien to canvas
                MyCanvas.Children.Add(alien);
            
        }

        //Check collision
        private void CheckCollision()
        {
            // Loop aliens list
            foreach(Alien alien in aliens)
            {
                foreach (Bullet bullet in bullets)
                {

                    Rect ARect = new Rect(alien.LocationX, alien.LocationY, alien.ActualWidth, alien.ActualHeight);
                    Rect BRect = new Rect(bullet.LocationX, bullet.LocationY, bullet.ActualWidth, bullet.ActualHeight);

                    //Does objects intersects
                    BRect.Intersect(ARect);
                    if (!BRect.IsEmpty)
                    {
                        MyCanvas.Children.Remove(alien);
                        MyCanvas.Children.Remove(bullet);
                        aliens.Remove(alien);
                        bullets.Remove(bullet);
                        HitCount++;
                        if (HitCount == 5)
                        {
                            alientimer.Interval = new TimeSpan(0, 0, 0, 1, 500);
                        }if(HitCount == 10)
                        {
                            alientimer.Interval = new TimeSpan(0, 0, 0, 1);
                        }if(HitCount == 15)
                        {
                            alientimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                        }
                        AddScore();
                        return;
                    }
                }
            }
            
        }

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

        //Score
        public void AddScore()
        {
            int value = int.Parse(PlayerScore.Text);

            if (HitCount>0)
            {
                value++;
            }

            PlayerScore.Text = value.ToString();
        }
       
    }
}
