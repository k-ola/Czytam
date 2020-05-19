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
using Czytam.Globals;

namespace Czytam.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ChooseLessonWindow.xaml
    /// </summary>
    public partial class ChooseLessonWindow : Window
    {
        private user _user;
        private LessonService _lessonService;


        public ChooseLessonWindow(user user)
        {
            _user = user;
            _lessonService = new LessonService();

            InitializeComponent();
            PrepareLessonsButtons();
        }


        private void PrepareLessonsButtons()
        {
            var usersLessons = _lessonService.GetLessonsByUser(_user);

            foreach (lesson lesson in usersLessons)
            {
                Button lessonButton = new Button
                {
                    Content = GlobalVariables.lessonNumberPartialText + lesson.lesson_number
                };
                lessonButton.Click += new RoutedEventHandler(LessonButton_Click);

                SetLessonButtonAsEnabledOrDisabled(lessonButton);

                if (lesson.is_done)
                {
                    lessonButton.CustomizeForDone();
                }
                else
                {
                    lessonButton.CustomizeForNotDone();
                }

                lessonsButtonsStackPanel.Children.Add(lessonButton);
            }
        }

        private void SetLessonButtonAsEnabledOrDisabled(Button lessonButton)
        {
            int.TryParse(lessonButton.Content.ToString().Replace(GlobalVariables.lessonNumberPartialText, ""), out int buttonLessonNumber);
            var lessonsDone = _lessonService.GetDoneLessonsNumbersByUser(_user);

            if (buttonLessonNumber != 0 &&
                lessonsDone != null &&
                lessonsDone.Count > 0 &&
               (lessonsDone.Contains(buttonLessonNumber) ||
                lessonsDone.Max() + 1 == buttonLessonNumber))
            {
                lessonButton.IsEnabled = true;
            }
            else if (buttonLessonNumber != 0 &&
                     buttonLessonNumber == _lessonService.GetFirstLessonNumber(_user))
            {
                lessonButton.IsEnabled = true;
            }
            else
            {
                lessonButton.IsEnabled = false;
            }
        }


        #region Events

        private void LessonButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse((sender as Button)?.Content.ToString().Replace(GlobalVariables.lessonNumberPartialText, ""), out int lessonNumber))
            {
                LessonWindow lessonWindow = new LessonWindow(_user, lessonNumber);
                lessonWindow.Show();
                this.Close();
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseModuleWindow chooseModuleWindow = new ChooseModuleWindow(_user);
            chooseModuleWindow.Show();
            this.Close();
        }

        #endregion
    }
}
