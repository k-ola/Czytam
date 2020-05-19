using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Repositories
{
    public class LessonRepository
    {
        private CzytamAppEntities1 _context;


        public LessonRepository()
        {
            _context = new CzytamAppEntities1();
        }


        public lesson CreateLesson(lesson lesson)
        {
            _context.lessons.Add(lesson);
            _context.SaveChanges();

            return lesson;
        }


        public IList<lesson> GetLessonsByUser(user user)
        {
            return _context.lessons.Where(l => l.user_id == user.id).ToList();
        }

        public void SetLessonAsDone(int lessonId)
        {
            var lesson = _context.lessons
                                 .Where(l => l.id == lessonId)
                                 .FirstOrDefault();

            if (lesson != null)
            {
                lesson.is_done = true;
                _context.SaveChanges();
            }
        }
    }
}
