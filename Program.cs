using Concord.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

DotNetEnv.Env.Load();
var connectionString = "mysql://root:rOt0H7sctkHS3ZmWj6tR@containers-us-west-174.railway.app:7957/railway";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<DatabaseContext>(
    opt => {
        opt
        .UseMySql(connectionString, serverVersion);
        if (builder.Environment.IsDevelopment())
      {
        opt
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging()
          .EnableDetailedErrors();
      }
    }
);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Run();
