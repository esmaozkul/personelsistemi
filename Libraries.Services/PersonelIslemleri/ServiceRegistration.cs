using Microsoft.Extensions.DependencyInjection;
using Libraries.Services.PersonelIslemleri;

namespace Libraries.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersonelServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonelIslemleriService, PersonelIslemleriService>();

            return services;
        }
    }
}
