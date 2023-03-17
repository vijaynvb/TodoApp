using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoApp.Customization;

namespace TodoApp.Models
{
    public class Todo // resource, Entity
    {
        [DisplayName("Todo Id")] // annotaction to customize the view filed names
        public int Id { get; set; }
        [Required(ErrorMessage ="Todo Titile is required")]
        [MinLength(2)] // where title should be minimum of 2 characters
        public string Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public bool Status { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DueDate { get; set; } // 

     /*   [CustomAgeValidation(18)]
        public int Age { get; set; } // age should be greater than 18
*/
        public Todo()
        {
        }
        public Todo(int id, string title, string description, bool status, DateTime dueDate)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            DueDate = dueDate;
        }
    }
}
