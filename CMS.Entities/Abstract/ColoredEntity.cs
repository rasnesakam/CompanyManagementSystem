using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Abstract
{
    public class ColoredEntity: PrimitiveEntity
    {
        public string ColorHex { get; set; }
    }
}
