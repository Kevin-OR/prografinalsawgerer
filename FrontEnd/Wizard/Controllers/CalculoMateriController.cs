using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wizard.Models;

namespace Wizard.Controllers
{
    public class CalculoMateriController : Controller
    {
        private readonly CalculoMateContext _context;

        public CalculoMateriController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: CalculoMateri
        public async Task<IActionResult> Index()
        {
            var calculoMateContext = _context.CalculoMateri.Include(c => c.IdCalculoNavigation).Include(c => c.IdMaterialNavigation).Include(c => c.IdMedParedesNavigation);
            return View(await calculoMateContext.ToListAsync());
        }

        // GET: CalculoMateri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculoMateri = await _context.CalculoMateri
                .Include(c => c.IdCalculoNavigation)
                .Include(c => c.IdMaterialNavigation)
                .Include(c => c.IdMedParedesNavigation)
                .FirstOrDefaultAsync(m => m.IdCalMateri == id);
            if (calculoMateri == null)
            {
                return NotFound();
            }

            return View(calculoMateri);
        }

        // GET: CalculoMateri/Create
        public IActionResult Create()
        {
            ViewData["IdCalculo"] = new SelectList(_context.ListCal, "IdCalculo", "NombreCalculo");
            ViewData["IdMaterial"] = new SelectList(_context.Materiales, "IdMaterial", "NombreMaterial");
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes");
            return View();
        }

        // POST: CalculoMateri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalMateri,IdMaterial,IdCalculo,TotalCalculo,IdMedParedes")] CalculoMateri calculoMateri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculoMateri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCalculo"] = new SelectList(_context.ListCal, "IdCalculo", "NombreCalculo", calculoMateri.IdCalculo);
            ViewData["IdMaterial"] = new SelectList(_context.Materiales, "IdMaterial", "NombreMaterial", calculoMateri.IdMaterial);
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes", calculoMateri.IdMedParedes);
            return View(calculoMateri);
        }

        // GET: CalculoMateri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculoMateri = await _context.CalculoMateri.FindAsync(id);
            if (calculoMateri == null)
            {
                return NotFound();
            }
            ViewData["IdCalculo"] = new SelectList(_context.ListCal, "IdCalculo", "NombreCalculo", calculoMateri.IdCalculo);
            ViewData["IdMaterial"] = new SelectList(_context.Materiales, "IdMaterial", "NombreMaterial", calculoMateri.IdMaterial);
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes", calculoMateri.IdMedParedes);
            return View(calculoMateri);
        }

        // POST: CalculoMateri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalMateri,IdMaterial,IdCalculo,TotalCalculo,IdMedParedes")] CalculoMateri calculoMateri)
        {
            if (id != calculoMateri.IdCalMateri)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculoMateri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculoMateriExists(calculoMateri.IdCalMateri))
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
            ViewData["IdCalculo"] = new SelectList(_context.ListCal, "IdCalculo", "NombreCalculo", calculoMateri.IdCalculo);
            ViewData["IdMaterial"] = new SelectList(_context.Materiales, "IdMaterial", "NombreMaterial", calculoMateri.IdMaterial);
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes", calculoMateri.IdMedParedes);
            return View(calculoMateri);
        }

        // GET: CalculoMateri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculoMateri = await _context.CalculoMateri
                .Include(c => c.IdCalculoNavigation)
                .Include(c => c.IdMaterialNavigation)
                .Include(c => c.IdMedParedesNavigation)
                .FirstOrDefaultAsync(m => m.IdCalMateri == id);
            if (calculoMateri == null)
            {
                return NotFound();
            }

            return View(calculoMateri);
        }

        // POST: CalculoMateri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calculoMateri = await _context.CalculoMateri.FindAsync(id);
            _context.CalculoMateri.Remove(calculoMateri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculoMateriExists(int id)
        {
            return _context.CalculoMateri.Any(e => e.IdCalMateri == id);
        }
    }
}
