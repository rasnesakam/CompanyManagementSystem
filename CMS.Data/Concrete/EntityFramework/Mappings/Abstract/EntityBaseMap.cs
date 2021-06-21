using CMS.Entities.Abstract;
using CMS.Shared.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Concrete.EntityFramework.Mappings.Abstract
{
    public class EntityBaseMap<BEntity> : IEntityTypeConfiguration<BEntity>
        where BEntity: EntityBase
    {

        public void Configure(EntityTypeBuilder<BEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreateDate)
                .IsRequired();

            builder.Property(e => e.ModifiedDate)
                .IsRequired();

            builder.Property(e => e.IsActive)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .IsRequired();
        }

    }
}
