using CMS.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        // GET: api/<RepliesController>
        [HttpGet]
        public IEnumerable<MissionCommentReply> Get()
        {
            return null;
        }

        // GET api/<RepliesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RepliesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RepliesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RepliesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
