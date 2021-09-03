using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Mvc.Areas.Admin.Controllers
{
    public class EditController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
