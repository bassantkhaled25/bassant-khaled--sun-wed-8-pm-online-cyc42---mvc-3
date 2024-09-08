using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.ViewModels
{
    public class DepartmentDto

    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int code { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<EmployeeDto>? Departments { get;set; }    //navigational prop (many)
      

    }
}
