using Microsoft.EntityFrameworkCore;
using TodoApp.Data.ModeTableMapping;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext 
    {
        // define the database and structure of the database will be managed over here

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // where is the db server?
            // connection string -> db server connection details 
            // Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False

            /*
             * 1. server = localhost, ip / instance of server - MSSQLServer process
             * 2. how to access this - windows authentication or db authentication [sa - password]
             * 3. database name - TodoDB
             */

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=TodoDB;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // fluent api customize the tables schema
            modelBuilder.UserModel();

            // seed some basic data 
            // administrator user in the user table
            modelBuilder.SeedDefaultData();
            base.OnModelCreating(modelBuilder);
        }

        // tables in db and entites in application mapping 
        public DbSet<Todo> Todos { get; set; } // plural many

        public DbSet<User> Users { get; set; }
    }
}
