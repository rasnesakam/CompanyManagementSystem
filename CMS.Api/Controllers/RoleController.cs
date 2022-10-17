using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Role> _roleService;

        public RoleController(RoleManager<Role> roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var roles = _roleService.Roles;
            return JsonSerializer.Serialize(new ReturnModel<Role>
            {
                StatusCode = (int)ResultStatus.Success,
                Messages = new(),
                Values = roles.ToList()
            });
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var roles = await _roleService.FindByIdAsync(id.ToString());
            return JsonSerializer.Serialize(new ReturnModel<Role>
            {
                StatusCode = (int)ResultStatus.Success,
                Messages = new(),
                Values = new List<Role>(new Role[] { roles })
            });
        }


        [HttpPost]
        public async Task<string> Post([FromBody] Role role)
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
