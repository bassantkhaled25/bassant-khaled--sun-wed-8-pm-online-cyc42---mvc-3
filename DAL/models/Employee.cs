using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Employee:BaseEntity

   {

        [Required]
        public string Name { get; set; }

        public int? Age { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        public decimal Salary { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime HiringDate { get; set; }
                                                                   //ForeignKey("Department")
        public int? DepartmentId { get; set; }
                                                                  // Navigational Property (one)
        public Department Department { get; set; }




    }





}
