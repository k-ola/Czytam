using Czytam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Services
{
    public class WordService
    {
        private WordRepository _wordRepository;


        public WordService()
        {
            _wordRepository = new WordRepository();
        }

        private IList<word> GetWordsByExerciseSetupId(int exerciseSetupId)
        {
            return _wordRepository.GetWordsByExerciseSetupId(exerciseSetupId);
        }

        public IList<word> GetLessonWordsByExerciseSetupId(int exerciseSetupId)
        {
            var allWordsForExerciseSetupId = GetWordsByExerciseSetupId(exerciseSetupId);

            return allWordsForExerciseSetupId.Where(w => w.is_lesson_only == true).ToList();
        }

        public IList<word> GetExerciseWordsByExerciseSetupId(int exerciseSetupId)
        {
            var allWordsForExerciseSetupId = GetWordsByExerciseSetupId(exerciseSetupId);
            return allWordsForExerciseSetupId.Where(w => w.is_lesson_only == false || w.is_lesson_only == null).ToList();
        }
    }
}
