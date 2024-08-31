﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class BaseEntity

   { 
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleated { get; set; }   //default = false;
   }
}
