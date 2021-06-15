using CMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Concrete
{
    public class Mission: TimedEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<MissionTag> MissionTags { get; set; }
        public ICollection<MissionComment> MissionComments { get; set; }
        public ICollection<MissionUser> MissionUsers { get; set; }
    }
}
