using CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class StatusListDto
    {
        public ICollection<Status> Statuses { get; set; }
    }
}
