﻿using DataAccess.Abstracts;
using DataAccess.Concrates.EntityFramework;
using DataAccess.Concretes.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            //bağımlılıklar
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IOperationClaimRepository, EfOperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, EfUserOperationClaimRepository>();

            //database context
            services.AddDbContext<BaseDbContext>();
            
            return services;
        }
    }
}
