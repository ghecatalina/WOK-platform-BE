using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using API.Middleware;
using Application.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var app = builder.Build();

//Exception Middleware
//app.UseMiddleware<ExceptionMiddleware>();

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
