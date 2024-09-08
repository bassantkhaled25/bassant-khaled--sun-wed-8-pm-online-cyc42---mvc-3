using DAL.Entities;
using System;
using SERVIES.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.interfaces
{
    public interface IDepartmentService
    {

        DepartmentDto GetbyId(int? id);                            //5 operations

        void Add(DepartmentDto entity);

        void Update(DepartmentDto entity);

        IEnumerable<DepartmentDto> GetAll();

        void Delete(DepartmentDto entity);
    }
}

