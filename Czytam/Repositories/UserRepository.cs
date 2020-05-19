using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Czytam.Repositories
{
    public class UserRepository
    {
        private CzytamAppEntities1 _context;


        public UserRepository()
        {
            _context = new CzytamAppEntities1();
        }

        public user CreateNewUser(user newUser)
        {
            _context.users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }


        public user GetUserByFirstName(string userFirstName)
        {
            return _context.users.Where(user => user.first_name.Equals(userFirstName)).FirstOrDefault();
        }
    }
}
