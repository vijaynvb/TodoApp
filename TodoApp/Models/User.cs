using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
   // [Table("People")]
    public class User
    {
        // entity framework customize the table or column fields
        public int Id { get; set; }
        //[Column(name:"First_Name", TypeName ="ntext")]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
       // [NotMapped]
        public int Age { get; set; }

        // not null features
        public string? Email { get; set; }

        public List<Todo> Todos { get; set; }

        public User()
        {
        }

        public User(int id, string name, DateTime dOB)
        {
            Id = id;
            Name = name;
            DOB = dOB;
        }
    }
}
