using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using API.Middleware;
using Application.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using Application;
using API.HostedServices;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;
using API.Extensions;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using API.Settings;

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
    options.AddSecurity();
});

//DB Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
    );

//Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//MediatR
builder.Services.AddMediatR(typeof(AssemblyMarker));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IDailyMenuRepository, DailyMenuRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var pargs = Environment.GetCommandLineArgs();
bool applyMigrationsMode = pargs.Contains("-apply-migrations");

if (!applyMigrationsMode)
    //Hosted Services
    builder.Services.AddHostedService<DatabaseMigrationsService>();

//Jwt Auth
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAuth(jwtSettings);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
