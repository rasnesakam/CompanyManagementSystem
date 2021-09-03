using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        private IWebHostEnvironment _hostEnvironment;

        public CompanyController(ICompanyService companyService, IWebHostEnvironment hostEnvironment)
        {
            _companyService = companyService;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> Get()
        {
            return (await _companyService.GetAll()).Data.Companies;
        }

        [HttpGet("{id}")]
        public async Task<Company> Get(int id)
        {
            return (await _companyService.Get(id)).Data.Company;
        }

        [HttpPost]
        public async Task<string> Post([FromForm] CompanyAddDto dto) 
        {
            if (dto.IconFile != null)
            {
                string uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads/company/logos");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                string file = Path.Combine(uploads, dto.IconFile.FileName);
                using (Stream stream = new FileStream(file, FileMode.Create))
                {
                    await dto.IconFile.CopyToAsync(stream);
                    dto.Icon = dto.IconFile.FileName;
                }
            }
            if (ModelState.IsValid)
            {

                var res = await _companyService.Add(dto, "ensar");
                if (res.Status == ResultStatus.Success)
                {
                    return JsonSerializer.Serialize<ReturnModel<Company>>(new ReturnModel<Company>
                    {
                        StatusCode = 200,
                        Messages = null
                    });
                }
                else return JsonSerializer.Serialize<ReturnModel<Company>>(new ReturnModel<Company>
                {
                    StatusCode = 500,
                    Messages = new List<string>(new string[] { res.Message })
                });
            }
            else
            {
                List<string> errs = new List<string>();
                foreach (var entry in ModelState.Values)
                {
                    foreach(ModelError error in entry.Errors)
                    {
                        errs.Add(error.ErrorMessage);
                    }
                }
                return JsonSerializer.Serialize<ReturnModel<Company>>(new ReturnModel<Company>
                {
                    StatusCode = 400,
                    Messages = errs
                });
            }
        }

        [HttpPut]
        public async Task<string> Put([FromBody] CompanyUpdateDto dto) {
            if (dto.IconFile != null)
            {
                string uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads/company/logos");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                string file = Path.Combine(uploads, dto.IconFile.FileName);
                using (Stream stream = new FileStream(file, FileMode.Create))
                {
                    await dto.IconFile.CopyToAsync(stream);
                    dto.Icon = dto.IconFile.FileName;
                }
            }
            if (ModelState.IsValid)
            {

                var res = await _companyService.Update(dto, "ensar");
                if (res.Status == ResultStatus.Success)
                {
                    return JsonSerializer.Serialize<ReturnModel<Company>>(new ReturnModel<Company>
                    {
                        StatusCode = 200,
                        Messages = null
                    });
                }
                else return JsonSerializer.Serialize<ReturnModel<Company>>(new ReturnModel<Company>
                {
                    StatusCode = 500,
                    Messages = new List<string>(new string[] { res.Message })
                });
            }
            else
            {
                List<string> errs = new List<string>();
                foreach (var entry in ModelState.Values)
                {
                    foreach (ModelError error in entry.Errors)
                    {
                        errs.Add(error.ErrorMessage);
                    }
                }
                return JsonSerializer.Serialize<ReturnModel<Company>>(new ReturnModel<Company>
                {
                    StatusCode = 400,
                    Messages = errs
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id) {
            var res = await _companyService.Delete(id,"ensar");
            return JsonSerializer.Serialize(new ReturnModel<Project>
            {
                Messages = new List<string>(new string[] { res.Message}),
                StatusCode = (int) res.Status,
                Values = null
            });
        }
    }
}
