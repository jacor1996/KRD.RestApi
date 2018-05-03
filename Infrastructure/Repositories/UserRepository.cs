using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            User _user = FindUser(user.Id);

            if (_user == null)
            {
                _context.Users.Add(user);
            }

            else
            {
                _user.Adress = user.Adress;
                _user.Name = user.Name;
                _user.Password = user.Password;
                _user.Surname = user.Surname;
            }

            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User userToDelete = FindUser(id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
            }

            _context.SaveChanges();
        }

        public User FindUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}
