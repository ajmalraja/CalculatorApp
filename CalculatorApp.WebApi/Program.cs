using CalculatorApp.Core;
using CalculatorApp.Core.Interfaces;
using CalculatorApp.Database;
using CalculatorApp.Database.Interfaces;
using CalculatorApp.Service.Interfaces;
using CalculatorApp.Service.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var constr = builder.Configuration.GetConnectionString("CalculatorApp");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICalculatorDBService, CalculatorDBService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
