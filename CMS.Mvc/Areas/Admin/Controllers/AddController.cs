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
        private IWebHostEnvironment _hostEnvironment;

        public AddController(ICompanyService companyService, IWebHostEnvironment hostEnvironment, ICentralService centralService, IDomainService domainService, IMailService mailService, INoteService noteService)
        {
            _companyService = companyService;
            _hostEnvironment = hostEnvironment;
            _centralService = centralService;
            _domainService = domainService;
            _mailService = mailService;
            _noteService = noteService;
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
    }
}
