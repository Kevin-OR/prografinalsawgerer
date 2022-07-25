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
    public class ListCalController : Controller
    {
        ListCalServices listCalServicios = new ListCalServices();
        ClienteServices clienteServicios = new ClienteServices();
        PersonaServices personaServicios = new PersonaServices();
        public ListCalController()
        {
        }

        // GET: ListCals
        public async Task<IActionResult> Index()
        {
            return View(await listCalServicios.GetAllAsync());
        }

        // GET: ListCals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listCal = listCalServicios.GetById(id);
            if (listCal == null)
            {
                return NotFound();
            }

            return View(listCal);
        }

        // GET: ListCals/Create
        public IActionResult Create()
        {
            ViewData["IdClie"] = new SelectList(clienteServicios.GetAll(), "IdClie", "Correo");
            ViewData["IdPer"] = new SelectList(personaServicios.GetAll(), "IdPer", "Clave");
            return View();
        }

        // POST: ListCals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalculo,NombreCalculo,IdPer,IdClie")] ListCal listCal)
        {
            if (ModelState.IsValid)
            {
                if (listCalServicios.Create(listCal))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["IdClie"] = new SelectList(clienteServicios.GetAll(), "IdClie", "Correo", listCal.IdClie);
            ViewData["IdPer"] = new SelectList(personaServicios.GetAll(), "IdPer", "Clave", listCal.IdPer);
            return View(listCal);
        }

        // GET: ListCals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var listCal = listCalServicios.GetById(id);
            if (listCal == null)
            {
                return NotFound();
            }
            ViewData["IdClie"] = new SelectList(clienteServicios.GetAll(), "IdClie", "Correo", listCal.IdClie);
            ViewData["IdPer"] = new SelectList(personaServicios.GetAll(), "IdPer", "Clave", listCal.IdPer);
            return View(listCal);
        }

        // POST: ListCals/Edit/5
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
                    if (listCalServicios.Updated(id, listCal))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = listCalServicios.GetById(id);
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
            ViewData["IdClie"] = new SelectList(clienteServicios.GetAll(), "IdClie", "Correo", listCal.IdClie);
            ViewData["IdPer"] = new SelectList(personaServicios.GetAll(), "IdPer", "Clave", listCal.IdPer);
            return View(listCal);
        }

        // GET: ListCals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listCal = listCalServicios.GetById(id);
            if (listCal == null)
            {
                return NotFound();
            }

            return View(listCal);
        }

        // POST: ListCals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await listCalServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
