using CMS.Entities.Abstract;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class CommentListDto<CEntity, PEntity> : DtoGetBase
        where PEntity : EntityBase, new()
        where CEntity : CommentEntityBase<PEntity>
    {
        public ICollection<CEntity> Comments { get; set; }
    }
}
