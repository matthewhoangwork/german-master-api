using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ProtocolAPI;
using System.Collections.Immutable;
using ProtocolAPI.Repositories;
using ProtocolAPI.Services;
using static Microsoft.AspNetCore.Builder.WebApplication;

var builder = CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
