using CMS.Entities.Concrete;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Abstract
{
    public class CommentEntityBase<TEntity>: EntityBase
        where TEntity:IEntity,new()
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ParentId { get; set; }
        public TEntity Parent { get; set; }
        public string Text { get; set; }

    }
}
