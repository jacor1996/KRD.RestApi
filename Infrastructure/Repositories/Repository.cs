using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BasicEntity
    {
        protected readonly DataContext Context;

        public Repository(DataContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            Context = context;
        }

        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}
