using CMS.Entities.Concrete;
using CMS.Shared.Entities.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class CompanyDto: DtoGetBase
    {
        public Company Company { get; set; }
    }
}
