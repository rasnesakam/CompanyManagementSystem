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
    public class ProjectUserMap : EntityBaseMap<ProjectUser>
    {
        public new void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            base.Configure(builder);
            builder.HasOne<Project>(pu => pu.Entity1).WithMany(p => p.ProjectUsers).HasForeignKey(pu => pu.Id1);
            builder.HasOne<User>(pu => pu.Entity2).WithMany(u => u.ProjectUsers).HasForeignKey(pu => pu.Id2);
            builder.ToTable("Project_User");
        }
    }
}
