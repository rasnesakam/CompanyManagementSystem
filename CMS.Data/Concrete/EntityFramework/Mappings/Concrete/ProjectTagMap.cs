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
    public class ProjectTagMap: EntityBaseMap<ProjectTag>
    {
        public new void Configure(EntityTypeBuilder<ProjectTag> builder)
        {
            base.Configure(builder);
            builder.HasOne<Project>(pt => pt.Entity1).WithMany(p => p.ProjectTags).HasForeignKey(pt => pt.Id1);
            builder.HasOne<Tag>(pt => pt.Entity2).WithMany(t => t.ProjectTags).HasForeignKey(pt => pt.Id2);
            builder.ToTable("Project_Tag");
        }
    }
}
