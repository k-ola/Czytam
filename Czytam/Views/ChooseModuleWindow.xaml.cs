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
    /// Logika interakcji dla klasy ChooseModuleWindow.xaml
    /// </summary>
    public partial class ChooseModuleWindow : Window
    {
        private user _user;


        public ChooseModuleWindow(user user)
        {
            _user = user;
            InitializeComponent();
        }


        #region Events

        private void ChooseExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseExerciseWindow chooseExerciseWindow = new ChooseExerciseWindow(_user, true);
            chooseExerciseWindow.Show();
            this.Close();
        }


        private void ChooseLessonButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseLessonWindow chooseLessonWindow = new ChooseLessonWindow(_user);
            chooseLessonWindow.Show();
            this.Close();
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseAccountWindow chooseAccountWindow = new ChooseAccountWindow();
            chooseAccountWindow.Show();
            this.Close();
        }

        #endregion
    }
}
