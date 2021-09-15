using CMS.Shared.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class NoteAddDto:AddDtoBase
    {
        [Display(Name="Not İsmi")]
        [Required]
        [MaxLength(50,ErrorMessage ="{0} alanı en fazla {1} karakter uzunluğunda olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Not Açıklaması")]
        [Required]
        [MaxLength(250, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır")]
        public string Description { get; set; }

        public int ParentId { get; set; }

        public int UserId { get; set; }
    }
}
