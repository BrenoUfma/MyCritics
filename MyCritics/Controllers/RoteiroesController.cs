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
    public class RoteiroesController : Controller
    {
        private readonly MyCriticsContext _context;

        public RoteiroesController(MyCriticsContext context)
        {
            _context = context;
        }

        // GET: Roteiroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roteiro.ToListAsync());
        }

        // GET: Roteiroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roteiro = await _context.Roteiro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roteiro == null)
            {
                return NotFound();
            }

            return View(roteiro);
        }

        // GET: Roteiroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roteiroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] Roteiro roteiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roteiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roteiro);
        }

        // GET: Roteiroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roteiro = await _context.Roteiro.FindAsync(id);
            if (roteiro == null)
            {
                return NotFound();
            }
            return View(roteiro);
        }

        // POST: Roteiroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] Roteiro roteiro)
        {
            if (id != roteiro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roteiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoteiroExists(roteiro.ID))
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
            return View(roteiro);
        }

        // GET: Roteiroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roteiro = await _context.Roteiro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roteiro == null)
            {
                return NotFound();
            }

            return View(roteiro);
        }

        // POST: Roteiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roteiro = await _context.Roteiro.FindAsync(id);
            _context.Roteiro.Remove(roteiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoteiroExists(int id)
        {
            return _context.Roteiro.Any(e => e.ID == id);
        }
    }
}
