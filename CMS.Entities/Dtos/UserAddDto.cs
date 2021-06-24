using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class UserAddDto
    {
        [Display(Name ="Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır")]
        public string LastName { get; set; }

        [Display(Name = "E Posta")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır")]
        public string EMail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(25, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        [MaxLength(25, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşmalıdır")]
        [MinLength(6, ErrorMessage = "{0} alanı en az {1} karakterden oluşmalıdır")]
        public byte[] PasswordHash { get; set; }

        [Display(Name = "Çalıştığı Şirket")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public int CompanyId { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "{0} alanı zorunludur")]
        public int RoleID { get; set; }
    }
}
