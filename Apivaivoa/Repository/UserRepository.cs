using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardVaiVoa.Models;

namespace CardVaiVoa.Repository
{
    public class UserRepository
    {
        private Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
        public User GetUserForEmail(string email)
        {
            var user = _context.Users
                    .Where(u => u.Email == email)
                    .FirstOrDefault();
            return user;

        }
        public User CreateUserForEmail(string email)
        {
            var user = new User()
            {
                Email = email
            };
            _context.Users.Add(user);
             _context.SaveChanges();
            return user;

        }
    }
}
