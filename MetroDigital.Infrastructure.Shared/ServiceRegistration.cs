using Microsoft.Extensions.DependencyInjection;
using MetroDigital.Infrastructure.Shared.Interfaces;
using MetroDigital.Infrastructure.Shared.Services;

namespace MetroDigital.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedService(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
