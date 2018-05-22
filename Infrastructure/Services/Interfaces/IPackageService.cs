using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Infrastructure.Services.Interfaces
{
    public interface IPackageService
    {
        IEnumerable<Package> GetAll();

        Package Get(int id);

        void Add(Package package);

        void Delete(Package package);
    }
}
