using CMS.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete.EntityFramework.Mappings.Abstract
{
    public class PrimitiveEntityMap <PEntity> : EntityBaseMap<PEntity>
        where PEntity: PrimitiveEntity
    {
        public new void Configure(EntityTypeBuilder<PEntity> builder)
        {
            base.Configure(builder);

            builder.Property(pe => pe.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(pe => pe.Description)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
