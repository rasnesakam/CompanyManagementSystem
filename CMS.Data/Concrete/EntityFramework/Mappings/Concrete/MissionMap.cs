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
    public class MissionMap:TimedEntityMap<Mission>
    {
        public new void Configure(EntityTypeBuilder<Mission> builder)
        {
            base.Configure(builder);

            builder.HasOne<Project>(m => m.Project).WithMany(p => p.Missions).HasForeignKey(m => m.ProjectId);

            builder.ToTable("Missions");
        }
    }
}
