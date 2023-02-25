using System.Reflection.Metadata.Ecma335;
using IntoItIf.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using moviesDb;
using tomtest.Data.Models;
using tomtest.Data.Repositories.ConcreteRepository;
using tomtest.Data.Repositories.InterfaceRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(
builder.Configuration.GetConnectionString("Db")
));

// builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
// builder.Configuration.GetConnectionString("Db")
// ));

// var d = () => builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
//   builder.Configuration.GetConnectionString("Db")
// ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5105"));
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateAsyncScope();
var services = scope.ServiceProvider;
try
{

  var context = services.GetRequiredService<DataContext>();
  await context.Database.MigrateAsync();
  await Seed.Seed.SeedCharacters(context);
}
catch (Exception ex)
{
  var logger = services.GetService<ILogger<Program>>();
  logger.LogError(ex, "An Error occured during migration");
}
app.Run();
