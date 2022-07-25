using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Wizard.Models;
using API.Wizard.Servicios;

using Microsoft.AspNetCore.Mvc;

namespace API.Wizard.Controllers
{
    public class ProvinciaController : Controller
    {
        ProvinciaServices provinciaServicios = new ProvinciaServices();
        public ProvinciaController()
        {
        }

        // GET: Provincias
        public async Task<IActionResult> Index()
        {
            return View(provinciaServicios.GetAll());
        }

        // GET: Provincias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = provinciaServicios.GetById(id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // GET: Provincias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoProvincia,NombreProvincia")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                if (provinciaServicios.Create(provincia))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = provinciaServicios.GetById(id);
            if (provincia == null)
            {
                return NotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoProvincia,NombreProvincia")] Provincia provincia)
        {
            if (id != provincia.CodigoProvincia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (provinciaServicios.Updated(id, provincia))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = provinciaServicios.GetById(id);
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
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provincia = provinciaServicios.GetById(id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await provinciaServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            };
            return RedirectToAction(nameof(Index));
        }
    }
}
