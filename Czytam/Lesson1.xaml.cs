using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace Czytam
{
    /// <summary>
    /// Logika interakcji dla klasy Lesson1.xaml
    /// </summary>
    public partial class Lesson1 : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public Lesson1()
        {
            InitializeComponent();
        }

        private void ChoLesson1(object sender, RoutedEventArgs e)
        {
            ChooseLesson objChoLes = new ChooseLesson();
            objChoLes.Show();
            this.Close();
        }

             

        private void Play(object sender, RoutedEventArgs e)
        {
            //MediaPlayer playSound = new MediaPlayer();
            var uri = new Uri(@"../../sounds/ma.mp3", UriKind.Relative);
            mediaPlayer.Open(uri);
            mediaPlayer.Play();
                      
        }

        private void Play2(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"../../sounds/ta.mp3", UriKind.Relative);
            mediaPlayer.Open(uri);
            mediaPlayer.Play();
        }

        private void Play3(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"../../sounds/la.mp3", UriKind.Relative);
            mediaPlayer.Open(uri);
            mediaPlayer.Play();
        }

        private void Play4(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"../../sounds/mi.mp3", UriKind.Relative);
            mediaPlayer.Open(uri);
            mediaPlayer.Play();
        }
    }
}
