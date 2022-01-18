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

        // GET: Avaliacaos1
        public async Task<IActionResult> Index()
        {
            var myCriticsContext = _context.Avaliacao.Include(a => a.Filme).Include(a => a.Usuario);
            return View(await myCriticsContext.ToListAsync());
        }

        // GET: Avaliacaos1/Details/5
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

        // GET: Avaliacaos1/Create
        public IActionResult Create(Filme filme)
        {
            var filmenome = _context.Filme.Where(m => m.ID.Equals(filme.ID)).FirstOrDefault();
            TempData["Filme"] = filmenome.Nome;
            return View();
        }

        // POST: Avaliacaos1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UsuarioID,FilmeID,NotaFilme,NotaDiretor,NotaFigurino,NotaRoteiro,NotaSonoplastia,Comentario")] Avaliacao avaliacao)
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

        // GET: Avaliacaos1/Edit/5
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

        // POST: Avaliacaos1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UsuarioID,FilmeID,NotaFilme,NotaDiretor,NotaFigurino,NotaRoteiro,NotaSonoplastia,Comentario")] Avaliacao avaliacao)
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

        // GET: Avaliacaos1/Delete/5
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

        // POST: Avaliacaos1/Delete/5
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
