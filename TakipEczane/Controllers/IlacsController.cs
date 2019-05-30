using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TakipEczane.Data;
using TakipEczane.Models;
using System.IO;

namespace TakipEczane.Controllers
{
    public class IlacsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public IlacsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> ShowEquivalents(string etki)
        {
            var equilavents = await _context
                .Ilac
                .Include(i => i.Etki)
                .Where(i => i.Etki.Etkigrubu == etki)
                .ToListAsync();

            return View(equilavents);
        }

        // GET: Ilacs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ilac.Include(i => i.Firma);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ilacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilac = await _context.Ilac
                .Include(i => i.Firma)
                .Include(i => i.Etki)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ilac == null)
            {
                return NotFound();
            }

            return View(ilac);
        }

        // GET: Ilacs/Create
        public IActionResult Create()
        {
            ViewData["FirmaId"] = new SelectList(_context.Firma, "Id", "Firmaadı");
            ViewData["RafId"] = new SelectList(_context.Raf, "Id", "Rafadı");
            ViewData["FormId"] = new SelectList(_context.Form, "Id", "Formadı");
            ViewData["EtkiId"] = new SelectList(_context.Etki, "Id", "Etkigrubu");
            ViewData["EtkenmaddeId"] = new SelectList(_context.Etkenmadde, "Id", "Etkenmaddeadı");

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ilac ilac, IFormFile FileUrl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilac);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            ViewData["FirmaId"] = new SelectList(_context.Firma, "Id", "Firmaadı", ilac.FirmaId);
            return View(ilac);
        }

        // GET: Ilacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilac = await _context.Ilac.FindAsync(id);
            if (ilac == null)
            {
                return NotFound();
            }
            ViewData["FirmaId"] = new SelectList(_context.Firma, "Id", "Firmaadı", ilac.FirmaId);
            return View(ilac);
        }

        // POST: Ilacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ilacadı,Barkod,Fiyat,Miktar,FirmaId")] Ilac ilac)
        {
            if (id != ilac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlacExists(ilac.Id))
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
            ViewData["FirmaId"] = new SelectList(_context.Firma, "Id", "Firmaadı", ilac.FirmaId);
            ViewData["EtkenmaddeId"] = new SelectList(_context.Etkenmadde, "Id", "Etkenmaddeadı", ilac.EtkenmaddeId);
            return View(ilac);
        }

        // GET: Ilacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilac = await _context.Ilac
                .Include(i => i.Firma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilac == null)
            {
                return NotFound();
            }

            return View(ilac);
        }

        // POST: Ilacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ilac = await _context.Ilac.FindAsync(id);
            _context.Ilac.Remove(ilac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlacExists(int id)
        {
            return _context.Ilac.Any(e => e.Id == id);
        }
    }
}
