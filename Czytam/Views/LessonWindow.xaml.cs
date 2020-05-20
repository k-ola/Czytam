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
using Czytam.Repositories;
using Czytam.Globals;

namespace Czytam.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LessonWindow.xaml
    /// </summary>
    public partial class LessonWindow : Window
    {
        private user _user;
        private int _lessonNumber;
        private LessonService _lessonService;
        private ExerciseService _exerciseService;
        private SyllableService _syllableService;
        private WordService _wordService;
        private MediaPlayer _mediaPlayer;


        public LessonWindow(user user, int lessonNumber)
        {
            _user = user;
            _lessonNumber = lessonNumber;
            _lessonService = new LessonService();
            _exerciseService = new ExerciseService();
            _syllableService = new SyllableService();
            _wordService = new WordService();
            _mediaPlayer = new MediaPlayer();

            InitializeComponent();
            PrepareTabs();
        }


        private void PrepareTabs()
        {
            PrepareDescriptionTab();
            PrepareSyllablesAndWordsTabs();
        }

        
        private void PrepareSyllablesAndWordsTabs()
        {
            int lessonSetupId = _lessonService.GetLessonSetupIdByLessonNumber(_lessonNumber);
            IList<int> exercisesSetupId = _exerciseService.GetExercisesSetupByLessonSetupId(lessonSetupId).Select(es => es.id).ToList();

            List<syllable> syllables = new List<syllable>();
            List<word> words = new List<word>();
            foreach (var exerciseSetupId in exercisesSetupId)
            {
                syllables.AddRange(_syllableService.GetSyllablesByExerciseSetupId(exerciseSetupId));
                words.AddRange(_wordService.GetLessonWordsByExerciseSetupId(exerciseSetupId));
            }

            if (syllables.Count == 0)
            {
                this.syllablesTab.Visibility = Visibility.Hidden;
            }
            else
            {
                this.syllablesTabLessonNumberLabel.Content = GlobalVariables.lessonNumberPartialText + _lessonNumber;
                PrepareSyllablesLablesAndSoundsButtons(syllables);
            }

            if (words.Count == 0)
            {
                this.wordsTab.Visibility = Visibility.Hidden;
            }
            else
            {
                this.wordsTabLessonNumberLabel.Content = GlobalVariables.lessonNumberPartialText + _lessonNumber;
                PrepareWordsLablesAndSoundsButtons(words);
            }
            Title = GlobalVariables.lessonNumberPartialText + _lessonNumber;
        }

        private void PrepareSyllablesLablesAndSoundsButtons(List<syllable> syllables)
        {
            foreach (var syllable in syllables)
            {
                string syllabeText = string.Empty;
                syllabeText += syllable.syllable_text.First().ToString().ToUpper() + syllable.syllable_text.Substring(1).ToLower();
                syllabeText += "    ";
                syllabeText += syllable.syllable_text.ToLower();
                syllabeText += "    ";
                syllabeText += syllable.syllable_text.ToUpper();

                Button syllableSoundButton = new Button
                {
                    Tag = syllable.syllable_text,
                    Content = "Odtwórz"
                };

                syllableSoundButton.Tag = syllable.syllable_text;
                syllableSoundButton.Click += new RoutedEventHandler(GlobalMethods.SoundButton_Click);
                syllableSoundButton.CustomizeAsSoundButton();

                StackPanel innerStackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                innerStackPanel.Children.Add(syllableSoundButton);
                innerStackPanel.Children.Add(new Label { Content = syllabeText });

                this.mainSyllablesStackPanel.Children.Add(innerStackPanel);
            }
        }


        private void PrepareWordsLablesAndSoundsButtons(List<word> words)
        {
            foreach (var word in words)
            {
                string wordText = string.Empty;
                wordText += word.word_text.First().ToString().ToUpper() + word.word_text.Substring(1).ToLower();
                wordText += "    ";
                wordText += word.word_text.ToLower();
                wordText += "    ";
                wordText += word.word_text.ToUpper();

                Button wordSoundButton = new Button
                {
                    Tag = word.word_text,
                    Content = "Odtwórz"
                };
                wordSoundButton.Tag = word.word_text;
                wordSoundButton.Click += new RoutedEventHandler(GlobalMethods.SoundButton_Click);
                wordSoundButton.CustomizeAsSoundButton();

                StackPanel innerStackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                innerStackPanel.Children.Add(wordSoundButton);
                innerStackPanel.Children.Add(new Label { Content = wordText });

                this.mainWordsStackPanel.Children.Add(innerStackPanel);
            }
        }


        private void PrepareDescriptionTab()
        {
            this.descriptionTabLessonNumberLabel.Content = GlobalVariables.lessonNumberPartialText + _lessonNumber;
            this.lessonDescriptionTextBlock.Text = _lessonService.GetLessonDescriptionByLessonNumber(_lessonNumber);
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseModuleWindow chooseModuleWindow = new ChooseModuleWindow(_user);
            chooseModuleWindow.Show();
            this.Close();
        }


        private void GoToExercisesButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseExerciseWindow chooseExerciseWindow = new ChooseExerciseWindow(_user, _lessonService.GetLessonsByUser(_user).Where(l => l.lesson_number == _lessonNumber).FirstOrDefault());
            chooseExerciseWindow.Show();
            this.Close();
        }
    }
}
