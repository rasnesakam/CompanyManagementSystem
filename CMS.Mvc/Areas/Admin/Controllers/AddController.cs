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
            IDataResult<CompanyListDto> res = await _companyService.GetAll();
            if (res.Status == ResultStatus.Success)
            {
                ViewBag.Companies = res.Data.Companies;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Central(CentralAddDto centralAddDto)
        {
            
            var compRes = await _companyService.GetAll();
            if (compRes.Status == ResultStatus.Success) ViewBag.Companies = compRes.Data.Companies;
            if (ModelState.IsValid)
            {
                var central = await _centralService.Add(centralAddDto,"ensar");
                if (central.Status == ResultStatus.Success)
                {
                    var returnView = JsonSerializer.Serialize(new BaseReturnModel<Central>
                    {
                        Data = central.Data.Central,
                        StatusCode = 201

                    });

                    return Json(returnView);
                }
            }
            return Json(
                JsonSerializer.Serialize(
                new BaseReturnModel<Central>
                {
                    PartialView = await this.RenderViewToStringAsync("Central", centralAddDto),
                    StatusCode = 400
                }));
        }



        public async Task<IActionResult> Domain()
        {
            IDataResult<CompanyListDto> res = await _companyService.GetAll();
            if (res.Status == ResultStatus.Success)
            {
                ViewBag.Companies = res.Data.Companies;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Domain(DomainAddDto domainAddDto)
        {
            var comps = await _companyService.GetAll();
            if (comps.Status == ResultStatus.Success) ViewBag.Companies = comps.Data.Companies;

            if (ModelState.IsValid)
            {
                var domain = await _domainService.Add(domainAddDto,"ensar");
                if (domain.Status == ResultStatus.Success)
                {
                    return Json(JsonSerializer.Serialize(new BaseReturnModel<Domain>
                    {
                        StatusCode = 201,
                        Message = domain.Message,
                        Data = domain.Data.Domain
                    }));
                }
                return Json(JsonSerializer.Serialize(new BaseReturnModel<Domain>
                {
                    StatusCode = 400,
                    Message = domain.Message
                }));
            }

            return Json(
                JsonSerializer.Serialize(
                    new BaseReturnModel<Domain>
                    {
                        StatusCode = 400,
                        Message = "Lütfen formunuzu yeniden gözden geçirin"
                    }
                    ));
        }

        public async Task<IActionResult> Mail()
        {
            IDataResult<CompanyListDto> res = await _companyService.GetAll();
            if (res.Status == ResultStatus.Success)
            {
                ViewBag.Companies = res.Data.Companies;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Mail(MailAddDto mailAddDto)
        {
            var comps = await _companyService.GetAll();
            if (comps.Status == ResultStatus.Success) ViewBag.Companies = comps.Data.Companies;

            if (ModelState.IsValid)
            {
                var mail = await _mailService.Add(mailAddDto, "ensar");
                if (mail.Status == ResultStatus.Success)
                {
                    return Json(JsonSerializer.Serialize(new BaseReturnModel<Mail>
                    {
                        StatusCode = 201,
                        Message = mail.Message,
                        Data = mail.Data.Mail
                    }));
                }
                return Json(JsonSerializer.Serialize(new BaseReturnModel<Mail>
                {
                    StatusCode = 400,
                    Message = mail.Message
                }));
            }

            return Json(
                JsonSerializer.Serialize(
                    new BaseReturnModel<Mail>
                    {
                        StatusCode = 400,
                        Message = "Lütfen formunuzu yeniden gözden geçirin"
                    }
                    ));
        }

        public async Task<IActionResult> Note()
        {
            IDataResult<CompanyListDto> res = await _companyService.GetAll();
            if (res.Status == ResultStatus.Success)
            {
                ViewBag.Companies = res.Data.Companies;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Note(NoteAddDto noteAddDto)
        {
            var comps = await _companyService.GetAll();
            if (comps.Status == ResultStatus.Success) ViewBag.Companies = comps.Data.Companies;

            if (ModelState.IsValid)
            {
                var note = await _noteService.Add(noteAddDto, "ensar");
                if (note.Status == ResultStatus.Success)
                {
                    return Json(JsonSerializer.Serialize(new BaseReturnModel<Note>
                    {
                        StatusCode = 201,
                        Message = note.Message,
                        Data = note.Data.Note
                    }));
                }
                return Json(JsonSerializer.Serialize(new BaseReturnModel<Note>
                {
                    StatusCode = 400,
                    Message = note.Message
                }));
            }

            return Json(
                JsonSerializer.Serialize(
                    new BaseReturnModel<Mail>
                    {
                        StatusCode = 400,
                        Message = "Lütfen formunuzu yeniden gözden geçirin"
                    }
                    ));
        }

        public async Task<IActionResult> Project(int compId)
        {
            ViewBag.CompanyId = compId;
            
            IDataResult<DtoListBase<Status>> statusRes = await _statusService.GetAll();
            if (statusRes.Status == ResultStatus.Success)
            {
                ViewBag.Statuses = statusRes.Data.Datas;
            }
            IDataResult<DtoListBase<Tag>> tagRes = await _tagService.GetAll();
            if (tagRes.Status == ResultStatus.Success)
            {
                ViewBag.Tags = tagRes.Data.Datas;
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Project(ProjectAddDto projectAddDto)
        {
            var comps = await _companyService.GetAll();
            if (comps.Status == ResultStatus.Success) ViewBag.Companies = comps.Data.Companies;
            IDataResult<DtoListBase<Status>> statusRes = await _statusService.GetAll();
            if (statusRes.Status == ResultStatus.Success)
            {
                ViewBag.Statuses = statusRes.Data.Datas;
            }
            IDataResult<DtoListBase<Tag>> tagRes = await _tagService.GetAll();
            if (tagRes.Status == ResultStatus.Success)
            {
                ViewBag.Tags = tagRes.Data.Datas;
            }
            if (ModelState.IsValid)
            {
                var project = await _projectService.Add(projectAddDto, "ensar");
                if (project.Status == ResultStatus.Success)
                {
                    return Json(JsonSerializer.Serialize(new BaseReturnModel<Project>
                    {
                        StatusCode = 201,
                        Message = project.Message,
                        Data = project.Data.Project
                    }));
                }
                return Json(JsonSerializer.Serialize(new BaseReturnModel<Project>
                {
                    StatusCode = 400,
                    Message = project.Message
                }));
            }
            return Json(
                JsonSerializer.Serialize(
                    new BaseReturnModel<Project>
                    {
                        StatusCode = 400,
                        Message = "Lütfen formunuzu yeniden gözden geçirin",
                        PartialView = await this.RenderViewToStringAsync(viewNamePath:"Project",model:projectAddDto)
                    }
                    ));
        }

        [HttpGet]
        public async Task<IActionResult> Mission(int projectId)
        {
            ViewBag.ProjectId = projectId;

            IDataResult<DtoListBase<Status>> statusRes = await _statusService.GetAll();
            if (statusRes.Status == ResultStatus.Success)
            {
                ViewBag.Statuses = statusRes.Data.Datas;
            }
            IDataResult<DtoListBase<Tag>> tagRes = await _tagService.GetAll();
            if (tagRes.Status == ResultStatus.Success)
            {
                ViewBag.Tags = tagRes.Data.Datas;
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Mission(MissionAddDto missionAddDto)
        {

            IDataResult<DtoListBase<Status>> statusRes = await _statusService.GetAll();
            if (statusRes.Status == ResultStatus.Success)
            {
                ViewBag.Statuses = statusRes.Data.Datas;
            }
            IDataResult<DtoListBase<Tag>> tagRes = await _tagService.GetAll();
            if (tagRes.Status == ResultStatus.Success)
            {
                ViewBag.Tags = tagRes.Data.Datas;
            }
            if (ModelState.IsValid)
            {
                var mission = await _missionService.Add(missionAddDto, "ensar");
                if (mission.Status == ResultStatus.Success)
                {
                    return Json(JsonSerializer.Serialize(new BaseReturnModel<Mission>
                    {
                        StatusCode = 201,
                        Message = mission.Message,
                        Data = mission.Data.Data
                    }));
                }
                return Json(JsonSerializer.Serialize(new BaseReturnModel<Mission>
                {
                    StatusCode = 400,
                    Message = mission.Message
                }));
            }
            return Json(
                JsonSerializer.Serialize(
                    new BaseReturnModel<Mission>
                    {
                        StatusCode = 400,
                        Message = "Lütfen formunuzu yeniden gözden geçirin",
                        PartialView = await this.RenderViewToStringAsync(viewNamePath: "Mission", model: missionAddDto)
                    }
                    ));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddDto<MissionComment,Mission> commentAddDto)
        {
            return Json("Bu yenilik getirilmedi");
        }
    }
}
