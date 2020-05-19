using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Czytam.Repositories;

namespace Czytam.Services
{
    public class SyllableService
    {
        private SyllableRepository _syllableRepository;
        private ExercisesSetupRepository _exercisesSetupRepository;


        public SyllableService()
        {
            _syllableRepository = new SyllableRepository();
            _exercisesSetupRepository = new ExercisesSetupRepository();
        }


        
        public IList<syllable> GetSyllablesByExerciseNumber(int exerciseNumber)
        {
            int exerciseSetupId = _exercisesSetupRepository.GetExerciseSetupIdByExerciseNumber(exerciseNumber);
            return _syllableRepository.GetSyllablesByExerciseSetupId(exerciseSetupId);
        }

        public IList<syllable> GetSyllablesByExerciseSetupId(int exerciseSetupId)
        {
            return _syllableRepository.GetSyllablesByExerciseSetupId(exerciseSetupId);
        }
    }
}
