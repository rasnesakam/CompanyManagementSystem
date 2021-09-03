using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Entities.Dtos
{
    public class IODtobase
    {

        public int Id { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }

        [Display(Name = "Aktivite durumu")]
        public bool IsActive { get; set; }

        [Display(Name = "Silinme durumu")]
        public bool IsDeleted { get; set; }

    }
}
