using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Account.Controllers
{
    [Area("Account")]
    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            foreach (var cookie in HttpContext.Request.Cookies)
                HttpContext.Response.Cookies.Delete(cookie.Key);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var customUser = await _userManager.FindByIdAsync("1");
                if (customUser == null)
                    ModelState.AddModelError("UY A A","ULAULAULAULA");
                var user = await _userManager.FindByEmailAsync(dto.UserNameOrEMail);
                if (user == null) user = await _userManager.FindByNameAsync(dto.UserNameOrEMail);
                if(user != null)
                {
                    var res = await _signInManager.PasswordSignInAsync(user,dto.Password,dto.RememberMe,false);
                    if (res.Succeeded)
                    {
                        HttpContext.Response.Cookies.Append("user", JsonSerializer.Serialize(user));
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else return RedirectToRoute("default",new { area = "Admin", controller = "Home", action = "Index" });
                    }
                }
                ModelState.AddModelError("", "Kullanıcı bilgileri geçersiz");
                
            }
            return View();

        }
    }
}
