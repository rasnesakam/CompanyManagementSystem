using AutoMapper;
using CMS.Api.Models;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public readonly IWebHostEnvironment _hostEnvironment;

        public UserController(UserManager<User> userManager, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }


        [HttpPost]
        public async Task<string> Post([FromForm] UserAddDto dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.AvatarFile != null)
                {
                    string uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads/users/avatars");
                    if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                    string file = Path.Combine(uploads, dto.AvatarFile.FileName);
                    using (Stream stream = new FileStream(file, FileMode.Create))
                    {
                        await dto.AvatarFile.CopyToAsync(stream);
                        dto.Avatar = dto.AvatarFile.FileName;
                    }
                }
                var user = _mapper.Map<User>(dto);
                var res = await _userManager.CreateAsync(user, dto.Password);
                List<string> messages = new List<string>();
                if (!res.Succeeded)
                {
                    messages.Add("Yeni üye oluşturulamadı.");
                    foreach (var err in res.Errors)
                    {
                        messages.Add(err.Description);
                    }
                }
                else messages.Add("Yeni üye başarıyla oluşturuldu");

                return JsonSerializer.Serialize(new ReturnModel<User>
                {
                    StatusCode = res.Succeeded ? 200 : 400,
                    Messages = messages
                });
            }
            List<string> errs = new List<string>();
            foreach (var entry in ModelState.Values)
            {
                foreach (var error in entry.Errors)
                {
                    errs.Add(error.ErrorMessage);
                }
            }
            return JsonSerializer.Serialize<ReturnModel<Company>>(new ReturnModel<Company>
            {
                StatusCode = 400,
                Messages = errs
            });

        }

        [HttpPut]
        public async Task<string> Put([FromBody] UserAddDto dto)
        {
            return JsonSerializer.Serialize(new ReturnModel<User>
            {
                StatusCode = (int)ResultStatus.Error,
                Messages = new(new string[] { "Bu özellik henüz mevcut değil" })
            });
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return JsonSerializer.Serialize(new ReturnModel<User>
            {
                StatusCode = (int)ResultStatus.Error,
                Messages = new(new string[] { "Bu özellik henüz mevcut değil" })
            });
        }

    }
}
