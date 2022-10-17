using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Entities.Dtos
{
    public class AddDtoBase
    {

        [Required(ErrorMessage = "Bu alanı kimin değiştirdiği belirtilmek zorundadır")]
        public string CreatedByName { get; set; }

        [Required(ErrorMessage ="Bu alanı kimin değiştirdiği belirtilmek zorundadır")]
        public string ModifiedByName { get; set; }

        [Display(Name = "Aktivite durumu")]
        public bool IsActive { get; set; }

        [Display(Name = "Silinme durumu")]
        public bool IsDeleted { get; set; }

    }
}
