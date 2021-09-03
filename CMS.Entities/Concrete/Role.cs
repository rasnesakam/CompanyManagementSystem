using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace CMS.Entities.Concrete
{
    public class Role:IdentityRole<int>
    {
        public ICollection<User> Users { get; set; }
    }
}
