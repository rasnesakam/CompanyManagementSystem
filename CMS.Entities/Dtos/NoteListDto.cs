using CMS.Entities.Concrete;
using CMS.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Dtos
{
    public class NoteListDto: DtoGetBase
    {
        public ICollection<Note> Notes { get; set; }
    }
}
