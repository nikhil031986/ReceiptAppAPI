using Receipt.Application;
using Receipt.Infra;

namespace Receipt.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {

            services.AddApplicationDI()
                     .AddInterDI();
            return services;
        }
    }
}
