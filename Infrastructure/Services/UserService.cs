using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(User user)
        {
            User userToAdd = _repository.GetById(user.Id);
            _repository.AddUser(user);

        }

        public void Delete(User user)
        {
            User userToDelete = _repository.GetById(user.Id);

            if (userToDelete != null)
            {
                _repository.DeleteUser(user.Id);
            }
        }

        public User Get(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
