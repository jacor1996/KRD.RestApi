using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private DataContext _context;

        public PackageRepository(DataContext context)
        {
            _context = context;
        }

        public void AddPackage(Package package)
        {
            Package _package = FindPackage(package.Id);

            if (_package == null)
            {
                _context.Packages.Add(package);
            }

            else
            {
                _package.State = package.State;
                _package.Time = package.Time;
            }

            _context.SaveChanges();
        }

        public Package FindPackage(int id)
        {
            return _context.Packages.FirstOrDefault(p => p.Id == id);
        }

        public void DeletePackage(int id)
        {
            Package package = FindPackage(id);

            if (package != null)
            {
                _context.Packages.Remove(package);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Package> GetPackages()
        {
            return _context.Packages;
        }
    }
}
