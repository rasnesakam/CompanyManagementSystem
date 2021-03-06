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
    public class MissionCommentMap: EntityBaseMap<MissionComment>
    {
        public new void Configure(EntityTypeBuilder<MissionComment> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasOne<User>(c => c.User).WithMany(u => u.MissionComments).HasForeignKey(c => c.UserId);
            builder.HasOne<Mission>(c => c.Parent).WithMany(m => m.MissionComments).HasForeignKey(c => c.ParentId);

            builder.ToTable("Mission_Comments");

        }
    }
}
