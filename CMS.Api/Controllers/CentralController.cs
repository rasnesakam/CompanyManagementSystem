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

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentralController : Controller
    {
        private readonly ICentralService centralService;

        public CentralController(ICentralService centralService)
        {
            this.centralService = centralService;
        }

        [HttpGet]
        public async Task<string> Get() 
        {
            var res = await centralService.GetAll();
            var model = new ReturnModel<Central>
            {
                Messages = new List<string>(new string[] { res.Message }),
                StatusCode = (int) res.Status,
                Values = res.Data

            };
            return JsonSerializer.Serialize<ReturnModel<Central>>(model);
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var res = await centralService.Get(id);
            return JsonSerializer.Serialize(new ReturnModel<Central>
            {
                Messages = new List<string>(new string[] { res.Message }),
                StatusCode = (int) res.Status,
                Values = new List<Central>(new Central[] { res.Data })
            });            
        }

        [HttpGet("company/{id}")]
        public async Task<string> GetFromCompany(int id)
        {
            var res = await centralService.GetAll();
            var model = new ReturnModel<Central>
            {
                Messages = new List<string>(new string[] { res.Message }),
                StatusCode = (int) res.Status,
                Values = res.Data

            };
            return JsonSerializer.Serialize<ReturnModel<Central>>(model);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] CentralAddDto dto)
        {
            ReturnModel<Central> model;
            if (ModelState.IsValid)
            {
                var res = await centralService.Add(dto);
                if (res.Status == ResultStatus.Success) model = new ReturnModel<Central>
                {
                    StatusCode = 201,
                    Messages = null,
                    Values = new List<Central>(new Central[] {res.Data})
                };
                else model = new ReturnModel<Central>
                {
                    StatusCode = 400,
                    Messages = new List<string>(new string[] { res.Message })
                };
            }
            else
            {
                List<string> errs = new List<string>();
                foreach(ModelStateEntry entry in ModelState.Values)
                {
                    foreach(ModelError err in entry.Errors)
                    {
                        errs.Add(err.ErrorMessage);
                    }
                }
                model = new ReturnModel<Central>
                {
                    StatusCode = 400,
                    Messages = errs
                };
            }
            return JsonSerializer.Serialize(model);
        }

        [HttpPut]
        public async Task<string> Put(CentralAddDto dto)
        {
            ReturnModel<Central> model;
            if (ModelState.IsValid)
            {
                var res = await centralService.Update(dto);
                if (res.Status == ResultStatus.Success) 
                    model = new ReturnModel<Central>
                    {
                        StatusCode = 201,
                        Messages = null
                    };
                else model = new ReturnModel<Central>
                {
                    StatusCode = 400,
                    Messages = new List<string>(new string[] { res.Message })
                };
            }
            else
            {
                List<string> errs = new List<string>();
                foreach (ModelStateEntry entry in ModelState.Values)
                {
                    foreach (ModelError err in entry.Errors)
                    {
                        errs.Add(err.ErrorMessage);
                    }
                }
                model = new ReturnModel<Central>
                {
                    StatusCode = 400,
                    Messages = errs
                };
            }
            return JsonSerializer.Serialize(model);
        }
    }
}
