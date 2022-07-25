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
    public class CalculoMateriController : Controller
    {
        CalculoMateriServices calculoMateriServicios = new CalculoMateriServices();
        ListCalServices listCalServicios = new ListCalServices();
        MaterialesServices materialesServicios = new MaterialesServices();
        MediParedesServices mediParedesServicios = new MediParedesServices();
        public CalculoMateriController()
        {
        }

        // GET: CalculoMateris
        public async Task<IActionResult> Index()
        {
            return View(await calculoMateriServicios.GetAllAsync());
        }

        // GET: CalculoMateris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculoMateri = calculoMateriServicios.GetById(id);
            if (calculoMateri == null)
            {
                return NotFound();
            }

            return View(calculoMateri);
        }

        // GET: CalculoMateris/Create
        public IActionResult Create()
        {
            ViewData["IdCalculo"] = new SelectList(listCalServicios.GetAll(), "IdCalculo", "NombreCalculo");
            ViewData["IdMaterial"] = new SelectList(materialesServicios.GetAll(), "IdMaterial", "NombreMaterial");
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes");
            return View();
        }

        // POST: CalculoMateris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalMateri,IdMaterial,IdCalculo,TotalCalculo,IdMedParedes")] CalculoMateri calculoMateri)
        {
            if (ModelState.IsValid)
            {
                if (calculoMateriServicios.Create(calculoMateri))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IdCalculo"] = new SelectList(listCalServicios.GetAll(), "IdCalculo", "NombreCalculo", calculoMateri.IdCalculo);
            ViewData["IdMaterial"] = new SelectList(materialesServicios.GetAll(), "IdMaterial", "NombreMaterial", calculoMateri.IdMaterial);
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes", calculoMateri.IdMedParedes);
            return View(calculoMateri);
        }

        // GET: CalculoMateris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculoMateri = calculoMateriServicios.GetById(id);
            if (calculoMateri == null)
            {
                return NotFound();
            }
            ViewData["IdCalculo"] = new SelectList(listCalServicios.GetAll(), "IdCalculo", "NombreCalculo", calculoMateri.IdCalculo);
            ViewData["IdMaterial"] = new SelectList(materialesServicios.GetAll(), "IdMaterial", "NombreMaterial", calculoMateri.IdMaterial);
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes", calculoMateri.IdMedParedes);
            return View(calculoMateri);
        }

        // POST: CalculoMateris/Edit/5
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
                    if (calculoMateriServicios.Updated(id, calculoMateri))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = calculoMateriServicios.GetById(id);
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
            ViewData["IdCalculo"] = new SelectList(listCalServicios.GetAll(), "IdCalculo", "NombreCalculo", calculoMateri.IdCalculo);
            ViewData["IdMaterial"] = new SelectList(materialesServicios.GetAll(), "IdMaterial", "NombreMaterial", calculoMateri.IdMaterial);
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes", calculoMateri.IdMedParedes);
            return View(calculoMateri);
        }

        // GET: CalculoMateris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var calculoMateri = calculoMateriServicios.GetById(id);
            if (calculoMateri == null)
            {
                return NotFound();
            }

            return View(calculoMateri);
        }

        // POST: CalculoMateris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await calculoMateriServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
