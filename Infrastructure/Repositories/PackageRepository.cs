using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {

        public PackageRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void AddPackage(Package package)
        {
            Package _package = GetById(package.Id);

            if (_package == null)
            {
                Context.Packages.Add(package);
            }

            else
            {
                _package.State = package.State;
                _package.Time = package.Time;
            }

            Context.SaveChanges();
        }

        public void DeletePackage(int id)
        {
            Package package = GetById(id);

            if (package != null)
            {
                Context.Packages.Remove(package);
                Context.SaveChanges();
            }
        }
    }
}
