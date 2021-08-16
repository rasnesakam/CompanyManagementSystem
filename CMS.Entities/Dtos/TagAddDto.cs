using CMS.Shared.Entities.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CMS.Entities.Dtos
{
    public class TagAddDto:IODtobase
    {
        [Display(Name = "Etiket İsmi")]
        [Required(ErrorMessage ="{0} alanı zorunludur")]
        [MaxLength(25,ErrorMessage ="{0} alanı en fazla 25 karakter uzunluğunda olmalıdır")]
        public string Name { get; set; }


        [Display(Name = "Etiket Acıklaması")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(250, ErrorMessage = "{0} alanı en fazla 250 karakter uzunluğunda olmalıdır")]
        public string Description { get; set; }


        [Display(Name = "Etiket rengi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string ColorHex { get; set; }
    }
}
