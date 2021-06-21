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
    public class CompanyMap: PrimitiveEntityMap<Company>
    {
        public new void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure(builder);

            builder.Property(cmp => cmp.BillAddress)
                .IsRequired()
                .HasMaxLength(250);
            
            builder.Property(cmp => cmp.ContactNumber)
                .IsRequired()
                .HasMaxLength(10);
            
            builder.Property(cmp => cmp.TaxNum)
                .IsRequired()
                .HasMaxLength(10); ;
            
            builder.Property(cmp => cmp.Icon)
                .IsRequired()
                .HasMaxLength(250); ;
            
            builder.Property(cmp => cmp.EMail)
                .IsRequired()
                .HasMaxLength(50);

            builder.ToTable("Companies");


        }
    }
}
