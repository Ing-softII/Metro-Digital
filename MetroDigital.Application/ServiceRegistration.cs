using MetroDigital.Application.Interfaces.Services;
using MetroDigital.Application.Mappings;
using MetroDigital.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MetroDigital.Application
{
    public static class ServiceRegistration
    {
        public static void AddServicesForWebApp(this IServiceCollection services)
        {

            #region "GenericService"

            services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));

            #endregion

            #region Patients

            #endregion


            #region "Helpers"


            #endregion

            #region "AutoMapper"

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(GeneralProfile));

            #endregion
        }
    }
}
