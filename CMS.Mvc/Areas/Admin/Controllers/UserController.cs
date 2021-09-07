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
    }
}
