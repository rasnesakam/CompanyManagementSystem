using CMS.Entities.Abstract;
using CMS.Entities.Concrete;
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
    public class TimedEntityMap<TEntity> :PrimitiveEntityMap<TEntity>
        where TEntity: TimedEntity
    {

        public new void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(te => te.StartDate);
            
            builder.Property(te => te.FinalDate);

        }


    }
}
