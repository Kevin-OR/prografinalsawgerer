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
    public class ClienteController : Controller
    {
        ClienteServices clienteServicios = new ClienteServices();
        CantonServices cantonServicios = new CantonServices();

        public ClienteController()
        {
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await clienteServicios.GetAllAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicios.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["CodigoCanton"] = new SelectList(cantonServicios.GetAll(), "CodigoCanton", "NombreCanton");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClie,Nombre,PriApellido,SeguApellido,Correo,Direccion,CodigoCanton")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (clienteServicios.Create(cliente))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CodigoCanton"] = new SelectList(cantonServicios.GetAll(), "CodigoCanton", "NombreCanton", cliente.CodigoCanton);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicios.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CodigoCanton"] = new SelectList(cantonServicios.GetAll(), "CodigoCanton", "NombreCanton", cliente.CodigoCanton);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClie,Nombre,PriApellido,SeguApellido,Correo,Direccion,CodigoCanton")] Cliente cliente)
        {
            if (id != cliente.IdClie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (clienteServicios.Updated(id, cliente))
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ee)
                {
                    var aux2 = clienteServicios.GetById(id);
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
            ViewData["CodigoCanton"] = new SelectList(cantonServicios.GetAll(), "CodigoCanton", "NombreCanton", cliente.CodigoCanton);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicios.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await clienteServicios.DeleteByIdAsync(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
