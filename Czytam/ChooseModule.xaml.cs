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
    public partial class ChooseModule : Window
    {
        public ChooseModule()
        {
            InitializeComponent();
        }

        private void ChoEx(object sender, RoutedEventArgs e)
        {
            ChooseEx objChooseEx = new ChooseEx();
            this.Close();
            objChooseEx.Show();
        }

        private void ChoLes(object sender, RoutedEventArgs e)
        {
            ChooseLesson objChooseLesson = new ChooseLesson();
            this.Close();
            objChooseLesson.Show();
        }

        private void ChoAcc(object sender, RoutedEventArgs e)
        {
            ChooseAcc objChooseAccount = new ChooseAcc();
            this.Close();
            objChooseAccount.Show();
        }
    }

    

    
}
