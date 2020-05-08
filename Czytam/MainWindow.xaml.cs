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
        private object objChooseAcc;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChoAcc(object sender, RoutedEventArgs e)
        {
            ChooseAcc objChooseAcc = new ChooseAcc();
            objChooseAcc.Show();
            this.Close();
        }
        
        private void AddAcc(object sender, RoutedEventArgs e)
        {
            AddAccount objAdd = new AddAccount();
            objAdd.Show();
            this.Close();
        }

        void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
