using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Entities.Dtos
{
    public class DtoListBase<Entity>: DtoGetBase
        where Entity: EntityBase
    {
        public ICollection<Entity> Datas { get; set; }
    }
}
