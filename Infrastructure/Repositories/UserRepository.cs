using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void AddUser(User user)
        {
            User _user = GetById(user.Id);

            if (_user == null)
            {
                Context.Users.Add(user);
            }

            else
            {
                _user.Adress = user.Adress;
                _user.Name = user.Name;
                _user.Password = user.Password;
                _user.Surname = user.Surname;
            }

            Context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User userToDelete = GetById(id);
            if (userToDelete != null)
            {
                Context.Users.Remove(userToDelete);
                Context.SaveChanges();
            }

            
        }

        //public User FindUser(int id)
        //{
        //    return _context.Users.FirstOrDefault(u => u.Id == id);
        //}

        //public IEnumerable<User> GetUsers()
        //{
        //    return _context.Users;
        //}
        
    }
}
