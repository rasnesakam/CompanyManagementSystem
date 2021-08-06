using CMS.Entities.Concrete;
using CMS.Mvc.Areas.Admin.Models;
using CMS.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private ICentralService _centralService;
        private ICompanyService _companyService;
        //private INoteService _noteService;
        private IMailService _mailService;
        private IDomainService _domainService;

        public HomeController(IDomainService domainService, IMailService mailService, ICentralService centralService, ICompanyService companyService)
        {
            _domainService = domainService;
            _mailService = mailService;
            _centralService = centralService;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {

            return View(new CompanyListModel
            {
                Companies = await _companyService.GetAll()
            });
        }
    }
}
