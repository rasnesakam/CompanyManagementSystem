using CMS.Data.Concrete.EntityFramework.Mappings.Abstract;
using CMS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete.EntityFramework.Mappings.Concrete
{
    public class RoleMap: IEntityTypeConfiguration<Role>
    {
        public new void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.ToTable("Roles");
            builder.Property(b => b.ConcurrencyStamp).IsConcurrencyToken();
            builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            builder.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            builder.HasData(new Role() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
        }
    }
}
