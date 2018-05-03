using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IPackageRepository
    {
        void AddPackage(Package package);

        Package FindPackage(int id);

        void DeletePackage(int id);

        IEnumerable<Package> GetPackages();
    }
}
