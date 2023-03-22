using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTO
{
    public class TodoDTO
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
        public DateTime? DueDate { get; set; }

        public TodoDTO()
        {
        }
        public TodoDTO( string title, string description, bool status, DateTime dueDate)
        {
            Title = title;
            Title = title;
            Description = description;
            Status = status;
            DueDate = dueDate;
        }
    }
}
