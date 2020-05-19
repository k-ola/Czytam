using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Repositories
{
    public class WordRepository
    {
        private CzytamAppEntities1 _context;


        public WordRepository()
        {
            _context = new CzytamAppEntities1();
        }

        public IList<word> GetWordsByExerciseSetupId(int exerciseSetupId)
        {
            return _context.words.Where(w => w.exercises_setup_id == exerciseSetupId).ToList();
        }

    }
}
