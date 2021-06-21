using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Abstract
{
    public class CollisionEntities<E1,E2> : EntityBase, IEntity
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }
        public E1 Entity1 { get; set; }
        public E2 Entity2 { get; set; }

    }
}
