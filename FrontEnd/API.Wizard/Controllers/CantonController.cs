using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Wizard.Models;
using API.Wizard.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Wizard.Controllers
{
    public class CantonController : Controller
    {
        CantonServices cantonServicios = new CantonServices();
        ProvinciaServices provinciaServicios = new ProvinciaServices();

        public CantonController()
        {
        }

        // GET: Cantons
        public async Task<IActionResult> Index()
        {
            return View(await cantonServicios.GetAllAsync());
        }

        // GET: Cantons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = cantonServicios.GetById(id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // GET: Cantons/Create
        public IActionResult Create()
        {
            ViewData["CodigoProvincia"] = new SelectList(provinciaServicios.GetAll(), "CodigoProvincia", "NombreProvincia");
            return View();
        }

        // POST: Cantons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCanton,CodigoProvincia,NombreCanton")] Canton canton)
        {
            if (ModelState.IsValid)
            {
                if (cantonServicios.Create(canton))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CodigoProvincia"] = new SelectList(provinciaServicios.GetAll(), "CodigoProvincia", "NombreProvincia", canton.CodigoProvincia);
            return View(canton);
        }

        // GET: Cantons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var canton = cantonServicios.GetById(id);
            if (canton == null)
            {
                return NotFound();
            }
            ViewData["CodigoProvincia"] = new SelectList(provinciaServicios.GetAll(), "CodigoProvincia", "NombreProvincia", canton.CodigoProvincia);
            return View(canton);
        }

        // POST: Cantons/Edit/5
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
                    if (cantonServicios.Updated(id, canton))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = cantonServicios.GetById(id);
                    if (aux2 == null)
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
            ViewData["CodigoProvincia"] = new SelectList(provinciaServicios.GetAll(), "CodigoProvincia", "NombreProvincia", canton.CodigoProvincia);
            return View(canton);
        }

        // GET: Cantons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var canton = cantonServicios.GetById(id);
            if (canton == null)
            {
                return NotFound();
            }

            return View(canton);
        }

        // POST: Cantons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await cantonServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
