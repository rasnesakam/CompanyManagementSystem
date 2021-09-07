using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Mvc.Areas.Admin.Models;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Extensions;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefinersController : Controller
    {
        private IStatusService _statusService;
        private ITagService _tagService;

        public DefinersController(IStatusService statusService, ITagService tagService)
        {
            _statusService = statusService;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Statuses()
        {
            var statuses = await _statusService.GetAll();
            return View(statuses.Data);
            
        }

        public async Task<IActionResult> Tags()
        {
            var tags = await _tagService.GetAll();
            return View(tags.Data);
        }

        [HttpGet]
        public IActionResult AddStatus()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddTag()
        {
            return View();
        }

    }
}
