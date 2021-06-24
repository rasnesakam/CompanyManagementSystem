using CMS.Entities.Concrete;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class DomainListDto: DtoGetBase
    {
        public ICollection<Domain> Domains { get; set; }
    }
}
