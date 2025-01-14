using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiluTienda.Data;
using MiluTienda.Models;

namespace MiluTienda.Controllers
{
    public class VariantesController : Controller
    {
        private readonly TiendaContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VariantesController(TiendaContext context, IWebHostEnvironment HostEnvironment)
        {
            _context = context;
            _webHostEnvironment = HostEnvironment;
        }

        // GET: Variantes
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.Variantes.Include(v => v.Producto);
            return View(await tiendaContext.ToListAsync());
        }

        // GET: Variantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variante = await _context.Variantes
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variante == null)
            {
                return NotFound();
            }

            return View(variante);
        }

        // GET: Variantes/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre");
            return View();
        }

        // POST: Variantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductoId,Atributo,NombreVariante,PrecioVariante,PrecioCadena")] Variante variante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(variante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", variante.ProductoId);
            return View(variante);
        }

        // GET: Variantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variante = await _context.Variantes.FindAsync(id);
            if (variante == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", variante.ProductoId);
            return View(variante);
        }

        // POST: Variantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductoId,Atributo,NombreVariante,PrecioVariante,PrecioCadena")] Variante variante)
        {
            if (id != variante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(variante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarianteExists(variante.Id))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", variante.ProductoId);
            return View(variante);
        }

        // GET: Variantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variante = await _context.Variantes
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variante == null)
            {
                return NotFound();
            }

            return View(variante);
        }

        // POST: Variantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var variante = await _context.Variantes.FindAsync(id);
            if (variante != null)
            {
                _context.Variantes.Remove(variante);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Productos", new { id = variante.ProductoId });
        }

        private bool VarianteExists(int id)
        {
            return _context.Variantes.Any(e => e.Id == id);
        }
        // GET: Variantes/CambiarImagen/5 
        public async Task<IActionResult> CambiarImagen(int? id)
        {
            if (id == null || _context.Variantes == null)
            {
                return NotFound();
            }
            var variante = await _context.Variantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (variante == null)
            {
                return NotFound();
            }
            return View(variante);
        }
        // POST: Variantes/CambiarImagen/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarImagen(int? id, IFormFile imagen)
        {
            if (id == null)
            {
                return NotFound();
            }

            var variante = await _context.Variantes.FindAsync(id);
            if (variante == null)
            {
                return NotFound();
            }

            if (imagen == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Copiar archivo de imagen 
                string strRutaImagenes = Path.Combine(_webHostEnvironment.WebRootPath, "imagenes/variantes");
                string strExtension = Path.GetExtension(imagen.FileName);
                string strNombreFichero = variante.Id.ToString() + strExtension;
                string strRutaFichero = Path.Combine(strRutaImagenes, strNombreFichero);
                using (var fileStream = new FileStream(strRutaFichero, FileMode.Create))
                {
                    imagen.CopyTo(fileStream);
                }

                // Actualizar producto con nueva imagen 
                variante.Imagen = strNombreFichero;
                try
                {
                    _context.Update(variante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VarianteExists(variante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(variante);
        }
    }
}
