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
    public class HomeController : Controller
    {
        private ICentralService _centralService;
        //private INoteService _noteService;
        private IMailService _mailService;
        private IDomainService _domainService;

        public HomeController(IDomainService domainService, IMailService mailService, ICentralService centralService)
        {
            _domainService = domainService;
            _mailService = mailService;
            _centralService = centralService;
        }

        public async Task<IActionResult> Index()
        {

            return View(new MainPageModel
            {
                Centrals = await _centralService.GetAll(),
                Mails = await _mailService.GetAll(),
                Domains = await _domainService.GetAll(),
                Notes = null
            });
        }
    }
}
