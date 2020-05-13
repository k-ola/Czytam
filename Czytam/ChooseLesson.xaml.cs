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
    /// Logika interakcji dla klasy WybierzLekcje.xaml
    /// </summary>
    public partial class ChooseLesson : Window
    {
        public ChooseLesson()
        {
            InitializeComponent();
        }

        private void ChoMod(object sender, RoutedEventArgs e)
        {
            ChooseModule objChooseMod = new ChooseModule();
            this.Close();
            objChooseMod.Show();
        }

        private void Les1(object sender, RoutedEventArgs e)
        {
            Lesson1 objLes1 = new Lesson1();
            objLes1.Show();
            this.Close();
        }
    }
}
