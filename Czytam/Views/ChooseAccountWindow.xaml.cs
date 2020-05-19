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
using Czytam.Services;
using Czytam.Extensions;

namespace Czytam.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ChooseAccountWindow.xaml
    /// </summary>
    public partial class ChooseAccountWindow : Window
    {
        private UserService _userService;


        public ChooseAccountWindow()
        {
            _userService = new UserService();

            InitializeComponent();
            PrepareUsersButtons();
        }


        private void PrepareUsersButtons()
        {
            var users = _userService.ReadAllUsers();

            foreach (var user in users)
            {
                Button userButton = new Button();
                userButton.Content = user.first_name + ", " + user.age_in_years + "lat";
                userButton.CustomizeAsUserButton();
                userButton.Click += new RoutedEventHandler(userButton_Click);
                this.usersButtonsStackPanel.Children.Add(userButton);
            }
        }


        #region Events

        private void MainMenu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            var buttonText = (sender as Button).Content.ToString();
            var user = _userService.GetUserByFirstName(buttonText.Substring(0, buttonText.IndexOf(',')));

            if (user != null)
            {
                ChooseModuleWindow chooseModuleWindow = new ChooseModuleWindow(user);
                chooseModuleWindow.Show();
                this.Close();
            }
        }

        #endregion
    }
}
