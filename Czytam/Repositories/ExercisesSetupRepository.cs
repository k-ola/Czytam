using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Repositories
{
    public class ExercisesSetupRepository
    {
        private CzytamAppEntities1 _context;


        public ExercisesSetupRepository()
        {
            _context = new CzytamAppEntities1();
        }

        public int GetExerciseSetupIdByExerciseNumber(int exerciseNumber)
        {
            return _context.exercises_setup.Where(ex => ex.exercise_number == exerciseNumber)
                                           .Select(ex => ex.exercise_number)
                                           .FirstOrDefault();
        }

        public IEnumerable<exercises_setup> GetAllExercisesSetup()
        {
            return _context.exercises_setup.ToList();
        }

        public IList<exercises_setup> GetExercisesSetupByLessonSetupId(int lessonSetupId)
        {
            return _context.exercises_setup.Where(es => es.lesson_id == lessonSetupId).ToList();
        }

        public string GetExerciseSetupDescriptionByExerciseNumber(int exerciseNumber)
        {
            return _context.exercises_setup.Where(ex => ex.exercise_number == exerciseNumber)
                                           .Select(ex => ex.exercise_description)
                                           .FirstOrDefault();
        }
    }
}
