using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class DependencyInjectionPersist
    {
        public static void ConfigureApplicationPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(option =>
              option.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            //todo : me : .UseSnakeCaseNamingConvention()? 
        }
    }

}

