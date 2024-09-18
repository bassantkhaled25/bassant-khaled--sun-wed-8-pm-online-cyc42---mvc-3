using System.ComponentModel.DataAnnotations;

namespace PL.ViewModel
{
	public class ForgetPasswordViewModel

	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }


	}
}
