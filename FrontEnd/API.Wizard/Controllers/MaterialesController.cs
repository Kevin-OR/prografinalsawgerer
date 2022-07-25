using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Wizard.Models;
using API.Wizard.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API.Wizard.Controllers
{
    public class MaterialesController : Controller
    {
        MaterialesServices materialesServicios = new MaterialesServices();
        public MaterialesController()
        {
        }

        // GET: Materiales
        public async Task<IActionResult> Index()
        {
            return View(materialesServicios.GetAll());
        }

        // GET: Materiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiales = materialesServicios.GetById(id);
            if (materiales == null)
            {
                return NotFound();
            }

            return View(materiales);
        }

        // GET: Materiales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterial,NombreMaterial,CantiMetro")] Materiales materiales)
        {
            if (ModelState.IsValid)
            {
                if (materialesServicios.Create(materiales))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(materiales);
        }

        // GET: Materiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiales = materialesServicios.GetById(id);
            if (materiales == null)
            {
                return NotFound();
            }
            return View(materiales);
        }

        // POST: Materiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterial,NombreMaterial,CantiMetro")] Materiales materiales)
        {
            if (id != materiales.IdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (materialesServicios.Updated(id, materiales))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = materialesServicios.GetById(id);
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
            return View(materiales);
        }

        // GET: Materiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiales = materialesServicios.GetById(id);
            if (materiales == null)
            {
                return NotFound();
            }

            return View(materiales);
        }

        // POST: Materiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(await materialesServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
