using Microsoft.OpenApi.Models;
using Services;
using Microsoft.EntityFrameworkCore;
using Data;
using Models.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton(Singleton.Instance);
builder.Services.AddDbContext<HoteldbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

GlobalVariables.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "HotelManagementAPI", Description = "" });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1"); c.RoutePrefix = string.Empty; });

app.UseAuthorization();

app.MapControllers();

app.Run();
