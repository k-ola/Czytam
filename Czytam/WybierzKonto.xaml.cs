﻿using System;
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

namespace Czytam
{
    /// <summary>
    /// Logika interakcji dla klasy Strona2.xaml
    /// </summary>
    public partial class WybierzKonto : Window
    {
        public WybierzKonto()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MainMenu(object sender, RoutedEventArgs e)
        {
           MainWindow objMainMenu = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainMenu.Show();
        }

        private void WybMod(object sender, RoutedEventArgs e)
        {
            WybierzModul objWybMod = new WybierzModul();
            this.Visibility = Visibility.Hidden;
            objWybMod.Show();
        }
    }
}
