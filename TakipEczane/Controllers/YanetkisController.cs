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
    public class YanetkisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YanetkisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yanetkis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yanetki.ToListAsync());
        }

        // GET: Yanetkis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanetki = await _context.Yanetki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yanetki == null)
            {
                return NotFound();
            }

            return View(yanetki);
        }

        // GET: Yanetkis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yanetkis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Yanetkiadı")] Yanetki yanetki)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yanetki);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yanetki);
        }

        // GET: Yanetkis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanetki = await _context.Yanetki.FindAsync(id);
            if (yanetki == null)
            {
                return NotFound();
            }
            return View(yanetki);
        }

        // POST: Yanetkis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Yanetkiadı")] Yanetki yanetki)
        {
            if (id != yanetki.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yanetki);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YanetkiExists(yanetki.Id))
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
            return View(yanetki);
        }

        // GET: Yanetkis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yanetki = await _context.Yanetki
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yanetki == null)
            {
                return NotFound();
            }

            return View(yanetki);
        }

        // POST: Yanetkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yanetki = await _context.Yanetki.FindAsync(id);
            _context.Yanetki.Remove(yanetki);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YanetkiExists(int id)
        {
            return _context.Yanetki.Any(e => e.Id == id);
        }
    }
}
