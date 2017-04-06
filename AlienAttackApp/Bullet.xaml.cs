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
    public sealed partial class Bullet : UserControl
    {
        
        public bool IsVisible { get; set; }
        public float Speed { get; set; }
        //public Vector2 origin;
        //public double Position;

        //x location
        public double LocationX { get; set; }
        //y location
        public double LocationY { get; set; }

        public Bullet()
        {
            this.InitializeComponent();
            //Speed = 10;
            IsVisible = true;
        }
    }
}
