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
    /// Logika interakcji dla klasy Ex1Desc.xaml
    /// </summary>
    public partial class Ex1Desc : Window
    {
        public Ex1Desc()
        {
            InitializeComponent();
        }

        private void ChoEx(object sender, RoutedEventArgs e)
        {
            ChooseEx objChooseEx = new ChooseEx();
            objChooseEx.Show();
            this.Close();
        }

        private void Ex1(object sender, RoutedEventArgs e)
        {
            Exercise1 objEx1 = new Exercise1();
            objEx1.Show();
            this.Close();

        }
    }
}
