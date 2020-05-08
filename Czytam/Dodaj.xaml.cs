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

namespace Czytam
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        public Dodaj()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MainMenu(object sender, RoutedEventArgs e)
        {
            {
                MainWindow objMainMenu = new MainWindow();
                this.Visibility = Visibility.Hidden;
                objMainMenu.Show();
            }
        }

        private void WybKon(object sender, RoutedEventArgs e)
        {
            WybierzKonto objWybierzKonto = new WybierzKonto();
            this.Visibility = Visibility.Hidden;
            objWybierzKonto.Show();
        }
    }
}
