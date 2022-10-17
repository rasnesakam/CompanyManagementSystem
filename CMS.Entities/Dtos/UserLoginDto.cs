using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class UserLoginDto
    {
        [Display(Name = "Kullanıcı Adı veya E Posta")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public string UserNameOrEMail { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
