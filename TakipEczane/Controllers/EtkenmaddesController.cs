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
    public class EtkenmaddesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtkenmaddesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etkenmaddes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etkenmadde.ToListAsync());
        }

        // GET: Etkenmaddes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugs = _context
               .Ilac
               .Where(i => i.FirmaId == id);

            if (drugs == null)
            {
                return NotFound();
            }

            return View(drugs);
        }

        // GET: Etkenmaddes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etkenmaddes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Etkenmaddeadı")] Etkenmadde etkenmadde)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etkenmadde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etkenmadde);
        }

        // GET: Etkenmaddes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkenmadde = await _context.Etkenmadde.FindAsync(id);
            if (etkenmadde == null)
            {
                return NotFound();
            }
            return View(etkenmadde);
        }

        // POST: Etkenmaddes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Etkenmaddeadı")] Etkenmadde etkenmadde)
        {
            if (id != etkenmadde.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etkenmadde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtkenmaddeExists(etkenmadde.Id))
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
            return View(etkenmadde);
        }

        // GET: Etkenmaddes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etkenmadde = await _context.Etkenmadde
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etkenmadde == null)
            {
                return NotFound();
            }

            return View(etkenmadde);
        }

        // POST: Etkenmaddes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etkenmadde = await _context.Etkenmadde.FindAsync(id);
            _context.Etkenmadde.Remove(etkenmadde);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtkenmaddeExists(int id)
        {
            return _context.Etkenmadde.Any(e => e.Id == id);
        }
    }
}
