using CMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities.Concrete
{
    public class Note: ChildPrimitiveEntity<Company>
    {
        public  int UserId { get; set; }
        public  User User { get; set; }
  
    }
}
