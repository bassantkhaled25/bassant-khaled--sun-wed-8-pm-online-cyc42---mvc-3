using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVIES.Helper
{
	public class Email                                      //add id لو عاوزه => table in db = in DAL

	{
		
		public string Subject { get; set; }
		public string body { get; set; }
		public string from { get; set; }
		public string To { get; set; }


	}
}
