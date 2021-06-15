using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Abstract
{
    public class PrimitiveEntity: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
