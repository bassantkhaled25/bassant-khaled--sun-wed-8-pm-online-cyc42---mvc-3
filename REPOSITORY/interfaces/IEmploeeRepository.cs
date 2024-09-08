using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.interfaces
{
public interface IEmploeeRepository:IGenericRepository<Employee>

{
    Employee GetbyId(int? id);                                                             //كل واحد بزود في ال interface بتاعه         
    IEnumerable<Employee> GetEmployeesbyName (string name);                              //عامل methods هاخدها => implement in class
  

 }
}
