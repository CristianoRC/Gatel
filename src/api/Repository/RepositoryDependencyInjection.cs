using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public static class RepositoryDependencyInjection
    {
        public static void InjectRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IAccessRepository, AccessRepository>();
        }
    }
}