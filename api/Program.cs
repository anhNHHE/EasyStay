using Microsoft.EntityFrameworkCore;
using api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<EasyStayContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EasyStayDB"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
