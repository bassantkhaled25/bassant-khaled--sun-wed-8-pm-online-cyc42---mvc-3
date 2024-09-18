using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser        //IdentityUser => class => بورث منه

	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public bool IsActive { get; set; }




    }
}
