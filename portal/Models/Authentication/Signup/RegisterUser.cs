using System.ComponentModel.DataAnnotations;

namespace portal.Models.Authentication.Signup
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string? Email { get; set; }
    }
}
