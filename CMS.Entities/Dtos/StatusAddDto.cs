using CMS.Shared.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class StatusAddDto : IODtobase
    {
        [Display(Name = "Durum İsmi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(25, ErrorMessage = "{0} alanı en fazla 25 karakterden oluşmalı")]
        public string Name { get; set; }

        [Display(Name = "Durum İsmi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(250, ErrorMessage = "{0} alanı en fazla 250 karakterden oluşmalı")]
        public string Description { get; set; }

        [Display(Name = "Durum Rengi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string ColorHex { get; set; }
    }
}
