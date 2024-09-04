using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.interfaces
{
   public interface IGenericRepository<T> where T : BaseEntity

   {

        T GetbyId(int? id);                            //5 operations

        void Add(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        void Delete(T entity);
    }

}
