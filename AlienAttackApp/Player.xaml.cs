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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace AlienAttackApp
{
    public sealed partial class Player : UserControl
    {

        private readonly double MaxLocationX = 800-70;
        private readonly double MinLocationX = 10;
        public double LocationX { get; set; }
        public double LocationY { get; set; }


        public Player()
        {
            this.InitializeComponent();
        }

        public void MoveLeft()
        {
            if (LocationX < MinLocationX) LocationX = MinLocationX;
            LocationX -= 10;
            SetLocation();
        }

        public void MoveRight()
        {
            if (LocationX > MaxLocationX) LocationX = MaxLocationX;
            LocationX += 10;
            SetLocation();
        }

        public void Shoot()
        {

        }

        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

    }
}
