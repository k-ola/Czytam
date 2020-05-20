using Czytam.Services;
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

namespace Czytam.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserService _userService;
        
        public MainWindow()
        {
            _userService = new UserService();
            InitializeComponent();
            PrepareUserButton();
        }

        private void PrepareUserButton()
        {
            var users = _userService.ReadAllUsers();

            if (users.Any())
            {
                this.chooseAccountButton.IsEnabled = true;
                this.chooseAccountButton.Visibility = Visibility.Visible;
            }
        }

        #region Events

        private void AddNewUserButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewUserWidnow = new AddNewUserWindow();
            addNewUserWidnow.Show();
            this.Close();
        }


        private void ChooseAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var chooseAccountWindow = new ChooseAccountWindow();
            chooseAccountWindow.Show();
            this.Close();
        }


        

        #endregion
    }
}
