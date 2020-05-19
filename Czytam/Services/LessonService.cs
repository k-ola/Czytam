using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Czytam.Repositories;

namespace Czytam.Services
{
    public class LessonService
    {
        private LessonRepository _lessonRepository;
        private LessonsSetupRepository _lessonsSetupRepository;
        private ExerciseService _exerciseService;


        public LessonService()
        {
            _lessonRepository = new LessonRepository();
            _lessonsSetupRepository = new LessonsSetupRepository();
            _exerciseService = new ExerciseService();
        }


        public IList<lesson> GetLessonsByUser(user user)
        {
            return _lessonRepository.GetLessonsByUser(user);
        }


        public string GetLessonDescriptionByLessonNumber(int lessonNumber)
        {
            return _lessonsSetupRepository.GetLessonDescriptionByLessonNumber(lessonNumber);
        }

        public lesson GetLessonByUserAndExerciseNumber(user user, int exerciseNumber)
        {
            var lessonId = user.lessons.SelectMany(l => l.exercises)
                .Where(ex => ex.exercise_number == exerciseNumber)
                .Select(ex => ex.lesson_id)
                .FirstOrDefault();

            return user.lessons.Where(l => l.id == lessonId)
                .FirstOrDefault();
        }



        public void CreateLessonsForNewUser(user newUser)
        {
            foreach (var lessonSetup in _lessonsSetupRepository.GetAllLessonsSetup())
            {
                var lesson = new lesson
                {
                    user_id = newUser.id,
                    lesson_number = lessonSetup.lesson_number,
                    is_done = false
                };

                lesson = _lessonRepository.CreateLesson(lesson);

                _exerciseService.CreateExercisesForNewLesson(lesson);
            }
        }

        public int GetLessonSetupIdByLessonNumber(int lessonNumber)
        {
            return _lessonsSetupRepository.GetLessonSetupIdByLessonNumber(lessonNumber);
        }

        public void SetLessonAsDone(user user, int exerciseNumber)
        {
            var lessonId = user.lessons.SelectMany(l => l.exercises)
                                       .Where(ex => ex.exercise_number == exerciseNumber)
                                       .Select(ex => ex.lesson_id)
                                       .FirstOrDefault();

            _lessonRepository.SetLessonAsDone(lessonId);
        }

        public IList<int> GetDoneLessonsNumbersByUser(user user)
        {
            return _lessonRepository.GetLessonsByUser(user)
                                .Where(l => l.is_done == true)
                               .Select(l => l.lesson_number)
                               .ToList();
        }

        public int GetFirstLessonNumber(user user)
        {
            var lessonsNumbers = user.lessons.Select(l => l.lesson_number).ToList();
            lessonsNumbers.Sort();

            return lessonsNumbers.FirstOrDefault();
        }
    }
}
