using AutoMapper;
using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;
        private readonly UserManager<User> _userManager;

        public ReplyController(IReplyService replyService, UserManager<User> userManager)
        {
            _replyService = replyService;
            _userManager = userManager;
        }


        // GET: api/<RepliesController>
        [HttpGet]
        public async Task<string> Get()
        {
            var res = await _replyService.GetAllByActiveAndNonDeleted();
            return JsonSerializer.Serialize(new ReturnModel<MissionCommentReply>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] {res.Message}),
                Values = res.Data
            });
        }

        // GET api/<RepliesController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await _replyService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<MissionCommentReply>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<MissionCommentReply>(new MissionCommentReply[] { res.Data })
            });
        }

        // POST api/<RepliesController>
        [HttpPost]
        public async Task<string> Post([FromBody] ReplyAddDto dto)
        {
            var res = await _replyService.Add(dto);
            return JsonSerializer.Serialize(new ReturnModel<MissionCommentReply>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<MissionCommentReply>(new MissionCommentReply[] { res.Data })
            });
        }

        // PUT api/<RepliesController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] ReplyAddDto dto)
        {
            var res = await _replyService.Update(id,dto);
            return JsonSerializer.Serialize(new ReturnModel<MissionCommentReply>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<MissionCommentReply>(new MissionCommentReply[] { res.Data })
            });
        }

        // DELETE api/<RepliesController>/5
        [HttpDelete("user/{userId}/id/{id}")]
        public async Task<string> Delete(int userId,int id)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var res = await _replyService.Delete(id, "ensar");
                return JsonSerializer.Serialize(new ReturnModel<string>
                {
                    StatusCode = (int) res.Status,
                    Messages = new(new string[] { res.Message })
                });
            }
            else return JsonSerializer.Serialize(new ReturnModel<string>
            {
                StatusCode = 400,
                Messages = new(new string[] { "Kullanıcının bu işlemi uygun değildir" })
            });
        }
    }
}
