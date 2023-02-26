using AutoMapper;
using Microsoft.EntityFrameworkCore;
using moviesDb;
using tomtest.Data.Repositories.ConcreteRepository;
using tomtest.Data.Repositories.InterfaceRepository;

namespace tomtest.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {



      services.AddDbContext<DataContext>(option =>
      {
        option.UseSqlServer(config.GetConnectionString("Db"));

      });
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


      services.AddCors();
      services.AddScoped<ICharacterRepository, CharacterRepository>();
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddAutoMapper(typeof(AppDomain));

      return services;
    }
  }
}