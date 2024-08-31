using DAL.contexts;
using DAL.Entities;
using REPOSITORY.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.repositers
{
    public class EmployeeRepository:GenericRepository<Employee> ,IEmploeeRepository

    {
        private readonly CompanyDbcontext _context;

        public EmployeeRepository(CompanyDbcontext Context) : base(Context)         //chaining on base

        {
            _context=Context;
        }

        public void Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee employee)
        { 
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesbyname(string name)         //use inteface (IEmployeeRep)  //get employee by ....
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)

        {
            throw new NotImplementedException();
        }
    }
}
