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
    public class CentralMap:PrimitiveEntityMap<Central>
    {
        public new void Configure(EntityTypeBuilder<Central> builder)
        {
            base.Configure(builder);
            builder.HasOne<Company>(c => c.Parent).WithMany(cmp => cmp.Centrals).HasForeignKey(c => c.ParentId);

            builder.ToTable("Centrals");
        }
    }
}
