using gb_active_service_api.Data.Contexts;

namespace gb_active_service_api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ActivesDbContext>();
            //services.AddScoped<INotificador, Notificador>();

            //services.AddScoped<ITorneioService, TorneioService>();
            
            //services.AddScoped<ITorneioRepository, TorneioRepository>();
            
            return services;
        }
    }
}
