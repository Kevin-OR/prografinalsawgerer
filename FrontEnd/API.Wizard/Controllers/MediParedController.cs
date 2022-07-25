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
    public class MediParedController : Controller
    {
        MediParedServices mediParedServicios = new MediParedServices();
        MediParedesServices mediParedesServicios = new MediParedesServices();

        public MediParedController()
        {
        }

        // GET: MediPareds
        public async Task<IActionResult> Index()
        {
            return View(await mediParedServicios.GetAllAsync());
        }

        // GET: MediPareds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediPared = mediParedServicios.GetById(id);
            if (mediPared == null)
            {
                return NotFound();
            }

            return View(mediPared);
        }

        // GET: MediPareds/Create
        public IActionResult Create()
        {
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes");
            return View();
        }

        // POST: MediPareds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedPared,Alto,Ancho,MetroCuadrado,IdMedParedes")] MediPared mediPared)
        {
            if (ModelState.IsValid)
            {
                if (mediParedServicios.Create(mediPared))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes", mediPared.IdMedParedes);
            return View(mediPared);
        }

        // GET: MediPareds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediPared = mediParedServicios.GetById(id);
            if (mediPared == null)
            {
                return NotFound();
            }
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes", mediPared.IdMedParedes);
            return View(mediPared);
        }

        // POST: MediPareds/Edit/5
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
                    if (mediParedServicios.Updated(id, mediPared))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = mediParedServicios.GetById(id);
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
            ViewData["IdMedParedes"] = new SelectList(mediParedesServicios.GetAll(), "IdMedParedes", "IdMedParedes", mediPared.IdMedParedes);
            return View(mediPared);
        }

        // GET: MediPareds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediPared = mediParedServicios.GetById(id);
            if (mediPared == null)
            {
                return NotFound();
            }

            return View(mediPared);
        }

        // POST: MediPareds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await mediParedServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
