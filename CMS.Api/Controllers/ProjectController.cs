using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/<ProjectsController>/company/{id}
        [HttpGet()]
        public async Task<string> Get()
        {
            var res = await _projectService.GetAll();
            return JsonSerializer.Serialize(new ReturnModel<Project>
            {
                StatusCode = (int) res.Status,
                Messages = new List<string>(new string[] { res.Message})
            });
        }

        // GET: api/<ProjectsController>/company/{id}
        [HttpGet("company/{id}")]
        public async Task<string> GetFromCompany(int id)
        {
            var res = await _projectService.GetAll(p=> p.CompanyId == id);
            return JsonSerializer.Serialize(new ReturnModel<Project>
            {
                StatusCode = (int)res.Status,
                Messages = new List<string>(new string[] { res.Message }),
                Values = res.Data.Projects
            });
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await _projectService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<Project>
            {
                StatusCode = (int)res.Status,
                Messages = new List<string>(new string[] { res.Data.Message }),
                Values = new List<Project>(new Project[] { res.Data.Project })
            });
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<string> Post([FromBody] ProjectAddDto dto)
        {
            ReturnModel<Project> model;
            if (ModelState.IsValid) 
            {
                var res = await _projectService.Add(dto, "ensar");
                model = new ReturnModel<Project>
                {
                    StatusCode = (int)res.Status,
                    Messages = new List<string>(new string[] { res.Message }),
                    Values = new List<Project>(new Project[] { res.Data.Project })
                };
            }
            else
            {
                List<string> messages = new List<string>();
                foreach(ModelStateEntry entry in ModelState.Values)
                {
                    foreach (ModelError error in entry.Errors)
                    {
                        messages.Add(error.ErrorMessage);
                    }
                }

                model = new ReturnModel<Project>
                {
                    Messages = messages,
                    StatusCode = (int) ResultStatus.Warning,
                    Values = null
                };
            }
            return JsonSerializer.Serialize(model);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] ProjectUpdateDto dto)
        {
            ReturnModel<Project> model;
            if (ModelState.IsValid)
            {
                var res = await _projectService.Update(dto, "ensar");
                model = new ReturnModel<Project>
                {
                    StatusCode = (int)res.Status,
                    Messages = new List<string>(new string[] { res.Message }),
                    Values = new List<Project>(new Project[] { res.Data.Project })
                };
            }
            else
            {
                List<string> messages = new List<string>();
                foreach (ModelStateEntry entry in ModelState.Values)
                {
                    foreach (ModelError error in entry.Errors)
                    {
                        messages.Add(error.ErrorMessage);
                    }
                }

                model = new ReturnModel<Project>
                {
                    Messages = messages,
                    StatusCode = (int)ResultStatus.Warning,
                    Values = null
                };
            }
            return JsonSerializer.Serialize(model);
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var res = await _projectService.Delete(id,"ensar");
            return JsonSerializer.Serialize(new ReturnModel<Project>
            {
                Messages = new List<string>(new string[] { res.Message }),
                StatusCode = (int)res.Status
            });
        }
    }
}
