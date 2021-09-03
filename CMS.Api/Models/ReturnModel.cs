using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Api.Models
{
    public class ReturnModel<Type>
    {
        public int StatusCode { get; set; }
        public List<string> Messages { get; set; }
        public ICollection<Type> Values { get; set; }
    }
}
