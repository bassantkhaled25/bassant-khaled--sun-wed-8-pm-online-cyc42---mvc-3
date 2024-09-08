using DAL.contexts;
using REPOSITORY.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.repositers
{
    public class UnitOfWork : IUnitOfWork                               //single transaction يعني يا تتنفذ كلها يا اما لا

    {
        private readonly CompanyDbcontext _context;

        public UnitOfWork(CompanyDbcontext context)                       //inject dbcontext

        { 
           _context = context;
           DepartmentRepository = new DepartmentRepository(context);
           EmploeeRepository = new EmployeeRepository(context);
    
        }                                    
        public IDepartmentRepository DepartmentRepository {get; set;}                    //اي repository هتبقي هنا 
        public IEmploeeRepository EmploeeRepository {get; set; }  

        public int complete()                                                   //method(save changes)
        
        =>_context.SaveChanges();


        
    }
}
