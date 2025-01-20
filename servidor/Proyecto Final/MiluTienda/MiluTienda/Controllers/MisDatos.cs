using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class MisDatos : Controller
    {
        private readonly TiendaContext _context;
        
        public MisDatos(TiendaContext context)
        {
            _context = context;
        }

        // GET: Clientes/Index (para mostrar los datos del usuario logueado)
        public async Task<IActionResult> Index()
        {
            // Obtener el usuario actual a partir de su User.Identity.Name
            var userId = User.Identity.Name;

            // Buscar el cliente en la base de datos usando el email del usuario logueado
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == userId); // Aquí asumimos que el Email es único

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente); // Pasamos el modelo (el cliente) a la vista
        }

        // GET: MisDatos/Create 
        public IActionResult Create()
        {
            return View();
        }

        // POST: MisDatos/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Create([Bind("Id,Nombre,Telefono,Direccion,Poblacion,CodPostal,Nif")] Clientes cliente)
        {
            // Asignar el Email del usuario actual 
            cliente.Email = User.Identity.Name;

            // Eliminamos Email del ModelState para poder validalo dsp
            ModelState.Remove("Email");

            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }

        // GET: MisDatos/Edit 
        public async Task<IActionResult> Edit()
        {
            // Se seleccionan los datos del empleado correspondiente al usuario actual 
            string? emailUsuario = User.Identity.Name;
            Clientes? cliente = await _context.Clientes
                  .Where(e => e.Email == emailUsuario)
                  .FirstOrDefaultAsync();
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: MisDatos/Edit 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Nombre,Email,Telefono,Direccion,Poblacion,CodPostal,Nif")] Clientes cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }

        private bool EmpleadoExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

