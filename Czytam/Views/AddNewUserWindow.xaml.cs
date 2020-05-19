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

namespace Czytam.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewUserWindow : Window
    {
        private UserService _userService;


        public AddNewUserWindow()
        {
            _userService = new UserService();
            InitializeComponent();
        }


        #region Events

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }


        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            var validationResult = _userService.ValidateUserData(this.firstNameTextBox.Text, this.dateOfBirthDatePicker.SelectedDate);

            if (validationResult.Item1) // Item1 corresponds to result of validation - true means that User data are correct
            {
                try
                {
                    _userService.CreateNewUser(this.firstNameTextBox.Text, this.dateOfBirthDatePicker.SelectedDate.Value);
                }
                catch (Exception)
                {
                    throw;
                }

                ChooseAccountWindow chooseAccountWindow = new ChooseAccountWindow();
                chooseAccountWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(validationResult.Item2); // Item2 corresponds to error message after data validation
            }
        }

        #endregion
    }
}
