using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data.ModeTableMapping;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public ILogger _logger { get; }

        public TodoDbContext(IConfiguration appConfig, ILogger<TodoDbContext> logger)
        {
            _appConfig = appConfig;
            _logger = logger;
        }
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

            var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");
            var userName = _appConfig.GetConnectionString("UserName");
            var password = _appConfig.GetConnectionString("Password");
            string connectionString = $"Server={server};Database={db};User Id={userName};Password={password};MultipleActiveResultSets=true";

            // log over here 
            _logger.LogInformation("Db Connection string: " + connectionString);

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

        //public DbSet<User> Users { get; set; }
    }
}
