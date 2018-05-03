using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);

        void DeleteUser(int id);

        User FindUser(int id);

        IEnumerable<User> GetUsers();
    }
}
