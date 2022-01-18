using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCritics.Data;
using MyCritics.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Controllers {
    public class HomeController : Controller {

        private readonly MyCriticsContext _context;

        public HomeController(MyCriticsContext context) {
            _context = context;
        }

        public Usuario Sessao(Usuario usuario) {

            var login = _context.Usuario.Where(a => a.Email.Equals(usuario.Email)).FirstOrDefault();

            return login;

        }


        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario) {


            if (Sessao(usuario).Password == usuario.Password) {
                TempData["Nome"] = Sessao(usuario).Nome;
                TempData["Sobrenome"] = Sessao(usuario).Sobrenome;
                TempData["ID"] = Sessao(usuario).ID;
                return View("Inicial", _context.Avaliacao.Include(a => a.Filme));
            }
            else {

                return View();
            }

        }

        public IActionResult Pesquisa() {
            return View();
        }
        public IActionResult Avaliacao() {
            return View();
        }
        public async Task<IActionResult> Perfil() {
            var myCriticsContext = _context.Avaliacao.Include(a => a.Filme).Include(a => a.Usuario).Where(m=>m.UsuarioID.Equals(TempData.Peek("ID")));
            return View(await myCriticsContext.ToListAsync());
        }

            public async Task<IActionResult> Indicacoes() {
            return View(await _context.Filme.ToListAsync());
        }

        public IActionResult Inicial() {
             ;
            return View(_context.Avaliacao.Include(a => a.Filme));
        }


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
