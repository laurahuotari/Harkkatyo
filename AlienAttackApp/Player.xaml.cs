using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Numerics;
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
        //max x location
        private readonly double MaxLocationX = 800 - 70;
        //min x location
        private readonly double MinLocationX = 0 + 9;
        //x location
        public double LocationX { get; set; }
        //y location
        public double LocationY { get; set; }

        //time between shooting bullets
        public int BulletInterval { get; set; }
        //bullet list
        public List<Bullet> bulletList;

        public Player()
        {
            this.InitializeComponent();
            bulletList = new List<Bullet>();
            BulletInterval = 20;
        }

        //move left
        public void MoveLeft()
        {
            if (LocationX < MinLocationX) LocationX = MinLocationX;
            LocationX -= 10;        //how many pixels
            SetLocation();
        }

        //move right
        public void MoveRight()
        {
            if (LocationX > MaxLocationX) LocationX = MaxLocationX;
            LocationX += 10;        //how many pixels
            SetLocation();
        }

        //location
        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }
}
