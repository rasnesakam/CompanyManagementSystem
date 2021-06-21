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
    public class MailMap: PrimitiveEntityMap<Mail>
    {
        public new void Configure(EntityTypeBuilder<Mail> builder)
        {
            base.Configure(builder);
            builder.HasOne<Company>(m => m.Parent).WithMany(cmp => cmp.Mails).HasForeignKey(m => m.ParentId);
            builder.ToTable("Mails");
        }
    }
}
