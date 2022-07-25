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
    public class MediParedController : Controller
    {
        private readonly CalculoMateContext _context;

        public MediParedController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: MediPared
        public async Task<IActionResult> Index()
        {
            var calculoMateContext = _context.MediPared.Include(m => m.IdMedParedesNavigation);
            return View(await calculoMateContext.ToListAsync());
        }

        // GET: MediPared/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediPared = await _context.MediPared
                .Include(m => m.IdMedParedesNavigation)
                .FirstOrDefaultAsync(m => m.IdMedPared == id);
            if (mediPared == null)
            {
                return NotFound();
            }

            return View(mediPared);
        }

        // GET: MediPared/Create
        public IActionResult Create()
        {
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes");
            return View();
        }

        // POST: MediPared/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedPared,Alto,Ancho,MetroCuadrado,IdMedParedes")] MediPared mediPared)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediPared);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes", mediPared.IdMedParedes);
            return View(mediPared);
        }

        // GET: MediPared/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediPared = await _context.MediPared.FindAsync(id);
            if (mediPared == null)
            {
                return NotFound();
            }
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes", mediPared.IdMedParedes);
            return View(mediPared);
        }

        // POST: MediPared/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedPared,Alto,Ancho,MetroCuadrado,IdMedParedes")] MediPared mediPared)
        {
            if (id != mediPared.IdMedPared)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediPared);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediParedExists(mediPared.IdMedPared))
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
            ViewData["IdMedParedes"] = new SelectList(_context.MediParedes, "IdMedParedes", "IdMedParedes", mediPared.IdMedParedes);
            return View(mediPared);
        }

        // GET: MediPared/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediPared = await _context.MediPared
                .Include(m => m.IdMedParedesNavigation)
                .FirstOrDefaultAsync(m => m.IdMedPared == id);
            if (mediPared == null)
            {
                return NotFound();
            }

            return View(mediPared);
        }

        // POST: MediPared/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediPared = await _context.MediPared.FindAsync(id);
            _context.MediPared.Remove(mediPared);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediParedExists(int id)
        {
            return _context.MediPared.Any(e => e.IdMedPared == id);
        }
    }
}
