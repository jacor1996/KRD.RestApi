using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services
{
    public class PackageService : IPackageService
    {
        private IPackageRepository _repository;

        public PackageService(IPackageRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Package> GetAll()
        {
            return _repository.GetAll();
        }

        public Package Get(int id)
        {
            return _repository.GetById(id);
        }

        public void Add(Package package)
        {
            Package packageToAdd = _repository.GetById(package.Id);

            if (packageToAdd == null)
            {
                _repository.AddPackage(package);
            }
        }

        public void Delete(Package package)
        {
            Package packageToDelete = _repository.GetById(package.Id);

            if (packageToDelete != null)
            {
                _repository.DeletePackage(package.Id);
            }
        }
    }
}
