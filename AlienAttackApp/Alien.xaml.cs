using Windows.System;
using System.Collections.Generic;
//using Windows.System.IO;
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
using System;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AlienAttackApp
{
    public sealed partial class Alien : UserControl
    {
        //timer
        private DispatcherTimer timer;

        //health
        public int Healt { get; set; }
        //x location
        public double LocationX { get; set; }
        //y location
        public double LocationY { get; set; }
        //speed
        private readonly double MaxSpeed = 10;
        private double speed;


        public Alien()
        {
            this.InitializeComponent();

            timer = new DispatcherTimer();

            timer.Tick += Timer_tick;
            timer.Start();
           
        }

        private void Timer_tick(object sender, object e)
        {
            Alien alien = new Alien();

        }



        //movement
        public void Movement()
        {
            if (speed > MaxSpeed) speed = MaxSpeed;


        }

        //been hit
        public void BeenHit()
        {

        }
    }
}
