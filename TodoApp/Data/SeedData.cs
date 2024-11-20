using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public static class SeedData
    {
        

        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {
            // seed roles in ASP.NET Core Identity, with Administrator and User roles
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new List<ApplicationUser>()
                {
                     // imporant: don't forget NormalizedUserName, NormalizedEmail 
                        new ApplicationUser {
                        UserName = "admin@g.com",
                        FirstName = "Admin",
                        LastName = "A",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@g.com"
                    },

                    new ApplicationUser {
                        UserName = "user@g.com",
                        FirstName = "User",
                        LastName = "U",
                        NormalizedUserName = "USER",
                        Email = "user@g.com"
                    },
                };


            modelBuilder.Entity<ApplicationUser>().HasData(users);


            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            // Add Password For All Users

            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "admin");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "user");

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId =
            roles.First(q => q.Name == "User").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId =
            roles.First(q => q.Name == "Admin").Id
            });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            modelBuilder.Entity<Todo>().HasData(
                new Todo(1, "Shopping", "For Birthday", false, DateTime.Now.AddDays(1)),
                new Todo(2, "Learn C#", "In Jump Training", false, DateTime.Now.AddDays(2)),
                new Todo(3, "Learn MSSQL", "In Jump Training", false, DateTime.Now.AddDays(2))
            );
        }
    }
}
