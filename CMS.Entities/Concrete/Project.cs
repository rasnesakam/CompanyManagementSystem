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
        public ICollection<ProjectTag> ProjectTags { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
        public ICollection<Mission> Missions { get; set; }
    }
}
