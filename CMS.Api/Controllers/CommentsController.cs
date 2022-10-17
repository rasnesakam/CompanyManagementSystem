using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMissionCommentService _commentService;

        public CommentsController(IMissionCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var res = await _commentService.GetAll();
            return JsonSerializer.Serialize(new ReturnModel<MissionComment>
            {
                Messages = new List<string>(new string[] { res.Message }),
                StatusCode = (int) res.Status,
                Values = res.Data
            });
        }

        [HttpGet("mission/{id}")]
        public async Task<string> GetForMission(int id)
        {
            var res = await _commentService.GetAll(m=> m.Id == id);
            return JsonSerializer.Serialize(new ReturnModel<MissionComment>
            {
                Messages = new List<string>(new string[] { res.Message }),
                StatusCode = (int)res.Status,
                Values = res.Data
            });
        }

        [HttpPost]
        public async Task<string> Post(CommentAddDto<MissionComment,Mission> dto) 
        {
            ReturnModel<MissionComment> model;
            if (ModelState.IsValid)
            {
                var res = await _commentService.Add(dto);
                model = new ReturnModel<MissionComment>
                {
                    StatusCode = (int)res.Status,
                    Messages = new List<string>(new string[] { res.Message }),
                    Values = new List<MissionComment>(new MissionComment[] { res.Data })
                };
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (ModelStateEntry entry in ModelState.Values) 
                { 
                    foreach(ModelError error in entry.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                model = new ReturnModel<MissionComment>
                {
                    Messages = errors,
                    Values = null,
                    StatusCode = (int)ResultStatus.Warning
                };
            }

            return JsonSerializer.Serialize(model);
        }

        [HttpPut("{id}")]
        public async Task<string> Put(int id, CommentAddDto<MissionComment,Mission> dto) 
        {
            ReturnModel<MissionComment> model;
            if (ModelState.IsValid)
            {
                var res = await _commentService.Update(id, dto);
                model = new ReturnModel<MissionComment>
                {
                    StatusCode = (int)res.Status,
                    Messages = new List<string>(new string[] { res.Message }),
                    Values = new List<MissionComment>(new MissionComment[] { res.Data })
                };
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (ModelStateEntry entry in ModelState.Values)
                {
                    foreach (ModelError error in entry.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                model = new ReturnModel<MissionComment>
                {
                    Messages = errors,
                    Values = null,
                    StatusCode = (int)ResultStatus.Warning
                };
            }

            return JsonSerializer.Serialize(model);
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id) 
        {
            var res = await _commentService.Delete(id,"ensar");
            return JsonSerializer.Serialize(new ReturnModel<MissionComment>
            {
                StatusCode = (int)res.Status,
                Messages = new List<string>(new string[] { res.Message }),
                Values = null
            });
        }
    }
}
