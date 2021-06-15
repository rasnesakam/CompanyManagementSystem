using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;

namespace CMS.Entities.Concrete
{
    public class Status: PrimitiveEntity
    {
        public ICollection<Project> Projects { get; set; }
        public ICollection<Mission> Missions { get; set; }
    }
}
