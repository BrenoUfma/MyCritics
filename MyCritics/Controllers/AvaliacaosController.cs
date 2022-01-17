using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCritics.Data;
using MyCritics.Models;

namespace MyCritics.Controllers
{
    public class AvaliacaosController : Controller
    {
        private readonly MyCriticsContext _context;

        public AvaliacaosController(MyCriticsContext context)
        {
            _context = context;
        }

        // GET: Avaliacaos
        public async Task<IActionResult> Index()
        {
            var myCriticsContext = _context.Avaliacao.Include(a => a.Filme).Include(a => a.Usuario);
            return View(await myCriticsContext.ToListAsync());
        }

        // GET: Avaliacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao
                .Include(a => a.Filme)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public IActionResult Create(Filme filme) {
            var Escolha = _context.Filme.Where(a => a.ID.Equals(filme.ID)).FirstOrDefault();
            ViewData["Nome"] = Escolha.Nome;
            ViewData["ID"] = Escolha.ID;

            return View();
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioID,FilmeID,NotaAtor,NotaDiretor,NotaFigurino,NotaRoteiro,NotaSonoplastia")] Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeID"] = new SelectList(_context.Filme, "ID", "ID", avaliacao.FilmeID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "ID", "ID", avaliacao.UsuarioID);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            ViewData["FilmeID"] = new SelectList(_context.Filme, "ID", "ID", avaliacao.FilmeID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "ID", "ID", avaliacao.UsuarioID);
            return View(avaliacao);
        }

        // POST: Avaliacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UsuarioID,FilmeID,NotaAtor,NotaDiretor,NotaFigurino,NotaRoteiro,NotaSonoplastia")] Avaliacao avaliacao)
        {
            if (id != avaliacao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeID"] = new SelectList(_context.Filme, "ID", "ID", avaliacao.FilmeID);
            ViewData["UsuarioID"] = new SelectList(_context.Usuario, "ID", "ID", avaliacao.UsuarioID);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.Avaliacao
                .Include(a => a.Filme)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.Avaliacao.FindAsync(id);
            _context.Avaliacao.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacao.Any(e => e.ID == id);
        }
    }
}
