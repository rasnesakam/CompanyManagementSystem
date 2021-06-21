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
    public class MissionCommentReplyDocsMap : PrimitiveEntityMap<MissionCommentReplyDocs>
    {
        public new void Configure(EntityTypeBuilder<MissionCommentReplyDocs> builder)
        {
            base.Configure(builder);

            builder.Property(mc => mc.Path)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(mc => mc.Type)
                .IsRequired()
                .HasMaxLength(5);

            builder.HasOne<MissionCommentReply>(mc => mc.Parent).WithMany(m => m.Docs).HasForeignKey(mc => mc.ParentId);
            builder.ToTable("Mission_Comment_Reply_Docs");
        }
    }
}
