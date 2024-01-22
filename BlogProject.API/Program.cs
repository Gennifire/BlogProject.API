//We first add services to the container
//Dotnet supports the dependency injection software design pattern,
//which is a technique for achieving inversion of control between
//classes and their dependencies.

using BlogProject.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext< ApplicationDbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogProjectConnectionString"));
});

var app = builder.Build();




// Configure the HTTP request pipeline.
// Pipeline to handle requests and responses.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
