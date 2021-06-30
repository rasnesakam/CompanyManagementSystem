using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Entities.Abstract
{
    public class EntityBase: IEntity
    {
        public int Id { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
