using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Abstract
{
    public class ChildPrimitiveEntity<TEntity> : PrimitiveEntity
        where TEntity:IEntity,new()
    {
        public int ParentId { get; set; }
        public TEntity Parent { get; set; }
    }
}
