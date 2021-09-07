using CMS.Shared.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class CompanyAddDto: IODtobase
    {
        [Display(Name = "Şirket İsmi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Şirket Hakkında")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(250, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string Description { get; set; }

        [Display(Name = "Fatura Adresi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(250,ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string BillAddress { get; set; }

        [Display(Name = "Fatura Numarası")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(10, ErrorMessage = "{0} alanı en fazla {1} rakamdan oluşmalıdır")]
        [MinLength(10, ErrorMessage = "{0} alanı en az{1} rakamdan oluşmalıdır")]
        public string TaxNum { get; set; }

        [Display(Name = "E Posta Adresi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string EMail { get; set; }

        [Display(Name = "İletişim Numarası")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(10, ErrorMessage = "{0} alanı en fazla {1} rakamdan oluşmalıdır")]
        [MinLength(10, ErrorMessage = "{0} alanı en az {1} rakamdan oluşmalıdır")]
        public string ContactNumber { get; set; }

        public string Icon { get; set; }

        [Display(Name = "Şirket Logosu")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public IFormFile IconFile { get; set; }
    }
}
