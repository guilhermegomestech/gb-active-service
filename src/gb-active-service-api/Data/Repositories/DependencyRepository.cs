using gb_active_service_api.Data.Contexts;
using gb_active_service_api.Interfaces.Repositories;
using gb_active_service_api.Models;

namespace gb_active_service_api.Data.Repositories
{
    public class DependencyRepository : Repository<Dependency>, IDependencyRepository
    {
        public DependencyRepository(ActivesDbContext context) : base(context)
        {
        }
    }
}
