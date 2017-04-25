using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AlienAttackApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        //music
        private MediaElement mediaElementMusic;

        public MainPage()
        {
            this.InitializeComponent();

            //change default start up mode
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            // size 800*600
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);
            //disable debugger info
            App.Current.DebugSettings.EnableFrameRateCounter = false;

            //load music
            LoadAudioMusic();

        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage));
        }

        private async void LoadAudioMusic()
        {
            StorageFolder folderMusic =
                await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile fileMusic =
                await folderMusic.GetFileAsync("space.wav");
            var streamMusic = await fileMusic.OpenAsync(FileAccessMode.Read);

            mediaElementMusic = new MediaElement();
            mediaElementMusic.IsLooping = true;
            mediaElementMusic.SetSource(streamMusic, fileMusic.ContentType);
        }
        //repeat when over;

    }
}
