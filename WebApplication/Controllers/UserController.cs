using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var _users = _userService.GetAll();

            //return Ok(new { users = _users });
            return Json(_users);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            User user = _userService.Get(id);

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
            _userService.Add(user);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            User userToEdit = _userService.Get(id);

            if (userToEdit == null)
            {
                return NotFound();
            }

            _userService.Add(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _userService.Get(id);

            if (user != null)
            {
                _userService.Delete(user);
                return Ok();
            }

            return NotFound();
        }
    }
}