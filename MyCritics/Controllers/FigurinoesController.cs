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
    public class FigurinoesController : Controller
    {
        private readonly MyCriticsContext _context;

        public FigurinoesController(MyCriticsContext context)
        {
            _context = context;
        }

        // GET: Figurinoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Figurino.ToListAsync());
        }

        // GET: Figurinoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var figurino = await _context.Figurino
                .FirstOrDefaultAsync(m => m.ID == id);
            if (figurino == null)
            {
                return NotFound();
            }

            return View(figurino);
        }

        // GET: Figurinoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Figurinoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] Figurino figurino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(figurino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(figurino);
        }

        // GET: Figurinoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var figurino = await _context.Figurino.FindAsync(id);
            if (figurino == null)
            {
                return NotFound();
            }
            return View(figurino);
        }

        // POST: Figurinoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] Figurino figurino)
        {
            if (id != figurino.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(figurino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FigurinoExists(figurino.ID))
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
            return View(figurino);
        }

        // GET: Figurinoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var figurino = await _context.Figurino
                .FirstOrDefaultAsync(m => m.ID == id);
            if (figurino == null)
            {
                return NotFound();
            }

            return View(figurino);
        }

        // POST: Figurinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var figurino = await _context.Figurino.FindAsync(id);
            _context.Figurino.Remove(figurino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FigurinoExists(int id)
        {
            return _context.Figurino.Any(e => e.ID == id);
        }
    }
}
