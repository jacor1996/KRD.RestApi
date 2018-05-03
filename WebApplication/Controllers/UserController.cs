using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        /*
        private static List<User> _users = new List<User>()
        {
            new User() {Id = 1, Name = "A", Surname = "A", Adress = "A 12", Password = "123"},
            new User() {Id = 2, Name = "B", Surname = "B", Adress = "B 124", Password = "123"},
            new User() {Id = 3, Name = "C", Surname = "C", Adress = "C 123", Password = "123"}
        };
        */

        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var _users = _userRepository.GetUsers();

            return Ok(new { users = _users });
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            //User user = _users.FirstOrDefault(u => u.Id == id);
            User user = _userRepository.FindUser(id);

            if (user == null)
            {
                return BadRequest();
            }
            
            return Ok(new { _user = user });
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromBody]User user)
        {
            //user.Id = _users.Count + 1;
            //_users.Add(user);

            //user.Id = _userRepository.GetUsers().Count() + 1;
            _userRepository.AddUser(user);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            User userToEdit = _userRepository.FindUser(id);

            if (userToEdit == null)
            {
                return NotFound();
            }

            //userToEdit.Name = user.Name;
            //userToEdit.Surname = user.Surname;
            //userToEdit.Adress = user.Adress;
            //userToEdit.Password = user.Password;
            _userRepository.AddUser(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //User user = _users.FirstOrDefault(u => u.Id == id);
            User user = _userRepository.FindUser(id);
            if (user != null)
            {
                //_users.Remove(user);
                _userRepository.DeleteUser(id);
            }

            return Ok();
        }
    }
}