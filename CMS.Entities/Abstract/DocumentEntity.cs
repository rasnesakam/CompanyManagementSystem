using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Abstract
{
    public class DocumentEntity<TEntity>: ChildPrimitiveEntity<TEntity>
        where TEntity: IEntity,new()
    {
        public string Path { get; set; }
        public string Type { get; set; }

    }
}
