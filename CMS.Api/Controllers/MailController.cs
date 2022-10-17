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
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var res = await _mailService.GetAll();
            return JsonSerializer.Serialize(new ReturnModel<Mail>
            {
                StatusCode = (int) res.Status,
                Messages = new(new string[] {res.Message} ),
                Values = res.Data
            });
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await _mailService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<Mail>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<Mail>(new Mail[] { res.Data })
            });
        }
        [HttpGet("company/{id}")]
        public async Task<string> GetForCompany(int id)
        {
            var res = await _mailService.GetAll(m=> m.ParentId == id);
            return JsonSerializer.Serialize(new ReturnModel<Mail>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }

        [HttpPost]
        public async Task<string> Post([FromBody] MailAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _mailService.Add(dto);
                return JsonSerializer.Serialize(new ReturnModel<Mail>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Mail>(new Mail[] { res.Data })
                });
            }
            else
            {
                List<string> messages = new();
                foreach(var entry in ModelState.Values)
                {
                    foreach(var err in entry.Errors)
                    {
                        messages.Add(err.ErrorMessage);
                    }
                }
                return JsonSerializer.Serialize(new ReturnModel<Mail>
                {
                    StatusCode = 400,
                    Messages = messages,

                });
            }
        }

        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] MailAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _mailService.Update(id, dto);
                return JsonSerializer.Serialize(new ReturnModel<Mail>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Mail>(new Mail[] { res.Data })
                });
            }
            else
            {
                List<string> messages = new();
                foreach (var entry in ModelState.Values)
                {
                    foreach (var err in entry.Errors)
                    {
                        messages.Add(err.ErrorMessage);
                    }
                }
                return JsonSerializer.Serialize(new ReturnModel<Mail>
                {
                    StatusCode = 400,
                    Messages = messages,

                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var res = await _mailService.Delete(id, "ensar");
            return JsonSerializer.Serialize(new ReturnModel<Mail>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message })
            });
        }
    }
}
