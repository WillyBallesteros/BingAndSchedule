using Data;
using Services.LocationService;

namespace API.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddContextDependencies(this IServiceCollection serviceCollection)
        {
            var services = serviceCollection;
            services.AddScoped<ILocationsApiDbContext, LocationsApiDbContext>();
            return services;
        }

        public static IServiceCollection AddServicesDependencies(this IServiceCollection serviceCollection)
        {
            var services = serviceCollection;
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }
    }
}
