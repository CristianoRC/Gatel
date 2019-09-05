using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessDependencyInjection
    {
        public static void InjectBusiness(this IServiceCollection services)
        {
            services.AddTransient<IUserBusiness, UserBusiness>();
        }
    }
}