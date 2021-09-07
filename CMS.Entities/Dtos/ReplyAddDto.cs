using CMS.Shared.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class ReplyAddDto:IODtobase
    {
        [Display(Name="Yorum")]
        [Required(ErrorMessage ="{0} alanı zorunludur")]
        [MaxLength(250,ErrorMessage ="{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string Text { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int ParentId { get; set; }
    }
}
