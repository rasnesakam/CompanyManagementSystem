using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Entities.Abstract;
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
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var res = await _missionService.GetAll();
            return JsonSerializer.Serialize(new ReturnModel<Mission>
            {
                StatusCode = (int) res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
            
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await _missionService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<Mission>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = new List<Mission>(new Mission[] {res.Data})
            });
        }

        [HttpGet("project/{id}")]
        public async Task<string> GetForProject(int id)
        {
            var res = await _missionService.GetAll(m=> m.Id == id);
            return JsonSerializer.Serialize(new ReturnModel<Mission>
            {
                StatusCode = (int)res.Status,
                Messages = new(new string[] { res.Message }),
                Values = res.Data
            });
        }

        [HttpPost]
        public async Task<string> Post(MissionAddDto dto) 
        {
            ReturnModel<Mission> model;
            if (ModelState.IsValid)
            {
                var res = await _missionService.Add(dto);

                model = new ReturnModel<Mission>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Mission>(new Mission[] { res.Data })
                };
            }
            else
            {
                List<string> errs = new();

                foreach(ModelStateEntry entry in ModelState.Values)
                {
                    foreach (ModelError error in entry.Errors) errs.Add(error.ErrorMessage);
                }
                model = new ReturnModel<Mission>
                {
                    StatusCode = (int)ResultStatus.Warning,
                    Messages = errs,
                    Values = null
                };
            }
            return JsonSerializer.Serialize(model);
        }

        [HttpPut]
        public async Task<string> Put(MissionAddDto dto) 
        {
            ReturnModel<Mission> model;
            if (ModelState.IsValid)
            {
                var res = await _missionService.Update(dto);
                model = new ReturnModel<Mission>
                {
                    StatusCode = (int)res.Status,
                    Messages = new(new string[] { res.Message }),
                    Values = new List<Mission>(new Mission[] { res.Data })
                };
            }
            else
            {
                List<string> errs = new();

                foreach (ModelStateEntry entry in ModelState.Values)
                {
                    foreach (ModelError error in entry.Errors) errs.Add(error.ErrorMessage);
                }
                model = new ReturnModel<Mission>
                {
                    StatusCode = (int)ResultStatus.Warning,
                    Messages = errs,
                    Values = null
                };
            }
            return JsonSerializer.Serialize(model);
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id) 
        {
            var res = await _missionService.Delete(id,"ensar");
            return JsonSerializer.Serialize(new ReturnModel<Mission>
            {
                Messages = new(new string[] { res.Message }),
                StatusCode = (int) res.Status,
                Values = null
            });
        }
    }
}
