using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class ProjectAddDto
    {
        [Display(Name="Proje İsmi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(50,ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Proje Açıklaması")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(250, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        public string Description { get; set; }

        [Display(Name = "Proje Başlangıç Tarihi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Proje Bitiş Tarihi")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime FinalDate { get; set; }

        [Display(Name = "Proje Durumu")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public int StatusId { get; set; }

        [Display(Name = "Proje Etiketleri")]
        public int[] Tags { get; set; }

    }
}
