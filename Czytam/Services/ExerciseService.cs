using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Czytam.Repositories;

namespace Czytam.Services
{
    public class ExerciseService
        {
            private ExerciseRepository _exerciseRepository;
            private ExercisesSetupRepository _exercisesSetupRepository;
            private LessonsSetupRepository _lessonsSetupRepository;


            public ExerciseService()
            {
                _exerciseRepository = new ExerciseRepository();
                _exercisesSetupRepository = new ExercisesSetupRepository();
                _lessonsSetupRepository = new LessonsSetupRepository();
            }


            public IList<exercis> GetAllExercisesByUserLessons(IList<lesson> userLessons)
            {
                return _exerciseRepository.GetAllExercisesByUserLessons(userLessons);
            }


            public void CreateExercisesForNewLesson(lesson lesson)
            {
                int lessonSetupId = _lessonsSetupRepository.GetLessonSetupIdByLessonNumber(lesson.lesson_number);

                foreach (var exerciseSetup in _exercisesSetupRepository.GetExercisesSetupByLessonSetupId(lessonSetupId))
                {
                    var exercise = new exercis
                    {
                        exercise_number = exerciseSetup.exercise_number,
                        lesson_id = lesson.id,
                        is_done = false
                    };

                    _exerciseRepository.CreateExercise(exercise);
                }
            }

            public IList<exercises_setup> GetExercisesSetupByLessonSetupId(int lessonSetupId)
            {
                return _exercisesSetupRepository.GetExercisesSetupByLessonSetupId(lessonSetupId);
            }

            public int GetExerciseSetupIdByExerciseNumber(int exerciseNumber)
            {
                return _exercisesSetupRepository.GetExerciseSetupIdByExerciseNumber(exerciseNumber);
            }

            public string GetExerciseDescriptionByExerciseNumber(int exerciseNumber)
            {
                return _exercisesSetupRepository.GetExerciseSetupDescriptionByExerciseNumber(exerciseNumber);
            }

            public IList<exercis> GetExercisesByUserSingleLesson(lesson lesson)
            {
                return _exerciseRepository.GetExercisesByUserSingleLesson(lesson);
            }

            public bool SetExerciseAsDone(user user, int exerciseNumber)
            {
                return _exerciseRepository.SetExerciseAsDone(user, exerciseNumber);
            }

            public IList<exercis> GetNextExercises(user user, int exerciseNumber)
            {
                IList<lesson> lessons = user.lessons.ToList();
                var allExercises = _exerciseRepository.GetAllExercisesByUserLessons(lessons);

                return allExercises.Where(ex => ex.exercise_number > exerciseNumber).ToList();
            }

            public IList<exercis> GetAllExercisesFromLesson(user user, int exerciseNumber)
            {
                return user.lessons
                           .Where(l => l.id == GetLessonIdByUserAndExerciseNumber(user, exerciseNumber))
                           .SelectMany(l => l.exercises)
                           .ToList();
            }


            public IList<exercis> GetNextExercisesFromLesson(user user, int exerciseNumber)
            {
                return user.lessons
                           .Where(l => l.id == GetLessonIdByUserAndExerciseNumber(user, exerciseNumber))
                           .SelectMany(l => l.exercises)
                           .ToList()
                           .Where(ex => ex.exercise_number > exerciseNumber)
                           .ToList();
            }

            public IList<int> GetPreviousExercisesNumbersFromLesson(user user, int exerciseNumber)
            {
                int lessonId = GetLessonIdByUserAndExerciseNumber(user, exerciseNumber);

                return user.lessons.Where(l => l.id == lessonId)
                                   .SelectMany(l => l.exercises)
                                   .Where(ex => ex.exercise_number < exerciseNumber)
                                   .Select(ex => ex.exercise_number)
                                   .ToList();
            }

            private int GetLessonIdByUserAndExerciseNumber(user user, int exerciseNumber)
            {
                return user.lessons
                           .ToList()
                           .SelectMany(l => l.exercises)
                           .Where(ex => ex.exercise_number == exerciseNumber)
                           .Select(ex => ex.lesson_id)
                           .FirstOrDefault();
            }


            public IList<int> GetDoneExercisesNumbersByLesson(lesson lesson)
            {
                return _exerciseRepository.GetDoneExercisesNumbersByLessonId(lesson.id);
            }

            public int GetFirstExerciseNumberFromLesson(lesson lesson)
            {
                var listOfExercises = lesson.exercises.Select(ex => ex.exercise_number).ToList();
                listOfExercises.Sort();

                return listOfExercises.FirstOrDefault();
            }

            public IList<int> GetDoneExercisesNumbersByUserAndExerciseNumber(user user, int exerciseNumber)
            {
                var lessonId = user.lessons.SelectMany(l => l.exercises)
                    .Where(ex => ex.exercise_number == exerciseNumber)
                    .Select(ex => ex.lesson_id)
                    .FirstOrDefault();

                return _exerciseRepository.GetDoneExercisesNumbersByLessonId(lessonId);
            }
        }
    }
