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
    /// Logika interakcji dla klasy WybierzModul.xaml
    /// </summary>
    public partial class WybierzModul : Window
    {
        public WybierzModul()
        {
            InitializeComponent();
        }

        private void WybCw(object sender, RoutedEventArgs e)
        {
            WybierzCwiczenie objWybCw = new WybierzCwiczenie();
            this.Close();
            objWybCw.Show();
        }

        private void WybLek(object sender, RoutedEventArgs e)
        {
            WybierzLekcje objWybLek = new WybierzLekcje();
            this.Close();
            objWybLek.Show();
        }

        private void WybKon(object sender, RoutedEventArgs e)
        {
            WybierzKonto objWybierzKonto = new WybierzKonto();
            this.Close();
            objWybierzKonto.Show();
        }
    }

    

    
}
