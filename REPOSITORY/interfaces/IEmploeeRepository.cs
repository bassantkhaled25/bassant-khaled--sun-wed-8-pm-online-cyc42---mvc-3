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
    Employee GetbyId(int id);                                    
    IEnumerable<Employee> GetEmployeesbyname (string name); 
  

 }
}
