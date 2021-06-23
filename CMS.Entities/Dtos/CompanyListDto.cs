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
    public class CompanyListDto: DtoGetBase
    {
        public ICollection<Company> Companies { get; set; }

        public override ResultStatus ResultStatus { get; set; } = ResultStatus.Success;
    }
}
