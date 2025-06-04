using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Receipt.Domain.Interfaces;
using Receipt.Infra.Data;
using Receipt.Infra.Repositories;

namespace Receipt.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInterDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite("Data Source=.\\AppData\\ReceiptAppDB.db");
            });

            services.AddScoped<IUserMasterRepositories, UserMasterRepositories>();
            services.AddScoped<ISiteMasterRepositories, SiteMasterRepositories>();
            services.AddScoped<IWingRepositories, wingRepositories>();
            services.AddScoped<ICustomerRepositories, CustomerRepositories>();
            services.AddScoped<IReceiptRepositories, ReceiptRepositories>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            return services;
        }
    }
}
