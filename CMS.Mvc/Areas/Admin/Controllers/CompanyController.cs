using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Mvc.Areas.Admin.Models;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;
        private IProjectService _projectService;
        private IMissionService _missionService;
        private IWebHostEnvironment _hostEnvironment;
        
        public CompanyController(ICompanyService companyService, IProjectService projectService, IMissionService missionService, IWebHostEnvironment hostEnvironment)
        {
            _companyService = companyService;
            _projectService = projectService;
            _missionService = missionService;
            _hostEnvironment = hostEnvironment;
        }
        
        public async Task<IActionResult> Index()
        {
            var res = await _companyService.GetAll();
            return View(res.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var res = await _companyService.Get(id);
            
            return View(new CompanyModel
            {
                Company = res.Data.Company,
                ResultStatus = res.Status,
                Message = res.Message
            });
        }

        [HttpGet]
        public async Task<IActionResult> Projects(int id)
        {
            var res = await _companyService.Get(id);
            res.Data.Company.Projects = (await _projectService.GetAll(p => p.CompanyId == id)).Data.Projects;
            return View(new CompanyModel
            {
                Company = res.Data.Company,
                ResultStatus = res.Status,
                Message = res.Message
            });
        }

        [HttpGet]
        public async Task<IActionResult> Missions(int projectId)
        {
            var res = await _missionService.GetAll(m => m.ProjectId == projectId);
            return View(res.Data);
        }

        [HttpGet]
        public async Task<IActionResult> MissionComments(int missionId)
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyAddDto companyAddDto)
        {
            if (companyAddDto.IconFile != null)
            {
                string uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads/company/logos");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                string file = Path.Combine(uploads, companyAddDto.IconFile.FileName);
                using (Stream stream = new FileStream(file, FileMode.Create))
                {
                    await companyAddDto.IconFile.CopyToAsync(stream);
                    companyAddDto.Icon = companyAddDto.IconFile.FileName;
                }
            }
            if (ModelState.IsValid)
            {

                var res = await _companyService.Add(companyAddDto, "ensar");
                if (res.Status == ResultStatus.Success)
                {
                    RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
