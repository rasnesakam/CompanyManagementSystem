using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Models
{
    public class MainPageModel
    {
        public IDataResult<DomainListDto> Domains { get; set; }
        public IDataResult<MailListDto> Mails { get; set; }
        public IDataResult<CentralListDto> Centrals { get; set; }
        public IDataResult<Note> Notes { get; set; }
    }
}
