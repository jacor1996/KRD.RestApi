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
    [Route("api/Package")]
    public class PackageController : Controller
    {
        private IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var packages = _packageService.GetAll();
            //return Ok(new {_packages = packages});
            return Json(packages);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            Package package = _packageService.Get(id);

            if (package == null)
            {
                return NotFound();
            }

            return Ok(new {_package = package});
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add([FromBody] Package package)
        {
            _packageService.Add(package);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Package package)
        {
            if (package == null || package.Id != id)
            {
                return BadRequest();
            }

            Package _package = _packageService.Get(id);

            if (_package == null)
            {
                return NotFound();
            }

            _packageService.Add(package);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Package _package = _packageService.Get(id);

            if (_package != null)
            {
                _packageService.Delete(_package);
            }

            return Ok();
        }
    }
}