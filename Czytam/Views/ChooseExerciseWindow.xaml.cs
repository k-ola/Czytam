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
    /// Logika interakcji dla klasy ChooseExerciseWindow.xaml
    /// </summary>
    public partial class ChooseExerciseWindow : Window
    {
        private user _user;
        private bool _isOpenedFromModuleWindow = false;
        private int _exerciseNumber;
        private lesson _lesson;
        private ExerciseService _exerciseService;
        private LessonService _lessonService;


        public ChooseExerciseWindow(user user, bool loadAllExcercises = false)
        {
            _user = user;
            _isOpenedFromModuleWindow = loadAllExcercises;
            _exerciseService = new ExerciseService();
            _lessonService = new LessonService();

            InitializeComponent();
            PrepareExercisesButtons(loadAllExcercises);
        }


        public ChooseExerciseWindow(user user, int exerciseNumber)
        {
            _exerciseNumber = exerciseNumber;

            _user = user;
            _exerciseService = new ExerciseService();
            _lessonService = new LessonService();

            InitializeComponent();
            PrepareExercisesButtons(false);
        }


        public ChooseExerciseWindow(user user, lesson lesson)
        {
            _lesson = lesson;

            _user = user;
            _exerciseService = new ExerciseService();
            _lessonService = new LessonService();

            InitializeComponent();
            PrepareExercisesButtons(false);
        }


        private void PrepareExercisesButtons(bool loadAllExcercises)
        {
            IList<exercis> listOfExercises = new List<exercis>();

            if (loadAllExcercises)
            {
                var lessons = _lessonService.GetLessonsByUser(_user);
                listOfExercises = _exerciseService.GetAllExercisesByUserLessons(lessons);
            }
            else if (_lesson != null)
            {
                listOfExercises = _exerciseService.GetExercisesByUserSingleLesson(_lesson);
            }
            else if (_exerciseNumber != 0)
            {
                listOfExercises = _exerciseService.GetAllExercisesFromLesson(_user, _exerciseNumber);
            }

            foreach (exercis exercise in listOfExercises)
            {
                Button exerciseButton = new Button
                {
                    Content = GlobalVariables.exerciseNumberPartialText + exercise.exercise_number
                };
                exerciseButton.Click += new RoutedEventHandler(ExerciseButton_Click);
                exerciseButton.CustomizeAsExerciseButton();
                SetExerciseButtonEnabledOrDisabled(exerciseButton);

                this.excercisesButtonStackPanel.Children.Add(exerciseButton);
            }
        }

        private void SetExerciseButtonEnabledOrDisabled(Button exerciseButton)
        {
            if (_isOpenedFromModuleWindow)
            {
                exerciseButton.IsEnabled = true;
                exerciseButton.CustomizeForNotDone();
            }
            else if (_lesson != null)
            {
                int.TryParse(exerciseButton.Content.ToString().Replace(GlobalVariables.exerciseNumberPartialText, ""), out int buttonExerciseNumber);
                var exercisesDoneFromLesson = _exerciseService.GetDoneExercisesNumbersByLesson(_lesson);

                if (buttonExerciseNumber != 0 &&
                    exercisesDoneFromLesson != null &&
                    exercisesDoneFromLesson.Count > 0 &&
                   (exercisesDoneFromLesson.Contains(buttonExerciseNumber) ||
                    exercisesDoneFromLesson.Max() + 1 == buttonExerciseNumber))
                {
                    exerciseButton.IsEnabled = true;
                }
                else if (buttonExerciseNumber != 0)
                {
                    int firstExerciseNumberFromLesson = _exerciseService.GetFirstExerciseNumberFromLesson(_lesson);

                    if (firstExerciseNumberFromLesson != 0 &&
                        firstExerciseNumberFromLesson == buttonExerciseNumber)
                    {
                        exerciseButton.IsEnabled = true;
                    }
                    else
                    {
                        exerciseButton.IsEnabled = false;
                    }
                }
                else
                {
                    exerciseButton.IsEnabled = false;
                }

                CustomizeExerciseButtonAsDoneOrNot(exerciseButton);
            }
            else if (_exerciseNumber != 0)
            {
                int.TryParse(exerciseButton.Content.ToString().Replace(GlobalVariables.exerciseNumberPartialText, ""), out int buttonExerciseNumber);
                var listOfExercisesNumbersAlreadyDone = _exerciseService.GetDoneExercisesNumbersByUserAndExerciseNumber(_user, _exerciseNumber);

                if (buttonExerciseNumber <= _exerciseNumber ||
                    (listOfExercisesNumbersAlreadyDone != null &&
                    listOfExercisesNumbersAlreadyDone.Count > 0 &&
                    (listOfExercisesNumbersAlreadyDone.Contains(buttonExerciseNumber) ||
                    buttonExerciseNumber <= listOfExercisesNumbersAlreadyDone.Max() + 1)))
                {
                    exerciseButton.IsEnabled = true;
                }
                else
                {
                    exerciseButton.IsEnabled = false;
                }

                CustomizeExerciseButtonAsDoneOrNot(exerciseButton);
            }
        }

        private void CustomizeExerciseButtonAsDoneOrNot(Button exerciseButton)
        {
            int.TryParse(exerciseButton.Content.ToString().Replace(GlobalVariables.exerciseNumberPartialText, ""), out int buttonExerciseNumber);
            var listOfExercisesNumbersAlreadyDone = _exerciseService.GetDoneExercisesNumbersByUserAndExerciseNumber(_user, buttonExerciseNumber);

            if (buttonExerciseNumber != 0 &&
                listOfExercisesNumbersAlreadyDone.Contains(buttonExerciseNumber))
            {
                exerciseButton.CustomizeForDone();
            }
            else
            {
                exerciseButton.CustomizeForNotDone();
            }
        }


        #region Events

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseModuleWindow chooseModuleWindow = new ChooseModuleWindow(_user);
            chooseModuleWindow.Show();
            this.Close();
        }


        private void ExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse((sender as Button)?.Content.ToString().Replace(GlobalVariables.exerciseNumberPartialText, ""), out int exerciseNumber))
            {
                ExerciseWindow exerciseWindow = new ExerciseWindow(_user, exerciseNumber, _isOpenedFromModuleWindow);
                exerciseWindow.Show();
                this.Close();
            }
        }

        #endregion
    }
}
