using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Entities.Dtos
{
    public class UpdateDtoBase: AddDtoBase
    {
        public int Id { get; set; }
    }
}
