using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Repositories
{
    public class ExerciseRepository
    {
        private CzytamAppEntities1 _context;


        public ExerciseRepository()
        {
            _context = new CzytamAppEntities1();
        }

        public IList<exercis> GetAllExercisesByUserLessons(IList<lesson> userLessons)
        {
            IList<int> lessonsId = userLessons.Select(lesson => lesson.id).ToList();

            return _context.exercises.Where(exercise => lessonsId.Contains(exercise.lesson_id)).ToList();
        }

        public void CreateExercise(exercis exercise)
        {
            _context.exercises.Add(exercise);
            _context.SaveChanges();
        }

        public IList<exercis> GetExercisesByUserSingleLesson(lesson lesson)
        {
            return _context.exercises.Where(ex => ex.lesson_id == lesson.id).ToList();
        }

        public bool SetExerciseAsDone(user user, int exerciseNumber)
        {
            bool wasExercisesUpdatedCorrectly = false;

            var lessonsIds = user.lessons.Select(l => l.id);
            var exerciseToUpdate = _context.exercises.Where(ex => ex.exercise_number == exerciseNumber && lessonsIds.Contains(ex.lesson_id))
                                                     .FirstOrDefault();

            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.is_done = true;
                _context.SaveChanges();

                wasExercisesUpdatedCorrectly = true;
            }

            return wasExercisesUpdatedCorrectly;
        }

        public IList<int> GetDoneExercisesNumbersByLessonId(int lessonId)
        {
            return _context.exercises.Where(ex => ex.lesson_id == lessonId && ex.is_done == true)
                .Select(ex => ex.exercise_number)
                .ToList();
        }
    }
}
