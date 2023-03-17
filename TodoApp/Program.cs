using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Repository;
using TodoApp.Repository.InMemory;
using TodoApp.Repository.MsSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Validation framework, DI asp.net core

// configure asp.net the ef library to connect for a db
builder.Services.AddDbContext<TodoDbContext>();

// DI object is configured by a constructor inject the object defined here 
builder.Services.AddScoped<TodoDbContext, TodoDbContext>();
// if test environment then work with inmemroy object
// else work with database
// asp.net automatically configures objects using DI concept
builder.Services.AddScoped<ITodoRepository, TodoDBRepository>();

//builder.Services.AddSingleton<ITodoRepository, TodoInMemoryRepository>();

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

app.UseAuthorization();

// it identifes the controllers folder list a set of url which it can prepare 
// /home
// /todo/GetAllTodos
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=GetAllTodos}/{id?}");

app.Run();
