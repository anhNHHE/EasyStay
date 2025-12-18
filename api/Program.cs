using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Interface.Repositories;
using api.Repository;
using api.Interface.Services;
using api.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<EasyStayContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EasyStayDB"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyStay API v1");
        c.RoutePrefix = ""; // ⭐ ROOT = Swagger
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
