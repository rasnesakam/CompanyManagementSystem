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
    public class CommentAddDto<CEntity,PEntity>
        where PEntity: EntityBase,new()
        where CEntity: CommentEntityBase<PEntity>
    {
        [Display(Name = "Yorum")]
        [Required(ErrorMessage = "Boş yorum gönderilemez")]
        [MaxLength(250,ErrorMessage ="{0} alanı en fazla 250 karakterden oluşmalıdır")]
        public string Text { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
