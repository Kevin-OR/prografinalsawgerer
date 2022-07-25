using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Wizard.Models;
using API.Wizard.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace API.Wizard.Controllers
{
    public class PersonaController : Controller
    {
        PersonaServices personaServicios = new PersonaServices();
        public PersonaController()
        {
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            return View(personaServicios.GetAll());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = personaServicios.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }


        // GET: Personas/Details/5
        public async Task<IActionResult> Login(int id, String Cla)
        {
            if (id == null && Cla == null)
            {
                return NotFound();
            }

            var persona = personaServicios.GetById(id);

            


            if (persona != null)
            {
                if (Cla == persona.Clave)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(persona);
        }


        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPer,Nombre,PriApellido,SeguApellido,Correo,Clave,Usuario")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                if (personaServicios.Create(persona))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = personaServicios.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPer,Nombre,PriApellido,SeguApellido,Correo,Clave,Usuario")] Persona persona)
        {
            if (id != persona.IdPer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (personaServicios.Updated(id, persona))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = personaServicios.GetById(id);
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
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = personaServicios.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await personaServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
