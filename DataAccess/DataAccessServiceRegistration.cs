using DataAccess.Abstracts;
using DataAccess.Concrates.EntityFramework;
using DataAccess.Concretes.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            //database
            services.AddDbContext<BaseDbContext>();

            return services;
        }
    }
}
