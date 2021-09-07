using CMS.Shared.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class MailAddDto:IODtobase
    {
        [Display(Name = "E Posta adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(50,ErrorMessage ="{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string Name { get; set; }

        [Display(Name = "E Posta Açıklaması")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(250, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string Description { get; set; }

        [Display(Name = "Şirket")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public int ParentId { get; set; }
    }
}
