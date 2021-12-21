using Microsoft.AspNetCore.Mvc;
using MyCritics.Models;
using MyCritics.Uteis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Controllers {
    public class HomeController : Controller {
        public IActionResult Login() {
            return View();
        }

        public IActionResult Index() {
           // DAL objDal = new DAL();
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
