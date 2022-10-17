using CMS.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        [HttpGet]
        public async Task<string> Get()
        {
            return "value";
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return "value";
        }

        [HttpGet("company/{id}")]
        public async Task<string> GetForCompany(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<string> Post()
        {
            return "value";
        }

        [HttpPut]
        public async Task<string> Put()
        {

            return "value";
        }

        [HttpDelete]
        public async Task<string> Delete()
        {
            return "value";
        }
    }
}
