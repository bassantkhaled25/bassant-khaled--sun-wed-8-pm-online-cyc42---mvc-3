using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class SignUpViewModel

    {
        [Required(ErrorMessage ="first Name is Required")]
        public string FirstName {  get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="invalid format for Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="password is Required")]

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is Required")]
        [Compare(nameof(Password),ErrorMessage ="confirm password doesnot match password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
        public bool IsAgree { get; set; }




    }
}
