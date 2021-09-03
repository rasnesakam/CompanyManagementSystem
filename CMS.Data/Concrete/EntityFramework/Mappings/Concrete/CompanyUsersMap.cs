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
    class CompanyUsersMap : EntityBaseMap<CompanyUsers>
    {
        public new void Configure(EntityTypeBuilder<CompanyUsers> builder)
        {
            base.Configure(builder);
            builder.HasOne<Company>(pt => pt.Entity1).WithMany(p => p.CompanyUsers).HasForeignKey(pt => pt.Id1);
            builder.HasOne<User>(pt => pt.Entity2).WithMany(t => t.CompanyUsers).HasForeignKey(pt => pt.Id2);
            builder.ToTable("CompanyUsers");
        }
    }
}
