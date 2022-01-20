using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Context.MainDB.Mappings;
using NetCoreWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Context.MainDB
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {

        }

        public string SchemaName { get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(this.SchemaName);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);

            SchemaBuilder(builder);
        }

        private static void SchemaBuilder(ModelBuilder builder)
        {
            builder.Entity<Menu>(MenuMappings.OnModelCreating);
        }
    }
}
