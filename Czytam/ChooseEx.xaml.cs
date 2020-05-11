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
    /// Logika interakcji dla klasy WybierzCwiczenie.xaml
    /// </summary>
    public partial class ChooseEx : Window
    {
        public ChooseEx()
        {
            InitializeComponent();
        }

        private void ChoMod(object sender, RoutedEventArgs e)
        {
            ChooseModule objChooseMod = new ChooseModule();
            objChooseMod.Show();
            this.Close();
        }

        private void ChoEx1(object sender, RoutedEventArgs e)
        {
            Ex1Desc objEx1dexc = new Ex1Desc();
            objEx1dexc.Show();
            this.Close();
        }
    }
}
