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
    public class DepartmentRepository:GenericRepository<Department> ,IDepartmentRepository

    {

        private readonly CompanyDbcontext _context;                                  //inject Dbcontext

        public DepartmentRepository(CompanyDbcontext Context) : base(Context)         //chaining on base

        {
            _context = Context;
        }
       // public void Add(Department department)
       // {
       //     _context.Set<Department>().Add(department);
       //     _context.SaveChanges();
       // }


       // public void Delete(Department department)
       // {
       //     throw new NotImplementedException();
       // }

       // public IEnumerable<Department> GetAll()

       //=> _context.Set<Department>().ToList();


       // public Department GetbyId(int? id)

       // => _context.Set<Department>().FirstOrDefault(x => x.Id == id);

       // public void Update(Employee employee)

       // {
       //     throw new NotImplementedException();
       // }
    }
}

