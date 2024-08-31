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
    public class DepartmentRepository:GenericRepository<Department> ,IDepartmentRepository
    {

        private readonly CompanyDbcontext _context;

        public DepartmentRepository(CompanyDbcontext Context) : base(Context)         //chaining on base

        {
            _context = Context;
        }

    }
}
