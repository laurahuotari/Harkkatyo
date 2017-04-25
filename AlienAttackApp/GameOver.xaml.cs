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
    public sealed partial class GameOver : UserControl
    {
        //x location
        public double LocationX { get; set; }
        //y location
        public double LocationY { get; set; }

        public GameOver()
        {
            this.InitializeComponent();
        }

        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        //navigates back to the front page (play again)

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
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
