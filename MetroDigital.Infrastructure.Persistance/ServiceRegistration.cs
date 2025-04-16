using MetroDigital.Application.Interfaces.Repositories;
using MetroDigital.Infrastructure.Persistance.Context;
using MetroDigital.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MetroDigital.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddContextInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("ContextDb");
                });
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.EnableSensitiveDataLogging();
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        mbox => mbox.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                });
            }
        }
    }
}
