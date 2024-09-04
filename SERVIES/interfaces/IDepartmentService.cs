using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.interfaces
{
    public interface IDepartmentService                      ////
    {

        Department GetbyId(int? id);                            //5 operations

        void Add(Department entity);

        void Update(Department entity);

        IEnumerable<Department> GetAll();

        void Delete(Department entity);
    }
}

