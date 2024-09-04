using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Department:BaseEntity

    {
       
       [MaxLength(50)]
       [Required(ErrorMessage = "DepartmentName is required")]                                 //configurations ممكن اعملها في فولدر لوحدها
        
      public string Name {  get; set; }

       [Required(ErrorMessage = "DepartmentCode is required")]
      public string code { get; set; }
                                                                     // Navigational prop (many)
      public ICollection <Employee> Employees { get; set; } = new HashSet <Employee>();



    }
}
