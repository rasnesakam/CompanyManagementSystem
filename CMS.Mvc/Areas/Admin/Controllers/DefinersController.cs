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
        [HttpPost]
        public async Task<IActionResult> AddStatus(StatusAddDto dto)
        {

            if (ModelState.IsValid)
            {
                var newStatus = await _statusService.Add(dto,"ensar");
                if (newStatus.Status == ResultStatus.Success)
                {
                    return Json(JsonSerializer.Serialize(new BaseReturnModel<Status>
                    {
                        StatusCode = 201,
                        Message = newStatus.Message,
                        Data = newStatus.Data.Data
                    }));
                }
                return Json(JsonSerializer.Serialize(new BaseReturnModel<Status>
                {
                    StatusCode = 400,
                    Message = newStatus.Message
                }));
            }
            return Json(
                JsonSerializer.Serialize(
                    new BaseReturnModel<Status>
                    {
                        PartialView = await this.RenderViewToStringAsync("AddStatus",dto),
                        StatusCode = 400
                    }
                    ));

        }

        [HttpGet]
        public IActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTag(TagAddDto dto)
        {

            if (ModelState.IsValid)
            {
                var newTag = await _tagService.Add(dto, "ensar");
                if (newTag.Status == ResultStatus.Success)
                {
                    return Json(JsonSerializer.Serialize(new BaseReturnModel<Tag>
                    {
                        StatusCode = 201,
                        Message = newTag.Message,
                        Data = newTag.Data.Data
                    }));
                }
                return Json(JsonSerializer.Serialize(new BaseReturnModel<Tag>
                {
                    StatusCode = 400,
                    Message = newTag.Message
                }));
            }
            return Json(
                JsonSerializer.Serialize(
                    new BaseReturnModel<Tag>
                    {
                        PartialView = await this.RenderViewToStringAsync("AddStatus", dto),
                        StatusCode = 400
                    }
                    ));

        }

    }
}
