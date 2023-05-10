using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Repository;
using TodoApp.Repository.InMemory;
using TodoApp.Repository.MsSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Validation framework, DI asp.net core

// configure asp.net the ef library to connect for a db
builder.Services.AddDbContext<TodoDbContext>();
// configure identity framework 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TodoDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
});


// DI object is configured by a constructor inject the object defined here 
builder.Services.AddScoped<TodoDbContext, TodoDbContext>();
// if test environment then work with inmemroy object
// else work with database
// asp.net automatically configures objects using DI concept
//builder.Services.AddScoped<ITodoRepository, TodoDBRepository>();

//builder.Services.AddSingleton<ITodoRepository, TodoInMemoryRepository>();
builder.Services.AddSingleton<ITodoRepository, TodoRestRepository>();

// DI 
// AddSingeton - one object is create for the full application
// AddScoped - a object is created for all request response pipeline
// AddTransient - a new object created for every request

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

// custom middleware to create and manage db migrations
app.Automigrate();

app.UseRouting();

app.UseAuthentication(); // this would enable the identity framework for having login register all other pages 

app.UseAuthorization(); // process the roles and claims 
// inbuilt object of identity framework [Principal] -> who is the user and what is his role and claims 

// it identifes the controllers folder list a set of url which it can prepare 
// /home
// /todo/GetAllTodos
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
