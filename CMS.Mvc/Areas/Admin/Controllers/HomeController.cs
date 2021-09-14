using CMS.Entities.Concrete;
using CMS.Mvc.Areas.Admin.Models;
using CMS.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
