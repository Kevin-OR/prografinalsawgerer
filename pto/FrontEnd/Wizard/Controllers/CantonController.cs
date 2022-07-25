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
    public class CantonController : Controller
    {
        private readonly CalculoMateContext _context;

        public CantonController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: Canton
        public async Task<IActionResult> Index()
        {
            var calculoMateContext = _context.Canton.Include(c => c.CodigoProvinciaNavigation);
            return View(await calculoMateContext.ToListAsync());
        }

        // GET: Canton/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton
                .Include(c => c.CodigoProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCanton == id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // GET: Canton/Create
        public IActionResult Create()
        {
            ViewData["CodigoProvincia"] = new SelectList(_context.Provincia, "CodigoProvincia", "NombreProvincia");
            return View();
        }

        // POST: Canton/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCanton,CodigoProvincia,NombreCanton")] Canton canton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoProvincia"] = new SelectList(_context.Provincia, "CodigoProvincia", "NombreProvincia", canton.CodigoProvincia);
            return View(canton);
        }

        // GET: Canton/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton.FindAsync(id);
            if (canton == null)
            {
                return NotFound();
            }
            ViewData["CodigoProvincia"] = new SelectList(_context.Provincia, "CodigoProvincia", "NombreProvincia", canton.CodigoProvincia);
            return View(canton);
        }

        // POST: Canton/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCanton,CodigoProvincia,NombreCanton")] Canton canton)
        {
            if (id != canton.CodigoCanton)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CantonExists(canton.CodigoCanton))
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
            ViewData["CodigoProvincia"] = new SelectList(_context.Provincia, "CodigoProvincia", "NombreProvincia", canton.CodigoProvincia);
            return View(canton);
        }

        // GET: Canton/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = await _context.Canton
                .Include(c => c.CodigoProvinciaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCanton == id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // POST: Canton/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var canton = await _context.Canton.FindAsync(id);
            _context.Canton.Remove(canton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CantonExists(int id)
        {
            return _context.Canton.Any(e => e.CodigoCanton == id);
        }
    }
}
