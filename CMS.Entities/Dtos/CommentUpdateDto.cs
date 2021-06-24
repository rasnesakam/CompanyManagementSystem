using CMS.Entities.Abstract;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class CommentUpdateDto<CEntity,PEntity>:CommentAddDto<CEntity,PEntity>
        where PEntity: EntityBase,new()
        where CEntity: CommentEntityBase<PEntity>
    {
        [Required]
        public int Id { get; set; }
    }
}
