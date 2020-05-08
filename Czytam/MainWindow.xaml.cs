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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Czytam
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object objWybierzKonto;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void WybKon(object sender, RoutedEventArgs e)
        {
            WybierzKonto objWybierzKonto = new WybierzKonto();
            this.Visibility = Visibility.Hidden;
            objWybierzKonto.Show();
            
        }
        
        private void DodKon(object sender, RoutedEventArgs e)
        {
            Dodaj objDodaj = new Dodaj();
            this.Visibility = Visibility.Hidden;
            objDodaj.Show();
        }

        void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
