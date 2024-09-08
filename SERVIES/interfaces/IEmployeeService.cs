using DAL.Entities;
using SERVIES.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.interfaces
{
   public interface IEmployeeService
    {

       EmployeeDto GetbyId(int? id);                            //5 operations

        void Add(EmployeeDto entity);
                                                        
        void Update(EmployeeDto entity);

        IEnumerable<EmployeeDto> GetAll();

        void Delete(EmployeeDto entity);

        IEnumerable<EmployeeDto> GetEmployeesbyName(string name);            //زودت ديه للسيرش + implementation in class employeeservice
    }
}
