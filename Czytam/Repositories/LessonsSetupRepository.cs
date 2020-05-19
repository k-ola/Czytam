using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Repositories
{
    public class LessonsSetupRepository
    {
        private CzytamAppEntities1 _context;


        public LessonsSetupRepository()
        {
            _context = new CzytamAppEntities1();
        }


        public IList<lessons_setup> GetAllLessonsSetup()
        {
            return _context.lessons_setup.ToList();
        }


        public string GetLessonDescriptionByLessonNumber(int lessonNumber)
        {
            return _context.lessons_setup.Where(l => l.lesson_number == lessonNumber)
                                         .Select(l => l.lesson_description)
                                         .FirstOrDefault();
        }

        public int GetLessonSetupIdByLessonNumber(int lessonNumber)
        {
            return _context.lessons_setup.Where(l => l.lesson_number == lessonNumber)
                                         .Select(l => l.id)
                                         .FirstOrDefault();
        }
    }
}
