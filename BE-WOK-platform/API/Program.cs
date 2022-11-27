using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using API.Middleware;
using Application.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using Application;
using API.HostedServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//file path for xml comments
var basePath = PlatformServices.Default.Application.ApplicationBasePath;
var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
var xmlPath = Path.Combine(basePath, fileName);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.Configure(xmlPath);
});

//DB Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
    );

//MediatR
builder.Services.AddMediatR(typeof(AssemblyMarker));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var pargs = Environment.GetCommandLineArgs();
bool applyMigrationsMode = pargs.Contains("-apply-migrations");

if (!applyMigrationsMode)
    //Hosted Services
    builder.Services.AddHostedService<DatabaseMigrationsService>();

var app = builder.Build();

//Exception Middleware
app.UseMiddleware<ExceptionMiddleware>();

if (applyMigrationsMode)
{
    app.Logger.LogInformation("Applying migrations...");

    using (var scope = app.Services.CreateScope())
    {
        await scope.ServiceProvider
            .GetRequiredService<AppDbContext>()
            .Database
            .MigrateAsync();
    }

    app.Logger.LogInformation("Applying migrations completed");

    return;
}

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
