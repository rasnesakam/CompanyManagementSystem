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
    public class MissionUserMap : EntityBaseMap<MissionUser>
    {
        public new void Configure(EntityTypeBuilder<MissionUser> builder)
        {
            base.Configure(builder);
            builder.HasOne<Mission>(mu => mu.Entity1).WithMany(m => m.MissionUsers).HasForeignKey(mu => mu.Id1);
            builder.HasOne<User>(mu => mu.Entity2).WithMany(u => u.MissionUsers).HasForeignKey(mu => mu.Id2);
            builder.ToTable("Mission_User");
        }
    }
}
