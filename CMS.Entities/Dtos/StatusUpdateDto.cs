using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class StatusUpdateDto: StatusAddDto
    {
        [Required]
        public int Id { get; set; }
    }
}
