using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data.ModeTableMapping
{
    public static class UserModeMapping
    {
        // extension methods -> syntax
        public static void UserModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .ToTable("People")
               .Property("Name")
               .HasColumnName("First_Name")
               .HasColumnType("ntext");
            modelBuilder.Entity<User>().Ignore(u => u.Age);

        }

    }
}
