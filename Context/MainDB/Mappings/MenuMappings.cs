using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreWebApi.Context.Helper;
using NetCoreWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Context.MainDB.Mappings
{
    public static class MenuMappings
    {
        public static void OnModelCreating(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu", SchemaHelper.DefaultTenantSchemaName);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Menu()
                {
                    Id = new Guid("9a24344b-3b92-4327-9b53-e7132668d1d0"),
                    Name = "Kategori",
                    Url = "/categories",
                });

            builder.HasData(
               new Menu()
               {
                   Id = new Guid("0f680b5c-a6b0-4956-803e-c9dcf1589279"),
                   Name = "Sepetim",
                   Url = "/cart",
               });
        }
    }
}
