using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.interfaces
{
   public interface IEmployeeService
    {

       Employee GetbyId(int? id);                            //5 operations

        void Add(Employee entity);

        void Update(Employee entity);

        IEnumerable<Employee> GetAll();

        void Delete(Employee entity);
    }
}
