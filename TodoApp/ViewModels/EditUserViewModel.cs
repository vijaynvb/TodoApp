using System.ComponentModel.DataAnnotations;

namespace TodoApp.ViewModels
{
    public class EditUserViewModel
    {
        // view validations
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
       
    }
}
