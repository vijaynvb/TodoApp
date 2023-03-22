using Microsoft.AspNetCore.Identity;
using TodoAPI.Configurations;
using TodoAPI.Data;
using TodoAPI.Models;
using TodoAPI.Repository;
using TodoAPI.Repository.MsSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // web api's
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddDbContext<TodoDbContext>();
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

builder.Services.AddScoped<ITodoRepository, TodoDBRepository>();
builder.Services.AddScoped<IAccountRepository, AccountDBRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // endpoints
    app.UseSwaggerUI(); // swagger editor to show the action urls for each operation
}

// maps you contrllers actions as urls
app.MapControllers();

app.Run();
