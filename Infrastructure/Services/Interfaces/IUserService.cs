using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);

        User Get(int id);

        void Delete(User user);

        IEnumerable<User> GetAll();
    }
}
