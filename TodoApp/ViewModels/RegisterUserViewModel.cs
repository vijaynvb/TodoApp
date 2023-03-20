using System.ComponentModel.DataAnnotations;

namespace TodoApp.ViewModels
{
    public class RegisterUserViewModel
    {
        // view validations
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and confirm password doesnt match")]
        public string  ConfirmPassword { get; set; }
    }
}
