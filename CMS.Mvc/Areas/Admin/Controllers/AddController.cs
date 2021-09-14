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
using Microsoft.AspNetCore.Authorization;

namespace CMS.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AddController : Controller
    {
        

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
