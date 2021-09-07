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
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var res = await _noteService.GetAll();
            return JsonSerializer.Serialize(new ReturnModel<Note>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await _noteService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<Note>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<Note>(new Note[] { res.Data })
            });
        }
        [HttpGet("company/{id}")]
        public async Task<string> GetForCompany(int id)
        {
            var res = await _noteService.GetAll(m => m.ParentId == id);
            return JsonSerializer.Serialize(new ReturnModel<Note>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }

        [HttpPost]
        public async Task<string> Post([FromBody] NoteAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _noteService.Add(dto);
                return JsonSerializer.Serialize(new ReturnModel<Note>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Note>(new Note[] { res.Data })
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
                return JsonSerializer.Serialize(new ReturnModel<Note>
                {
                    StatusCode = 400,
                    Messages = messages,

                });
            }
        }

        [HttpPut]
        public async Task<string> Put([FromBody] MailAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _noteService.Update(dto);
                return JsonSerializer.Serialize(new ReturnModel<Note>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Note>(new Note[] { res.Data })
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
                return JsonSerializer.Serialize(new ReturnModel<Note>
                {
                    StatusCode = 400,
                    Messages = messages,

                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var res = await _noteService.Delete(id, "ensar");
            return JsonSerializer.Serialize(new ReturnModel<Mail>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message })
            });
        }
    }
}
