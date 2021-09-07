using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using CMS.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using CMS.Mvc.Areas.Admin.Models;
using CMS.Shared.Utilities.Extensions;
using CMS.Entities.Concrete;
using CMS.Shared.Entities.Dtos;

namespace CMS.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddController : Controller
    {
        private ICompanyService _companyService;
        private ICentralService _centralService;
        private IDomainService _domainService;
        private INoteService _noteService;
        private IMailService _mailService;
        private IProjectService _projectService;
        private ITagService _tagService;
        private IStatusService _statusService;
        private IMissionService _missionService;
        private IWebHostEnvironment _hostEnvironment;

        public AddController(ICompanyService companyService, ICentralService centralService, IDomainService domainService, INoteService noteService, IMailService mailService, IProjectService projectService, ITagService tagService, IStatusService statusService, IMissionService missionService, IWebHostEnvironment hostEnvironment)
        {
            _companyService = companyService;
            _centralService = centralService;
            _domainService = domainService;
            _noteService = noteService;
            _mailService = mailService;
            _projectService = projectService;
            _tagService = tagService;
            _statusService = statusService;
            _missionService = missionService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Central()
        {
            
            return View();
        }


        public async Task<IActionResult> Domain()
        {
            
            return View();
        }


        public async Task<IActionResult> Mail()
        {
            
            return View();
        }

        public async Task<IActionResult> Note()
        {
            
            return View();
        }

        public async Task<IActionResult> Project(int compId)
        {
            ViewBag.CompanyId = compId;
            
            
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Mission(int projectId)
        {
            ViewBag.ProjectId = projectId;

            

            return View();
        }
    }
}
