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
    public class MediParedesController : Controller
    {
        private readonly CalculoMateContext _context;

        public MediParedesController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: MediParedes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediParedes.ToListAsync());
        }

        // GET: MediParedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediParedes = await _context.MediParedes
                .FirstOrDefaultAsync(m => m.IdMedParedes == id);
            if (mediParedes == null)
            {
                return NotFound();
            }

            return View(mediParedes);
        }

        // GET: MediParedes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MediParedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedParedes,TotalAlto,TotalAncho,TotalMetroCuadrado")] MediParedes mediParedes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediParedes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediParedes);
        }

        // GET: MediParedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediParedes = await _context.MediParedes.FindAsync(id);
            if (mediParedes == null)
            {
                return NotFound();
            }
            return View(mediParedes);
        }

        // POST: MediParedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedParedes,TotalAlto,TotalAncho,TotalMetroCuadrado")] MediParedes mediParedes)
        {
            if (id != mediParedes.IdMedParedes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediParedes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediParedesExists(mediParedes.IdMedParedes))
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
            return View(mediParedes);
        }

        // GET: MediParedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediParedes = await _context.MediParedes
                .FirstOrDefaultAsync(m => m.IdMedParedes == id);
            if (mediParedes == null)
            {
                return NotFound();
            }

            return View(mediParedes);
        }

        // POST: MediParedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mediParedes = await _context.MediParedes.FindAsync(id);
            _context.MediParedes.Remove(mediParedes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediParedesExists(int id)
        {
            return _context.MediParedes.Any(e => e.IdMedParedes == id);
        }
    }
}
