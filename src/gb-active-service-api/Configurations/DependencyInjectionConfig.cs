using gb_active_service_api.Data.Contexts;
using gb_active_service_api.Data.Repositories;
using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Interfaces.Services;
using gb_active_service_api.Notifications;
using gb_active_service_api.Services;

namespace gb_active_service_api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ActivesDbContext>();
            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<IActiveService, ActiveService>();
            services.AddScoped<IDependencyService, DependencyService>();
            services.AddScoped<IResponsibleService, ResponsibleService>();

            services.AddScoped<IActiveRepository, ActiveRepository>();
            services.AddScoped<IDependencyRepository, DependencyRepository>();
            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();

            return services;
        }
    }
}
