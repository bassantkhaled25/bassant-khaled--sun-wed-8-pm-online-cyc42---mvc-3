using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.ViewModels
{
    public class EmployeeDto                        //view model

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public IFormFile Image { get; set; }                            //install package(IFormFile)
        public string? ImageUrl { get; set; }                             //input من بره  هتيجي                    
        public int? DepartmentId { get; set; }                               // Foreign Key                                                             
        public DepartmentDto? Department { get; set; }                    // Navigational prop (one)
        public DateTime CreatedAt { get; set; }   




    }
}
