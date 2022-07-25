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
    public class ListCalController : Controller
    {
        private readonly CalculoMateContext _context;

        public ListCalController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: ListCal
        public async Task<IActionResult> Index()
        {
            var calculoMateContext = _context.ListCal.Include(l => l.IdClieNavigation).Include(l => l.IdPerNavigation);
            return View(await calculoMateContext.ToListAsync());
        }

        // GET: ListCal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listCal = await _context.ListCal
                .Include(l => l.IdClieNavigation)
                .Include(l => l.IdPerNavigation)
                .FirstOrDefaultAsync(m => m.IdCalculo == id);
            if (listCal == null)
            {
                return NotFound();
            }

            return View(listCal);
        }

        // GET: ListCal/Create
        public IActionResult Create()
        {
            ViewData["IdClie"] = new SelectList(_context.Cliente, "IdClie", "Correo");
            ViewData["IdPer"] = new SelectList(_context.Persona, "IdPer", "Clave");
            return View();
        }

        // POST: ListCal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalculo,NombreCalculo,IdPer,IdClie")] ListCal listCal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listCal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClie"] = new SelectList(_context.Cliente, "IdClie", "Correo", listCal.IdClie);
            ViewData["IdPer"] = new SelectList(_context.Persona, "IdPer", "Clave", listCal.IdPer);
            return View(listCal);
        }

        // GET: ListCal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listCal = await _context.ListCal.FindAsync(id);
            if (listCal == null)
            {
                return NotFound();
            }
            ViewData["IdClie"] = new SelectList(_context.Cliente, "IdClie", "Correo", listCal.IdClie);
            ViewData["IdPer"] = new SelectList(_context.Persona, "IdPer", "Clave", listCal.IdPer);
            return View(listCal);
        }

        // POST: ListCal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalculo,NombreCalculo,IdPer,IdClie")] ListCal listCal)
        {
            if (id != listCal.IdCalculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listCal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListCalExists(listCal.IdCalculo))
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
            ViewData["IdClie"] = new SelectList(_context.Cliente, "IdClie", "Correo", listCal.IdClie);
            ViewData["IdPer"] = new SelectList(_context.Persona, "IdPer", "Clave", listCal.IdPer);
            return View(listCal);
        }

        // GET: ListCal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listCal = await _context.ListCal
                .Include(l => l.IdClieNavigation)
                .Include(l => l.IdPerNavigation)
                .FirstOrDefaultAsync(m => m.IdCalculo == id);
            if (listCal == null)
            {
                return NotFound();
            }

            return View(listCal);
        }

        // POST: ListCal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listCal = await _context.ListCal.FindAsync(id);
            _context.ListCal.Remove(listCal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListCalExists(int id)
        {
            return _context.ListCal.Any(e => e.IdCalculo == id);
        }
    }
}
