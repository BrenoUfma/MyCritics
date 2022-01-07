using Microsoft.AspNetCore.Mvc;
using MyCritics.Data;
using MyCritics.Models;
using System.Diagnostics;
using System.Linq;

namespace MyCritics.Controllers {
    public class HomeController : Controller {
        private readonly MyCriticsContext _context;
        public HomeController(MyCriticsContext context) {
            _context = context;
        }

        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario usuario) {

            var login = _context.Usuario.Where(a => a.Email.Equals(usuario.Email)).FirstOrDefault();
            if (login.Password == usuario.Password) {
                return RedirectToAction("Inicial");
            }
            else {
                return View();
            }
              
        }


        public IActionResult Index() {
            return View();
        }

        public IActionResult Inicial() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
