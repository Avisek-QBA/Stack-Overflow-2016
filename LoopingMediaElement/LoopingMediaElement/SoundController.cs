﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace LoopingMediaElement
{
    public class SoundController
    {
        public static MediaElement loop = new MediaElement();
        public static async void stopLoop()
        {
            loop.Stop();
        }

        public static async Task LoadAndPlayAsync()
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("Click.wav");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            loop.AutoPlay = false;
            loop.SetSource(stream, file.ContentType);
            //or simpler -
            //loop.Source = new Uri("ms-appx:///Assets/Click.wav", UriKind.Absolute);
            loop.MediaOpened += Loop_MediaOpened;
            loop.IsLooping = true;
        }

        private static void Loop_MediaOpened(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //play once the media is actually ready
            loop.Play();
        }
    }
}
