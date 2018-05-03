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
    [Route("api/Package")]
    public class PackageController : Controller
    {
        private IPackageRepository _packageRepository;

        public PackageController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            var packages = _packageRepository.GetPackages();
            return Ok(new {_packages = packages});
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            Package package = _packageRepository.FindPackage(id);

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
            _packageRepository.AddPackage(package);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Package package)
        {
            if (package == null || package.Id != id)
            {
                return BadRequest();
            }

            Package _package = _packageRepository.FindPackage(id);

            if (_package == null)
            {
                return NotFound();
            }

            _packageRepository.AddPackage(package);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Package _package = _packageRepository.FindPackage(id);

            if (_package != null)
            {
                _packageRepository.DeletePackage(id);
            }

            return Ok();
        }
    }
}