using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Repositories
{
    public class SyllableRepository
    {
        private CzytamAppEntities1 _context;


        public SyllableRepository()
        {
            _context = new CzytamAppEntities1();
        }


        public IList<syllable> GetSyllablesByExerciseSetupId(int exerciseId)
        {
            return _context.syllables.Where(syllable => syllable.exercises_setup_id == exerciseId).ToList();
        }
    }
}
