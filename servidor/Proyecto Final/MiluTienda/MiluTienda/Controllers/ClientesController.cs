using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ClientesController : Controller
    {
        private readonly TiendaContext _context;

        public ClientesController(TiendaContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string nombre, string email, string poblacion, string codPostal, string nif, int page = 1)
        {
            // Número de elementos por página
            int pageSize = 10;

            // Filtrar clientes según los parámetros
            var clientesQuery = _context.Clientes.AsQueryable();

            // Filtro por Nombre
            if (!string.IsNullOrEmpty(nombre))
            {
                clientesQuery = clientesQuery.Where(c => c.Nombre.Contains(nombre));
            }

            // Filtro por Email
            if (!string.IsNullOrEmpty(email))
            {
                clientesQuery = clientesQuery.Where(c => c.Email.Contains(email));
            }

            // Filtro por Población
            if (!string.IsNullOrEmpty(poblacion))
            {
                clientesQuery = clientesQuery.Where(c => c.Poblacion.Contains(poblacion));
            }

            // Filtro por Código Postal
            if (!string.IsNullOrEmpty(codPostal))
            {
                clientesQuery = clientesQuery.Where(c => c.CodPostal.Contains(codPostal));
            }

            // Filtro por NIF
            if (!string.IsNullOrEmpty(nif))
            {
                clientesQuery = clientesQuery.Where(c => c.Nif.Contains(nif));
            }

            // Obtener el número total de clientes
            var totalClientes = await clientesQuery.CountAsync();

            // Obtener los clientes filtrados y paginados
            var clientes = await clientesQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Crear el modelo de paginación
            var model = new PaginatedList<Clientes>(clientes, totalClientes, page, pageSize);

            // Pasar los parámetros de búsqueda a la vista a través de ViewData
            ViewData["Nombre"] = nombre;
            ViewData["Email"] = email;
            ViewData["Poblacion"] = poblacion;
            ViewData["CodPostal"] = codPostal;
            ViewData["Nif"] = nif;

            return View(model);
        }



        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Telefono,Direccion,Poblacion,CodPostal,Nif")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Telefono,Direccion,Poblacion,CodPostal,Nif")] Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.Id))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes != null)
            {
                _context.Clientes.Remove(clientes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
