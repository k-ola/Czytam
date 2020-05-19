using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Czytam.Repositories;

namespace Czytam.Services
{
    public class UserService
    {
        private LessonService _lessonService;
        private UserRepository _userRepository;
        private LessonsSetupRepository _lessonsSetupRepository;


        public UserService()
        {
            _lessonService = new LessonService();
            _userRepository = new UserRepository();
            _lessonsSetupRepository = new LessonsSetupRepository();
        }


        public Tuple<bool, string> ValidateUserData(string firstName, DateTime? dateOfBirth)
        {
            bool isValid = true;
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(firstName))
            {
                isValid &= false;
                errorMessage += "Podano nieprawidłowe (puste) imię.";
            }

            if (dateOfBirth.HasValue && dateOfBirth.Value.Date > DateTime.Today)
            {
                isValid &= false;
                errorMessage += "Podano nieprawidłową (przyszłą) datę.";
            }

            if (dateOfBirth.HasValue && IsUserAdult(dateOfBirth.Value))
            {
                isValid &= false;
                errorMessage += "Skoro masz 18 lat to zapewne umiesz już czytać";
            }

            if (!dateOfBirth.HasValue)
            {
                isValid &= false;
                errorMessage += "Podano nieprawidłową (pustą) datę.";
            }

            if (UserAlreadyExists(firstName))
            {
                isValid &= false;
                errorMessage += "Użytkownik o takim imieniu już istnieje.";
            }

            return new Tuple<bool, string>(isValid, errorMessage);
        }


        private bool UserAlreadyExists(string firstName)
        {
            user userFroDatabase = null;
            // TODO usunac context z servisu
            using (var context = new CzytamAppEntities1())
            {
                userFroDatabase = context.users.Where(user => user.first_name.Equals(firstName)).FirstOrDefault();
            }

            return userFroDatabase != null;
        }

        public user GetUserByFirstName(string userFirstName)
        {
            return _userRepository.GetUserByFirstName(userFirstName);
        }

        private bool IsUserAdult(DateTime dateOfBirth)
        {
            bool isAdult = false;

            if (dateOfBirth.Year + 18 < DateTime.Today.Year ||
               (dateOfBirth.Year + 18 == DateTime.Today.Year && dateOfBirth.Month < DateTime.Today.Month) ||
               (dateOfBirth.Year + 18 == DateTime.Today.Year && dateOfBirth.Month == DateTime.Today.Month && dateOfBirth.Day <= DateTime.Today.Day))
            {
                isAdult = true;
            }

            return isAdult;
        }


        public IList<user> ReadAllUsers()
        {
            IList<user> users;
            // TODO usunac context z servisu
            using (var context = new CzytamAppEntities1())
            {
                users = context.users.ToList();
            }

            return users;
        }


        public void CreateNewUser(string firstName, DateTime dateOfBirth)
        {
            var newUser = new user()
            {
                first_name = firstName,
                date_of_birth = dateOfBirth,
            };

            newUser = _userRepository.CreateNewUser(newUser);

            _lessonService.CreateLessonsForNewUser(newUser);
        }
    }
}
