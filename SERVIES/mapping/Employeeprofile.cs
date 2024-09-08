using AutoMapper;
using DAL.Entities;
using SERVIES.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.mapping
{
    public class Employeeprofile:Profile
    {

        public Employeeprofile()                          //reverse (2 way destination) (source - destination)
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();            //+ register
           
        }    
    }
}
