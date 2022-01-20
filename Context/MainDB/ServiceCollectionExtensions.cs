using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Context.MainDB
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureTenantDbContext(this DbContextOptionsBuilder builder, string connectionString, string migrationAssembly)
        {
            builder.UseSqlServer(
                connectionString, (options) =>
                {
                    options.MigrationsAssembly(migrationAssembly);
                    options.MigrationsHistoryTable("__TenantMigrationsHistory", "dbo");
                });

           // builder.ReplaceService<IModelCacheKeyFactory, MultiTenantModelCacheKeyFactory>();
        }
     
       
        public static void AddPersistenceInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddRelationalData<MainDbContext>((options) =>
            {
                options.ConfigureTenantDbContext(configuration["Data:MainDbContext:ConnectionString"], configuration["Data:MainDbContext:MigrationsAssembly"]);
            });
        }
    }
}
