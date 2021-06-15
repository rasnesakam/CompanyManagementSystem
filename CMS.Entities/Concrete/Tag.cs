using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;

namespace CMS.Entities.Concrete
{
    public class Tag: PrimitiveEntity
    {
        public ICollection<ProjectTag> Projects { get; set; }
        public ICollection<MissionTag> Missions { get; set; }
    }
}
