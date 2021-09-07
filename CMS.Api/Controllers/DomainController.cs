using AutoMapper;
using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly IDomainService _domainService;

        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        [HttpGet]
        public async Task<string> Get() 
        {
            var res = await _domainService.GetAll();
            return JsonSerializer.Serialize(new ReturnModel<Domain>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }
        
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await _domainService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<Domain>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<Domain>(new Domain[] {res.Data})
            });
        }

        [HttpGet("company/{id}")]
        public async Task<string> GetForCompany(int id)
        {
            var res = await _domainService.GetAll(d=> d.ParentId == id);
            return JsonSerializer.Serialize(new ReturnModel<Domain>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }

        [HttpPost]
        public async Task<string> Post([FromBody] DomainAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _domainService.Add(dto);
                return JsonSerializer.Serialize(new ReturnModel<Domain>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Domain>(new Domain[] { res.Data })
                });
            }
            else
            {
                List<string> messages = new();
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        messages.Add(error.ErrorMessage);
                    }
                }
                return JsonSerializer.Serialize(new ReturnModel<Domain>
                {
                    StatusCode = 400,
                    Messages = messages,
                    Values = null
                });
            }
        }

        [HttpPut]
        public async Task<string> Put([FromBody] DomainAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _domainService.Add(dto);
                return JsonSerializer.Serialize(new ReturnModel<Domain>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Domain>(new Domain[] { res.Data })
                });
            }
            else
            {
                List<string> messages = new();
                foreach (var entry in ModelState.Values)
                {
                    foreach (var error in entry.Errors)
                    {
                        messages.Add(error.ErrorMessage);
                    }
                }
                return JsonSerializer.Serialize(new ReturnModel<Domain>
                {
                    StatusCode = 400,
                    Messages = messages,
                    Values = null
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var res = await _domainService.Delete(id,"ensar");
            return JsonSerializer.Serialize(new ReturnModel<Domain>
            {
                StatusCode = (int) res.Status,
                Messages = new(new string[] { res.Message }),
                Values = null
            });
        }

    }
}
