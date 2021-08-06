using CMS.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Models
{
    public class CentralReturnViewModel
    {
        public int StatusCode { get; set; }
        public CentralAddDto CentralAddDto { get; set; }
        public string PartialView { get; set;}
    }
}
