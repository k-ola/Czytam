using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public User(string firstName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
        }
        public static Tuple<bool, string> ValidateUserData(string firstName, DateTime? dateOfBirth)
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
                errorMessage += "Skoro masz 18 lat to zapewne umiesz już czytać 😉";
            }
            return new Tuple<bool, string>(isValid, errorMessage);
        }
        private static bool IsUserAdult(DateTime dateOfBirth)
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
    }
}
