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
    public class SonoplastiasController : Controller
    {
        private readonly MyCriticsContext _context;

        public SonoplastiasController(MyCriticsContext context)
        {
            _context = context;
        }

        // GET: Sonoplastias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sonoplastia.ToListAsync());
        }

        // GET: Sonoplastias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonoplastia = await _context.Sonoplastia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sonoplastia == null)
            {
                return NotFound();
            }

            return View(sonoplastia);
        }

        // GET: Sonoplastias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sonoplastias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descricao")] Sonoplastia sonoplastia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sonoplastia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sonoplastia);
        }

        // GET: Sonoplastias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonoplastia = await _context.Sonoplastia.FindAsync(id);
            if (sonoplastia == null)
            {
                return NotFound();
            }
            return View(sonoplastia);
        }

        // POST: Sonoplastias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descricao")] Sonoplastia sonoplastia)
        {
            if (id != sonoplastia.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sonoplastia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SonoplastiaExists(sonoplastia.ID))
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
            return View(sonoplastia);
        }

        // GET: Sonoplastias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonoplastia = await _context.Sonoplastia
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sonoplastia == null)
            {
                return NotFound();
            }

            return View(sonoplastia);
        }

        // POST: Sonoplastias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sonoplastia = await _context.Sonoplastia.FindAsync(id);
            _context.Sonoplastia.Remove(sonoplastia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SonoplastiaExists(int id)
        {
            return _context.Sonoplastia.Any(e => e.ID == id);
        }
    }
}
