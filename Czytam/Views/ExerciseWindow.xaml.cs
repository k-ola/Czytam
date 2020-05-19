using Czytam.Extensions;
using Czytam.Globals;
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
using System.Windows.Shapes;

namespace Czytam.Views
{
    /// <summary>
    /// Interaction logic for ExerciseWindow.xaml
    /// </summary>
    public partial class ExerciseWindow : Window
    {
        private user _user;
        private int _exerciseNumber;
        private bool _isOpenedFromModuleWindow;
        private bool _isTooltipTextCleared = false;

        private ExerciseService _exerciseService;
        private SyllableService _syllableService;
        private WordService _wordService;
        private LessonService _lessonService;
        private string _wordToGuess = string.Empty;
        private const string _defaultSyllablesTextBoxText = "Tu pojawią się sylaby, które wybrałeś.";
        private int _wordsToGuessCount = -1;
        private int _wordsAlreadyGuessedCount = 0;

        public ExerciseWindow(user user, int exerciseNumber, bool isOpenedFromModuleWindow = false)
        {
            _user = user;
            _exerciseNumber = exerciseNumber;
            _isOpenedFromModuleWindow = isOpenedFromModuleWindow;
            _exerciseService = new ExerciseService();
            _syllableService = new SyllableService();
            _wordService = new WordService();
            _lessonService = new LessonService();

            InitializeComponent();
            PrepareExerciseDescription();
            PrepareSyllablesButtons();
            PrepareSoundsButtons();
        }

        private void PrepareSoundsButtons()
        {
            int exerciseSetupId = _exerciseService.GetExerciseSetupIdByExerciseNumber(_exerciseNumber);
            var words = _wordService.GetExerciseWordsByExerciseSetupId(exerciseSetupId);

            if (words != null)
            {
                int counter = 1;
                foreach (var word in words.OrderBy(a => Guid.NewGuid()).ToList()) //OrderBy used to randomized collection
                {
                    Button wordSoundButton = new Button
                    {
                        Tag = word.word_text
                    };
                    wordSoundButton.Content = "Słowo " + counter;
                    wordSoundButton.CustomizeAsSoundButton();
                    wordSoundButton.Click += new RoutedEventHandler(WordSoundButton_Click);

                    this.wordsSoundButtonsStackPanel.Children.Add(wordSoundButton);

                    counter++;
                }

                _wordsToGuessCount = words.Count;
            }
        }

        private void PrepareExerciseDescription()
        {
            this.exerciseNumberLabel.Content = GlobalVariables.exerciseNumberPartialText + _exerciseNumber;
            this.exerciseDescriptionTextBlock.Text = _exerciseService.GetExerciseDescriptionByExerciseNumber(_exerciseNumber);

            Title = GlobalVariables.exerciseNumberPartialText + _exerciseNumber;
        }

        private void PrepareSyllablesButtons()
        {
            var listOfSyllables = new List<syllable>();
            for (int i = 1; i <= _exerciseNumber; i++)
            {
                listOfSyllables.AddRange(_syllableService.GetSyllablesByExerciseNumber(i));
            }

            var listOfSyllablesText = new List<string>();
            foreach (syllable syllable in listOfSyllables)
            {
                listOfSyllablesText.Add(syllable.syllable_text);
                //listOfSyllablesText.Add(syllable.syllable_text.ToUpper()); //We need to display both lower and uppercases syllables
            }

            foreach (string syllableText in listOfSyllablesText.OrderBy(a => Guid.NewGuid()).ToList()) //OrderBy used to randomized collection
            {
                Button syllableButton = new Button();
                syllableButton.Content = syllableText;
                syllableButton.Click += new RoutedEventHandler(SyllableButton_Click);
                syllableButton.CustomizeAsSyllableButton();

                this.syllablesButtonsStackPanel.Children.Add(syllableButton);
            }
        }


        private void SetWordSoundButtonAsGuessed(string wordToGuess)
        {
            foreach (Button button in this.wordsSoundButtonsStackPanel.Children)
            {
                if (button.Tag.ToString().Equals(wordToGuess))
                {
                    button.CustomizeForWordsDone();
                    button.IsEnabled = false;
                }
            }
        }



