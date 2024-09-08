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
    public class EmployeeRepository : GenericRepository<Employee>, IEmploeeRepository

    {
        private readonly CompanyDbcontext _context;                               //inject Dbcontext

        public EmployeeRepository(CompanyDbcontext Context) : base(Context)       //chaining on base

        {
            _context = Context;
        }

        //search                                                          //احطها في ال service => لاني هنادي عليها من هناك
        public IEnumerable<Employee> GetEmployeesbyName(string name)                 //IEnumrable >>  عشان وارد اعمل سيرش بكلمه وترجع => list   ..  /* no pagination + لو بشتغل ع داتا صغيره مش كبيره IEnumarable */      //use inteface (IEmployeeRep)  //get employee by ....

            => _context.Employees.Where(x=>
             
             x.Name.Trim().ToLower().Contains(name.Trim().ToLower())||                //trim to remove spaces
             x.Email.Trim().ToLower().Contains(name.Trim().ToLower())||               
             x.PhoneNumber.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();                 
        
    }               //خليت ال functionality تشتغل (name - email - phoneNum)

}

       
    

