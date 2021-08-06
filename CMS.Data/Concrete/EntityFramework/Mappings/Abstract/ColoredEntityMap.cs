using CMS.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete.EntityFramework.Mappings.Abstract
{
    public class ColoredEntityMap<TEntity>: PrimitiveEntityMap<TEntity>
        where TEntity : ColoredEntity
    {
        public new void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(te => te.ColorHex)
                .HasMaxLength(8)
                .IsRequired();

        }
    }
}
