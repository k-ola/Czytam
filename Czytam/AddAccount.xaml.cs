using Czytam.Models;
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
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MainMenu(object sender, RoutedEventArgs e)
        {
            {
                MainWindow objMainMenu = new MainWindow();
                this.Visibility = Visibility.Hidden;
                objMainMenu.Show();
            }
        }

        private void ChoAcc(object sender, RoutedEventArgs e)
        {
            var validationResult = User.ValidateUserData(this.firstNameTextBox.Text, this.dateOfBirthDatePicker.SelectedDate);
            if (validationResult.Item1)
            {
                User newUser = new User(this.firstNameTextBox.Text, this.dateOfBirthDatePicker.SelectedDate.Value);
                ChooseAcc objChooseAcc = new ChooseAcc();
                objChooseAcc.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(validationResult.Item2);


            }
        }
    }
}
