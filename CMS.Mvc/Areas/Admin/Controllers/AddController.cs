using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using CMS.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Controllers
{
    public class AddController : Controller
    {
        private ICompanyService _companyService;

        public AddController(ICompanyService companyService)
        {
            _companyService = companyService;
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

        public async Task<IActionResult> Company()
        {

            return View();
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

        public async Task<IActionResult> Mail()
        {
            IDataResult<CompanyListDto> res = await _companyService.GetAll();
            if (res.Status == ResultStatus.Success)
            {
                ViewBag.Companies = res.Data.Companies;
            }
            return View();
        }
    }
}
