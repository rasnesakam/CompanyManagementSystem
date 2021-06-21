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
    public class MissionTagMap : EntityBaseMap<MissionTag>
    {
        public new void Configure(EntityTypeBuilder<MissionTag> builder)
        {
            base.Configure(builder);
            builder.HasOne<Mission>(mt => mt.Entity1).WithMany(m => m.MissionTags).HasForeignKey(mt => mt.Id1);
            builder.HasOne<Tag>(mt => mt.Entity2).WithMany(t => t.MissionTags).HasForeignKey(mt => mt.Id2);
            builder.ToTable("Mission_Tag");
        }
    }
}
