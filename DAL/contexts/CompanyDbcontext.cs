using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.contexts
{
    public class CompanyDbcontext : IdentityDbContext<ApplicationUser>

    {

  

        public CompanyDbcontext(DbContextOptions <CompanyDbcontext> options) : base (options)     //constructor
        {

        }

        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //{                                                                                  //connection string
        //    optionsBuilder.UseSqlServer("Server = .; Database = companyMVC; Trusted_Connection = true");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)

        //{
        //    modelBuilder.Entity<BaseEntity>().HasQueryFilter (x => !x.IsDeleated);   //global filtering (soft delete)
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

       
    }
}
