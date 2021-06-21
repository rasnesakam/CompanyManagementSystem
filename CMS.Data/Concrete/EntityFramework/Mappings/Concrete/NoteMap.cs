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
    public class NoteMap:PrimitiveEntityMap<Note>
    {
        public new void Configure(EntityTypeBuilder<Note> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Notes");
        }
    }
}
