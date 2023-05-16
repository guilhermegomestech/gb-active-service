using gb_active_service_api.Data.Contexts;
using gb_active_service_api.Data.Repositories;
using gb_active_service_api.Interfaces.Notifications;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Notifications;

namespace gb_active_service_api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ActivesDbContext>();
            services.AddScoped<INotificator, Notificator>();

            //services.AddScoped<ITorneioService, TorneioService>();
            
            services.AddScoped<IActiveRepository, ActiveRepository>();
            services.AddScoped<IDependencyRepository, DependencyRepository>();
            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();

            return services;
        }
    }
}
