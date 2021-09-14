using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Mvc.Areas.Admin.Models;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CompanyController : Controller
    {
        
        
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            ViewBag.CompanyId = id;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Projects(int id)
        {
            ViewBag.CompanyId = id;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Missions(int projectId)
        {
            ViewBag.ProjectId = projectId;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MissionComments(int missionId)
        {
            ViewBag.MissionID = missionId;
            return View();
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }



    }
}
