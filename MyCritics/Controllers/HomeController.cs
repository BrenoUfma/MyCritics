using Microsoft.AspNetCore.Mvc;
using MyCritics.Data;
using MyCritics.Models;
using System.Diagnostics;

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
            var Login = _context.Usuario.FindAsync(usuario.Email);
            if (Login.Result.Password == usuario.Password) {
                return Privacy();
            }
            else {
                return View();
            }
                
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
