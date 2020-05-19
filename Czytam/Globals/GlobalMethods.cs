using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Czytam.Globals
{
    public static class GlobalMethods
    {
        public static void SoundButton_Click(object sender, RoutedEventArgs e)
        {
            string soundToPlay = (sender as Button)?.Tag.ToString();

            if (!string.IsNullOrWhiteSpace(soundToPlay))
            {
                var uri = new Uri(GlobalVariables.pathToSoundFiles + soundToPlay + ".mp3", UriKind.Relative);

                var mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(uri);
                mediaPlayer.Play();
            }
        }
    }
}
