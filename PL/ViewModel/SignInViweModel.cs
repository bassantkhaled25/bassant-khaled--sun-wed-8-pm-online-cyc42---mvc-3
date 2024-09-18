using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
	public class SignInViweModel
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool RemeberMe { get; set; }                     //not required


	}
}
