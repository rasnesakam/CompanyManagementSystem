using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;

namespace CMS.Entities.Concrete
{
    public class Reminder: ChildPrimitiveEntity<Company>
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
