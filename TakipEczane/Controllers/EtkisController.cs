using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TakipEczane.Data;
using TakipEczane.Models;

namespace TakipEczane.Controllers
{
    public class EtkisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtkisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etkis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etki.ToListAsync());
        }

        // GET: Etkis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etki = await _context.Etki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etki == null)
            {
                return NotFound();
            }

            return View(etki);
        }

        // GET: Etkis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etkis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Etkigrubu")] Etki etki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etki);
        }

        // GET: Etkis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etki = await _context.Etki.FindAsync(id);
            if (etki == null)
            {
                return NotFound();
            }
            return View(etki);
        }

        // POST: Etkis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Etkigrubu")] Etki etki)
        {
            if (id != etki.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtkiExists(etki.Id))
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
            return View(etki);
        }

        // GET: Etkis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etki = await _context.Etki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etki == null)
            {
                return NotFound();
            }

            return View(etki);
        }

        // POST: Etkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etki = await _context.Etki.FindAsync(id);
            _context.Etki.Remove(etki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtkiExists(int id)
        {
            return _context.Etki.Any(e => e.Id == id);
        }
    }
}
