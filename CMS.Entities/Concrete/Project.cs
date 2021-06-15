using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;

namespace CMS.Entities.Concrete
{
    public class Project: TimedEntity
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<ProjectTag> Tags { get; set; }
        public ICollection<ProjectUser> Users { get; set; }
        public ICollection<MissionComment> Comments { get; set; }
    }
}
