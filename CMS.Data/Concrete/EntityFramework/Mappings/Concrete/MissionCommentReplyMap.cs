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
    public class MissionCommentReplyMap : EntityBaseMap<MissionCommentReply>
    {
        public new void Configure(EntityTypeBuilder<MissionCommentReply> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(250);

            builder.ToTable("Mission_Comments_Replies");

        }
    }
}
