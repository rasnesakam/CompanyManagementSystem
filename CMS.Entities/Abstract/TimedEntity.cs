using CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Abstract
{
    public class TimedEntity: PrimitiveEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
