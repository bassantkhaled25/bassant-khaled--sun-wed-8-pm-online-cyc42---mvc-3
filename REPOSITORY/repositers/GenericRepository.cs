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

        private readonly CompanyDbcontext _Context;               //inject Dbcontext 

        public GenericRepository(CompanyDbcontext Context)

        {
            _Context = Context;
        }
        public void Add(T entity)                                //or create             //ضروري اعمل save changes عشان اللي بعمله يسمع هناك

        {
            _Context.Set<T>().Add(entity);
            //_Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);                               //hard delete //soft delete(like update)
                                                                            //_Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()

       => _Context.Set<T>().ToList();

        public T GetbyId(int? id)

      => _Context.Set<T>().Find(id);                                                         //set <T> ميعرفش عنده حاجه اسمها id  .. فمش بعمل firstordefault

        public void Update(T entity)

       => _Context.Set<T>().Update(entity);

        //_Context.SaveChanges();
    }
}

