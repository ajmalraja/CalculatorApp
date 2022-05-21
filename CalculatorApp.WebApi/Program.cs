using CalculatorApp.Core;
using CalculatorApp.Service.Interfaces;
using CalculatorApp.Service.Services;
using CalculatorApp.WebApi.Controllers;
using NLog;


var builder = WebApplication.CreateBuilder(args);
var constr = builder.Configuration.GetConnectionString("CalculatorApp");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICalculatorDBService, CalculatorDBService>();

//Logging service added
builder.Services.AddLogging(logging => logging.AddConsole());
builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(svc => svc.GetRequiredService<ILogger<CalculatorController>>());


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
