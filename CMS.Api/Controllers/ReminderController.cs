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
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService mailService)
        {
            _reminderService = mailService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var res = await _reminderService.GetAll();
            return JsonSerializer.Serialize(new ReturnModel<Reminder>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await _reminderService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<Reminder>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<Reminder>(new Reminder[] { res.Data })
            });
        }
        [HttpGet("company/{id}")]
        public async Task<string> GetForCompany(int id)
        {
            var res = await _reminderService.GetAll(m => m.ParentId == id);
            return JsonSerializer.Serialize(new ReturnModel<Reminder>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }

        [HttpPost]
        public async Task<string> Post([FromBody] ReminderAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _reminderService.Add(dto);
                return JsonSerializer.Serialize(new ReturnModel<Reminder>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Reminder>(new Reminder[] { res.Data })
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
                return JsonSerializer.Serialize(new ReturnModel<Reminder>
                {
                    StatusCode = 400,
                    Messages = messages,

                });
            }
        }

        [HttpPut]
        public async Task<string> Put([FromBody] ReminderAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _reminderService.Update(dto);
                return JsonSerializer.Serialize(new ReturnModel<Reminder>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Reminder>(new Reminder[] { res.Data })
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
                return JsonSerializer.Serialize(new ReturnModel<Reminder>
                {
                    StatusCode = 400,
                    Messages = messages,

                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var res = await _reminderService.Delete(id, "ensar");
            return JsonSerializer.Serialize(new ReturnModel<Reminder>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message })
            });
        }
    }
}
