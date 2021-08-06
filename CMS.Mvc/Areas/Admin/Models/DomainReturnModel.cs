using CMS.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Models
{
    public class DomainReturnModel
    {
        public int StatusCode { get; set; }
        public DomainAddDto domainAddDto { get; set; }
        public string Message { get; set; }
    }
}
