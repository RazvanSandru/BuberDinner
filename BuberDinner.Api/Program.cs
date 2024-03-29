using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddApi();

var app = builder.Build();
app.MapControllers();
app.UseExceptionHandler("/error");

app.Run();
