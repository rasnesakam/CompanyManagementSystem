using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class NoteAddDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public int UserId { get; set; }
    }
}