        private bool CheckIfExerciseDone()
        {
            bool isDone = false;

            if (_wordsAlreadyGuessedCount == _wordsToGuessCount &&
                !_isOpenedFromModuleWindow)
            {
                _exerciseService.SetExerciseAsDone(_user, _exerciseNumber); // We want to set excersice as done only when it was opened from Lessons module

                if (_exerciseService.GetNextExercisesFromLesson(_user, _exerciseNumber).Count > 0)
                {
                    MessageBox.Show(this, "Brawo! Zapisałeś poprawnie wszystkie słowa. \n Możemy teraz przejść do następnego ćwiczenia.");
                    this.nextExerciseButton.IsEnabled = true;
                }
                else if (_exerciseService.GetNextExercisesFromLesson(_user, _exerciseNumber).Count == 0)
                {
                    MessageBox.Show(this, "Brawo! Ukończyłeś wszystkie ćwiczenia z tej lekcji.");
                    _lessonService.SetLessonAsDone(_user, _exerciseNumber);

                    int currentLessonNumber = _lessonService.GetLessonByUserAndExerciseNumber(_user, _exerciseNumber).lesson_number;
                    int lastLessonNumber = _user.lessons.Select(l => l.lesson_number).Max();

                    if (currentLessonNumber < lastLessonNumber)
                    {
                        this.nextLessonButton.Visibility = Visibility.Visible;
                    }

                }

                isDone = true;
            }
            else if (_wordsAlreadyGuessedCount == _wordsToGuessCount &&
                    _isOpenedFromModuleWindow)
            {
                if (_exerciseService.GetNextExercises(_user, _exerciseNumber).Count > 0)
                {
                    MessageBox.Show(this, "Brawo! Zgadłeś wszystkie słowa. \n Możemy teraz przejść do następnego ćwiczenia.");
                    this.nextExerciseButton.IsEnabled = true;
                }
                else if (_exerciseService.GetNextExercises(_user, _exerciseNumber).Count == 0)
                {
                    MessageBox.Show(this, "Niestety, to już wszystkie ćwiczenia");
                }

                isDone = true;
            }
            return isDone;
        }

        #region Events

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseExerciseWindow chooseExerciseWindow;

            if (_isOpenedFromModuleWindow)
            {
                chooseExerciseWindow = new ChooseExerciseWindow(_user, true);
            }
            else
            {
                chooseExerciseWindow = new ChooseExerciseWindow(_user, _exerciseNumber);
            }

            chooseExerciseWindow.Show();
            this.Close();
        }


        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            bool isWordGuessed = this.syllablesTextBox.Text.ToLower().Equals(_wordToGuess.ToLower());

            if (isWordGuessed)
            {
                SetWordSoundButtonAsGuessed(_wordToGuess);

                _wordToGuess = string.Empty;
                _wordsAlreadyGuessedCount += 1;

                if (!CheckIfExerciseDone())
                {
                    MessageBox.Show(this, "Brawo! \n Czas na kolejne słowo!");
                }
            }
            else
            {
                MessageBox.Show(this, "Niestety, to nie te sylaby. \n Spróbuj raz jeszcze.");
            }

            this.syllablesTextBox.Text = _defaultSyllablesTextBoxText;
            _isTooltipTextCleared = false;
        }


        private void SyllableButton_Click(object sender, RoutedEventArgs e)
        {
            string syllableText = (sender as Button)?.Content.ToString();

            if (_isTooltipTextCleared)
            {
                this.syllablesTextBox.Text += syllableText;
            }
            else
            {
                this.syllablesTextBox.Text = syllableText;
                _isTooltipTextCleared = true;
            }
        }


        private void WordSoundButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalMethods.SoundButton_Click(sender, e);

            _wordToGuess = (sender as Button)?.Tag.ToString();
        }


        private void NextExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            ExerciseWindow nextExerciseWindow = new ExerciseWindow(_user, _exerciseNumber + 1, _isOpenedFromModuleWindow);
            nextExerciseWindow.Show();
            this.Close();
        }

        private void NextLessonButton_Click(object sender, RoutedEventArgs e)
        {
            LessonWindow lessonWindow = new LessonWindow(_user, _lessonService.GetLessonByUserAndExerciseNumber(_user, _exerciseNumber).lesson_number + 1);
            lessonWindow.Show();
            this.Close();
        }

        #endregion
    }
}
