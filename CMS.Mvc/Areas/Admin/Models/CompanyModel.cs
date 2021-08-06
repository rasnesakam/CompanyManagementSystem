using CMS.Entities.Concrete;
using CMS.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Models
{
    public class CompanyModel
    {
        public Company Company { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
    }
}
