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
    public class DiretorsController : Controller
    {
        private readonly MyCriticsContext _context;

        public DiretorsController(MyCriticsContext context)
        {
            _context = context;
        }

        // GET: Diretors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diretor.ToListAsync());
        }

        // GET: Diretors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // GET: Diretors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diretors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,DataNasc")] Diretor diretor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diretor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diretor);
        }

        // GET: Diretors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor.FindAsync(id);
            if (diretor == null)
            {
                return NotFound();
            }
            return View(diretor);
        }

        // POST: Diretors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,DataNasc")] Diretor diretor)
        {
            if (id != diretor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diretor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiretorExists(diretor.ID))
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
            return View(diretor);
        }

        // GET: Diretors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // POST: Diretors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diretor = await _context.Diretor.FindAsync(id);
            _context.Diretor.Remove(diretor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiretorExists(int id)
        {
            return _context.Diretor.Any(e => e.ID == id);
        }
    }
}
