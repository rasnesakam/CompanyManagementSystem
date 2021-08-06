using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Models
{
    public class BaseReturnModel<D>
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public D Data {get;set;}
        public int StatusCode {get;set;}
        public string Message {get;set;}
        public string PartialView {get;set;}
    }
}
