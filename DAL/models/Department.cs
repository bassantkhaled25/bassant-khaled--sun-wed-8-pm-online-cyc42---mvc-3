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
        [Required]
        [MaxLength(50)]
      public string Name {  get; set; }
      public string code { get; set; }
                                                                     // Navigational prop (many)
      public ICollection <Employee> Employees { get; set; } = new HashSet <Employee>();



    }
}
