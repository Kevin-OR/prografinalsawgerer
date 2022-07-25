using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Wizard.Models;
using API.Wizard.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API.Wizard.Controllers
{
    public class MediParedesController : Controller
    {
        MediParedesServices mediParedesServicios = new MediParedesServices();
        public MediParedesController()
        {
        }

        // GET: MediParedes
        public async Task<IActionResult> Index()
        {
            return View(mediParedesServicios.GetAll());
        }

        // GET: MediParedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediParedes = mediParedesServicios.GetById(id);
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
                if (mediParedesServicios.Create(mediParedes))
                {
                    return RedirectToAction(nameof(Index));
                }
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

            var mediParedes = mediParedesServicios.GetById(id);
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
                    if (mediParedesServicios.Updated(id, mediParedes))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = mediParedesServicios.GetById(id);
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
            return View(mediParedes);
        }

        // GET: MediParedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediParedes = mediParedesServicios.GetById(id);
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
            if (await mediParedesServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
