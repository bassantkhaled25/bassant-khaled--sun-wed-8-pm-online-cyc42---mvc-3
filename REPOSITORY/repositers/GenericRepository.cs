using DAL.contexts;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using REPOSITORY.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.repositers
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly CompanyDbcontext _Context;

        public GenericRepository(CompanyDbcontext Context)

        {
            _Context = Context;
        }
        public void Add(T entity)

        => _Context.Set<T>().Add(entity);
       

        public void Delete(T entity)

       => _Context.Set<T>().Remove(entity);

        public IEnumerable<T> GetAll()

       => _Context.Set<T>().ToList();

        public T GetbyId(int id)

      => _Context.Set<T>().Find(id);

        public void Update(T entity)

      => _Context.Set<T>().Update(entity);

    }
}
