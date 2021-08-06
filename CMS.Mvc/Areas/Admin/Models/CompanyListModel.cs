using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Models
{
    public class CompanyListModel
    {
        public IDataResult<CompanyListDto> Companies { get; set; }
    }
}
