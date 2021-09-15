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
using System.Net.Http;

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
            HttpClient client = new HttpClient();
            HttpResponseMessage status = await client.GetAsync("https://localhost:44310/api/Status");
            status.EnsureSuccessStatusCode();
            string statusResponse = await status.Content.ReadAsStringAsync();
            HttpResponseMessage tags = await client.GetAsync("https://localhost:44310/api/Status");
            tags.EnsureSuccessStatusCode();
            string TagsResponse = await tags.Content.ReadAsStringAsync();

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
