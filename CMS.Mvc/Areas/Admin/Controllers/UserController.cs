using AutoMapper;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserAddDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.AvatarFile != null)
                {
                    string uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads/users/avatars");
                    if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                    string file = Path.Combine(uploads, model.AvatarFile.FileName);
                    using (Stream stream = new FileStream(file, FileMode.Create))
                    {
                        await model.AvatarFile.CopyToAsync(stream);
                        model.Avatar = model.AvatarFile.FileName;
                    }
                }
                var user = _mapper.Map<User>(model);
                var res = await _userManager.CreateAsync(user,model.Password);
                ViewBag.Succeeded = res.Succeeded; 
                ViewBag.Success =  res.Succeeded ? "Yeni üye başarıyla oluşturuldu" : "Yeni üye oluşturulamadı";
                ViewBag.Errors = res.Errors;
            }
            return View();
        }
    }
}
