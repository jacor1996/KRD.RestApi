using System;
using System.Collections.Generic;
using System.Text;
using Common.Entities;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : BasicEntity
    {
        T GetById(int id);

        IList<T> GetAll();
    }
}
